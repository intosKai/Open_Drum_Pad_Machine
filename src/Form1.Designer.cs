namespace DrumPad_beta
{
    partial class WorkForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.pBtns = new System.Windows.Forms.Panel();
            this.ofd = new System.Windows.Forms.OpenFileDialog();
            this.pTracks = new System.Windows.Forms.Panel();
            this.copyright = new System.Windows.Forms.Label();
            this.cbMetronome = new System.Windows.Forms.CheckBox();
            this.mtbBPS = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.psignal = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // pBtns
            // 
            this.pBtns.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pBtns.BackColor = System.Drawing.Color.Tan;
            this.pBtns.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pBtns.Location = new System.Drawing.Point(12, 13);
            this.pBtns.Margin = new System.Windows.Forms.Padding(0);
            this.pBtns.MaximumSize = new System.Drawing.Size(1024, 1024);
            this.pBtns.MinimumSize = new System.Drawing.Size(256, 256);
            this.pBtns.Name = "pBtns";
            this.pBtns.Size = new System.Drawing.Size(512, 512);
            this.pBtns.TabIndex = 0;
            // 
            // ofd
            // 
            this.ofd.Filter = "All files|*.*";
            this.ofd.Title = "Choose your file";
            // 
            // pTracks
            // 
            this.pTracks.BackColor = System.Drawing.Color.DimGray;
            this.pTracks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pTracks.Location = new System.Drawing.Point(527, 13);
            this.pTracks.Name = "pTracks";
            this.pTracks.Size = new System.Drawing.Size(360, 178);
            this.pTracks.TabIndex = 7;
            // 
            // copyright
            // 
            this.copyright.AutoSize = true;
            this.copyright.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.copyright.Location = new System.Drawing.Point(535, 489);
            this.copyright.Name = "copyright";
            this.copyright.Size = new System.Drawing.Size(238, 36);
            this.copyright.TabIndex = 10;
            this.copyright.Text = "Created by Petr Ivanov \r\nwith CSCore library";
            // 
            // cbMetronome
            // 
            this.cbMetronome.AutoSize = true;
            this.cbMetronome.Location = new System.Drawing.Point(527, 197);
            this.cbMetronome.Name = "cbMetronome";
            this.cbMetronome.Size = new System.Drawing.Size(90, 19);
            this.cbMetronome.TabIndex = 12;
            this.cbMetronome.Text = "Metronome";
            this.cbMetronome.UseVisualStyleBackColor = true;
            this.cbMetronome.CheckStateChanged += new System.EventHandler(this.cbMetronome_CheckStateChanged);
            // 
            // mtbBPS
            // 
            this.mtbBPS.Location = new System.Drawing.Point(581, 216);
            this.mtbBPS.Mask = "009";
            this.mtbBPS.Name = "mtbBPS";
            this.mtbBPS.Size = new System.Drawing.Size(28, 21);
            this.mtbBPS.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(527, 219);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 15);
            this.label1.TabIndex = 14;
            this.label1.Text = "BPS:";
            // 
            // psignal
            // 
            this.psignal.BackColor = System.Drawing.Color.White;
            this.psignal.Location = new System.Drawing.Point(787, 425);
            this.psignal.Name = "psignal";
            this.psignal.Size = new System.Drawing.Size(100, 100);
            this.psignal.TabIndex = 15;
            // 
            // WorkForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(904, 539);
            this.Controls.Add(this.psignal);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.mtbBPS);
            this.Controls.Add(this.cbMetronome);
            this.Controls.Add(this.copyright);
            this.Controls.Add(this.pTracks);
            this.Controls.Add(this.pBtns);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1024, 1024);
            this.Name = "WorkForm";
            this.Text = "Open Drum Pad beta";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.WorkForm_FormClosing);
            this.Load += new System.EventHandler(this.WorkForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.WorkForm_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.WorkForm_KeyUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pBtns;
        private System.Windows.Forms.OpenFileDialog ofd;
        private System.Windows.Forms.Panel pTracks;
        private System.Windows.Forms.Label copyright;
        private System.Windows.Forms.CheckBox cbMetronome;
        private System.Windows.Forms.MaskedTextBox mtbBPS;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel psignal;
    }
}

