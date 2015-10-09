namespace IOD_Builder
{
    partial class Main
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
            this.filePath = new System.Windows.Forms.TextBox();
            this.browseBtn = new System.Windows.Forms.Button();
            this.buildBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.percentOut = new System.Windows.Forms.Label();
            this.outputBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // filePath
            // 
            this.filePath.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.filePath.Location = new System.Drawing.Point(12, 25);
            this.filePath.Name = "filePath";
            this.filePath.ReadOnly = true;
            this.filePath.Size = new System.Drawing.Size(286, 20);
            this.filePath.TabIndex = 0;
            // 
            // browseBtn
            // 
            this.browseBtn.Location = new System.Drawing.Point(304, 23);
            this.browseBtn.Name = "browseBtn";
            this.browseBtn.Size = new System.Drawing.Size(75, 23);
            this.browseBtn.TabIndex = 1;
            this.browseBtn.Text = "Browse...";
            this.browseBtn.UseVisualStyleBackColor = true;
            this.browseBtn.Click += new System.EventHandler(this.browseBtn_Click);
            // 
            // buildBtn
            // 
            this.buildBtn.Location = new System.Drawing.Point(211, 272);
            this.buildBtn.Name = "buildBtn";
            this.buildBtn.Size = new System.Drawing.Size(75, 23);
            this.buildBtn.TabIndex = 2;
            this.buildBtn.Text = "Build";
            this.buildBtn.UseVisualStyleBackColor = true;
            this.buildBtn.Click += new System.EventHandler(this.buildBtn_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelBtn.Location = new System.Drawing.Point(304, 272);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 3;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(12, 66);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(340, 32);
            this.progressBar.TabIndex = 4;
            // 
            // percentOut
            // 
            this.percentOut.AutoSize = true;
            this.percentOut.Location = new System.Drawing.Point(358, 76);
            this.percentOut.Name = "percentOut";
            this.percentOut.Size = new System.Drawing.Size(21, 13);
            this.percentOut.TabIndex = 5;
            this.percentOut.Text = "0%";
            // 
            // outputBox
            // 
            this.outputBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.outputBox.Location = new System.Drawing.Point(12, 115);
            this.outputBox.Multiline = true;
            this.outputBox.Name = "outputBox";
            this.outputBox.ReadOnly = true;
            this.outputBox.Size = new System.Drawing.Size(367, 121);
            this.outputBox.TabIndex = 6;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(391, 307);
            this.Controls.Add(this.outputBox);
            this.Controls.Add(this.percentOut);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.buildBtn);
            this.Controls.Add(this.browseBtn);
            this.Controls.Add(this.filePath);
            this.Name = "Main";
            this.Text = "IOD Builder";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox filePath;
        private System.Windows.Forms.Button browseBtn;
        private System.Windows.Forms.Button buildBtn;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label percentOut;
        private System.Windows.Forms.TextBox outputBox;
    }
}

