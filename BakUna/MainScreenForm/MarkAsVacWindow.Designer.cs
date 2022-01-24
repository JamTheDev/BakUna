
namespace BakUna.MainScreenForm
{
    partial class MarkAsVacWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MarkAsVacWindow));
            this.doseComboBox = new System.Windows.Forms.ComboBox();
            this.vaccinationTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.confirm_btn = new System.Windows.Forms.Button();
            this.loadingGif = new System.Windows.Forms.PictureBox();
            this.userLabel = new System.Windows.Forms.Label();
            this.transactionConfirmationlabel = new System.Windows.Forms.Label();
            this.closeButton = new System.Windows.Forms.Button();
            this.vaccinator_tb = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.vaccination_site_tb = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.vaccineComboBox = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.loadingGif)).BeginInit();
            this.SuspendLayout();
            // 
            // doseComboBox
            // 
            this.doseComboBox.FormattingEnabled = true;
            this.doseComboBox.Items.AddRange(new object[] {
            "First Dose",
            "Second Dose",
            "Booster"});
            this.doseComboBox.Location = new System.Drawing.Point(11, 187);
            this.doseComboBox.Name = "doseComboBox";
            this.doseComboBox.Size = new System.Drawing.Size(187, 23);
            this.doseComboBox.TabIndex = 0;
            this.doseComboBox.Text = "Select Dose";
            // 
            // vaccinationTimePicker
            // 
            this.vaccinationTimePicker.Location = new System.Drawing.Point(12, 261);
            this.vaccinationTimePicker.Name = "vaccinationTimePicker";
            this.vaccinationTimePicker.Size = new System.Drawing.Size(186, 23);
            this.vaccinationTimePicker.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Montserrat", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(13, 240);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Date Of Vaccination";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Montserrat", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(12, 168);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Dose";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(73, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(311, 91);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // confirm_btn
            // 
            this.confirm_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(196)))), ((int)(((byte)(143)))));
            this.confirm_btn.FlatAppearance.BorderSize = 0;
            this.confirm_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.confirm_btn.Font = new System.Drawing.Font("Montserrat", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.confirm_btn.ForeColor = System.Drawing.Color.White;
            this.confirm_btn.Location = new System.Drawing.Point(13, 407);
            this.confirm_btn.Name = "confirm_btn";
            this.confirm_btn.Size = new System.Drawing.Size(145, 34);
            this.confirm_btn.TabIndex = 38;
            this.confirm_btn.Text = "Confirm Changes";
            this.confirm_btn.UseVisualStyleBackColor = false;
            this.confirm_btn.Click += new System.EventHandler(this.OnConfirmChanges);
            // 
            // loadingGif
            // 
            this.loadingGif.Image = global::BakUna.Properties.Resources.Load_Anim;
            this.loadingGif.Location = new System.Drawing.Point(164, 407);
            this.loadingGif.Name = "loadingGif";
            this.loadingGif.Size = new System.Drawing.Size(34, 34);
            this.loadingGif.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.loadingGif.TabIndex = 39;
            this.loadingGif.TabStop = false;
            // 
            // userLabel
            // 
            this.userLabel.Font = new System.Drawing.Font("Montserrat", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.userLabel.Location = new System.Drawing.Point(13, 106);
            this.userLabel.Name = "userLabel";
            this.userLabel.Size = new System.Drawing.Size(424, 46);
            this.userLabel.TabIndex = 40;
            this.userLabel.Text = "Mark As Vaccinated";
            this.userLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // transactionConfirmationlabel
            // 
            this.transactionConfirmationlabel.AutoSize = true;
            this.transactionConfirmationlabel.BackColor = System.Drawing.Color.Transparent;
            this.transactionConfirmationlabel.Font = new System.Drawing.Font("Montserrat", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.transactionConfirmationlabel.Location = new System.Drawing.Point(13, 384);
            this.transactionConfirmationlabel.Name = "transactionConfirmationlabel";
            this.transactionConfirmationlabel.Size = new System.Drawing.Size(0, 16);
            this.transactionConfirmationlabel.TabIndex = 41;
            // 
            // closeButton
            // 
            this.closeButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(196)))), ((int)(((byte)(143)))));
            this.closeButton.FlatAppearance.BorderSize = 0;
            this.closeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closeButton.Font = new System.Drawing.Font("Montserrat", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.closeButton.ForeColor = System.Drawing.Color.White;
            this.closeButton.Location = new System.Drawing.Point(379, 407);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(58, 34);
            this.closeButton.TabIndex = 42;
            this.closeButton.Text = "Close";
            this.closeButton.UseVisualStyleBackColor = false;
            this.closeButton.Click += new System.EventHandler(this.CloseWindow);
            // 
            // vaccinator_tb
            // 
            this.vaccinator_tb.Location = new System.Drawing.Point(263, 187);
            this.vaccinator_tb.Name = "vaccinator_tb";
            this.vaccinator_tb.PlaceholderText = "e. g Jam";
            this.vaccinator_tb.Size = new System.Drawing.Size(174, 23);
            this.vaccinator_tb.TabIndex = 43;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Montserrat", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(263, 168);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 16);
            this.label3.TabIndex = 44;
            this.label3.Text = "Vaccinator";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Montserrat", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(263, 245);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 16);
            this.label4.TabIndex = 46;
            this.label4.Text = "Vaccination Site";
            // 
            // vaccination_site_tb
            // 
            this.vaccination_site_tb.Location = new System.Drawing.Point(263, 264);
            this.vaccination_site_tb.Name = "vaccination_site_tb";
            this.vaccination_site_tb.PlaceholderText = "e. g Hiyas Convention";
            this.vaccination_site_tb.Size = new System.Drawing.Size(174, 23);
            this.vaccination_site_tb.TabIndex = 45;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Montserrat", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(13, 313);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 16);
            this.label5.TabIndex = 48;
            this.label5.Text = "Vaccine Brand";
            // 
            // vaccineComboBox
            // 
            this.vaccineComboBox.FormattingEnabled = true;
            this.vaccineComboBox.Items.AddRange(new object[] {
            "Pfizer",
            "CoronaVac",
            "Covaxin",
            "Johnson&Johnson",
            "Moderna",
            "Nova Vax",
            "AstraZeneca",
            "Sinopharm",
            "Sputnik Light",
            "Sputnik V"});
            this.vaccineComboBox.Location = new System.Drawing.Point(12, 332);
            this.vaccineComboBox.Name = "vaccineComboBox";
            this.vaccineComboBox.Size = new System.Drawing.Size(187, 23);
            this.vaccineComboBox.TabIndex = 47;
            this.vaccineComboBox.Text = "Select Brand";
            // 
            // MarkAsVacWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(449, 453);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.vaccineComboBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.vaccination_site_tb);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.vaccinator_tb);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.transactionConfirmationlabel);
            this.Controls.Add(this.userLabel);
            this.Controls.Add(this.loadingGif);
            this.Controls.Add(this.confirm_btn);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.vaccinationTimePicker);
            this.Controls.Add(this.doseComboBox);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MarkAsVacWindow";
            this.Text = "MarkAsVacButton";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.loadingGif)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox doseComboBox;
        private System.Windows.Forms.DateTimePicker vaccinationTimePicker;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button confirm_btn;
        private System.Windows.Forms.PictureBox loadingGif;
        private System.Windows.Forms.Label userLabel;
        private System.Windows.Forms.Label transactionConfirmationlabel;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.TextBox vaccinator_tb;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox vaccination_site_tb;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox vaccineComboBox;
    }
}