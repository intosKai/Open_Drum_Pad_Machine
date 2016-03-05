using System;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;
using enums;
using DrumPad_beta.Constants;

namespace DrumPad_beta
{
    public partial class WorkForm : Form
    {
        public Button[] btnArr = new Button[VARS.NUM_OF_PAD];

        private Pad[] pad = new Pad[VARS.NUM_OF_PAD];
        private TrackBar[] tbr = new TrackBar[VARS.NUM_OF_PAD];
        private ContextMenu[] cm = new ContextMenu[VARS.NUM_OF_PAD];
        private MenuItem mi;
        private Thread Metronome;
        private LoadFrm loadframe = new LoadFrm();





        public WorkForm()
        {
            this.Hide();
            loadframe.Show();
            InitializeComponent();
        }

        private void ContMenuCreate()
        {
            

            for (int i = 0; i < VARS.NUM_OF_PAD; i++)
            {
                MenuItem menuItem1 = new MenuItem();
                menuItem1.Index = 0;
                menuItem1.Text = "Bind key";
                menuItem1.Tag = (int)i;
                menuItem1.Click += new EventHandler(this.BindKey_Click);

                MenuItem menuItem2 = new MenuItem();
                menuItem2.Text = "Mode";
                menuItem2.Tag = (int)i;
                MenuItem subItem1 = new MenuItem();
                subItem1.Text = "Play again";
                subItem1.RadioCheck = true;
                subItem1.Checked = true;
                subItem1.Click += new EventHandler(this.Mode_Changed);
                menuItem2.MenuItems.Add(subItem1);
                subItem1 = new MenuItem();
                subItem1.Text = "Loop";
                subItem1.RadioCheck = true;
                subItem1.Click += new EventHandler(this.Mode_Changed);
                menuItem2.MenuItems.Add(subItem1);

                cm[i] = new ContextMenu();
                cm[i].MenuItems.Add(menuItem1);
                cm[i].MenuItems.Add(menuItem2);
            }

        }
        private void ButtonCreate()
        {
            for(int i = VARS.NUM_OF_PAD_IN_ROW-1, s = 0; i >= 0; i--)
                for(int j = 0; j < VARS.NUM_OF_PAD_IN_ROW; j++, s++)
                {
                    //Bitmap bm = new Bitmap(Image.FromFile())
                    btnArr[s] = new Button();
                    btnArr[s].Width = btnArr[s].Height = pBtns.Height / VARS.NUM_OF_PAD_IN_ROW;
                    btnArr[s].Text = (s + 1).ToString();
                    btnArr[s].Location = new Point(j * pBtns.Width / VARS.NUM_OF_PAD_IN_ROW- 1, i * pBtns.Height / VARS.NUM_OF_PAD_IN_ROW - 1);
                    //btnArr[s].BackColor = Color.Bisque;
                    btnArr[s].Click += new System.EventHandler(this.arrBtn_Click);
                    btnArr[s].Tag = s;
                    btnArr[s].ContextMenu = cm[s];
                    btnArr[s].Margin = new Padding(0);
                    btnArr[s].Padding = new Padding(0);
                    btnArr[s].TabStop = false;
                    btnArr[s].FlatStyle = FlatStyle.Flat;
                    btnArr[s].Cursor = Cursors.Hand;
                    btnArr[s].TabIndex = 0;
                    btnArr[s].BackgroundImage = Properties.Resources.btnUp;
                    btnArr[s].BackgroundImageLayout = ImageLayout.Tile;
                    
                    pBtns.Controls.Add(btnArr[s]);
                }
        }
        private void PadInit()
        {
            for (int i = 0; i < VARS.NUM_OF_PAD; i++)
            {
                pad[i] = new Pad();
            }
        }
        private void TrackBarCreate()
        {
            for (int i = VARS.NUM_OF_PAD_IN_ROW - 1, s = 0; i >= 0; i--)
                for (int j = 0; j < VARS.NUM_OF_PAD_IN_ROW; j++, s++)
                {
                    tbr[s] = new TrackBar();
                    tbr[s].Width = pTracks.Width / VARS.NUM_OF_PAD_IN_ROW;
                    tbr[s].Height = pTracks.Height / VARS.NUM_OF_PAD_IN_ROW;
                    tbr[s].Location = new Point(j * pTracks.Width / VARS.NUM_OF_PAD_IN_ROW, i * pTracks.Height / VARS.NUM_OF_PAD_IN_ROW);
                    tbr[s].Tag = s;
                    tbr[s].Maximum = 100;
                    tbr[s].Minimum = 0;
                    tbr[s].Value = 100;
                    tbr[s].Scroll += new System.EventHandler(this.arrTbs_Set);

                    pTracks.Controls.Add(tbr[s]);
                }
        }
        private void arrTbs_Set(object sender, EventArgs e)
        {
            TrackBar tb = (TrackBar)sender;
            int num;

            num = (int)tb.Tag;
            pad[num].SetVol(tbr[num].Value / 100.0f);
        }
        private void arrBtn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int n = int.Parse(btn.Text)-1;

