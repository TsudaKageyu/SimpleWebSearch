using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Microsoft.VisualStudio.Shell;

namespace TsudaKageyu.SimpleWebSearch
{
    [Guid("121DFA5A-B80F-4C61-8734-87720996BBAB")]
    public class GeneralOptionPage : DialogPage
    {
        private GeneralOptionPageControl control = new GeneralOptionPageControl();

        protected override IWin32Window Window
        {
            get { return control; }
        }

        public string SearchEngineName
        {
            get { return control.SearchEngineName; }
            set { control.SearchEngineName = value; }
        }

        public string SearchEngineURL
        {
            get { return control.SearchEngineURL; }
            set { control.SearchEngineURL = value; }
        }

        public int QueryCodePage
        {
            get { return control.QueryCodePage; }
            set { control.QueryCodePage = value; }
        }

        public bool UseBuiltInBrowser
        {
            get { return control.UseBuiltInBrowser; }
            set { control.UseBuiltInBrowser = value; }
        }
    }
}
