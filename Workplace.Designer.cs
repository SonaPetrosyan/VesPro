namespace WindowsFormsApp4
{
    partial class Workplace
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.powerbox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.getprinterbox = new System.Windows.Forms.ListBox();
            this.HollUpDown = new System.Windows.Forms.NumericUpDown();
            this.comboBoxRest = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.savebutton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column17 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column18 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column19 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column20 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column21 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.helpProvider1 = new System.Windows.Forms.HelpProvider();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.HollUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.powerbox);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.getprinterbox);
            this.panel1.Controls.Add(this.HollUpDown);
            this.panel1.Controls.Add(this.comboBoxRest);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.savebutton);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Location = new System.Drawing.Point(2, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1636, 111);
            this.panel1.TabIndex = 9;
            // 
            // powerbox
            // 
            this.powerbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.powerbox.FormattingEnabled = true;
            this.powerbox.Items.AddRange(new object[] {
            "ամեն ինչ R/W",
            "ամեն ինչ R",
            "պատվեր R/W",
            "պատվեր և մարող R/W",
            "պատվեր R",
            "պատվեր, շարժ  R",
            "տեղեկատուներ  R"});
            this.powerbox.Location = new System.Drawing.Point(323, 50);
            this.powerbox.Name = "powerbox";
            this.powerbox.Size = new System.Drawing.Size(242, 28);
            this.powerbox.TabIndex = 17;
            this.powerbox.Visible = false;
            this.powerbox.SelectedIndexChanged += new System.EventHandler(this.powerbox_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(383, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(122, 20);
            this.label3.TabIndex = 16;
            this.label3.Text = "հնարավորույթ";
            // 
            // getprinterbox
            // 
            this.getprinterbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.getprinterbox.FormattingEnabled = true;
            this.getprinterbox.ItemHeight = 20;
            this.getprinterbox.Location = new System.Drawing.Point(682, 2);
            this.getprinterbox.Name = "getprinterbox";
            this.getprinterbox.Size = new System.Drawing.Size(216, 104);
            this.getprinterbox.TabIndex = 15;
            this.getprinterbox.Visible = false;
            this.getprinterbox.Click += new System.EventHandler(this.getprinterbox_Click);
            // 
            // HollUpDown
            // 
            this.HollUpDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HollUpDown.Location = new System.Drawing.Point(1167, 47);
            this.HollUpDown.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.HollUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.HollUpDown.Name = "HollUpDown";
            this.HollUpDown.Size = new System.Drawing.Size(79, 27);
            this.HollUpDown.TabIndex = 14;
            this.HollUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // comboBoxRest
            // 
            this.comboBoxRest.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxRest.FormattingEnabled = true;
            this.comboBoxRest.Location = new System.Drawing.Point(927, 47);
            this.comboBoxRest.Name = "comboBoxRest";
            this.comboBoxRest.Size = new System.Drawing.Size(194, 28);
            this.comboBoxRest.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(1175, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 20);
            this.label2.TabIndex = 12;
            this.label2.Text = "Սրահ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(978, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 20);
            this.label1.TabIndex = 11;
            this.label1.Text = "Ռեստորան";
            // 
            // savebutton
            // 
            this.savebutton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.savebutton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.savebutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.savebutton.Location = new System.Drawing.Point(109, 37);
            this.savebutton.Name = "savebutton";
            this.savebutton.Size = new System.Drawing.Size(75, 42);
            this.savebutton.TabIndex = 10;
            this.savebutton.Text = "Save";
            this.savebutton.UseVisualStyleBackColor = false;
            this.savebutton.Visible = false;
            this.savebutton.Click += new System.EventHandler(this.savebutton_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(13, 37);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 42);
            this.button1.TabIndex = 9;
            this.button1.Text = "Add";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeight = 29;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8,
            this.Column9,
            this.Column10,
            this.Column11,
            this.Column12,
            this.Column13,
            this.Column14,
            this.Column15,
            this.Column16,
            this.Column17,
            this.Column18,
            this.Column19,
            this.Column20,
            this.Column21});
            this.dataGridView1.Location = new System.Drawing.Point(2, 114);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 6;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1475, 620);
            this.dataGridView1.TabIndex = 10;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            this.dataGridView1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellEndEdit);
            // 
            // Column1
            // 
            this.Column1.Frozen = true;
            this.Column1.HeaderText = "N#";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.Width = 60;
            // 
            // Column2
            // 
            this.Column2.Frozen = true;
            this.Column2.HeaderText = "նկարագրություն";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.Width = 125;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "հնարավորույթ";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 150;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "հաշվի տպիչ";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            this.Column4.Width = 80;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "նախահաշվի";
            this.Column5.MinimumWidth = 6;
            this.Column5.Name = "Column5";
            this.Column5.Width = 80;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "ՀԴՄ տպիչ";
            this.Column6.MinimumWidth = 6;
            this.Column6.Name = "Column6";
            this.Column6.Width = 80;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "տպիչ 1";
            this.Column7.MinimumWidth = 6;
            this.Column7.Name = "Column7";
            this.Column7.Width = 80;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "տպիչ 2";
            this.Column8.MinimumWidth = 6;
            this.Column8.Name = "Column8";
            this.Column8.Width = 80;
            // 
            // Column9
            // 
            this.Column9.HeaderText = "տպիչ 3";
            this.Column9.MinimumWidth = 6;
            this.Column9.Name = "Column9";
            this.Column9.Width = 80;
            // 
            // Column10
            // 
            this.Column10.HeaderText = "տպիչ 4";
            this.Column10.MinimumWidth = 6;
            this.Column10.Name = "Column10";
            this.Column10.Width = 80;
            // 
            // Column11
            // 
            this.Column11.HeaderText = "տպիչ 5";
            this.Column11.MinimumWidth = 6;
            this.Column11.Name = "Column11";
            this.Column11.Width = 80;
            // 
            // Column12
            // 
            this.Column12.HeaderText = "տպիչ 6";
            this.Column12.MinimumWidth = 6;
            this.Column12.Name = "Column12";
            this.Column12.Width = 80;
            // 
            // Column13
            // 
            this.Column13.HeaderText = "տպիչ 7";
            this.Column13.MinimumWidth = 6;
            this.Column13.Name = "Column13";
            this.Column13.Width = 80;
            // 
            // Column14
            // 
            this.Column14.HeaderText = "տպիչ 8";
            this.Column14.MinimumWidth = 6;
            this.Column14.Name = "Column14";
            this.Column14.Width = 80;
            // 
            // Column15
            // 
            this.Column15.HeaderText = "տպիչ 9";
            this.Column15.MinimumWidth = 6;
            this.Column15.Name = "Column15";
            this.Column15.Width = 80;
            // 
            // Column16
            // 
            this.Column16.HeaderText = "տպիչ 10";
            this.Column16.MinimumWidth = 6;
            this.Column16.Name = "Column16";
            this.Column16.Width = 80;
            // 
            // Column17
            // 
            this.Column17.HeaderText = "տպիչ 11";
            this.Column17.MinimumWidth = 6;
            this.Column17.Name = "Column17";
            this.Column17.Width = 80;
            // 
            // Column18
            // 
            this.Column18.HeaderText = "տպիչ 12";
            this.Column18.MinimumWidth = 6;
            this.Column18.Name = "Column18";
            this.Column18.Width = 80;
            // 
            // Column19
            // 
            this.Column19.HeaderText = "տպիչ 13";
            this.Column19.MinimumWidth = 6;
            this.Column19.Name = "Column19";
            this.Column19.Width = 80;
            // 
            // Column20
            // 
            this.Column20.HeaderText = "տպիչ 14";
            this.Column20.MinimumWidth = 6;
            this.Column20.Name = "Column20";
            this.Column20.Width = 80;
            // 
            // Column21
            // 
            this.Column21.HeaderText = "տպիչ 15";
            this.Column21.MinimumWidth = 6;
            this.Column21.Name = "Column21";
            this.Column21.Width = 125;
            // 
            // Workplace
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(1834, 737);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.HelpButton = true;
            this.Name = "Workplace";
            this.Text = "Workplace";
            this.Load += new System.EventHandler(this.Workplace_Load);
            this.ResizeBegin += new System.EventHandler(this.Workplace_ResizeBegin);
            this.ResizeEnd += new System.EventHandler(this.Workplace_ResizeEnd);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.HollUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.NumericUpDown HollUpDown;
        private System.Windows.Forms.ComboBox comboBoxRest;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button savebutton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ListBox getprinterbox;
        private System.Windows.Forms.ComboBox powerbox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column12;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column13;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column14;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column15;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column16;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column17;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column18;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column19;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column20;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column21;
        private System.Windows.Forms.HelpProvider helpProvider1;
    }
}