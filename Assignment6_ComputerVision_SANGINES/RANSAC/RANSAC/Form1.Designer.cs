namespace RANSAC
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
            this.original_panel = new System.Windows.Forms.Panel();
            this.transformed_panel = new System.Windows.Forms.Panel();
            this.ransac_panel = new System.Windows.Forms.Panel();
            this.initialize_btn = new System.Windows.Forms.Button();
            this.transformation_btn = new System.Windows.Forms.Button();
            this.ransac_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // original_panel
            // 
            this.original_panel.Location = new System.Drawing.Point(23, 35);
            this.original_panel.Name = "original_panel";
            this.original_panel.Size = new System.Drawing.Size(281, 341);
            this.original_panel.TabIndex = 0;
            // 
            // transformed_panel
            // 
            this.transformed_panel.Location = new System.Drawing.Point(325, 35);
            this.transformed_panel.Name = "transformed_panel";
            this.transformed_panel.Size = new System.Drawing.Size(281, 341);
            this.transformed_panel.TabIndex = 1;
            // 
            // ransac_panel
            // 
            this.ransac_panel.Location = new System.Drawing.Point(628, 35);
            this.ransac_panel.Name = "ransac_panel";
            this.ransac_panel.Size = new System.Drawing.Size(281, 341);
            this.ransac_panel.TabIndex = 2;
            // 
            // initialize_btn
            // 
            this.initialize_btn.Location = new System.Drawing.Point(88, 394);
            this.initialize_btn.Name = "initialize_btn";
            this.initialize_btn.Size = new System.Drawing.Size(118, 23);
            this.initialize_btn.TabIndex = 3;
            this.initialize_btn.Text = "Initialize Shapes";
            this.initialize_btn.UseVisualStyleBackColor = true;
            this.initialize_btn.Click += new System.EventHandler(this.initialize_btn_Click);
            // 
            // transformation_btn
            // 
            this.transformation_btn.Location = new System.Drawing.Point(408, 394);
            this.transformation_btn.Name = "transformation_btn";
            this.transformation_btn.Size = new System.Drawing.Size(125, 23);
            this.transformation_btn.TabIndex = 4;
            this.transformation_btn.Text = "Apply Transformation";
            this.transformation_btn.UseVisualStyleBackColor = true;
            this.transformation_btn.Click += new System.EventHandler(this.transformation_btn_Click);
            // 
            // ransac_btn
            // 
            this.ransac_btn.Location = new System.Drawing.Point(747, 394);
            this.ransac_btn.Name = "ransac_btn";
            this.ransac_btn.Size = new System.Drawing.Size(75, 23);
            this.ransac_btn.TabIndex = 5;
            this.ransac_btn.Text = "RANSAC";
            this.ransac_btn.UseVisualStyleBackColor = true;
            this.ransac_btn.Click += new System.EventHandler(this.ransac_btn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(949, 510);
            this.Controls.Add(this.ransac_btn);
            this.Controls.Add(this.transformation_btn);
            this.Controls.Add(this.initialize_btn);
            this.Controls.Add(this.ransac_panel);
            this.Controls.Add(this.transformed_panel);
            this.Controls.Add(this.original_panel);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel original_panel;
        private System.Windows.Forms.Panel transformed_panel;
        private System.Windows.Forms.Panel ransac_panel;
        private System.Windows.Forms.Button initialize_btn;
        private System.Windows.Forms.Button transformation_btn;
        private System.Windows.Forms.Button ransac_btn;
    }
}

