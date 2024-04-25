namespace WindowsFormsApp4
{
    partial class HelpDialogForm
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
            this.richTextBoxHelpContent = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // richTextBoxHelpContent
            // 
            this.richTextBoxHelpContent.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.richTextBoxHelpContent.ForeColor = System.Drawing.SystemColors.InfoText;
            this.richTextBoxHelpContent.Location = new System.Drawing.Point(-3, 2);
            this.richTextBoxHelpContent.Name = "richTextBoxHelpContent";
            this.richTextBoxHelpContent.Size = new System.Drawing.Size(785, 377);
            this.richTextBoxHelpContent.TabIndex = 0;
            this.richTextBoxHelpContent.Text = "";
            this.richTextBoxHelpContent.TextChanged += new System.EventHandler(this.richTextBoxHelpContent_TextChanged);
            // 
            // HelpDialogForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(774, 372);
            this.Controls.Add(this.richTextBoxHelpContent);
            this.Name = "HelpDialogForm";
            this.Text = "Օգնություն";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBoxHelpContent;
    }
}