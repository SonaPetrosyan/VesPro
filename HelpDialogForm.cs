using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    public partial class HelpDialogForm : Form
    {
        public HelpDialogForm()
        {
            InitializeComponent();
        }

        public void SetHelpContent(string content)
        {
            richTextBoxHelpContent.Text = content;         
        }

        private void richTextBoxHelpContent_TextChanged(object sender, EventArgs e)
        {
            // Adjust the size of the form to fit the content of the RichTextBox
            int contentHeight = richTextBoxHelpContent.GetPreferredSize(new Size(richTextBoxHelpContent.Width, 0)).Height;
            int additionalHeight = contentHeight - richTextBoxHelpContent.Height;

            // Adjust the form height by the additional height needed
            this.Height += additionalHeight;
        }
    }
}
