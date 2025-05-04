namespace TalepTahmin
{
    partial class LoginForm
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
            TbxEmail = new TextBox();
            TbxSifre = new TextBox();
            BtnGirisYap = new Button();
            lblEmail = new Label();
            label2 = new Label();
            SuspendLayout();
            // 
            // TbxEmail
            // 
            TbxEmail.Location = new Point(261, 138);
            TbxEmail.Name = "TbxEmail";
            TbxEmail.Size = new Size(176, 27);
            TbxEmail.TabIndex = 0;
            // 
            // TbxSifre
            // 
            TbxSifre.Location = new Point(261, 221);
            TbxSifre.Name = "TbxSifre";
            TbxSifre.PasswordChar = '*';
            TbxSifre.Size = new Size(176, 27);
            TbxSifre.TabIndex = 1;
            // 
            // BtnGirisYap
            // 
            BtnGirisYap.Location = new Point(517, 167);
            BtnGirisYap.Name = "BtnGirisYap";
            BtnGirisYap.Size = new Size(126, 51);
            BtnGirisYap.TabIndex = 2;
            BtnGirisYap.Text = "Giriş Yap";
            BtnGirisYap.UseVisualStyleBackColor = true;
            BtnGirisYap.Click += BtnGirisYap_Click;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(261, 105);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(46, 20);
            lblEmail.TabIndex = 3;
            lblEmail.Text = "Email";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(261, 198);
            label2.Name = "label2";
            label2.Size = new Size(39, 20);
            label2.TabIndex = 4;
            label2.Text = "Şifre";
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label2);
            Controls.Add(lblEmail);
            Controls.Add(BtnGirisYap);
            Controls.Add(TbxSifre);
            Controls.Add(TbxEmail);
            Name = "LoginForm";
            Text = "LoginForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox TbxEmail;
        private TextBox TbxSifre;
        private Button BtnGirisYap;
        private Label lblEmail;
        private Label label2;
    }
}