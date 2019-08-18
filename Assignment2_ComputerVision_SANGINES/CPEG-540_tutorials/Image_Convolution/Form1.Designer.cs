namespace Image_Convolution
{
    partial class Form1
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.ApplyMaskBtn = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.LoadImgBtn = new System.Windows.Forms.Button();
            this.Savebtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.Window;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(23, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(403, 319);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // ApplyMaskBtn
            // 
            this.ApplyMaskBtn.Enabled = false;
            this.ApplyMaskBtn.Location = new System.Drawing.Point(9, 112);
            this.ApplyMaskBtn.Name = "ApplyMaskBtn";
            this.ApplyMaskBtn.Size = new System.Drawing.Size(178, 25);
            this.ApplyMaskBtn.TabIndex = 1;
            this.ApplyMaskBtn.Text = "Apply Filter";
            this.ApplyMaskBtn.UseVisualStyleBackColor = true;
            this.ApplyMaskBtn.Click += new System.EventHandler(this.ApplyMaskBtn_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox7);
            this.groupBox1.Controls.Add(this.textBox8);
            this.groupBox1.Controls.Add(this.textBox9);
            this.groupBox1.Controls.Add(this.textBox4);
            this.groupBox1.Controls.Add(this.textBox5);
            this.groupBox1.Controls.Add(this.textBox6);
            this.groupBox1.Controls.Add(this.textBox3);
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Controls.Add(this.ApplyMaskBtn);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Location = new System.Drawing.Point(449, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(206, 148);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "3 By 3 kernel ";
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(147, 83);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(53, 20);
            this.textBox7.TabIndex = 21;
            this.textBox7.Text = "(1 , 1)";
            // 
            // textBox8
            // 
            this.textBox8.Location = new System.Drawing.Point(147, 54);
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(53, 20);
            this.textBox8.TabIndex = 20;
            this.textBox8.Text = "(1 , 0)";
            // 
            // textBox9
            // 
            this.textBox9.Location = new System.Drawing.Point(147, 28);
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new System.Drawing.Size(53, 20);
            this.textBox9.TabIndex = 19;
            this.textBox9.Text = "(1 , -1)";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(76, 85);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(53, 20);
            this.textBox4.TabIndex = 18;
            this.textBox4.Text = "(0 , 1)";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(76, 56);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(53, 20);
            this.textBox5.TabIndex = 17;
            this.textBox5.Text = "(0 , 0)";
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(76, 30);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(53, 20);
            this.textBox6.TabIndex = 16;
            this.textBox6.Text = "(0 , -1)";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(6, 86);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(53, 20);
            this.textBox3.TabIndex = 15;
            this.textBox3.Text = "(-1 , 1)";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(6, 57);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(53, 20);
            this.textBox2.TabIndex = 14;
            this.textBox2.Text = "(-1 , 0)";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(6, 31);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(53, 20);
            this.textBox1.TabIndex = 13;
            this.textBox1.Text = "(-1 , -1)";
            // 
            // LoadImgBtn
            // 
            this.LoadImgBtn.Location = new System.Drawing.Point(23, 375);
            this.LoadImgBtn.Name = "LoadImgBtn";
            this.LoadImgBtn.Size = new System.Drawing.Size(128, 46);
            this.LoadImgBtn.TabIndex = 5;
            this.LoadImgBtn.Text = "Load Image";
            this.LoadImgBtn.UseVisualStyleBackColor = true;
            this.LoadImgBtn.Click += new System.EventHandler(this.LoadImgBtn_Click);
            // 
            // Savebtn
            // 
            this.Savebtn.Location = new System.Drawing.Point(182, 375);
            this.Savebtn.Name = "Savebtn";
            this.Savebtn.Size = new System.Drawing.Size(113, 44);
            this.Savebtn.TabIndex = 15;
            this.Savebtn.Text = "Save Image";
            this.Savebtn.UseVisualStyleBackColor = true;
            this.Savebtn.Click += new System.EventHandler(this.Savebtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(706, 476);
            this.Controls.Add(this.Savebtn);
            this.Controls.Add(this.LoadImgBtn);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button ApplyMaskBtn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button LoadImgBtn;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.TextBox textBox9;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button Savebtn;
    }
}

