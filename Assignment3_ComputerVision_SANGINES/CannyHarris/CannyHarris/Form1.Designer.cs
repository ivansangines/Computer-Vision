namespace CannyHarris
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
            this.load_btn = new System.Windows.Forms.Button();
            this.canny_btn = new System.Windows.Forms.Button();
            this.harris_btn = new System.Windows.Forms.Button();
            this.original_img = new System.Windows.Forms.PictureBox();
            this.modified_img = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.original_img)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.modified_img)).BeginInit();
            this.SuspendLayout();
            // 
            // load_btn
            // 
            this.load_btn.Location = new System.Drawing.Point(24, 47);
            this.load_btn.Name = "load_btn";
            this.load_btn.Size = new System.Drawing.Size(75, 23);
            this.load_btn.TabIndex = 0;
            this.load_btn.Text = "Load Image";
            this.load_btn.UseVisualStyleBackColor = true;
            this.load_btn.Click += new System.EventHandler(this.load_btn_Click);
            // 
            // canny_btn
            // 
            this.canny_btn.Location = new System.Drawing.Point(24, 157);
            this.canny_btn.Name = "canny_btn";
            this.canny_btn.Size = new System.Drawing.Size(75, 23);
            this.canny_btn.TabIndex = 1;
            this.canny_btn.Text = "Canny";
            this.canny_btn.UseVisualStyleBackColor = true;
            this.canny_btn.Click += new System.EventHandler(this.canny_btn_Click);
            // 
            // harris_btn
            // 
            this.harris_btn.Location = new System.Drawing.Point(24, 197);
            this.harris_btn.Name = "harris_btn";
            this.harris_btn.Size = new System.Drawing.Size(75, 23);
            this.harris_btn.TabIndex = 2;
            this.harris_btn.Text = "Harris";
            this.harris_btn.UseVisualStyleBackColor = true;
            this.harris_btn.Click += new System.EventHandler(this.harris_btn_Click);
            // 
            // original_img
            // 
            this.original_img.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.original_img.Location = new System.Drawing.Point(142, 47);
            this.original_img.Name = "original_img";
            this.original_img.Size = new System.Drawing.Size(368, 304);
            this.original_img.TabIndex = 3;
            this.original_img.TabStop = false;
            // 
            // modified_img
            // 
            this.modified_img.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.modified_img.Location = new System.Drawing.Point(553, 47);
            this.modified_img.Name = "modified_img";
            this.modified_img.Size = new System.Drawing.Size(368, 304);
            this.modified_img.TabIndex = 4;
            this.modified_img.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(252, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "ORIGINAL IMAGE";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(706, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "MODIFIED IMAGE";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(997, 522);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.modified_img);
            this.Controls.Add(this.original_img);
            this.Controls.Add(this.harris_btn);
            this.Controls.Add(this.canny_btn);
            this.Controls.Add(this.load_btn);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.original_img)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.modified_img)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button load_btn;
        private System.Windows.Forms.Button canny_btn;
        private System.Windows.Forms.Button harris_btn;
        private System.Windows.Forms.PictureBox original_img;
        private System.Windows.Forms.PictureBox modified_img;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

