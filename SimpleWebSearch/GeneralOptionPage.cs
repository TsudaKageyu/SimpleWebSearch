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

        public string Caption
        {
            get { return control.Caption; }
            set { control.Caption = value; }
        }

        public string URL
        {
            get { return control.URL; }
            set { control.URL = value; }
        }

        public int CodePage
        {
            get { return control.CodePage; }
            set { control.CodePage = value; }
        }

        public bool UseBuiltInBrowser
        {
            get { return control.UseBuiltInBrowser; }
            set { control.UseBuiltInBrowser = value; }
        }
    }
}
