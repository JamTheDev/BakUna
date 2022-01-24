
namespace BakUna.LoginElements
{
    partial class AuthWindow
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
            this.city_name_label = new System.Windows.Forms.Label();
            this.city_branch_loc = new System.Windows.Forms.Label();
            this.password_txt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.loading_gif = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.close_btn = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.error = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.loading_gif)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // city_name_label
            // 
            this.city_name_label.Font = new System.Drawing.Font("Montserrat", 21F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.city_name_label.Location = new System.Drawing.Point(12, 20);
            this.city_name_label.Name = "city_name_label";
            this.city_name_label.Size = new System.Drawing.Size(476, 47);
            this.city_name_label.TabIndex = 0;
            this.city_name_label.Text = "CITY_NAME";
            this.city_name_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // city_branch_loc
            // 
            this.city_branch_loc.Font = new System.Drawing.Font("Montserrat", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.city_branch_loc.ForeColor = System.Drawing.Color.DarkGray;
            this.city_branch_loc.Location = new System.Drawing.Point(12, 67);
            this.city_branch_loc.Name = "city_branch_loc";
            this.city_branch_loc.Size = new System.Drawing.Size(476, 30);
            this.city_branch_loc.TabIndex = 1;
            this.city_branch_loc.Text = "BRANCH_LOC";
            this.city_branch_loc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // password_txt
            // 
            this.password_txt.Location = new System.Drawing.Point(77, 145);
            this.password_txt.Name = "password_txt";
            this.password_txt.Size = new System.Drawing.Size(350, 23);
            this.password_txt.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Montserrat", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(77, 117);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(187, 25);
            this.label3.TabIndex = 3;
            this.label3.Text = "PASSWORD";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // loading_gif
            // 
            this.loading_gif.Image = global::BakUna.Properties.Resources.Load_Anim;
            this.loading_gif.Location = new System.Drawing.Point(397, 112);
            this.loading_gif.Name = "loading_gif";
            this.loading_gif.Size = new System.Drawing.Size(30, 30);
            this.loading_gif.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.loading_gif.TabIndex = 4;
            this.loading_gif.TabStop = false;
            // 
            // button1
            // 
            this.button1.BackgroundImage = global::BakUna.Properties.Resources.Green_gradient;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Montserrat", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button1.Location = new System.Drawing.Point(77, 222);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(350, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "LOGIN";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // close_btn
            // 
            this.close_btn.BackgroundImage = global::BakUna.Properties.Resources.Green_gradient;
            this.close_btn.FlatAppearance.BorderSize = 0;
            this.close_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.close_btn.Font = new System.Drawing.Font("Montserrat", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.close_btn.Location = new System.Drawing.Point(464, 12);
            this.close_btn.Name = "close_btn";
            this.close_btn.Size = new System.Drawing.Size(24, 23);
            this.close_btn.TabIndex = 6;
            this.close_btn.Text = "X";
            this.close_btn.UseVisualStyleBackColor = true;
            this.close_btn.Click += new System.EventHandler(this.close_btn_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.SystemColors.Control;
            this.pictureBox2.Image = global::BakUna.Properties.Resources.Green_gradient;
            this.pictureBox2.Location = new System.Drawing.Point(12, 273);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(476, 10);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 47;
            this.pictureBox2.TabStop = false;
            // 
            // error
            // 
            this.error.Font = new System.Drawing.Font("Montserrat", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.error.Location = new System.Drawing.Point(77, 173);
            this.error.Name = "error";
            this.error.Size = new System.Drawing.Size(350, 36);
            this.error.TabIndex = 48;
            this.error.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AuthWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 295);
            this.Controls.Add(this.error);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.close_btn);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.loading_gif);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.password_txt);
            this.Controls.Add(this.city_branch_loc);
            this.Controls.Add(this.city_name_label);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AuthWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AuthWindow";
            this.Load += new System.EventHandler(this.OnFormLoad);
            ((System.ComponentModel.ISupportInitialize)(this.loading_gif)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label city_name_label;
        private System.Windows.Forms.Label city_branch_loc;
        private System.Windows.Forms.TextBox password_txt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox loading_gif;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button close_btn;
        private System.Windows.Forms.Label branch_loc;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label error;
    }
}