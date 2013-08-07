using System;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;
using System.Web;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;

namespace TsudaKageyu.SimpleWebSearch
{
    [PackageRegistration(UseManagedResourcesOnly = true)]
    [InstalledProductRegistration("#110", "#112", "1.0")]
    [ProvideMenuResource("Menus.ctmenu", 1)]
    [ProvideAutoLoad(UIContextGuids.SolutionExists)]
    [ProvideOptionPage(typeof(GeneralOptionPage), "Simple Web Search", "General", 113, 114, true)]
    [Guid("da557abd-6945-4daf-98f2-a254d988b905")]
    [ComVisible(true)]
    public sealed class SimpleWebSearchPackage : Package
    {
        private const string GUID_Commands = "f51e3850-97df-43ac-a3db-e0e44d363b88";
        private const int ID_MenuItem = 0x0100;

        private const int QueryWordMaxLength = 128;

        private string queryWord = "";

        public SimpleWebSearchPackage()
        {
        }

        private void UpdateQueryWord()
        {
            var dte = (EnvDTE.DTE)GetService(typeof(EnvDTE.DTE));
            var selection = (EnvDTE.TextSelection)dte.ActiveDocument.Selection;
            if (selection.IsEmpty)
            {
                int line = selection.ActivePoint.Line;
                int offset = selection.ActivePoint.LineCharOffset;

                selection.SelectLine();
                string text = selection.Text;

                int pos1 = offset - 1;
                while (pos1 > 0)
                {
                    char c = text[pos1 - 1];
                    if (Char.IsWhiteSpace(c) || Char.IsPunctuation(c))
                        break;

                    pos1--;
                }

                int pos2 = offset - 2;
                while (pos2 < text.Length - 1)
                {
                    char c = text[pos2 + 1];
                    if (Char.IsWhiteSpace(c) || Char.IsPunctuation(c))
                        break;

                    pos2++;
                }

                queryWord = text.Substring(pos1, pos2 - pos1 + 1).Trim();

                selection.MoveToLineAndOffset(line, offset);
            }
            else
            {
                int retIndex = selection.Text.IndexOf("\r\n");
                if (retIndex != -1)
                    queryWord = selection.Text.Substring(0, retIndex);
                else
                    queryWord = selection.Text.Trim();
            }

            if (queryWord.Length > QueryWordMaxLength)
                queryWord = "";
        }

        protected override void Initialize()
        {
            base.Initialize();

            var service = GetService(typeof(IMenuCommandService)) as OleMenuCommandService;
            if (service != null)
            {
                var guid = new Guid(GUID_Commands);

                var command = new OleMenuCommand(
                    command_Click, new CommandID(new Guid(GUID_Commands), ID_MenuItem));
                command.BeforeQueryStatus += new EventHandler(command_BeforeQueryStatus);
                service.AddCommand(command);
            }
        }

        private void command_BeforeQueryStatus(object sender, EventArgs e)
        {
            var command = (OleMenuCommand)sender;
            int id = command.CommandID.ID;
            if (id == ID_MenuItem)
            {
                UpdateQueryWord();
                if (queryWord != "")
                {
                    var options = (GeneralOptionPage)GetDialogPage(typeof(GeneralOptionPage));

                    var word = queryWord;
                    if (word.Length > 30)
                        word = word.Substring(0, 27) + "...";

                    command.Text = String.Format(Resources.MenuText, word, options.SearchEngineName);
                    command.Visible = true;
                }
                else
                {
                    command.Visible = false;
                }
            }
            else
            {
                Debug.WriteLine(
                    "SimpleWebSearchPackage.command_BeforeQueryStatus - Invalid command ID.");
            }
        }

        private void command_Click(object sender, EventArgs e)
        {
            var command = (OleMenuCommand)sender;
            int id = command.CommandID.ID;
            if (id == ID_MenuItem)
            {
                var options = (GeneralOptionPage)GetDialogPage(typeof(GeneralOptionPage));
                var encoding = Encoding.GetEncoding(options.QueryCodePage);
                var url = options.SearchEngineURL.Replace(
                    "%QUERY%", HttpUtility.UrlEncode(queryWord, encoding));

                if (!Uri.IsWellFormedUriString(url, UriKind.Absolute))
                {
                    Debug.WriteLine(
                        "SimpleWebSearchPackage.command_Click - Ill-formed URL.");
                    return;
                }

                if (options.UseBuiltInBrowser)
                {
                    var dte = (EnvDTE.DTE)GetService(typeof(EnvDTE.DTE));
                    dte.ItemOperations.Navigate(url);
                }
                else
                {
                    Process.Start(url);
                }
            }
            else
            {
                Debug.WriteLine(
                    "SimpleWebSearchPackage.command_Click - Invalid command ID.");
            }
        }
    }
}
