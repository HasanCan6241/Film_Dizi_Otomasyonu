namespace Film_Dizi_Otomasyonu
{
    partial class SikayetOlustur
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
            this.SikayetAciklamasiInput = new System.Windows.Forms.RichTextBox();
            this.SikayetBasligiInput = new System.Windows.Forms.TextBox();
            this.SikayetAciklamasiText = new System.Windows.Forms.Label();
            this.SikayetBasligiText = new System.Windows.Forms.Label();
            this.SikayetButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // SikayetAciklamasiInput
            // 
            this.SikayetAciklamasiInput.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.SikayetAciklamasiInput.Location = new System.Drawing.Point(9, 98);
            this.SikayetAciklamasiInput.Name = "SikayetAciklamasiInput";
            this.SikayetAciklamasiInput.Size = new System.Drawing.Size(360, 251);
            this.SikayetAciklamasiInput.TabIndex = 0;
            this.SikayetAciklamasiInput.Text = "";
            // 
            // SikayetBasligiInput
            // 
            this.SikayetBasligiInput.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.SikayetBasligiInput.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.SikayetBasligiInput.Location = new System.Drawing.Point(9, 31);
            this.SikayetBasligiInput.Name = "SikayetBasligiInput";
            this.SikayetBasligiInput.Size = new System.Drawing.Size(360, 22);
            this.SikayetBasligiInput.TabIndex = 2;
            // 
            // SikayetAciklamasiText
            // 
            this.SikayetAciklamasiText.AutoSize = true;
            this.SikayetAciklamasiText.Location = new System.Drawing.Point(12, 80);
            this.SikayetAciklamasiText.Name = "SikayetAciklamasiText";
            this.SikayetAciklamasiText.Size = new System.Drawing.Size(114, 15);
            this.SikayetAciklamasiText.TabIndex = 1;
            this.SikayetAciklamasiText.Text = "Şikayet Açıklamanız:";
            // 
            // SikayetBasligiText
            // 
            this.SikayetBasligiText.AutoSize = true;
            this.SikayetBasligiText.Location = new System.Drawing.Point(12, 13);
            this.SikayetBasligiText.Name = "SikayetBasligiText";
            this.SikayetBasligiText.Size = new System.Drawing.Size(84, 15);
            this.SikayetBasligiText.TabIndex = 1;
            this.SikayetBasligiText.Text = "Şikayet Başlığı:";
            // 
            // SikayetButton
            // 
            this.SikayetButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SikayetButton.BackColor = System.Drawing.Color.Yellow;
            this.SikayetButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SikayetButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SikayetButton.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.SikayetButton.Location = new System.Drawing.Point(12, 361);
            this.SikayetButton.Name = "SikayetButton";
            this.SikayetButton.Size = new System.Drawing.Size(357, 29);
            this.SikayetButton.TabIndex = 3;
            this.SikayetButton.Text = "Şikayet Talebini Oluştur";
            this.SikayetButton.UseVisualStyleBackColor = false;
            this.SikayetButton.Click += new System.EventHandler(this.SikayetButton_Click);
            // 
            // SikayetOlustur
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 402);
            this.Controls.Add(this.SikayetButton);
            this.Controls.Add(this.SikayetBasligiInput);
            this.Controls.Add(this.SikayetBasligiText);
            this.Controls.Add(this.SikayetAciklamasiText);
            this.Controls.Add(this.SikayetAciklamasiInput);
            this.Name = "SikayetOlustur";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SikayetOlustur";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SikayetOlustur_FormClosed);
            this.Load += new System.EventHandler(this.SikayetOlustur_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private RichTextBox SikayetAciklamasiInput;
        private TextBox SikayetBasligiInput;
        private Label SikayetAciklamasiText;
        private Label SikayetBasligiText;
        private Button SikayetButton;
    }
}