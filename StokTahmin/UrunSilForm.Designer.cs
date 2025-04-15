namespace TalepTahmin
{
    partial class UrunSilForm
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
            label1 = new Label();
            CboxUrunAdı = new ComboBox();
            tbxFiyat = new TextBox();
            label3 = new Label();
            tbxMiktar = new TextBox();
            label2 = new Label();
            BtnUrunSil = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(43, 62);
            label1.Name = "label1";
            label1.Size = new Size(67, 20);
            label1.TabIndex = 14;
            label1.Text = "Ürün Adı";
            // 
            // CboxUrunAdı
            // 
            CboxUrunAdı.FormattingEnabled = true;
            CboxUrunAdı.Location = new Point(152, 58);
            CboxUrunAdı.Name = "CboxUrunAdı";
            CboxUrunAdı.Size = new Size(151, 28);
            CboxUrunAdı.TabIndex = 13;
            CboxUrunAdı.SelectedIndexChanged += CboxUrunAdı_SelectedIndexChanged;
            // 
            // tbxFiyat
            // 
            tbxFiyat.Location = new Point(152, 150);
            tbxFiyat.Name = "tbxFiyat";
            tbxFiyat.Size = new Size(151, 27);
            tbxFiyat.TabIndex = 20;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(43, 153);
            label3.Name = "label3";
            label3.Size = new Size(40, 20);
            label3.TabIndex = 19;
            label3.Text = "Fiyat";
            // 
            // tbxMiktar
            // 
            tbxMiktar.Location = new Point(152, 106);
            tbxMiktar.Name = "tbxMiktar";
            tbxMiktar.Size = new Size(151, 27);
            tbxMiktar.TabIndex = 18;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(43, 109);
            label2.Name = "label2";
            label2.Size = new Size(51, 20);
            label2.TabIndex = 17;
            label2.Text = "Miktar";
            // 
            // BtnUrunSil
            // 
            BtnUrunSil.Location = new Point(466, 119);
            BtnUrunSil.Name = "BtnUrunSil";
            BtnUrunSil.Size = new Size(94, 29);
            BtnUrunSil.TabIndex = 21;
            BtnUrunSil.Text = "Ürünü Sil";
            BtnUrunSil.UseVisualStyleBackColor = true;
            BtnUrunSil.Click += BtnUrunSil_Click;
            // 
            // UrunSilForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(BtnUrunSil);
            Controls.Add(tbxFiyat);
            Controls.Add(label3);
            Controls.Add(tbxMiktar);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(CboxUrunAdı);
            Name = "UrunSilForm";
            Text = "UrunSilForm";
            Load += UrunSilForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ComboBox CboxUrunAdı;
        private TextBox tbxFiyat;
        private Label label3;
        private TextBox tbxMiktar;
        private Label label2;
        private Button BtnUrunSil;
    }
}