namespace ParserSite
{
    partial class ShowMore
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
            this.rtxtInformation = new System.Windows.Forms.RichTextBox();
            this.grpInformation = new System.Windows.Forms.GroupBox();
            this.grpInformation.SuspendLayout();
            this.SuspendLayout();
            // 
            // rtxtInformation
            // 
            this.rtxtInformation.Location = new System.Drawing.Point(6, 19);
            this.rtxtInformation.Name = "rtxtInformation";
            this.rtxtInformation.Size = new System.Drawing.Size(348, 312);
            this.rtxtInformation.TabIndex = 0;
            this.rtxtInformation.Text = "";
            // 
            // grpInformation
            // 
            this.grpInformation.Controls.Add(this.rtxtInformation);
            this.grpInformation.Location = new System.Drawing.Point(12, 12);
            this.grpInformation.Name = "grpInformation";
            this.grpInformation.Size = new System.Drawing.Size(360, 337);
            this.grpInformation.TabIndex = 0;
            this.grpInformation.TabStop = false;
            this.grpInformation.Text = "Текст";
            // 
            // ShowMore
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 361);
            this.Controls.Add(this.grpInformation);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ShowMore";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Дополнительная информация";
            this.grpInformation.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtxtInformation;
        private System.Windows.Forms.GroupBox grpInformation;
    }
}