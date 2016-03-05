using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;

namespace DrumPad_beta
{
    public partial class LoadFrm : Form
    {
        public int Progress
        {
            get
            {
                return this.pbLoad.Value;
            }
            set
            {
                this.pbLoad.Value = value;
            }
        }
        private delegate void ProgressDelegate(int progress);

        private ProgressDelegate del;
        public LoadFrm()
        {
            InitializeComponent();
            label3.Text = "Version: " + Application.ProductVersion.ToString();
            this.pbLoad.Maximum = 100;
            del = this.UpdateProgressInternal;
        }

        private void UpdateProgressInternal(int progress)
        {
            if (this.Handle == null)
            {
                return;
            }

            this.pbLoad.Value = progress;
        }

        public void UpdateProgress(int progress)
        {
            this.Invoke(del, progress);
        }
    }
}
