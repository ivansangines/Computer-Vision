namespace HistogramEqualization
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
            this.btnLoad = new System.Windows.Forms.Button();
            this.picOriginal = new System.Windows.Forms.PictureBox();
            this.picModified = new System.Windows.Forms.PictureBox();
            this.btnHisto = new System.Windows.Forms.Button();
            this.btnGrey = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picOriginal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picModified)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(21, 42);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(89, 31);
            this.btnLoad.TabIndex = 0;
            this.btnLoad.Text = "Load Image";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // picOriginal
            // 
            this.picOriginal.Location = new System.Drawing.Point(138, 42);
            this.picOriginal.Name = "picOriginal";
            this.picOriginal.Size = new System.Drawing.Size(382, 389);
            this.picOriginal.TabIndex = 1;
            this.picOriginal.TabStop = false;
            // 
            // picModified
            // 
            this.picModified.Location = new System.Drawing.Point(526, 42);
            this.picModified.Name = "picModified";
            this.picModified.Size = new System.Drawing.Size(382, 389);
            this.picModified.TabIndex = 2;
            this.picModified.TabStop = false;
            // 
            // btnHisto
            // 
            this.btnHisto.Location = new System.Drawing.Point(21, 198);
            this.btnHisto.Name = "btnHisto";
            this.btnHisto.Size = new System.Drawing.Size(89, 29);
            this.btnHisto.TabIndex = 3;
            this.btnHisto.Text = "Histogram";
            this.btnHisto.UseVisualStyleBackColor = true;
            this.btnHisto.Click += new System.EventHandler(this.btnHisto_Click);
            // 
            // btnGrey
            // 
            this.btnGrey.Location = new System.Drawing.Point(21, 118);
            this.btnGrey.Name = "btnGrey";
            this.btnGrey.Size = new System.Drawing.Size(89, 29);
            this.btnGrey.TabIndex = 4;
            this.btnGrey.Text = "Conver to Grey";
            this.btnGrey.UseVisualStyleBackColor = true;
            this.btnGrey.Click += new System.EventHandler(this.btnGrey_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(931, 519);
            this.Controls.Add(this.btnGrey);
            this.Controls.Add(this.btnHisto);
            this.Controls.Add(this.picModified);
            this.Controls.Add(this.picOriginal);
            this.Controls.Add(this.btnLoad);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.picOriginal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picModified)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.PictureBox picOriginal;
        private System.Windows.Forms.PictureBox picModified;
        private System.Windows.Forms.Button btnHisto;
        private System.Windows.Forms.Button btnGrey;
    }
}