            if (DialogResult.OK != ofd.ShowDialog())
                return;

            if (pad[n] != null)
                pad[n].Dispose();
            pad[n] = new Pad(ofd.FileName);

            if (!pad[n].IsInit)
                MessageBox.Show("File can't load!", "Error!");




            tbr[n].Focus();
        }
        private void WorkForm_KeyDown(object sender, KeyEventArgs e)
        {
            int btnNum = KeyBind.Bind(e.KeyData);
            if (btnNum == -1)
            {
                StopAll();
                return;
            }

            if (pad[btnNum].Mode == PlayMode.PlayAgain)
            {
                pad[btnNum].Play();
            }
            else if (pad[btnNum].Mode == PlayMode.Loop)
                pad[btnNum].LoopStop();

            btnArr[btnNum].BackgroundImage = Properties.Resources.btnDown;

            e.Handled = true;
        }
        private void WorkForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //закрытие формы
            for (int i = 0; i < VARS.NUM_OF_PAD; i++)
                    pad[i].Dispose();
        }
        private void WorkForm_KeyUp(object sender, KeyEventArgs e)
        {
            int btnNum = KeyBind.Bind(e.KeyCode);
            if (btnNum == -1)
                return;
            btnArr[btnNum].BackgroundImage = Properties.Resources.btnUp;
        }
        private void StopAll()
        {
            for (int i = 0; i < VARS.NUM_OF_PAD; i++)
                pad[i].Stop();
        }
        private void Mode_Changed(object sender, EventArgs e)
        {
            MenuItem mItem = (MenuItem)sender;
            pad[(int)mItem.Parent.Tag].SetMode((PlayMode)mItem.Index);
            foreach (MenuItem mitem in cm[(int)mItem.Parent.Tag].MenuItems[1].MenuItems)
                mitem.Checked = false;
            mItem.Checked = true;
        }
        private void BindKey_Click(object sender, EventArgs e)
        {
            mi = (MenuItem)sender;

            KeySetFrm frm = new KeySetFrm(sender);
            frm.ShowDialog();
            KeyBind.LoadBinds();
        }
        private void SignalPlay()
        {
            const int second = 60000;
            int t;
            try { t = second / int.Parse(mtbBPS.Text) / 2; }
            catch { MessageBox.Show("Insert BPS", "ERROR!"); return; }
            while(true)
            {
                psignal.BackColor = Color.Red;
                Thread.Sleep(t);
                psignal.BackColor = Color.White;
                Thread.Sleep(t);
            }
        }
        private void WorkForm_Load(object sender, EventArgs e)
        {
            loadframe.Progress = 10;
            KeyBind.LoadBinds();
            loadframe.Progress += 15;
            ContMenuCreate();
            loadframe.Progress += 15;
            ButtonCreate();
            loadframe.Progress += 15;
            TrackBarCreate();
            loadframe.Progress += 15;
            PadInit();
            loadframe.Progress += 10;
            this.KeyPreview = true;
            loadframe.Progress = 100;
            this.Show();
            loadframe.Close();
            loadframe.Dispose();
        }
        private void cbMetronome_CheckStateChanged(object sender, EventArgs e)
        {
            CheckBox cb = (CheckBox)sender;
            if (cb.Checked)
            {
                if (Metronome == null)
                    Metronome = new Thread(SignalPlay);
                Metronome.Start();
                //Pad.delay = 60000 / int.Parse(mtbBPS.Text) / 2;
            }
            else
            {
                Metronome.Abort();
                Metronome = new Thread(SignalPlay);
            }
        }


    }
}
