namespace BakUna.MainScreenForm
{
    partial class MainScreen
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
            this.vScrollBar1 = new System.Windows.Forms.VScrollBar();
            this.VacListBox = new System.Windows.Forms.ListBox();
            this.NonVacListBox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // vScrollBar1
            // 
            this.vScrollBar1.Location = new System.Drawing.Point(0, 0);
            this.vScrollBar1.Name = "vScrollBar1";
            this.vScrollBar1.Size = new System.Drawing.Size(17, 80);
            this.vScrollBar1.TabIndex = 0;
            // 
            // VacListBox
            // 
            this.VacListBox.BackColor = System.Drawing.Color.White;
            this.VacListBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.VacListBox.Cursor = System.Windows.Forms.Cursors.SizeNESW;
            this.VacListBox.FormattingEnabled = true;
            this.VacListBox.ItemHeight = 15;
            this.VacListBox.Location = new System.Drawing.Point(460, 169);
            this.VacListBox.Name = "VacListBox";
            this.VacListBox.Size = new System.Drawing.Size(375, 480);
            this.VacListBox.TabIndex = 1;
            this.VacListBox.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.VacBoxDrawItem);
            // 
            // NonVacListBox
            // 
            this.NonVacListBox.BackColor = System.Drawing.Color.White;
            this.NonVacListBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.NonVacListBox.Cursor = System.Windows.Forms.Cursors.SizeNESW;
            this.NonVacListBox.FormattingEnabled = true;
            this.NonVacListBox.ItemHeight = 15;
            this.NonVacListBox.Location = new System.Drawing.Point(862, 169);
            this.NonVacListBox.Name = "NonVacListBox";
            this.NonVacListBox.Size = new System.Drawing.Size(375, 480);
            this.NonVacListBox.TabIndex = 2;
            this.NonVacListBox.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.NonVacDrawItem);
            // 
            // MainScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 661);
            this.Controls.Add(this.NonVacListBox);
            this.Controls.Add(this.VacListBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainScreen";
            this.Text = "MainScreen";
            this.Load += new System.EventHandler(this.OnFormLoad);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.VScrollBar vScrollBar1;
        private System.Windows.Forms.ListBox VacListBox;
        private System.Windows.Forms.ListBox NonVacListBox;
    }
}