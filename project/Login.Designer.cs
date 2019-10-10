namespace project
{
    partial class Login
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.kadi = new System.Windows.Forms.TextBox();
            this.ksifre = new System.Windows.Forms.TextBox();
            this.btnGirisYap = new System.Windows.Forms.Button();
            this.ımageList1 = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(48, 90);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Kullanıcı Adı :";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(52, 154);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "Şifre :";
            // 
            // kadi
            // 
            this.kadi.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.kadi.Location = new System.Drawing.Point(201, 90);
            this.kadi.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.kadi.Name = "kadi";
            this.kadi.ShortcutsEnabled = false;
            this.kadi.Size = new System.Drawing.Size(210, 28);
            this.kadi.TabIndex = 2;
            this.kadi.KeyDown += new System.Windows.Forms.KeyEventHandler(this.kadi_KeyDown);
            // 
            // ksifre
            // 
            this.ksifre.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ksifre.Location = new System.Drawing.Point(201, 154);
            this.ksifre.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ksifre.Name = "ksifre";
            this.ksifre.ShortcutsEnabled = false;
            this.ksifre.Size = new System.Drawing.Size(210, 28);
            this.ksifre.TabIndex = 3;
            this.ksifre.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ksifre_KeyDown);
            // 
            // btnGirisYap
            // 
            this.btnGirisYap.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnGirisYap.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnGirisYap.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnGirisYap.ImageKey = "if_login_173049.png";
            this.btnGirisYap.ImageList = this.ımageList1;
            this.btnGirisYap.Location = new System.Drawing.Point(222, 262);
            this.btnGirisYap.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnGirisYap.Name = "btnGirisYap";
            this.btnGirisYap.Size = new System.Drawing.Size(130, 80);
            this.btnGirisYap.TabIndex = 4;
            this.btnGirisYap.Text = "Giriş Yap";
            this.btnGirisYap.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGirisYap.UseVisualStyleBackColor = true;
            this.btnGirisYap.Click += new System.EventHandler(this.btnGirisYap_Click);
            // 
            // ımageList1
            // 
            this.ımageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ımageList1.ImageStream")));
            this.ımageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.ımageList1.Images.SetKeyName(0, "if_login_173049.png");
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGoldenrod;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(525, 425);
            this.Controls.Add(this.btnGirisYap);
            this.Controls.Add(this.ksifre);
            this.Controls.Add(this.kadi);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Giriş Ekranı";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Login_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox kadi;
        private System.Windows.Forms.TextBox ksifre;
        private System.Windows.Forms.Button btnGirisYap;
        private System.Windows.Forms.ImageList ımageList1;
    }
}

