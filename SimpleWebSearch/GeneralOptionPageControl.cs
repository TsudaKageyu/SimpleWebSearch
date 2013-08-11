using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TsudaKageyu.SimpleWebSearch
{
    public partial class GeneralOptionPageControl : UserControl
    {
        private class EncodingItem
        {
            public int CodePage { get; private set; }

            public EncodingItem(int codePage)
            {
                CodePage = codePage;
            }

            public Encoding ToEncoding()
            {
                return Encoding.GetEncoding(CodePage);
            }

            public override string ToString()
            {
                return Encoding.GetEncoding(CodePage).EncodingName;
            }
        }

        public string Caption
        {
            get
            {
                return txtName.Text;
            }
            set
            {
                txtName.Text = value;
            }
        }

        public string URL
        {
            get
            {
                return txtURL.Text;
            }
            set
            {
                txtURL.Text = value;
            }
        }

        public int CodePage
        {
            get
            {
                return ((EncodingItem)cmbEncoding.SelectedItem).CodePage;
            }
            set
            {
                var cmb = cmbEncoding;

                var item = cmb.Items.OfType<EncodingItem>().FirstOrDefault(x => x.CodePage == value);
                if (item != null)
                    cmb.SelectedItem = item;
                else
                    throw new ArgumentException("The code page is not supported.");
            }
        }

        public bool UseBuiltInBrowser
        {
            get
            {
                return rbBuiltInBrowser.Checked;
            }
            set
            {
                if (value)
                    rbBuiltInBrowser.Checked = true;
                else
                    rbDefaultBrowser.Checked = true;
            }
        }

        public GeneralOptionPageControl()
        {
            InitializeComponent();
            
            // List all the available text encodings.
            {
                var cmb = cmbEncoding;

                cmb.BeginUpdate();

                var items = new List<object>(
                    Encoding.GetEncodings().Select(x => new EncodingItem(x.CodePage)));
                items.OrderBy(x => ((EncodingItem)x).CodePage);

                cmb.Items.AddRange(items.ToArray());
                cmb.SelectedIndex = items.FindIndex(x => ((EncodingItem)x).CodePage == 65001);

                cmb.EndUpdate();
            }

            RestoreDefault();
        }

        private void RestoreDefault()
        {
            Caption  = Resources.DefaultCaption;
            URL      = Resources.DefaultURL;
            CodePage = int.Parse(Resources.DefaultCodePage);
            UseBuiltInBrowser = bool.Parse(Resources.DefaultUseBuiltInBrowser);
        }

        private void cmbEncoding_SelectedIndexChanged(object sender, EventArgs e)
        {
            var cmb = cmbEncoding;
            var enc = ((EncodingItem)cmb.Items[cmb.SelectedIndex]).ToEncoding();

            var text = String.Format(
                "Code Page: {0}\nIANA Name: {1}", enc.CodePage, enc.WebName);

            tipEncoding.SetToolTip(cmb, text);
        }

        private void btnRestoreDefault_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(
                this,
                Resources.ConfirmRestoreDefault,
                Resources.ExtensionTitle,
                MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
                RestoreDefault();
        }
    }
}
