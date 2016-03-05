using System;
using System.Windows.Forms;

namespace DrumPad_beta
{
    public partial class KeySetFrm : Form
    {
        MenuItem mi;
        Keys CurrKey;

        public KeySetFrm(object sender)
        {
            InitializeComponent();
            mi = (MenuItem)sender;
        }
        private void KeySetFrm_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
        }
        private void tbPressedkey_KeyDown(object sender, KeyEventArgs e)
        {
            tbPressedkey.Text = e.KeyData.ToString();
            CurrKey = e.KeyData;
            e.Handled = true;
        }
        private void btnAccept_Click(object sender, EventArgs e)
        {
            KeyBind.SetBind((int)mi.Tag, CurrKey);
            KeyBind.SaveBinds();
            this.Close();
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
