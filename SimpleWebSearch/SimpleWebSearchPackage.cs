using System;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Globalization;
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

        private bool IsIdentifierChar(string s, int index)
        {
            // Rough check for the letter can be used in a C# identifier. 

            if (index < 0 || s.Length - 1 < index)
                return false;

            if (Char.IsLetterOrDigit(s, index))
                return true;

            var category = Char.GetUnicodeCategory(s, index);

            if (category == UnicodeCategory.ConnectorPunctuation)
                return true;

            if (category == UnicodeCategory.Format)
                return true;

            return false;
        }

        private void UpdateQueryWord()
        {
            var dte = (EnvDTE.DTE)GetService(typeof(EnvDTE.DTE));
            var selection = (EnvDTE.TextSelection)dte.ActiveDocument.Selection;
            if (selection.IsEmpty)
            {
                // Detect the query word if nothing is selected.

                int line = selection.ActivePoint.Line;
                int offset = selection.ActivePoint.LineCharOffset;

                selection.SelectLine();
                string text = selection.Text;
                selection.MoveToLineAndOffset(line, offset);

                if (IsIdentifierChar(text, offset - 2))
                {
                    // The caret is at the middle or the end of a word.

                    selection.WordLeft(false);
                    selection.WordRight(true);
                    queryWord = selection.Text.Trim();
                }
                else if (IsIdentifierChar(text, offset - 1))
                {
                    // The caret is at the beginning of a word.

                    selection.WordRight(true);
                    queryWord = selection.Text.Trim();
                }
                else
                {
                    // The caret is not in a word.

                    queryWord = "";
                }

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

                    command.Text = options.Caption.Replace("%QUERY%", word);
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
                var encoding = Encoding.GetEncoding(options.CodePage);
                var url = options.URL.Replace(
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
