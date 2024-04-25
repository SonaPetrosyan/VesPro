using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.Linq;

namespace WindowsFormsApp4
{
    public partial class order
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.group1 = new System.Windows.Forms.Button();
            this.process1 = new System.Diagnostics.Process();
            this.group2 = new System.Windows.Forms.Button();
            this.group3 = new System.Windows.Forms.Button();
            this.group4 = new System.Windows.Forms.Button();
            this.group5 = new System.Windows.Forms.Button();
            this.group6 = new System.Windows.Forms.Button();
            this.group7 = new System.Windows.Forms.Button();
            this.group8 = new System.Windows.Forms.Button();
            this.group9 = new System.Windows.Forms.Button();
            this.group10 = new System.Windows.Forms.Button();
            this.group11 = new System.Windows.Forms.Button();
            this.group12 = new System.Windows.Forms.Button();
            this.group13 = new System.Windows.Forms.Button();
            this.group14 = new System.Windows.Forms.Button();
            this.group15 = new System.Windows.Forms.Button();
            this.group16 = new System.Windows.Forms.Button();
            this.group17 = new System.Windows.Forms.Button();
            this.group18 = new System.Windows.Forms.Button();
            this.group19 = new System.Windows.Forms.Button();
            this.group20 = new System.Windows.Forms.Button();
            this.group21 = new System.Windows.Forms.Button();
            this.group22 = new System.Windows.Forms.Button();
            this.group23 = new System.Windows.Forms.Button();
            this.group24 = new System.Windows.Forms.Button();
            this.group25 = new System.Windows.Forms.Button();
            this.group26 = new System.Windows.Forms.Button();
            this.group27 = new System.Windows.Forms.Button();
            this.group28 = new System.Windows.Forms.Button();
            this.group29 = new System.Windows.Forms.Button();
            this.group30 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tab1 = new System.Windows.Forms.Button();
            this.nest = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.bill = new System.Windows.Forms.Label();
            this.command = new System.Windows.Forms.Button();
            this.tab2 = new System.Windows.Forms.Button();
            this.tab3 = new System.Windows.Forms.Button();
            this.tab4 = new System.Windows.Forms.Button();
            this.tab5 = new System.Windows.Forms.Button();
            this.ManagerBox = new System.Windows.Forms.TextBox();
            this.department1 = new System.Windows.Forms.Button();
            this.department2 = new System.Windows.Forms.Button();
            this.department3 = new System.Windows.Forms.Button();
            this.department4 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tab7 = new System.Windows.Forms.Button();
            this.tab6 = new System.Windows.Forms.Button();
            this.tab14 = new System.Windows.Forms.Button();
            this.tab13 = new System.Windows.Forms.Button();
            this.tab12 = new System.Windows.Forms.Button();
            this.tab11 = new System.Windows.Forms.Button();
            this.tab10 = new System.Windows.Forms.Button();
            this.tab9 = new System.Windows.Forms.Button();
            this.tab8 = new System.Windows.Forms.Button();
            this.tab21 = new System.Windows.Forms.Button();
            this.tab20 = new System.Windows.Forms.Button();
            this.tab19 = new System.Windows.Forms.Button();
            this.tab18 = new System.Windows.Forms.Button();
            this.tab17 = new System.Windows.Forms.Button();
            this.tab16 = new System.Windows.Forms.Button();
            this.tab15 = new System.Windows.Forms.Button();
            this.tab28 = new System.Windows.Forms.Button();
            this.tab27 = new System.Windows.Forms.Button();
            this.tab26 = new System.Windows.Forms.Button();
            this.tab25 = new System.Windows.Forms.Button();
            this.tab24 = new System.Windows.Forms.Button();
            this.tab23 = new System.Windows.Forms.Button();
            this.tab22 = new System.Windows.Forms.Button();
            this.tab35 = new System.Windows.Forms.Button();
            this.tab34 = new System.Windows.Forms.Button();
            this.tab33 = new System.Windows.Forms.Button();
            this.tab32 = new System.Windows.Forms.Button();
            this.tab31 = new System.Windows.Forms.Button();
            this.tab30 = new System.Windows.Forms.Button();
            this.tab29 = new System.Windows.Forms.Button();
            this.tab42 = new System.Windows.Forms.Button();
            this.tab41 = new System.Windows.Forms.Button();
            this.tab40 = new System.Windows.Forms.Button();
            this.tab39 = new System.Windows.Forms.Button();
            this.tab38 = new System.Windows.Forms.Button();
            this.tab37 = new System.Windows.Forms.Button();
            this.tab36 = new System.Windows.Forms.Button();
            this.tab49 = new System.Windows.Forms.Button();
            this.tab48 = new System.Windows.Forms.Button();
            this.tab47 = new System.Windows.Forms.Button();
            this.tab46 = new System.Windows.Forms.Button();
            this.tab45 = new System.Windows.Forms.Button();
            this.tab44 = new System.Windows.Forms.Button();
            this.tab43 = new System.Windows.Forms.Button();
            this.tab56 = new System.Windows.Forms.Button();
            this.tab55 = new System.Windows.Forms.Button();
            this.tab54 = new System.Windows.Forms.Button();
            this.tab53 = new System.Windows.Forms.Button();
            this.tab52 = new System.Windows.Forms.Button();
            this.tab51 = new System.Windows.Forms.Button();
            this.tab50 = new System.Windows.Forms.Button();
            this.tab63 = new System.Windows.Forms.Button();
            this.tab61 = new System.Windows.Forms.Button();
            this.tab60 = new System.Windows.Forms.Button();
            this.tab59 = new System.Windows.Forms.Button();
            this.tab58 = new System.Windows.Forms.Button();
            this.tab57 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.number8 = new System.Windows.Forms.Button();
            this.number3 = new System.Windows.Forms.Button();
            this.number2 = new System.Windows.Forms.Button();
            this.number1 = new System.Windows.Forms.Button();
            this.number0 = new System.Windows.Forms.Button();
            this.number4 = new System.Windows.Forms.Button();
            this.number7 = new System.Windows.Forms.Button();
            this.number6 = new System.Windows.Forms.Button();
            this.number5 = new System.Windows.Forms.Button();
            this.number9 = new System.Windows.Forms.Button();
            this.number_enter = new System.Windows.Forms.Button();
            this.number_point = new System.Windows.Forms.Button();
            this.number_delete = new System.Windows.Forms.Button();
            this.open_nest = new System.Windows.Forms.Button();
            this.backspace = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.accept = new System.Windows.Forms.Button();
            this.printbutton1 = new System.Windows.Forms.Button();
            this.printbutton2 = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            this.amount = new System.Windows.Forms.Label();
            this.service = new System.Windows.Forms.Label();
            this.discount = new System.Windows.Forms.Label();
            this.total = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.tab62 = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.addition10 = new System.Windows.Forms.Button();
            this.addition6 = new System.Windows.Forms.Button();
            this.addition7 = new System.Windows.Forms.Button();
            this.addition8 = new System.Windows.Forms.Button();
            this.addition9 = new System.Windows.Forms.Button();
            this.addition5 = new System.Windows.Forms.Button();
            this.addition3 = new System.Windows.Forms.Button();
            this.addition4 = new System.Windows.Forms.Button();
            this.addition1 = new System.Windows.Forms.Button();
            this.addition2 = new System.Windows.Forms.Button();
            this.addition12 = new System.Windows.Forms.Button();
            this.addition20 = new System.Windows.Forms.Button();
            this.addition16 = new System.Windows.Forms.Button();
            this.addition17 = new System.Windows.Forms.Button();
            this.addition18 = new System.Windows.Forms.Button();
            this.addition19 = new System.Windows.Forms.Button();
            this.addition15 = new System.Windows.Forms.Button();
            this.addition13 = new System.Windows.Forms.Button();
            this.addition14 = new System.Windows.Forms.Button();
            this.addition11 = new System.Windows.Forms.Button();
            this.DepartmentClick = new System.Windows.Forms.Button();
            this.GroupClick = new System.Windows.Forms.Button();
            this.AdditionClick = new System.Windows.Forms.Button();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label13 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ShtrichCode = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.Seans = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.PartnersComboBox = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.gid = new System.Windows.Forms.Label();
            this.tab69 = new System.Windows.Forms.Button();
            this.tab70 = new System.Windows.Forms.Button();
            this.tab68 = new System.Windows.Forms.Button();
            this.tab67 = new System.Windows.Forms.Button();
            this.tab66 = new System.Windows.Forms.Button();
            this.tab65 = new System.Windows.Forms.Button();
            this.tab64 = new System.Windows.Forms.Button();
            this.label18 = new System.Windows.Forms.Label();
            this.legend = new System.Windows.Forms.Label();
            this.cancel2 = new System.Windows.Forms.Button();
            this.numericUpDown3 = new System.Windows.Forms.NumericUpDown();
            this.label17 = new System.Windows.Forms.Label();
            this.department5 = new System.Windows.Forms.Button();
            this.HelpButton = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.TipMoney = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.remove = new System.Windows.Forms.Button();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).BeginInit();
            this.SuspendLayout();
            // 
            // group1
            // 
            this.group1.BackColor = System.Drawing.Color.White;
            this.group1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.group1.FlatAppearance.BorderColor = System.Drawing.Color.Maroon;
            this.group1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Green;
            this.group1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.group1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.group1.ForeColor = System.Drawing.Color.Maroon;
            this.group1.Location = new System.Drawing.Point(12, 5);
            this.group1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.group1.Name = "group1";
            this.group1.Size = new System.Drawing.Size(79, 23);
            this.group1.TabIndex = 0;
            this.group1.Text = "group1";
            this.group1.UseVisualStyleBackColor = false;
            this.group1.Visible = false;
            this.group1.Click += new System.EventHandler(this.group1_Click);
            // 
            // process1
            // 
            this.process1.StartInfo.Domain = "";
            this.process1.StartInfo.LoadUserProfile = false;
            this.process1.StartInfo.Password = null;
            this.process1.StartInfo.StandardErrorEncoding = null;
            this.process1.StartInfo.StandardOutputEncoding = null;
            this.process1.StartInfo.UserName = "";
            this.process1.SynchronizingObject = this;
            // 
            // group2
            // 
            this.group2.BackColor = System.Drawing.Color.White;
            this.group2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.group2.FlatAppearance.BorderColor = System.Drawing.Color.Maroon;
            this.group2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Green;
            this.group2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.group2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.group2.ForeColor = System.Drawing.Color.Maroon;
            this.group2.Location = new System.Drawing.Point(92, 5);
            this.group2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.group2.Name = "group2";
            this.group2.Size = new System.Drawing.Size(79, 23);
            this.group2.TabIndex = 3;
            this.group2.Text = "group2";
            this.group2.UseVisualStyleBackColor = false;
            this.group2.Visible = false;
            this.group2.Click += new System.EventHandler(this.group2_Click);
            // 
            // group3
            // 
            this.group3.BackColor = System.Drawing.Color.White;
            this.group3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.group3.FlatAppearance.BorderColor = System.Drawing.Color.Maroon;
            this.group3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.group3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.group3.ForeColor = System.Drawing.Color.Maroon;
            this.group3.Location = new System.Drawing.Point(173, 5);
            this.group3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.group3.Name = "group3";
            this.group3.Size = new System.Drawing.Size(79, 23);
            this.group3.TabIndex = 5;
            this.group3.Text = "button3";
            this.group3.UseVisualStyleBackColor = false;
            this.group3.Visible = false;
            this.group3.Click += new System.EventHandler(this.group3_Click);
            // 
            // group4
            // 
            this.group4.BackColor = System.Drawing.Color.White;
            this.group4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.group4.FlatAppearance.BorderColor = System.Drawing.Color.Maroon;
            this.group4.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.group4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.group4.ForeColor = System.Drawing.Color.Maroon;
            this.group4.Location = new System.Drawing.Point(253, 5);
            this.group4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.group4.Name = "group4";
            this.group4.Size = new System.Drawing.Size(79, 23);
            this.group4.TabIndex = 4;
            this.group4.Text = "group4";
            this.group4.UseVisualStyleBackColor = false;
            this.group4.Visible = false;
            this.group4.Click += new System.EventHandler(this.group4_Click);
            // 
            // group5
            // 
            this.group5.BackColor = System.Drawing.Color.White;
            this.group5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.group5.FlatAppearance.BorderColor = System.Drawing.Color.Maroon;
            this.group5.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.group5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.group5.ForeColor = System.Drawing.Color.Maroon;
            this.group5.Location = new System.Drawing.Point(334, 5);
            this.group5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.group5.Name = "group5";
            this.group5.Size = new System.Drawing.Size(79, 23);
            this.group5.TabIndex = 9;
            this.group5.Text = "group5";
            this.group5.UseVisualStyleBackColor = false;
            this.group5.Visible = false;
            this.group5.Click += new System.EventHandler(this.group5_Click);
            // 
            // group6
            // 
            this.group6.BackColor = System.Drawing.Color.White;
            this.group6.Cursor = System.Windows.Forms.Cursors.Hand;
            this.group6.FlatAppearance.BorderColor = System.Drawing.Color.Maroon;
            this.group6.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.group6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.group6.ForeColor = System.Drawing.Color.Maroon;
            this.group6.Location = new System.Drawing.Point(414, 5);
            this.group6.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.group6.Name = "group6";
            this.group6.Size = new System.Drawing.Size(79, 23);
            this.group6.TabIndex = 8;
            this.group6.Text = "group6";
            this.group6.UseVisualStyleBackColor = false;
            this.group6.Visible = false;
            this.group6.Click += new System.EventHandler(this.group6_Click);
            // 
            // group7
            // 
            this.group7.BackColor = System.Drawing.Color.White;
            this.group7.Cursor = System.Windows.Forms.Cursors.Hand;
            this.group7.FlatAppearance.BorderColor = System.Drawing.Color.Maroon;
            this.group7.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.group7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.group7.ForeColor = System.Drawing.Color.Maroon;
            this.group7.Location = new System.Drawing.Point(495, 5);
            this.group7.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.group7.Name = "group7";
            this.group7.Size = new System.Drawing.Size(79, 23);
            this.group7.TabIndex = 7;
            this.group7.Text = "group7";
            this.group7.UseVisualStyleBackColor = false;
            this.group7.Visible = false;
            this.group7.Click += new System.EventHandler(this.group7_Click);
            // 
            // group8
            // 
            this.group8.BackColor = System.Drawing.Color.White;
            this.group8.Cursor = System.Windows.Forms.Cursors.Hand;
            this.group8.FlatAppearance.BorderColor = System.Drawing.Color.Maroon;
            this.group8.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.group8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.group8.ForeColor = System.Drawing.Color.Maroon;
            this.group8.Location = new System.Drawing.Point(576, 5);
            this.group8.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.group8.Name = "group8";
            this.group8.Size = new System.Drawing.Size(79, 23);
            this.group8.TabIndex = 6;
            this.group8.Text = "group8";
            this.group8.UseVisualStyleBackColor = false;
            this.group8.Visible = false;
            this.group8.Click += new System.EventHandler(this.group8_Click);
            // 
            // group9
            // 
            this.group9.BackColor = System.Drawing.Color.White;
            this.group9.Cursor = System.Windows.Forms.Cursors.Hand;
            this.group9.FlatAppearance.BorderColor = System.Drawing.Color.Maroon;
            this.group9.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.group9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.group9.ForeColor = System.Drawing.Color.Maroon;
            this.group9.Location = new System.Drawing.Point(657, 5);
            this.group9.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.group9.Name = "group9";
            this.group9.Size = new System.Drawing.Size(79, 23);
            this.group9.TabIndex = 11;
            this.group9.Text = "group9";
            this.group9.UseVisualStyleBackColor = false;
            this.group9.Visible = false;
            this.group9.Click += new System.EventHandler(this.group9_Click);
            // 
            // group10
            // 
            this.group10.BackColor = System.Drawing.Color.White;
            this.group10.Cursor = System.Windows.Forms.Cursors.Hand;
            this.group10.FlatAppearance.BorderColor = System.Drawing.Color.Maroon;
            this.group10.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.group10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.group10.ForeColor = System.Drawing.Color.Maroon;
            this.group10.Location = new System.Drawing.Point(738, 5);
            this.group10.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.group10.Name = "group10";
            this.group10.Size = new System.Drawing.Size(79, 23);
            this.group10.TabIndex = 10;
            this.group10.Text = "group10";
            this.group10.UseVisualStyleBackColor = false;
            this.group10.Visible = false;
            this.group10.Click += new System.EventHandler(this.group10_Click);
            // 
            // group11
            // 
            this.group11.BackColor = System.Drawing.Color.White;
            this.group11.Cursor = System.Windows.Forms.Cursors.Hand;
            this.group11.FlatAppearance.BorderColor = System.Drawing.Color.Maroon;
            this.group11.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.group11.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.group11.ForeColor = System.Drawing.Color.Maroon;
            this.group11.Location = new System.Drawing.Point(818, 5);
            this.group11.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.group11.Name = "group11";
            this.group11.Size = new System.Drawing.Size(79, 23);
            this.group11.TabIndex = 16;
            this.group11.Text = "group11";
            this.group11.UseVisualStyleBackColor = false;
            this.group11.Visible = false;
            this.group11.Click += new System.EventHandler(this.group11_Click);
            // 
            // group12
            // 
            this.group12.BackColor = System.Drawing.Color.White;
            this.group12.Cursor = System.Windows.Forms.Cursors.Hand;
            this.group12.FlatAppearance.BorderColor = System.Drawing.Color.Maroon;
            this.group12.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.group12.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.group12.ForeColor = System.Drawing.Color.Maroon;
            this.group12.Location = new System.Drawing.Point(899, 5);
            this.group12.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.group12.Name = "group12";
            this.group12.Size = new System.Drawing.Size(79, 23);
            this.group12.TabIndex = 15;
            this.group12.Text = "group12";
            this.group12.UseVisualStyleBackColor = false;
            this.group12.Visible = false;
            this.group12.Click += new System.EventHandler(this.group12_Click);
            // 
            // group13
            // 
            this.group13.BackColor = System.Drawing.Color.White;
            this.group13.Cursor = System.Windows.Forms.Cursors.Hand;
            this.group13.FlatAppearance.BorderColor = System.Drawing.Color.Maroon;
            this.group13.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.group13.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.group13.ForeColor = System.Drawing.Color.Maroon;
            this.group13.Location = new System.Drawing.Point(979, 5);
            this.group13.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.group13.Name = "group13";
            this.group13.Size = new System.Drawing.Size(79, 23);
            this.group13.TabIndex = 14;
            this.group13.Text = "group13";
            this.group13.UseVisualStyleBackColor = false;
            this.group13.Visible = false;
            this.group13.Click += new System.EventHandler(this.group13_Click);
            // 
            // group14
            // 
            this.group14.BackColor = System.Drawing.Color.White;
            this.group14.Cursor = System.Windows.Forms.Cursors.Hand;
            this.group14.FlatAppearance.BorderColor = System.Drawing.Color.Maroon;
            this.group14.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.group14.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.group14.ForeColor = System.Drawing.Color.Maroon;
            this.group14.Location = new System.Drawing.Point(1060, 5);
            this.group14.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.group14.Name = "group14";
            this.group14.Size = new System.Drawing.Size(79, 23);
            this.group14.TabIndex = 13;
            this.group14.Text = "group14";
            this.group14.UseVisualStyleBackColor = false;
            this.group14.Visible = false;
            this.group14.Click += new System.EventHandler(this.group14_Click);
            // 
            // group15
            // 
            this.group15.BackColor = System.Drawing.Color.White;
            this.group15.Cursor = System.Windows.Forms.Cursors.Hand;
            this.group15.FlatAppearance.BorderColor = System.Drawing.Color.Maroon;
            this.group15.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.group15.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.group15.ForeColor = System.Drawing.Color.Maroon;
            this.group15.Location = new System.Drawing.Point(1141, 5);
            this.group15.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.group15.Name = "group15";
            this.group15.Size = new System.Drawing.Size(79, 23);
            this.group15.TabIndex = 12;
            this.group15.Text = "group15";
            this.group15.UseVisualStyleBackColor = false;
            this.group15.Visible = false;
            this.group15.Click += new System.EventHandler(this.group15_Click);
            // 
            // group16
            // 
            this.group16.BackColor = System.Drawing.Color.White;
            this.group16.Cursor = System.Windows.Forms.Cursors.Hand;
            this.group16.FlatAppearance.BorderColor = System.Drawing.Color.Maroon;
            this.group16.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.group16.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.group16.ForeColor = System.Drawing.Color.Maroon;
            this.group16.Location = new System.Drawing.Point(12, 32);
            this.group16.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.group16.Name = "group16";
            this.group16.Size = new System.Drawing.Size(79, 23);
            this.group16.TabIndex = 31;
            this.group16.Text = "group16";
            this.group16.UseVisualStyleBackColor = false;
            this.group16.Visible = false;
            this.group16.Click += new System.EventHandler(this.group16_Click);
            // 
            // group17
            // 
            this.group17.BackColor = System.Drawing.Color.White;
            this.group17.Cursor = System.Windows.Forms.Cursors.Hand;
            this.group17.FlatAppearance.BorderColor = System.Drawing.Color.Maroon;
            this.group17.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.group17.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.group17.ForeColor = System.Drawing.Color.Maroon;
            this.group17.Location = new System.Drawing.Point(92, 32);
            this.group17.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.group17.Name = "group17";
            this.group17.Size = new System.Drawing.Size(79, 23);
            this.group17.TabIndex = 30;
            this.group17.Text = "group17";
            this.group17.UseVisualStyleBackColor = false;
            this.group17.Visible = false;
            this.group17.Click += new System.EventHandler(this.group17_Click);
            // 
            // group18
            // 
            this.group18.BackColor = System.Drawing.Color.White;
            this.group18.Cursor = System.Windows.Forms.Cursors.Hand;
            this.group18.FlatAppearance.BorderColor = System.Drawing.Color.Maroon;
            this.group18.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.group18.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.group18.ForeColor = System.Drawing.Color.Maroon;
            this.group18.Location = new System.Drawing.Point(173, 32);
            this.group18.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.group18.Name = "group18";
            this.group18.Size = new System.Drawing.Size(79, 23);
            this.group18.TabIndex = 29;
            this.group18.Text = "group18";
            this.group18.UseVisualStyleBackColor = false;
            this.group18.Visible = false;
            this.group18.Click += new System.EventHandler(this.group18_Click);
            // 
            // group19
            // 
            this.group19.BackColor = System.Drawing.Color.White;
            this.group19.Cursor = System.Windows.Forms.Cursors.Hand;
            this.group19.FlatAppearance.BorderColor = System.Drawing.Color.Maroon;
            this.group19.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.group19.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.group19.ForeColor = System.Drawing.Color.Maroon;
            this.group19.Location = new System.Drawing.Point(253, 32);
            this.group19.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.group19.Name = "group19";
            this.group19.Size = new System.Drawing.Size(79, 23);
            this.group19.TabIndex = 28;
            this.group19.Text = "group19";
            this.group19.UseVisualStyleBackColor = false;
            this.group19.Visible = false;
            this.group19.Click += new System.EventHandler(this.group19_Click);
            // 
            // group20
            // 
            this.group20.BackColor = System.Drawing.Color.White;
            this.group20.Cursor = System.Windows.Forms.Cursors.Hand;
            this.group20.FlatAppearance.BorderColor = System.Drawing.Color.Maroon;
            this.group20.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.group20.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.group20.ForeColor = System.Drawing.Color.Maroon;
            this.group20.Location = new System.Drawing.Point(334, 32);
            this.group20.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.group20.Name = "group20";
            this.group20.Size = new System.Drawing.Size(79, 23);
            this.group20.TabIndex = 27;
            this.group20.Text = "group20";
            this.group20.UseVisualStyleBackColor = false;
            this.group20.Visible = false;
            this.group20.Click += new System.EventHandler(this.group20_Click);
            // 
            // group21
            // 
            this.group21.BackColor = System.Drawing.Color.White;
            this.group21.Cursor = System.Windows.Forms.Cursors.Hand;
            this.group21.FlatAppearance.BorderColor = System.Drawing.Color.Maroon;
            this.group21.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.group21.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.group21.ForeColor = System.Drawing.Color.Maroon;
            this.group21.Location = new System.Drawing.Point(414, 32);
            this.group21.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.group21.Name = "group21";
            this.group21.Size = new System.Drawing.Size(79, 23);
            this.group21.TabIndex = 26;
            this.group21.Text = "group21";
            this.group21.UseVisualStyleBackColor = false;
            this.group21.Visible = false;
            this.group21.Click += new System.EventHandler(this.group21_Click);
            // 
            // group22
            // 
            this.group22.BackColor = System.Drawing.Color.White;
            this.group22.Cursor = System.Windows.Forms.Cursors.Hand;
            this.group22.FlatAppearance.BorderColor = System.Drawing.Color.Maroon;
            this.group22.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.group22.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.group22.ForeColor = System.Drawing.Color.Maroon;
            this.group22.Location = new System.Drawing.Point(495, 32);
            this.group22.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.group22.Name = "group22";
            this.group22.Size = new System.Drawing.Size(79, 23);
            this.group22.TabIndex = 25;
            this.group22.Text = "group22";
            this.group22.UseVisualStyleBackColor = false;
            this.group22.Visible = false;
            this.group22.Click += new System.EventHandler(this.group22_Click);
            // 
            // group23
            // 
            this.group23.BackColor = System.Drawing.Color.White;
            this.group23.Cursor = System.Windows.Forms.Cursors.Hand;
            this.group23.FlatAppearance.BorderColor = System.Drawing.Color.Maroon;
            this.group23.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.group23.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.group23.ForeColor = System.Drawing.Color.Maroon;
            this.group23.Location = new System.Drawing.Point(576, 32);
            this.group23.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.group23.Name = "group23";
            this.group23.Size = new System.Drawing.Size(79, 23);
            this.group23.TabIndex = 24;
            this.group23.Text = "group23";
            this.group23.UseVisualStyleBackColor = false;
            this.group23.Visible = false;
            this.group23.Click += new System.EventHandler(this.group23_Click);
            // 
            // group24
            // 
            this.group24.BackColor = System.Drawing.Color.White;
            this.group24.Cursor = System.Windows.Forms.Cursors.Hand;
            this.group24.FlatAppearance.BorderColor = System.Drawing.Color.Maroon;
            this.group24.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.group24.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.group24.ForeColor = System.Drawing.Color.Maroon;
            this.group24.Location = new System.Drawing.Point(657, 32);
            this.group24.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.group24.Name = "group24";
            this.group24.Size = new System.Drawing.Size(79, 23);
            this.group24.TabIndex = 23;
            this.group24.Text = "group24";
            this.group24.UseVisualStyleBackColor = false;
            this.group24.Visible = false;
            this.group24.Click += new System.EventHandler(this.group24_Click);
            // 
            // group25
            // 
            this.group25.BackColor = System.Drawing.Color.White;
            this.group25.Cursor = System.Windows.Forms.Cursors.Hand;
            this.group25.FlatAppearance.BorderColor = System.Drawing.Color.Maroon;
            this.group25.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.group25.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.group25.ForeColor = System.Drawing.Color.Maroon;
            this.group25.Location = new System.Drawing.Point(738, 32);
            this.group25.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.group25.Name = "group25";
            this.group25.Size = new System.Drawing.Size(79, 23);
            this.group25.TabIndex = 22;
            this.group25.Text = "group25";
            this.group25.UseVisualStyleBackColor = false;
            this.group25.Visible = false;
            this.group25.Click += new System.EventHandler(this.group25_Click);
            // 
            // group26
            // 
            this.group26.BackColor = System.Drawing.Color.White;
            this.group26.Cursor = System.Windows.Forms.Cursors.Hand;
            this.group26.FlatAppearance.BorderColor = System.Drawing.Color.Maroon;
            this.group26.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.group26.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.group26.ForeColor = System.Drawing.Color.Maroon;
            this.group26.Location = new System.Drawing.Point(818, 32);
            this.group26.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.group26.Name = "group26";
            this.group26.Size = new System.Drawing.Size(79, 23);
            this.group26.TabIndex = 21;
            this.group26.Text = "group26";
            this.group26.UseVisualStyleBackColor = false;
            this.group26.Visible = false;
            this.group26.Click += new System.EventHandler(this.group26_Click);
            // 
            // group27
            // 
            this.group27.BackColor = System.Drawing.Color.White;
            this.group27.Cursor = System.Windows.Forms.Cursors.Hand;
            this.group27.FlatAppearance.BorderColor = System.Drawing.Color.Maroon;
            this.group27.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.group27.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.group27.ForeColor = System.Drawing.Color.Maroon;
            this.group27.Location = new System.Drawing.Point(899, 32);
            this.group27.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.group27.Name = "group27";
            this.group27.Size = new System.Drawing.Size(79, 23);
            this.group27.TabIndex = 20;
            this.group27.Text = "group27";
            this.group27.UseVisualStyleBackColor = false;
            this.group27.Visible = false;
            this.group27.Click += new System.EventHandler(this.group27_Click);
            // 
            // group28
            // 
            this.group28.BackColor = System.Drawing.Color.White;
            this.group28.Cursor = System.Windows.Forms.Cursors.Hand;
            this.group28.FlatAppearance.BorderColor = System.Drawing.Color.Maroon;
            this.group28.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.group28.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.group28.ForeColor = System.Drawing.Color.Maroon;
            this.group28.Location = new System.Drawing.Point(979, 32);
            this.group28.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.group28.Name = "group28";
            this.group28.Size = new System.Drawing.Size(79, 23);
            this.group28.TabIndex = 19;
            this.group28.Text = "group28";
            this.group28.UseVisualStyleBackColor = false;
            this.group28.Visible = false;
            this.group28.Click += new System.EventHandler(this.group28_Click);
            // 
            // group29
            // 
            this.group29.BackColor = System.Drawing.Color.White;
            this.group29.Cursor = System.Windows.Forms.Cursors.Hand;
            this.group29.FlatAppearance.BorderColor = System.Drawing.Color.Maroon;
            this.group29.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.group29.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.group29.ForeColor = System.Drawing.Color.Maroon;
            this.group29.Location = new System.Drawing.Point(1060, 32);
            this.group29.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.group29.Name = "group29";
            this.group29.Size = new System.Drawing.Size(79, 23);
            this.group29.TabIndex = 18;
            this.group29.Text = "group29";
            this.group29.UseVisualStyleBackColor = false;
            this.group29.Visible = false;
            this.group29.Click += new System.EventHandler(this.group29_Click);
            // 
            // group30
            // 
            this.group30.BackColor = System.Drawing.Color.White;
            this.group30.Cursor = System.Windows.Forms.Cursors.Hand;
            this.group30.FlatAppearance.BorderColor = System.Drawing.Color.Maroon;
            this.group30.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.group30.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.group30.ForeColor = System.Drawing.Color.Maroon;
            this.group30.Location = new System.Drawing.Point(1141, 32);
            this.group30.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.group30.Name = "group30";
            this.group30.Size = new System.Drawing.Size(79, 23);
            this.group30.TabIndex = 17;
            this.group30.Text = "group30";
            this.group30.UseVisualStyleBackColor = false;
            this.group30.Visible = false;
            this.group30.Click += new System.EventHandler(this.group30_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Maroon;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Location = new System.Drawing.Point(-1, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1225, 1);
            this.label1.TabIndex = 32;
            this.label1.Text = "label1";
            // 
            // tab1
            // 
            this.tab1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.tab1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tab1.FlatAppearance.BorderColor = System.Drawing.Color.Maroon;
            this.tab1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.tab1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tab1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tab1.ForeColor = System.Drawing.Color.Black;
            this.tab1.Location = new System.Drawing.Point(11, 94);
            this.tab1.Margin = new System.Windows.Forms.Padding(0);
            this.tab1.Name = "tab1";
            this.tab1.Size = new System.Drawing.Size(60, 39);
            this.tab1.TabIndex = 33;
            this.tab1.Text = "1";
            this.tab1.UseVisualStyleBackColor = false;
            this.tab1.Click += new System.EventHandler(this.tab1_Click);
            this.tab1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.tab1_MouseMove);
            // 
            // nest
            // 
            this.nest.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nest.Location = new System.Drawing.Point(1014, 92);
            this.nest.Name = "nest";
            this.nest.Size = new System.Drawing.Size(61, 23);
            this.nest.TabIndex = 34;
            this.nest.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(1099, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 23);
            this.label3.TabIndex = 37;
            this.label3.Text = "Bill N#";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // bill
            // 
            this.bill.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.bill.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bill.Location = new System.Drawing.Point(1102, 96);
            this.bill.Name = "bill";
            this.bill.Size = new System.Drawing.Size(55, 20);
            this.bill.TabIndex = 36;
            this.bill.Text = "bill";
            this.bill.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // command
            // 
            this.command.Location = new System.Drawing.Point(1085, 437);
            this.command.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.command.Name = "command";
            this.command.Size = new System.Drawing.Size(75, 23);
            this.command.TabIndex = 38;
            this.command.Tag = "none";
            this.command.Text = "command";
            this.command.UseVisualStyleBackColor = true;
            this.command.Click += new System.EventHandler(this.command_Click);
            // 
            // tab2
            // 
            this.tab2.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.tab2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tab2.FlatAppearance.BorderColor = System.Drawing.Color.Maroon;
            this.tab2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.tab2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tab2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tab2.ForeColor = System.Drawing.Color.Black;
            this.tab2.Location = new System.Drawing.Point(72, 94);
            this.tab2.Margin = new System.Windows.Forms.Padding(0);
            this.tab2.Name = "tab2";
            this.tab2.Size = new System.Drawing.Size(60, 39);
            this.tab2.TabIndex = 39;
            this.tab2.Text = "2";
            this.tab2.UseVisualStyleBackColor = false;
            this.tab2.Click += new System.EventHandler(this.tab2_Click);
            this.tab2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.tab2_MouseMove);
            // 
            // tab3
            // 
            this.tab3.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.tab3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tab3.FlatAppearance.BorderColor = System.Drawing.Color.Maroon;
            this.tab3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.tab3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tab3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tab3.ForeColor = System.Drawing.Color.Black;
            this.tab3.Location = new System.Drawing.Point(133, 94);
            this.tab3.Margin = new System.Windows.Forms.Padding(0);
            this.tab3.Name = "tab3";
            this.tab3.Size = new System.Drawing.Size(60, 39);
            this.tab3.TabIndex = 40;
            this.tab3.Text = "3";
            this.tab3.UseVisualStyleBackColor = false;
            this.tab3.Click += new System.EventHandler(this.tab3_Click);
            this.tab3.MouseMove += new System.Windows.Forms.MouseEventHandler(this.tab3_MouseMove);
            // 
            // tab4
            // 
            this.tab4.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.tab4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tab4.FlatAppearance.BorderColor = System.Drawing.Color.Maroon;
            this.tab4.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.tab4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tab4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tab4.ForeColor = System.Drawing.Color.Black;
            this.tab4.Location = new System.Drawing.Point(195, 94);
            this.tab4.Margin = new System.Windows.Forms.Padding(0);
            this.tab4.Name = "tab4";
            this.tab4.Size = new System.Drawing.Size(60, 39);
            this.tab4.TabIndex = 41;
            this.tab4.Text = "4";
            this.tab4.UseVisualStyleBackColor = false;
            this.tab4.Click += new System.EventHandler(this.tab4_Click);
            this.tab4.MouseMove += new System.Windows.Forms.MouseEventHandler(this.tab4_MouseMove);
            // 
            // tab5
            // 
            this.tab5.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.tab5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tab5.FlatAppearance.BorderColor = System.Drawing.Color.Maroon;
            this.tab5.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.tab5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tab5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tab5.ForeColor = System.Drawing.Color.Black;
            this.tab5.Location = new System.Drawing.Point(256, 94);
            this.tab5.Margin = new System.Windows.Forms.Padding(0);
            this.tab5.Name = "tab5";
            this.tab5.Size = new System.Drawing.Size(60, 39);
            this.tab5.TabIndex = 42;
            this.tab5.Text = "5";
            this.tab5.UseVisualStyleBackColor = false;
            this.tab5.Click += new System.EventHandler(this.tab5_Click);
            this.tab5.MouseMove += new System.Windows.Forms.MouseEventHandler(this.tab5_MouseMove);
            // 
            // ManagerBox
            // 
            this.ManagerBox.Location = new System.Drawing.Point(790, 67);
            this.ManagerBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ManagerBox.Name = "ManagerBox";
            this.ManagerBox.PasswordChar = '+';
            this.ManagerBox.Size = new System.Drawing.Size(193, 22);
            this.ManagerBox.TabIndex = 43;
            this.ManagerBox.Text = "manager";
            this.ManagerBox.Enter += new System.EventHandler(this.ManagerBox_Enter);
            this.ManagerBox.Leave += new System.EventHandler(this.ManagerBox_Leave);
            // 
            // department1
            // 
            this.department1.BackColor = System.Drawing.Color.White;
            this.department1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.department1.FlatAppearance.BorderColor = System.Drawing.Color.Maroon;
            this.department1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.department1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.department1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.department1.ForeColor = System.Drawing.Color.Maroon;
            this.department1.Location = new System.Drawing.Point(16, 62);
            this.department1.Margin = new System.Windows.Forms.Padding(0);
            this.department1.Name = "department1";
            this.department1.Size = new System.Drawing.Size(82, 25);
            this.department1.TabIndex = 44;
            this.department1.Text = "dep1";
            this.department1.UseVisualStyleBackColor = false;
            this.department1.Visible = false;
            this.department1.Click += new System.EventHandler(this.department1_Click);
            // 
            // department2
            // 
            this.department2.BackColor = System.Drawing.Color.White;
            this.department2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.department2.FlatAppearance.BorderColor = System.Drawing.Color.Maroon;
            this.department2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.department2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.department2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.department2.ForeColor = System.Drawing.Color.Maroon;
            this.department2.Location = new System.Drawing.Point(101, 62);
            this.department2.Margin = new System.Windows.Forms.Padding(0);
            this.department2.Name = "department2";
            this.department2.Size = new System.Drawing.Size(82, 25);
            this.department2.TabIndex = 45;
            this.department2.Text = "dep2";
            this.department2.UseVisualStyleBackColor = false;
            this.department2.Visible = false;
            this.department2.Click += new System.EventHandler(this.department2_Click);
            // 
            // department3
            // 
            this.department3.BackColor = System.Drawing.Color.White;
            this.department3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.department3.FlatAppearance.BorderColor = System.Drawing.Color.Maroon;
            this.department3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.department3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.department3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.department3.ForeColor = System.Drawing.Color.Maroon;
            this.department3.Location = new System.Drawing.Point(185, 62);
            this.department3.Margin = new System.Windows.Forms.Padding(0);
            this.department3.Name = "department3";
            this.department3.Size = new System.Drawing.Size(82, 25);
            this.department3.TabIndex = 46;
            this.department3.Text = "dep3";
            this.department3.UseVisualStyleBackColor = false;
            this.department3.Visible = false;
            this.department3.Click += new System.EventHandler(this.department3_Click);
            // 
            // department4
            // 
            this.department4.BackColor = System.Drawing.Color.White;
            this.department4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.department4.FlatAppearance.BorderColor = System.Drawing.Color.Maroon;
            this.department4.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.department4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.department4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.department4.ForeColor = System.Drawing.Color.Maroon;
            this.department4.Location = new System.Drawing.Point(269, 62);
            this.department4.Margin = new System.Windows.Forms.Padding(0);
            this.department4.Name = "department4";
            this.department4.Size = new System.Drawing.Size(82, 25);
            this.department4.TabIndex = 47;
            this.department4.Text = "dep4";
            this.department4.UseVisualStyleBackColor = false;
            this.department4.Visible = false;
            this.department4.Click += new System.EventHandler(this.department4_Click);
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Maroon;
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label4.Location = new System.Drawing.Point(-4, 89);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(443, 1);
            this.label4.TabIndex = 48;
            this.label4.Text = "label4";
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Maroon;
            this.label5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label5.Location = new System.Drawing.Point(440, 62);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(1, 436);
            this.label5.TabIndex = 49;
            this.label5.Text = "label5";
            // 
            // tab7
            // 
            this.tab7.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.tab7.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tab7.FlatAppearance.BorderColor = System.Drawing.Color.Maroon;
            this.tab7.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.tab7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tab7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tab7.ForeColor = System.Drawing.Color.Black;
            this.tab7.Location = new System.Drawing.Point(379, 94);
            this.tab7.Margin = new System.Windows.Forms.Padding(0);
            this.tab7.Name = "tab7";
            this.tab7.Size = new System.Drawing.Size(60, 39);
            this.tab7.TabIndex = 51;
            this.tab7.Text = "7";
            this.tab7.UseVisualStyleBackColor = false;
            this.tab7.Click += new System.EventHandler(this.tab7_Click);
            this.tab7.MouseMove += new System.Windows.Forms.MouseEventHandler(this.tab7_MouseMove);
            // 
            // tab6
            // 
            this.tab6.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.tab6.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tab6.FlatAppearance.BorderColor = System.Drawing.Color.Maroon;
            this.tab6.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.tab6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tab6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tab6.ForeColor = System.Drawing.Color.Black;
            this.tab6.Location = new System.Drawing.Point(317, 94);
            this.tab6.Margin = new System.Windows.Forms.Padding(0);
            this.tab6.Name = "tab6";
            this.tab6.Size = new System.Drawing.Size(60, 39);
            this.tab6.TabIndex = 50;
            this.tab6.Text = "6";
            this.tab6.UseVisualStyleBackColor = false;
            this.tab6.Click += new System.EventHandler(this.tab6_Click);
            this.tab6.MouseMove += new System.Windows.Forms.MouseEventHandler(this.tab6_MouseMove);
            // 
            // tab14
            // 
            this.tab14.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.tab14.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tab14.FlatAppearance.BorderColor = System.Drawing.Color.Maroon;
            this.tab14.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.tab14.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tab14.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tab14.ForeColor = System.Drawing.Color.Black;
            this.tab14.Location = new System.Drawing.Point(379, 134);
            this.tab14.Margin = new System.Windows.Forms.Padding(0);
            this.tab14.Name = "tab14";
            this.tab14.Size = new System.Drawing.Size(60, 39);
            this.tab14.TabIndex = 61;
            this.tab14.Text = "14";
            this.tab14.UseVisualStyleBackColor = false;
            this.tab14.Click += new System.EventHandler(this.tab14_Click);
            this.tab14.MouseMove += new System.Windows.Forms.MouseEventHandler(this.tab14_MouseMove);
            // 
            // tab13
            // 
            this.tab13.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.tab13.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tab13.FlatAppearance.BorderColor = System.Drawing.Color.Maroon;
            this.tab13.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.tab13.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tab13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tab13.ForeColor = System.Drawing.Color.Black;
            this.tab13.Location = new System.Drawing.Point(317, 134);
            this.tab13.Margin = new System.Windows.Forms.Padding(0);
            this.tab13.Name = "tab13";
            this.tab13.Size = new System.Drawing.Size(60, 39);
            this.tab13.TabIndex = 60;
            this.tab13.Text = "13";
            this.tab13.UseVisualStyleBackColor = false;
            this.tab13.Click += new System.EventHandler(this.tab13_Click);
            this.tab13.MouseMove += new System.Windows.Forms.MouseEventHandler(this.tab13_MouseMove);
            // 
            // tab12
            // 
            this.tab12.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.tab12.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tab12.FlatAppearance.BorderColor = System.Drawing.Color.Maroon;
            this.tab12.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.tab12.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tab12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tab12.ForeColor = System.Drawing.Color.Black;
            this.tab12.Location = new System.Drawing.Point(256, 134);
            this.tab12.Margin = new System.Windows.Forms.Padding(0);
            this.tab12.Name = "tab12";
            this.tab12.Size = new System.Drawing.Size(60, 39);
            this.tab12.TabIndex = 59;
            this.tab12.Text = "12";
            this.tab12.UseVisualStyleBackColor = false;
            this.tab12.Click += new System.EventHandler(this.tab12_Click);
            this.tab12.MouseMove += new System.Windows.Forms.MouseEventHandler(this.tab12_MouseMove);
            // 
            // tab11
            // 
            this.tab11.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.tab11.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tab11.FlatAppearance.BorderColor = System.Drawing.Color.Maroon;
            this.tab11.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.tab11.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tab11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tab11.ForeColor = System.Drawing.Color.Black;
            this.tab11.Location = new System.Drawing.Point(195, 134);
            this.tab11.Margin = new System.Windows.Forms.Padding(0);
            this.tab11.Name = "tab11";
            this.tab11.Size = new System.Drawing.Size(60, 39);
            this.tab11.TabIndex = 58;
            this.tab11.Text = "11";
            this.tab11.UseVisualStyleBackColor = false;
            this.tab11.Click += new System.EventHandler(this.tab11_Click);
            this.tab11.MouseMove += new System.Windows.Forms.MouseEventHandler(this.tab11_MouseMove);
            // 
            // tab10
            // 
            this.tab10.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.tab10.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tab10.FlatAppearance.BorderColor = System.Drawing.Color.Maroon;
            this.tab10.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.tab10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tab10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tab10.ForeColor = System.Drawing.Color.Black;
            this.tab10.Location = new System.Drawing.Point(133, 134);
            this.tab10.Margin = new System.Windows.Forms.Padding(0);
            this.tab10.Name = "tab10";
            this.tab10.Size = new System.Drawing.Size(60, 39);
            this.tab10.TabIndex = 57;
            this.tab10.Text = "10";
            this.tab10.UseVisualStyleBackColor = false;
            this.tab10.Click += new System.EventHandler(this.tab10_Click);
            this.tab10.MouseMove += new System.Windows.Forms.MouseEventHandler(this.tab10_MouseMove);
            // 
            // tab9
            // 
            this.tab9.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.tab9.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tab9.FlatAppearance.BorderColor = System.Drawing.Color.Maroon;
            this.tab9.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.tab9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tab9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tab9.ForeColor = System.Drawing.Color.Black;
            this.tab9.Location = new System.Drawing.Point(72, 134);
            this.tab9.Margin = new System.Windows.Forms.Padding(0);
            this.tab9.Name = "tab9";
            this.tab9.Size = new System.Drawing.Size(60, 39);
            this.tab9.TabIndex = 56;
            this.tab9.Text = "9";
            this.tab9.UseVisualStyleBackColor = false;
            this.tab9.Click += new System.EventHandler(this.tab9_Click);
            this.tab9.MouseMove += new System.Windows.Forms.MouseEventHandler(this.tab9_MouseMove);
            // 
            // tab8
            // 
            this.tab8.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.tab8.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tab8.FlatAppearance.BorderColor = System.Drawing.Color.Maroon;
            this.tab8.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.tab8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tab8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tab8.ForeColor = System.Drawing.Color.Black;
            this.tab8.Location = new System.Drawing.Point(11, 134);
            this.tab8.Margin = new System.Windows.Forms.Padding(0);
            this.tab8.Name = "tab8";
            this.tab8.Size = new System.Drawing.Size(60, 39);
            this.tab8.TabIndex = 55;
            this.tab8.Text = "8";
            this.tab8.UseVisualStyleBackColor = false;
            this.tab8.Click += new System.EventHandler(this.tab8_Click);
            this.tab8.MouseMove += new System.Windows.Forms.MouseEventHandler(this.tab8_MouseMove);
            // 
            // tab21
            // 
            this.tab21.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.tab21.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tab21.FlatAppearance.BorderColor = System.Drawing.Color.Maroon;
            this.tab21.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.tab21.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tab21.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tab21.ForeColor = System.Drawing.Color.Black;
            this.tab21.Location = new System.Drawing.Point(379, 175);
            this.tab21.Margin = new System.Windows.Forms.Padding(0);
            this.tab21.Name = "tab21";
            this.tab21.Size = new System.Drawing.Size(60, 39);
            this.tab21.TabIndex = 68;
            this.tab21.Text = "21";
            this.tab21.UseVisualStyleBackColor = false;
            this.tab21.Click += new System.EventHandler(this.tab21_Click);
            this.tab21.MouseMove += new System.Windows.Forms.MouseEventHandler(this.tab21_MouseMove);
            // 
            // tab20
            // 
            this.tab20.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.tab20.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tab20.FlatAppearance.BorderColor = System.Drawing.Color.Maroon;
            this.tab20.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.tab20.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tab20.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tab20.ForeColor = System.Drawing.Color.Black;
            this.tab20.Location = new System.Drawing.Point(317, 175);
            this.tab20.Margin = new System.Windows.Forms.Padding(0);
            this.tab20.Name = "tab20";
            this.tab20.Size = new System.Drawing.Size(60, 39);
            this.tab20.TabIndex = 67;
            this.tab20.Text = "20";
            this.tab20.UseVisualStyleBackColor = false;
            this.tab20.Click += new System.EventHandler(this.tab20_Click);
            this.tab20.MouseMove += new System.Windows.Forms.MouseEventHandler(this.tab20_MouseMove);
            // 
            // tab19
            // 
            this.tab19.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.tab19.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tab19.FlatAppearance.BorderColor = System.Drawing.Color.Maroon;
            this.tab19.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.tab19.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tab19.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tab19.ForeColor = System.Drawing.Color.Black;
            this.tab19.Location = new System.Drawing.Point(256, 175);
            this.tab19.Margin = new System.Windows.Forms.Padding(0);
            this.tab19.Name = "tab19";
            this.tab19.Size = new System.Drawing.Size(60, 39);
            this.tab19.TabIndex = 66;
            this.tab19.Text = "19";
            this.tab19.UseVisualStyleBackColor = false;
            this.tab19.Click += new System.EventHandler(this.tab19_Click);
            this.tab19.MouseMove += new System.Windows.Forms.MouseEventHandler(this.tab19_MouseMove);
            // 
            // tab18
            // 
            this.tab18.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.tab18.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tab18.FlatAppearance.BorderColor = System.Drawing.Color.Maroon;
            this.tab18.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.tab18.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tab18.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tab18.ForeColor = System.Drawing.Color.Black;
            this.tab18.Location = new System.Drawing.Point(195, 175);
            this.tab18.Margin = new System.Windows.Forms.Padding(0);
            this.tab18.Name = "tab18";
            this.tab18.Size = new System.Drawing.Size(60, 39);
            this.tab18.TabIndex = 65;
            this.tab18.Text = "18";
            this.tab18.UseVisualStyleBackColor = false;
            this.tab18.Click += new System.EventHandler(this.tab18_Click);
            this.tab18.MouseMove += new System.Windows.Forms.MouseEventHandler(this.tab18_MouseMove);
            // 
            // tab17
            // 
            this.tab17.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.tab17.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tab17.FlatAppearance.BorderColor = System.Drawing.Color.Maroon;
            this.tab17.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.tab17.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tab17.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tab17.ForeColor = System.Drawing.Color.Black;
            this.tab17.Location = new System.Drawing.Point(133, 175);
            this.tab17.Margin = new System.Windows.Forms.Padding(0);
            this.tab17.Name = "tab17";
            this.tab17.Size = new System.Drawing.Size(60, 39);
            this.tab17.TabIndex = 64;
            this.tab17.Text = "17";
            this.tab17.UseVisualStyleBackColor = false;
            this.tab17.Click += new System.EventHandler(this.tab17_Click);
            this.tab17.MouseMove += new System.Windows.Forms.MouseEventHandler(this.tab17_MouseMove);
            // 
            // tab16
            // 
            this.tab16.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.tab16.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tab16.FlatAppearance.BorderColor = System.Drawing.Color.Maroon;
            this.tab16.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.tab16.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tab16.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tab16.ForeColor = System.Drawing.Color.Black;
            this.tab16.Location = new System.Drawing.Point(72, 175);
            this.tab16.Margin = new System.Windows.Forms.Padding(0);
            this.tab16.Name = "tab16";
            this.tab16.Size = new System.Drawing.Size(60, 39);
            this.tab16.TabIndex = 63;
            this.tab16.Text = "16";
            this.tab16.UseVisualStyleBackColor = false;
            this.tab16.Click += new System.EventHandler(this.tab16_Click);
            this.tab16.MouseMove += new System.Windows.Forms.MouseEventHandler(this.tab16_MouseMove);
            // 
            // tab15
            // 
            this.tab15.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.tab15.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tab15.FlatAppearance.BorderColor = System.Drawing.Color.Maroon;
            this.tab15.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.tab15.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tab15.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tab15.ForeColor = System.Drawing.Color.Black;
            this.tab15.Location = new System.Drawing.Point(11, 175);
            this.tab15.Margin = new System.Windows.Forms.Padding(0);
            this.tab15.Name = "tab15";
            this.tab15.Size = new System.Drawing.Size(60, 39);
            this.tab15.TabIndex = 62;
            this.tab15.Text = "15";
            this.tab15.UseVisualStyleBackColor = false;
            this.tab15.Click += new System.EventHandler(this.tab15_Click);
            this.tab15.MouseMove += new System.Windows.Forms.MouseEventHandler(this.tab15_MouseMove);
            // 
            // tab28
            // 
            this.tab28.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.tab28.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tab28.FlatAppearance.BorderColor = System.Drawing.Color.Maroon;
            this.tab28.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.tab28.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tab28.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tab28.ForeColor = System.Drawing.Color.Black;
            this.tab28.Location = new System.Drawing.Point(379, 215);
            this.tab28.Margin = new System.Windows.Forms.Padding(0);
            this.tab28.Name = "tab28";
            this.tab28.Size = new System.Drawing.Size(60, 39);
            this.tab28.TabIndex = 75;
            this.tab28.Text = "28";
            this.tab28.UseVisualStyleBackColor = false;
            this.tab28.Click += new System.EventHandler(this.tab28_Click);
            this.tab28.MouseMove += new System.Windows.Forms.MouseEventHandler(this.tab28_MouseMove);
            // 
            // tab27
            // 
            this.tab27.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.tab27.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tab27.FlatAppearance.BorderColor = System.Drawing.Color.Maroon;
            this.tab27.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.tab27.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tab27.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tab27.ForeColor = System.Drawing.Color.Black;
            this.tab27.Location = new System.Drawing.Point(317, 215);
            this.tab27.Margin = new System.Windows.Forms.Padding(0);
            this.tab27.Name = "tab27";
            this.tab27.Size = new System.Drawing.Size(60, 39);
            this.tab27.TabIndex = 74;
            this.tab27.Text = "27";
            this.tab27.UseVisualStyleBackColor = false;
            this.tab27.Click += new System.EventHandler(this.tab27_Click);
            this.tab27.MouseMove += new System.Windows.Forms.MouseEventHandler(this.tab27_MouseMove);
            // 
            // tab26
            // 
            this.tab26.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.tab26.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tab26.FlatAppearance.BorderColor = System.Drawing.Color.Maroon;
            this.tab26.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.tab26.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tab26.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tab26.ForeColor = System.Drawing.Color.Black;
            this.tab26.Location = new System.Drawing.Point(256, 215);
            this.tab26.Margin = new System.Windows.Forms.Padding(0);
            this.tab26.Name = "tab26";
            this.tab26.Size = new System.Drawing.Size(60, 39);
            this.tab26.TabIndex = 73;
            this.tab26.Text = "26";
            this.tab26.UseVisualStyleBackColor = false;
            this.tab26.Click += new System.EventHandler(this.tab26_Click);
            this.tab26.MouseMove += new System.Windows.Forms.MouseEventHandler(this.tab26_MouseMove);
            // 
            // tab25
            // 
            this.tab25.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.tab25.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tab25.FlatAppearance.BorderColor = System.Drawing.Color.Maroon;
            this.tab25.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.tab25.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tab25.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tab25.ForeColor = System.Drawing.Color.Black;
            this.tab25.Location = new System.Drawing.Point(195, 215);
            this.tab25.Margin = new System.Windows.Forms.Padding(0);
            this.tab25.Name = "tab25";
            this.tab25.Size = new System.Drawing.Size(60, 39);
            this.tab25.TabIndex = 72;
            this.tab25.Text = "25";
            this.tab25.UseVisualStyleBackColor = false;
            this.tab25.Click += new System.EventHandler(this.tab25_Click);
            this.tab25.MouseMove += new System.Windows.Forms.MouseEventHandler(this.tab25_MouseMove);
            // 
            // tab24
            // 
            this.tab24.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.tab24.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tab24.FlatAppearance.BorderColor = System.Drawing.Color.Maroon;
            this.tab24.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.tab24.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tab24.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tab24.ForeColor = System.Drawing.Color.Black;
            this.tab24.Location = new System.Drawing.Point(133, 215);
            this.tab24.Margin = new System.Windows.Forms.Padding(0);
            this.tab24.Name = "tab24";
            this.tab24.Size = new System.Drawing.Size(60, 39);
            this.tab24.TabIndex = 71;
            this.tab24.Text = "24";
            this.tab24.UseVisualStyleBackColor = false;
            this.tab24.Click += new System.EventHandler(this.tab24_Click);
            this.tab24.MouseMove += new System.Windows.Forms.MouseEventHandler(this.tab24_MouseMove);
            // 
            // tab23
            // 
            this.tab23.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.tab23.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tab23.FlatAppearance.BorderColor = System.Drawing.Color.Maroon;
            this.tab23.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.tab23.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tab23.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tab23.ForeColor = System.Drawing.Color.Black;
            this.tab23.Location = new System.Drawing.Point(72, 215);
            this.tab23.Margin = new System.Windows.Forms.Padding(0);
            this.tab23.Name = "tab23";
            this.tab23.Size = new System.Drawing.Size(60, 39);
            this.tab23.TabIndex = 70;
            this.tab23.Text = "23";
            this.tab23.UseVisualStyleBackColor = false;
            this.tab23.Click += new System.EventHandler(this.tab23_Click);
            this.tab23.MouseMove += new System.Windows.Forms.MouseEventHandler(this.tab23_MouseMove);
            // 
            // tab22
            // 
            this.tab22.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.tab22.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tab22.FlatAppearance.BorderColor = System.Drawing.Color.Maroon;
            this.tab22.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.tab22.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tab22.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tab22.ForeColor = System.Drawing.Color.Black;
            this.tab22.Location = new System.Drawing.Point(11, 215);
            this.tab22.Margin = new System.Windows.Forms.Padding(0);
            this.tab22.Name = "tab22";
            this.tab22.Size = new System.Drawing.Size(60, 39);
            this.tab22.TabIndex = 69;
            this.tab22.Text = "22";
            this.tab22.UseVisualStyleBackColor = false;
            this.tab22.Click += new System.EventHandler(this.tab22_Click);
            this.tab22.MouseMove += new System.Windows.Forms.MouseEventHandler(this.tab22_MouseMove);
            // 
            // tab35
            // 
            this.tab35.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.tab35.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tab35.FlatAppearance.BorderColor = System.Drawing.Color.Maroon;
            this.tab35.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.tab35.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tab35.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tab35.ForeColor = System.Drawing.Color.Black;
            this.tab35.Location = new System.Drawing.Point(379, 256);
            this.tab35.Margin = new System.Windows.Forms.Padding(0);
            this.tab35.Name = "tab35";
            this.tab35.Size = new System.Drawing.Size(60, 39);
            this.tab35.TabIndex = 82;
            this.tab35.Text = "35";
            this.tab35.UseVisualStyleBackColor = false;
            this.tab35.Click += new System.EventHandler(this.tab35_Click);
            this.tab35.MouseMove += new System.Windows.Forms.MouseEventHandler(this.tab35_MouseMove);
            // 
            // tab34
            // 
            this.tab34.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.tab34.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tab34.FlatAppearance.BorderColor = System.Drawing.Color.Maroon;
            this.tab34.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.tab34.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tab34.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tab34.ForeColor = System.Drawing.Color.Black;
            this.tab34.Location = new System.Drawing.Point(317, 256);
            this.tab34.Margin = new System.Windows.Forms.Padding(0);
            this.tab34.Name = "tab34";
            this.tab34.Size = new System.Drawing.Size(60, 39);
            this.tab34.TabIndex = 81;
            this.tab34.Text = "34";
            this.tab34.UseVisualStyleBackColor = false;
            this.tab34.Click += new System.EventHandler(this.tab34_Click);
            this.tab34.MouseMove += new System.Windows.Forms.MouseEventHandler(this.tab34_MouseMove);
            // 
            // tab33
            // 
            this.tab33.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.tab33.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tab33.FlatAppearance.BorderColor = System.Drawing.Color.Maroon;
            this.tab33.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.tab33.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tab33.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tab33.ForeColor = System.Drawing.Color.Black;
            this.tab33.Location = new System.Drawing.Point(256, 256);
            this.tab33.Margin = new System.Windows.Forms.Padding(0);
            this.tab33.Name = "tab33";
            this.tab33.Size = new System.Drawing.Size(60, 39);
            this.tab33.TabIndex = 80;
            this.tab33.Text = "33";
            this.tab33.UseVisualStyleBackColor = false;
            this.tab33.Click += new System.EventHandler(this.tab33_Click);
            this.tab33.MouseMove += new System.Windows.Forms.MouseEventHandler(this.tab33_MouseMove);
            // 
            // tab32
            // 
            this.tab32.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.tab32.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tab32.FlatAppearance.BorderColor = System.Drawing.Color.Maroon;
            this.tab32.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.tab32.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tab32.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tab32.ForeColor = System.Drawing.Color.Black;
            this.tab32.Location = new System.Drawing.Point(195, 256);
            this.tab32.Margin = new System.Windows.Forms.Padding(0);
            this.tab32.Name = "tab32";
            this.tab32.Size = new System.Drawing.Size(60, 39);
            this.tab32.TabIndex = 79;
            this.tab32.Text = "32";
            this.tab32.UseVisualStyleBackColor = false;
            this.tab32.Click += new System.EventHandler(this.tab32_Click);
            this.tab32.MouseMove += new System.Windows.Forms.MouseEventHandler(this.tab32_MouseMove);
            // 
            // tab31
            // 
            this.tab31.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.tab31.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tab31.FlatAppearance.BorderColor = System.Drawing.Color.Maroon;
            this.tab31.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.tab31.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tab31.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tab31.ForeColor = System.Drawing.Color.Black;
            this.tab31.Location = new System.Drawing.Point(133, 256);
            this.tab31.Margin = new System.Windows.Forms.Padding(0);
            this.tab31.Name = "tab31";
            this.tab31.Size = new System.Drawing.Size(60, 39);
            this.tab31.TabIndex = 78;
            this.tab31.Text = "31";
            this.tab31.UseVisualStyleBackColor = false;
            this.tab31.Click += new System.EventHandler(this.tab31_Click);
            this.tab31.MouseMove += new System.Windows.Forms.MouseEventHandler(this.tab31_MouseMove);
            // 
            // tab30
            // 
            this.tab30.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.tab30.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tab30.FlatAppearance.BorderColor = System.Drawing.Color.Maroon;
            this.tab30.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.tab30.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tab30.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tab30.ForeColor = System.Drawing.Color.Black;
            this.tab30.Location = new System.Drawing.Point(72, 256);
            this.tab30.Margin = new System.Windows.Forms.Padding(0);
            this.tab30.Name = "tab30";
            this.tab30.Size = new System.Drawing.Size(60, 39);
            this.tab30.TabIndex = 77;
            this.tab30.Text = "30";
            this.tab30.UseVisualStyleBackColor = false;
            this.tab30.Click += new System.EventHandler(this.tab30_Click);
            this.tab30.MouseMove += new System.Windows.Forms.MouseEventHandler(this.tab30_MouseMove);
            // 
            // tab29
            // 
            this.tab29.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.tab29.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tab29.FlatAppearance.BorderColor = System.Drawing.Color.Maroon;
            this.tab29.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.tab29.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tab29.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tab29.ForeColor = System.Drawing.Color.Black;
            this.tab29.Location = new System.Drawing.Point(11, 256);
            this.tab29.Margin = new System.Windows.Forms.Padding(0);
            this.tab29.Name = "tab29";
            this.tab29.Size = new System.Drawing.Size(60, 39);
            this.tab29.TabIndex = 76;
            this.tab29.Text = "29";
            this.tab29.UseVisualStyleBackColor = false;
            this.tab29.Click += new System.EventHandler(this.tab29_Click);
            this.tab29.MouseMove += new System.Windows.Forms.MouseEventHandler(this.tab29_MouseMove);
            // 
            // tab42
            // 
            this.tab42.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.tab42.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tab42.FlatAppearance.BorderColor = System.Drawing.Color.Maroon;
            this.tab42.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.tab42.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tab42.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tab42.ForeColor = System.Drawing.Color.Black;
            this.tab42.Location = new System.Drawing.Point(379, 297);
            this.tab42.Margin = new System.Windows.Forms.Padding(0);
            this.tab42.Name = "tab42";
            this.tab42.Size = new System.Drawing.Size(60, 39);
            this.tab42.TabIndex = 89;
            this.tab42.Text = "42";
            this.tab42.UseVisualStyleBackColor = false;
            this.tab42.Click += new System.EventHandler(this.tab42_Click);
            this.tab42.MouseMove += new System.Windows.Forms.MouseEventHandler(this.tab42_MouseMove);
            // 
            // tab41
            // 
            this.tab41.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.tab41.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tab41.FlatAppearance.BorderColor = System.Drawing.Color.Maroon;
            this.tab41.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.tab41.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tab41.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tab41.ForeColor = System.Drawing.Color.Black;
            this.tab41.Location = new System.Drawing.Point(317, 297);
            this.tab41.Margin = new System.Windows.Forms.Padding(0);
            this.tab41.Name = "tab41";
            this.tab41.Size = new System.Drawing.Size(60, 39);
            this.tab41.TabIndex = 88;
            this.tab41.Text = "41";
            this.tab41.UseVisualStyleBackColor = false;
            this.tab41.Click += new System.EventHandler(this.tab41_Click);
            this.tab41.MouseMove += new System.Windows.Forms.MouseEventHandler(this.tab41_MouseMove);
            // 
            // tab40
            // 
            this.tab40.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.tab40.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tab40.FlatAppearance.BorderColor = System.Drawing.Color.Maroon;
            this.tab40.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.tab40.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tab40.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tab40.ForeColor = System.Drawing.Color.Black;
            this.tab40.Location = new System.Drawing.Point(256, 297);
            this.tab40.Margin = new System.Windows.Forms.Padding(0);
            this.tab40.Name = "tab40";
            this.tab40.Size = new System.Drawing.Size(60, 39);
            this.tab40.TabIndex = 87;
            this.tab40.Text = "40";
            this.tab40.UseVisualStyleBackColor = false;
            this.tab40.Click += new System.EventHandler(this.tab40_Click);
            this.tab40.MouseMove += new System.Windows.Forms.MouseEventHandler(this.tab40_MouseMove);
            // 
            // tab39
            // 
            this.tab39.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.tab39.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tab39.FlatAppearance.BorderColor = System.Drawing.Color.Maroon;
            this.tab39.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.tab39.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tab39.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tab39.ForeColor = System.Drawing.Color.Black;
            this.tab39.Location = new System.Drawing.Point(195, 297);
            this.tab39.Margin = new System.Windows.Forms.Padding(0);
            this.tab39.Name = "tab39";
            this.tab39.Size = new System.Drawing.Size(60, 39);
            this.tab39.TabIndex = 86;
            this.tab39.Text = "39";
            this.tab39.UseVisualStyleBackColor = false;
            this.tab39.Click += new System.EventHandler(this.tab39_Click);
            this.tab39.MouseMove += new System.Windows.Forms.MouseEventHandler(this.tab39_MouseMove);
            // 
            // tab38
            // 
            this.tab38.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.tab38.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tab38.FlatAppearance.BorderColor = System.Drawing.Color.Maroon;
            this.tab38.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.tab38.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tab38.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tab38.ForeColor = System.Drawing.Color.Black;
            this.tab38.Location = new System.Drawing.Point(133, 297);
            this.tab38.Margin = new System.Windows.Forms.Padding(0);
            this.tab38.Name = "tab38";
            this.tab38.Size = new System.Drawing.Size(60, 39);
            this.tab38.TabIndex = 85;
            this.tab38.Text = "38";
            this.tab38.UseVisualStyleBackColor = false;
            this.tab38.Click += new System.EventHandler(this.tab38_Click);
            this.tab38.MouseMove += new System.Windows.Forms.MouseEventHandler(this.tab38_MouseMove);
            // 
            // tab37
            // 
            this.tab37.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.tab37.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tab37.FlatAppearance.BorderColor = System.Drawing.Color.Maroon;
            this.tab37.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.tab37.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tab37.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tab37.ForeColor = System.Drawing.Color.Black;
            this.tab37.Location = new System.Drawing.Point(72, 297);
            this.tab37.Margin = new System.Windows.Forms.Padding(0);
            this.tab37.Name = "tab37";
            this.tab37.Size = new System.Drawing.Size(60, 39);
            this.tab37.TabIndex = 84;
            this.tab37.Text = "37";
            this.tab37.UseVisualStyleBackColor = false;
            this.tab37.Click += new System.EventHandler(this.tab37_Click);
            this.tab37.MouseMove += new System.Windows.Forms.MouseEventHandler(this.tab37_MouseMove);
            // 
            // tab36
            // 
            this.tab36.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.tab36.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tab36.FlatAppearance.BorderColor = System.Drawing.Color.Maroon;
            this.tab36.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.tab36.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tab36.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tab36.ForeColor = System.Drawing.Color.Black;
            this.tab36.Location = new System.Drawing.Point(11, 297);
            this.tab36.Margin = new System.Windows.Forms.Padding(0);
            this.tab36.Name = "tab36";
            this.tab36.Size = new System.Drawing.Size(60, 39);
            this.tab36.TabIndex = 83;
            this.tab36.Text = "36";
            this.tab36.UseVisualStyleBackColor = false;
            this.tab36.Click += new System.EventHandler(this.tab36_Click);
            this.tab36.MouseMove += new System.Windows.Forms.MouseEventHandler(this.tab36_MouseMove);
            // 
            // tab49
            // 
            this.tab49.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.tab49.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tab49.FlatAppearance.BorderColor = System.Drawing.Color.Maroon;
            this.tab49.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.tab49.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tab49.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tab49.ForeColor = System.Drawing.Color.Black;
            this.tab49.Location = new System.Drawing.Point(379, 337);
            this.tab49.Margin = new System.Windows.Forms.Padding(0);
            this.tab49.Name = "tab49";
            this.tab49.Size = new System.Drawing.Size(60, 39);
            this.tab49.TabIndex = 96;
            this.tab49.Text = "49";
            this.tab49.UseVisualStyleBackColor = false;
            this.tab49.Click += new System.EventHandler(this.tab49_Click);
            this.tab49.MouseMove += new System.Windows.Forms.MouseEventHandler(this.tab49_MouseMove);
            // 
            // tab48
            // 
            this.tab48.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.tab48.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tab48.FlatAppearance.BorderColor = System.Drawing.Color.Maroon;
            this.tab48.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.tab48.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tab48.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tab48.ForeColor = System.Drawing.Color.Black;
            this.tab48.Location = new System.Drawing.Point(317, 337);
            this.tab48.Margin = new System.Windows.Forms.Padding(0);
            this.tab48.Name = "tab48";
            this.tab48.Size = new System.Drawing.Size(60, 39);
            this.tab48.TabIndex = 95;
            this.tab48.Text = "48";
            this.tab48.UseVisualStyleBackColor = false;
            this.tab48.Click += new System.EventHandler(this.tab48_Click);
            this.tab48.MouseMove += new System.Windows.Forms.MouseEventHandler(this.tab48_MouseMove);
            // 
            // tab47
            // 
            this.tab47.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.tab47.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tab47.FlatAppearance.BorderColor = System.Drawing.Color.Maroon;
            this.tab47.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.tab47.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tab47.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tab47.ForeColor = System.Drawing.Color.Black;
            this.tab47.Location = new System.Drawing.Point(256, 337);
            this.tab47.Margin = new System.Windows.Forms.Padding(0);
            this.tab47.Name = "tab47";
            this.tab47.Size = new System.Drawing.Size(60, 39);
            this.tab47.TabIndex = 94;
            this.tab47.Text = "47";
            this.tab47.UseVisualStyleBackColor = false;
            this.tab47.Click += new System.EventHandler(this.tab47_Click);
            this.tab47.MouseMove += new System.Windows.Forms.MouseEventHandler(this.tab47_MouseMove);
            // 
            // tab46
            // 
            this.tab46.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.tab46.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tab46.FlatAppearance.BorderColor = System.Drawing.Color.Maroon;
            this.tab46.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.tab46.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tab46.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tab46.ForeColor = System.Drawing.Color.Black;
            this.tab46.Location = new System.Drawing.Point(195, 337);
            this.tab46.Margin = new System.Windows.Forms.Padding(0);
            this.tab46.Name = "tab46";
            this.tab46.Size = new System.Drawing.Size(60, 39);
            this.tab46.TabIndex = 93;
            this.tab46.Text = "46";
            this.tab46.UseVisualStyleBackColor = false;
            this.tab46.Click += new System.EventHandler(this.tab46_Click);
            this.tab46.MouseMove += new System.Windows.Forms.MouseEventHandler(this.tab46_MouseMove);
            // 
            // tab45
            // 
            this.tab45.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.tab45.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tab45.FlatAppearance.BorderColor = System.Drawing.Color.Maroon;
            this.tab45.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.tab45.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tab45.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tab45.ForeColor = System.Drawing.Color.Black;
            this.tab45.Location = new System.Drawing.Point(133, 337);
            this.tab45.Margin = new System.Windows.Forms.Padding(0);
            this.tab45.Name = "tab45";
            this.tab45.Size = new System.Drawing.Size(60, 39);
            this.tab45.TabIndex = 92;
            this.tab45.Text = "45";
            this.tab45.UseVisualStyleBackColor = false;
            this.tab45.Click += new System.EventHandler(this.tab45_Click);
            this.tab45.MouseMove += new System.Windows.Forms.MouseEventHandler(this.tab45_MouseMove);
            // 
            // tab44
            // 
            this.tab44.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.tab44.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tab44.FlatAppearance.BorderColor = System.Drawing.Color.Maroon;
            this.tab44.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.tab44.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tab44.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tab44.ForeColor = System.Drawing.Color.Black;
            this.tab44.Location = new System.Drawing.Point(72, 337);
            this.tab44.Margin = new System.Windows.Forms.Padding(0);
            this.tab44.Name = "tab44";
            this.tab44.Size = new System.Drawing.Size(60, 39);
            this.tab44.TabIndex = 91;
            this.tab44.Text = "44";
            this.tab44.UseVisualStyleBackColor = false;
            this.tab44.Click += new System.EventHandler(this.tab44_Click);
            this.tab44.MouseMove += new System.Windows.Forms.MouseEventHandler(this.tab44_MouseMove);
            // 
            // tab43
            // 
            this.tab43.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.tab43.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tab43.FlatAppearance.BorderColor = System.Drawing.Color.Maroon;
            this.tab43.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.tab43.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tab43.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tab43.ForeColor = System.Drawing.Color.Black;
            this.tab43.Location = new System.Drawing.Point(11, 337);
            this.tab43.Margin = new System.Windows.Forms.Padding(0);
            this.tab43.Name = "tab43";
            this.tab43.Size = new System.Drawing.Size(60, 39);
            this.tab43.TabIndex = 90;
            this.tab43.Text = "43";
            this.tab43.UseVisualStyleBackColor = false;
            this.tab43.Click += new System.EventHandler(this.tab43_Click);
            this.tab43.MouseMove += new System.Windows.Forms.MouseEventHandler(this.tab43_MouseMove);
            // 
            // tab56
            // 
            this.tab56.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.tab56.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tab56.FlatAppearance.BorderColor = System.Drawing.Color.Maroon;
            this.tab56.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.tab56.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tab56.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tab56.ForeColor = System.Drawing.Color.Black;
            this.tab56.Location = new System.Drawing.Point(379, 377);
            this.tab56.Margin = new System.Windows.Forms.Padding(0);
            this.tab56.Name = "tab56";
            this.tab56.Size = new System.Drawing.Size(60, 39);
            this.tab56.TabIndex = 103;
            this.tab56.Text = "56";
            this.tab56.UseVisualStyleBackColor = false;
            this.tab56.Click += new System.EventHandler(this.tab56_Click);
            this.tab56.MouseMove += new System.Windows.Forms.MouseEventHandler(this.tab56_MouseMove);
            // 
            // tab55
            // 
            this.tab55.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.tab55.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tab55.FlatAppearance.BorderColor = System.Drawing.Color.Maroon;
            this.tab55.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.tab55.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tab55.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tab55.ForeColor = System.Drawing.Color.Black;
            this.tab55.Location = new System.Drawing.Point(317, 377);
            this.tab55.Margin = new System.Windows.Forms.Padding(0);
            this.tab55.Name = "tab55";
            this.tab55.Size = new System.Drawing.Size(60, 39);
            this.tab55.TabIndex = 102;
            this.tab55.Text = "55";
            this.tab55.UseVisualStyleBackColor = false;
            this.tab55.Click += new System.EventHandler(this.tab55_Click);
            this.tab55.MouseMove += new System.Windows.Forms.MouseEventHandler(this.tab55_MouseMove);
            // 
            // tab54
            // 
            this.tab54.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.tab54.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tab54.FlatAppearance.BorderColor = System.Drawing.Color.Maroon;
            this.tab54.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.tab54.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tab54.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tab54.ForeColor = System.Drawing.Color.Black;
            this.tab54.Location = new System.Drawing.Point(256, 377);
            this.tab54.Margin = new System.Windows.Forms.Padding(0);
            this.tab54.Name = "tab54";
            this.tab54.Size = new System.Drawing.Size(60, 39);
            this.tab54.TabIndex = 101;
            this.tab54.Text = "54";
            this.tab54.UseVisualStyleBackColor = false;
            this.tab54.Click += new System.EventHandler(this.tab54_Click);
            this.tab54.MouseMove += new System.Windows.Forms.MouseEventHandler(this.tab54_MouseMove);
            // 
            // tab53
            // 
            this.tab53.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.tab53.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tab53.FlatAppearance.BorderColor = System.Drawing.Color.Maroon;
            this.tab53.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.tab53.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tab53.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tab53.ForeColor = System.Drawing.Color.Black;
            this.tab53.Location = new System.Drawing.Point(195, 377);
            this.tab53.Margin = new System.Windows.Forms.Padding(0);
            this.tab53.Name = "tab53";
            this.tab53.Size = new System.Drawing.Size(60, 39);
            this.tab53.TabIndex = 100;
            this.tab53.Text = "53";
            this.tab53.UseVisualStyleBackColor = false;
            this.tab53.Click += new System.EventHandler(this.tab53_Click);
            this.tab53.MouseMove += new System.Windows.Forms.MouseEventHandler(this.tab53_MouseMove);
            // 
            // tab52
            // 
            this.tab52.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.tab52.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tab52.FlatAppearance.BorderColor = System.Drawing.Color.Maroon;
            this.tab52.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.tab52.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tab52.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tab52.ForeColor = System.Drawing.Color.Black;
            this.tab52.Location = new System.Drawing.Point(133, 377);
            this.tab52.Margin = new System.Windows.Forms.Padding(0);
            this.tab52.Name = "tab52";
            this.tab52.Size = new System.Drawing.Size(60, 39);
            this.tab52.TabIndex = 99;
            this.tab52.Text = "52";
            this.tab52.UseVisualStyleBackColor = false;
            this.tab52.Click += new System.EventHandler(this.tab52_Click);
            this.tab52.MouseMove += new System.Windows.Forms.MouseEventHandler(this.tab52_MouseMove);
            // 
            // tab51
            // 
            this.tab51.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.tab51.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tab51.FlatAppearance.BorderColor = System.Drawing.Color.Maroon;
            this.tab51.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.tab51.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tab51.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tab51.ForeColor = System.Drawing.Color.Black;
            this.tab51.Location = new System.Drawing.Point(72, 377);
            this.tab51.Margin = new System.Windows.Forms.Padding(0);
            this.tab51.Name = "tab51";
            this.tab51.Size = new System.Drawing.Size(60, 39);
            this.tab51.TabIndex = 98;
            this.tab51.Text = "51";
            this.tab51.UseVisualStyleBackColor = false;
            this.tab51.Click += new System.EventHandler(this.tab51_Click);
            this.tab51.MouseMove += new System.Windows.Forms.MouseEventHandler(this.tab51_MouseMove);
            // 
            // tab50
            // 
            this.tab50.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.tab50.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tab50.FlatAppearance.BorderColor = System.Drawing.Color.Maroon;
            this.tab50.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.tab50.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tab50.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tab50.ForeColor = System.Drawing.Color.Black;
            this.tab50.Location = new System.Drawing.Point(11, 377);
            this.tab50.Margin = new System.Windows.Forms.Padding(0);
            this.tab50.Name = "tab50";
            this.tab50.Size = new System.Drawing.Size(60, 39);
            this.tab50.TabIndex = 97;
            this.tab50.Text = "50";
            this.tab50.UseVisualStyleBackColor = false;
            this.tab50.Click += new System.EventHandler(this.tab50_Click);
            this.tab50.MouseMove += new System.Windows.Forms.MouseEventHandler(this.tab50_MouseMove);
            // 
            // tab63
            // 
            this.tab63.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.tab63.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tab63.FlatAppearance.BorderColor = System.Drawing.Color.Maroon;
            this.tab63.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.tab63.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tab63.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tab63.ForeColor = System.Drawing.Color.Black;
            this.tab63.Location = new System.Drawing.Point(379, 418);
            this.tab63.Margin = new System.Windows.Forms.Padding(0);
            this.tab63.Name = "tab63";
            this.tab63.Size = new System.Drawing.Size(60, 39);
            this.tab63.TabIndex = 110;
            this.tab63.Text = "63";
            this.tab63.UseVisualStyleBackColor = false;
            this.tab63.Click += new System.EventHandler(this.tab63_Click);
            this.tab63.MouseMove += new System.Windows.Forms.MouseEventHandler(this.tab63_MouseMove);
            // 
            // tab61
            // 
            this.tab61.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.tab61.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tab61.FlatAppearance.BorderColor = System.Drawing.Color.Maroon;
            this.tab61.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.tab61.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tab61.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tab61.ForeColor = System.Drawing.Color.Black;
            this.tab61.Location = new System.Drawing.Point(256, 418);
            this.tab61.Margin = new System.Windows.Forms.Padding(0);
            this.tab61.Name = "tab61";
            this.tab61.Size = new System.Drawing.Size(60, 39);
            this.tab61.TabIndex = 108;
            this.tab61.Text = "61";
            this.tab61.UseVisualStyleBackColor = false;
            this.tab61.Click += new System.EventHandler(this.tab61_Click);
            this.tab61.MouseMove += new System.Windows.Forms.MouseEventHandler(this.tab61_MouseMove);
            // 
            // tab60
            // 
            this.tab60.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.tab60.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tab60.FlatAppearance.BorderColor = System.Drawing.Color.Maroon;
            this.tab60.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.tab60.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tab60.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tab60.ForeColor = System.Drawing.Color.Black;
            this.tab60.Location = new System.Drawing.Point(195, 418);
            this.tab60.Margin = new System.Windows.Forms.Padding(0);
            this.tab60.Name = "tab60";
            this.tab60.Size = new System.Drawing.Size(60, 39);
            this.tab60.TabIndex = 107;
            this.tab60.Text = "60";
            this.tab60.UseVisualStyleBackColor = false;
            this.tab60.Click += new System.EventHandler(this.tab60_Click);
            this.tab60.MouseMove += new System.Windows.Forms.MouseEventHandler(this.tab60_MouseMove);
            // 
            // tab59
            // 
            this.tab59.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.tab59.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tab59.FlatAppearance.BorderColor = System.Drawing.Color.Maroon;
            this.tab59.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.tab59.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tab59.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tab59.ForeColor = System.Drawing.Color.Black;
            this.tab59.Location = new System.Drawing.Point(133, 418);
            this.tab59.Margin = new System.Windows.Forms.Padding(0);
            this.tab59.Name = "tab59";
            this.tab59.Size = new System.Drawing.Size(60, 39);
            this.tab59.TabIndex = 106;
            this.tab59.Text = "59";
            this.tab59.UseVisualStyleBackColor = false;
            this.tab59.Click += new System.EventHandler(this.tab59_Click);
            this.tab59.MouseMove += new System.Windows.Forms.MouseEventHandler(this.tab59_MouseMove);
            // 
            // tab58
            // 
            this.tab58.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.tab58.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tab58.FlatAppearance.BorderColor = System.Drawing.Color.Maroon;
            this.tab58.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.tab58.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tab58.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tab58.ForeColor = System.Drawing.Color.Black;
            this.tab58.Location = new System.Drawing.Point(72, 418);
            this.tab58.Margin = new System.Windows.Forms.Padding(0);
            this.tab58.Name = "tab58";
            this.tab58.Size = new System.Drawing.Size(60, 39);
            this.tab58.TabIndex = 105;
            this.tab58.Text = "58";
            this.tab58.UseVisualStyleBackColor = false;
            this.tab58.Click += new System.EventHandler(this.tab58_Click);
            this.tab58.MouseMove += new System.Windows.Forms.MouseEventHandler(this.tab58_MouseMove);
            // 
            // tab57
            // 
            this.tab57.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.tab57.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tab57.FlatAppearance.BorderColor = System.Drawing.Color.Maroon;
            this.tab57.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.tab57.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tab57.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tab57.ForeColor = System.Drawing.Color.Black;
            this.tab57.Location = new System.Drawing.Point(11, 418);
            this.tab57.Margin = new System.Windows.Forms.Padding(0);
            this.tab57.Name = "tab57";
            this.tab57.Size = new System.Drawing.Size(60, 39);
            this.tab57.TabIndex = 104;
            this.tab57.Text = "57";
            this.tab57.UseVisualStyleBackColor = false;
            this.tab57.Click += new System.EventHandler(this.tab57_Click);
            this.tab57.MouseMove += new System.Windows.Forms.MouseEventHandler(this.tab57_MouseMove);
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.Maroon;
            this.label6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label6.Location = new System.Drawing.Point(-1, 500);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(1168, 1);
            this.label6.TabIndex = 111;
            this.label6.Text = "label6";
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridView2.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView2.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.dataGridView2.ColumnHeadersHeight = 29;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4});
            this.dataGridView2.Location = new System.Drawing.Point(787, 206);
            this.dataGridView2.Margin = new System.Windows.Forms.Padding(0);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.RowHeadersWidth = 8;
            this.dataGridView2.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridView2.RowTemplate.Height = 24;
            this.dataGridView2.RowTemplate.ReadOnly = true;
            this.dataGridView2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridView2.Size = new System.Drawing.Size(537, 196);
            this.dataGridView2.TabIndex = 112;
            this.dataGridView2.Tag = "none";
            this.dataGridView2.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellClick);
            this.dataGridView2.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView2_CellFormatting);
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black;
            this.dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewTextBoxColumn1.FillWeight = 10F;
            this.dataGridViewTextBoxColumn1.Frozen = true;
            this.dataGridViewTextBoxColumn1.HeaderText = "Name";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn1.Width = 290;
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
            this.dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridViewTextBoxColumn2.Frozen = true;
            this.dataGridViewTextBoxColumn2.HeaderText = "Price";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 80;
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Black;
            this.dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridViewTextBoxColumn3.HeaderText = "quantity";
            this.dataGridViewTextBoxColumn3.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 50;
            // 
            // dataGridViewTextBoxColumn4
            // 
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.Black;
            this.dataGridViewTextBoxColumn4.DefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridViewTextBoxColumn4.HeaderText = "amount";
            this.dataGridViewTextBoxColumn4.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 105;
            // 
            // number8
            // 
            this.number8.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.number8.Cursor = System.Windows.Forms.Cursors.Hand;
            this.number8.FlatAppearance.BorderColor = System.Drawing.Color.Maroon;
            this.number8.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.number8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.number8.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.number8.Location = new System.Drawing.Point(1000, 122);
            this.number8.Margin = new System.Windows.Forms.Padding(0);
            this.number8.Name = "number8";
            this.number8.Size = new System.Drawing.Size(69, 39);
            this.number8.TabIndex = 113;
            this.number8.Text = "8";
            this.number8.UseVisualStyleBackColor = false;
            this.number8.Click += new System.EventHandler(this.number8_Click);
            // 
            // number3
            // 
            this.number3.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.number3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.number3.FlatAppearance.BorderColor = System.Drawing.Color.Maroon;
            this.number3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.number3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.number3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.number3.Location = new System.Drawing.Point(1000, 164);
            this.number3.Margin = new System.Windows.Forms.Padding(0);
            this.number3.Name = "number3";
            this.number3.Size = new System.Drawing.Size(69, 39);
            this.number3.TabIndex = 114;
            this.number3.Text = "3";
            this.number3.UseVisualStyleBackColor = false;
            this.number3.Click += new System.EventHandler(this.number3_Click);
            // 
            // number2
            // 
            this.number2.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.number2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.number2.FlatAppearance.BorderColor = System.Drawing.Color.Maroon;
            this.number2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.number2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.number2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.number2.Location = new System.Drawing.Point(929, 164);
            this.number2.Margin = new System.Windows.Forms.Padding(0);
            this.number2.Name = "number2";
            this.number2.Size = new System.Drawing.Size(69, 39);
            this.number2.TabIndex = 116;
            this.number2.Text = "2";
            this.number2.UseVisualStyleBackColor = false;
            this.number2.Click += new System.EventHandler(this.number2_Click);
            // 
            // number1
            // 
            this.number1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.number1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.number1.FlatAppearance.BorderColor = System.Drawing.Color.Maroon;
            this.number1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.number1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.number1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.number1.Location = new System.Drawing.Point(859, 164);
            this.number1.Margin = new System.Windows.Forms.Padding(0);
            this.number1.Name = "number1";
            this.number1.Size = new System.Drawing.Size(69, 39);
            this.number1.TabIndex = 115;
            this.number1.Text = "1";
            this.number1.UseVisualStyleBackColor = false;
            this.number1.Click += new System.EventHandler(this.number1_Click);
            // 
            // number0
            // 
            this.number0.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.number0.Cursor = System.Windows.Forms.Cursors.Hand;
            this.number0.FlatAppearance.BorderColor = System.Drawing.Color.Maroon;
            this.number0.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.number0.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.number0.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.number0.Location = new System.Drawing.Point(787, 164);
            this.number0.Margin = new System.Windows.Forms.Padding(0);
            this.number0.Name = "number0";
            this.number0.Size = new System.Drawing.Size(69, 39);
            this.number0.TabIndex = 117;
            this.number0.Text = "0";
            this.number0.UseVisualStyleBackColor = false;
            this.number0.Click += new System.EventHandler(this.number0_Click);
            // 
            // number4
            // 
            this.number4.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.number4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.number4.FlatAppearance.BorderColor = System.Drawing.Color.Maroon;
            this.number4.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.number4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.number4.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.number4.Location = new System.Drawing.Point(1071, 164);
            this.number4.Margin = new System.Windows.Forms.Padding(0);
            this.number4.Name = "number4";
            this.number4.Size = new System.Drawing.Size(69, 39);
            this.number4.TabIndex = 118;
            this.number4.Text = "4";
            this.number4.UseVisualStyleBackColor = false;
            this.number4.Click += new System.EventHandler(this.number4_Click);
            // 
            // number7
            // 
            this.number7.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.number7.Cursor = System.Windows.Forms.Cursors.Hand;
            this.number7.FlatAppearance.BorderColor = System.Drawing.Color.Maroon;
            this.number7.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.number7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.number7.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.number7.Location = new System.Drawing.Point(929, 122);
            this.number7.Margin = new System.Windows.Forms.Padding(0);
            this.number7.Name = "number7";
            this.number7.Size = new System.Drawing.Size(69, 39);
            this.number7.TabIndex = 121;
            this.number7.Text = "7";
            this.number7.UseVisualStyleBackColor = false;
            this.number7.Click += new System.EventHandler(this.number7_Click);
            // 
            // number6
            // 
            this.number6.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.number6.Cursor = System.Windows.Forms.Cursors.Hand;
            this.number6.FlatAppearance.BorderColor = System.Drawing.Color.Maroon;
            this.number6.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.number6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.number6.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.number6.Location = new System.Drawing.Point(859, 122);
            this.number6.Margin = new System.Windows.Forms.Padding(0);
            this.number6.Name = "number6";
            this.number6.Size = new System.Drawing.Size(69, 39);
            this.number6.TabIndex = 120;
            this.number6.Text = "6";
            this.number6.UseVisualStyleBackColor = false;
            this.number6.Click += new System.EventHandler(this.number6_Click);
            // 
            // number5
            // 
            this.number5.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.number5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.number5.FlatAppearance.BorderColor = System.Drawing.Color.Maroon;
            this.number5.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.number5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.number5.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.number5.Location = new System.Drawing.Point(787, 122);
            this.number5.Margin = new System.Windows.Forms.Padding(0);
            this.number5.Name = "number5";
            this.number5.Size = new System.Drawing.Size(69, 39);
            this.number5.TabIndex = 119;
            this.number5.Text = "5";
            this.number5.UseVisualStyleBackColor = false;
            this.number5.Click += new System.EventHandler(this.number5_Click);
            // 
            // number9
            // 
            this.number9.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.number9.Cursor = System.Windows.Forms.Cursors.Hand;
            this.number9.FlatAppearance.BorderColor = System.Drawing.Color.Maroon;
            this.number9.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.number9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.number9.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.number9.Location = new System.Drawing.Point(1071, 122);
            this.number9.Margin = new System.Windows.Forms.Padding(0);
            this.number9.Name = "number9";
            this.number9.Size = new System.Drawing.Size(69, 39);
            this.number9.TabIndex = 122;
            this.number9.Text = "9";
            this.number9.UseVisualStyleBackColor = false;
            this.number9.Click += new System.EventHandler(this.number9_Click);
            // 
            // number_enter
            // 
            this.number_enter.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.number_enter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.number_enter.FlatAppearance.BorderColor = System.Drawing.Color.Maroon;
            this.number_enter.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.number_enter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.number_enter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.number_enter.Location = new System.Drawing.Point(1232, 149);
            this.number_enter.Margin = new System.Windows.Forms.Padding(0);
            this.number_enter.Name = "number_enter";
            this.number_enter.Size = new System.Drawing.Size(89, 55);
            this.number_enter.TabIndex = 123;
            this.number_enter.Tag = "9999999";
            this.number_enter.Text = "Enter";
            this.number_enter.UseVisualStyleBackColor = false;
            this.number_enter.Click += new System.EventHandler(this.number_enter_Click);
            // 
            // number_point
            // 
            this.number_point.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.number_point.Cursor = System.Windows.Forms.Cursors.Hand;
            this.number_point.FlatAppearance.BorderColor = System.Drawing.Color.Maroon;
            this.number_point.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.number_point.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.number_point.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.number_point.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.number_point.Location = new System.Drawing.Point(1141, 177);
            this.number_point.Margin = new System.Windows.Forms.Padding(0);
            this.number_point.Name = "number_point";
            this.number_point.Size = new System.Drawing.Size(89, 26);
            this.number_point.TabIndex = 124;
            this.number_point.Text = "o";
            this.number_point.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.number_point.UseVisualStyleBackColor = false;
            this.number_point.Click += new System.EventHandler(this.number_point_Click);
            // 
            // number_delete
            // 
            this.number_delete.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.number_delete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.number_delete.FlatAppearance.BorderColor = System.Drawing.Color.Maroon;
            this.number_delete.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.number_delete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.number_delete.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.number_delete.Location = new System.Drawing.Point(1141, 149);
            this.number_delete.Margin = new System.Windows.Forms.Padding(0);
            this.number_delete.Name = "number_delete";
            this.number_delete.Size = new System.Drawing.Size(89, 26);
            this.number_delete.TabIndex = 125;
            this.number_delete.Text = "Delete";
            this.number_delete.UseVisualStyleBackColor = false;
            // 
            // open_nest
            // 
            this.open_nest.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.open_nest.Cursor = System.Windows.Forms.Cursors.Hand;
            this.open_nest.FlatAppearance.BorderColor = System.Drawing.Color.Maroon;
            this.open_nest.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.open_nest.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.open_nest.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.open_nest.Location = new System.Drawing.Point(1141, 122);
            this.open_nest.Margin = new System.Windows.Forms.Padding(0);
            this.open_nest.Name = "open_nest";
            this.open_nest.Size = new System.Drawing.Size(89, 26);
            this.open_nest.TabIndex = 126;
            this.open_nest.Text = "Open";
            this.open_nest.UseVisualStyleBackColor = false;
            this.open_nest.Visible = false;
            // 
            // backspace
            // 
            this.backspace.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.backspace.Cursor = System.Windows.Forms.Cursors.Hand;
            this.backspace.FlatAppearance.BorderColor = System.Drawing.Color.Maroon;
            this.backspace.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.backspace.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.backspace.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.backspace.Location = new System.Drawing.Point(1232, 122);
            this.backspace.Margin = new System.Windows.Forms.Padding(0);
            this.backspace.Name = "backspace";
            this.backspace.Size = new System.Drawing.Size(89, 26);
            this.backspace.TabIndex = 127;
            this.backspace.Text = "Backspace";
            this.backspace.UseVisualStyleBackColor = false;
            this.backspace.Click += new System.EventHandler(this.backspace_Click);
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.Maroon;
            this.label7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label7.Location = new System.Drawing.Point(1224, 5);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(1, 54);
            this.label7.TabIndex = 128;
            this.label7.Text = "label7";
            // 
            // accept
            // 
            this.accept.BackColor = System.Drawing.Color.White;
            this.accept.FlatAppearance.BorderColor = System.Drawing.Color.SaddleBrown;
            this.accept.FlatAppearance.BorderSize = 2;
            this.accept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.accept.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.accept.ForeColor = System.Drawing.Color.Maroon;
            this.accept.Location = new System.Drawing.Point(1086, 403);
            this.accept.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.accept.Name = "accept";
            this.accept.Size = new System.Drawing.Size(76, 29);
            this.accept.TabIndex = 130;
            this.accept.Tag = "none";
            this.accept.Text = "Save";
            this.accept.UseVisualStyleBackColor = false;
            this.accept.Visible = false;
            this.accept.Click += new System.EventHandler(this.accept_Click);
            // 
            // printbutton1
            // 
            this.printbutton1.BackColor = System.Drawing.Color.White;
            this.printbutton1.FlatAppearance.BorderColor = System.Drawing.Color.SaddleBrown;
            this.printbutton1.FlatAppearance.BorderSize = 2;
            this.printbutton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.printbutton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.printbutton1.ForeColor = System.Drawing.Color.Maroon;
            this.printbutton1.Location = new System.Drawing.Point(1010, 403);
            this.printbutton1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.printbutton1.Name = "printbutton1";
            this.printbutton1.Size = new System.Drawing.Size(76, 29);
            this.printbutton1.TabIndex = 131;
            this.printbutton1.Tag = "none";
            this.printbutton1.Text = "Print";
            this.printbutton1.UseVisualStyleBackColor = false;
            this.printbutton1.Visible = false;
            this.printbutton1.Click += new System.EventHandler(this.printbutton1_Click);
            // 
            // printbutton2
            // 
            this.printbutton2.BackColor = System.Drawing.Color.White;
            this.printbutton2.FlatAppearance.BorderColor = System.Drawing.Color.SaddleBrown;
            this.printbutton2.FlatAppearance.BorderSize = 2;
            this.printbutton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.printbutton2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.printbutton2.ForeColor = System.Drawing.Color.Maroon;
            this.printbutton2.Location = new System.Drawing.Point(934, 403);
            this.printbutton2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.printbutton2.Name = "printbutton2";
            this.printbutton2.Size = new System.Drawing.Size(76, 29);
            this.printbutton2.TabIndex = 132;
            this.printbutton2.Tag = "none";
            this.printbutton2.Text = "Preview";
            this.printbutton2.UseVisualStyleBackColor = false;
            this.printbutton2.Visible = false;
            this.printbutton2.Click += new System.EventHandler(this.printbutton2_Click);
            // 
            // cancel
            // 
            this.cancel.BackColor = System.Drawing.Color.White;
            this.cancel.FlatAppearance.BorderColor = System.Drawing.Color.SaddleBrown;
            this.cancel.FlatAppearance.BorderSize = 2;
            this.cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancel.ForeColor = System.Drawing.Color.Maroon;
            this.cancel.Location = new System.Drawing.Point(854, 403);
            this.cancel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(80, 29);
            this.cancel.TabIndex = 133;
            this.cancel.Tag = "none";
            this.cancel.Text = "Release";
            this.cancel.UseVisualStyleBackColor = false;
            this.cancel.Visible = false;
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // amount
            // 
            this.amount.BackColor = System.Drawing.Color.White;
            this.amount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.amount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.amount.Location = new System.Drawing.Point(1229, 404);
            this.amount.Name = "amount";
            this.amount.Size = new System.Drawing.Size(91, 23);
            this.amount.TabIndex = 134;
            this.amount.Text = "amount";
            this.amount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // service
            // 
            this.service.BackColor = System.Drawing.Color.White;
            this.service.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.service.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.service.Location = new System.Drawing.Point(1229, 426);
            this.service.Name = "service";
            this.service.Size = new System.Drawing.Size(91, 23);
            this.service.TabIndex = 135;
            this.service.Tag = "";
            this.service.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // discount
            // 
            this.discount.BackColor = System.Drawing.Color.White;
            this.discount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.discount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.discount.Location = new System.Drawing.Point(1229, 448);
            this.discount.Name = "discount";
            this.discount.Size = new System.Drawing.Size(91, 23);
            this.discount.TabIndex = 136;
            this.discount.Tag = "";
            this.discount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // total
            // 
            this.total.BackColor = System.Drawing.Color.White;
            this.total.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.total.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.total.Location = new System.Drawing.Point(1229, 492);
            this.total.Name = "total";
            this.total.Size = new System.Drawing.Size(91, 23);
            this.total.TabIndex = 137;
            this.total.Text = "total";
            this.total.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(1170, 404);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 23);
            this.label2.TabIndex = 138;
            this.label2.Text = "Amount";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(1189, 427);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(40, 23);
            this.label8.TabIndex = 139;
            this.label8.Text = "+";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(1189, 448);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(40, 23);
            this.label9.TabIndex = 140;
            this.label9.Text = "-";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(1186, 492);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(42, 23);
            this.label10.TabIndex = 141;
            this.label10.Text = "Total";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tab62
            // 
            this.tab62.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.tab62.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tab62.FlatAppearance.BorderColor = System.Drawing.Color.Maroon;
            this.tab62.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.tab62.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tab62.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tab62.ForeColor = System.Drawing.Color.Black;
            this.tab62.Location = new System.Drawing.Point(319, 418);
            this.tab62.Margin = new System.Windows.Forms.Padding(0);
            this.tab62.Name = "tab62";
            this.tab62.Size = new System.Drawing.Size(59, 39);
            this.tab62.TabIndex = 142;
            this.tab62.Text = "62";
            this.tab62.UseVisualStyleBackColor = false;
            this.tab62.Click += new System.EventHandler(this.tab62_Click);
            this.tab62.MouseMove += new System.Windows.Forms.MouseEventHandler(this.tab62_MouseMove);
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.Maroon;
            this.label11.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label11.Location = new System.Drawing.Point(1167, 403);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(1, 148);
            this.label11.TabIndex = 175;
            this.label11.Text = "label11";
            // 
            // addition10
            // 
            this.addition10.BackColor = System.Drawing.Color.White;
            this.addition10.Cursor = System.Windows.Forms.Cursors.Hand;
            this.addition10.FlatAppearance.BorderColor = System.Drawing.Color.Maroon;
            this.addition10.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.addition10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addition10.ForeColor = System.Drawing.Color.Maroon;
            this.addition10.Location = new System.Drawing.Point(1051, 503);
            this.addition10.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.addition10.Name = "addition10";
            this.addition10.Size = new System.Drawing.Size(113, 23);
            this.addition10.TabIndex = 153;
            this.addition10.Text = "button22";
            this.addition10.UseVisualStyleBackColor = false;
            this.addition10.Click += new System.EventHandler(this.addition10_Click);
            // 
            // addition6
            // 
            this.addition6.BackColor = System.Drawing.Color.White;
            this.addition6.Cursor = System.Windows.Forms.Cursors.Hand;
            this.addition6.FlatAppearance.BorderColor = System.Drawing.Color.Maroon;
            this.addition6.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.addition6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addition6.ForeColor = System.Drawing.Color.Maroon;
            this.addition6.Location = new System.Drawing.Point(592, 503);
            this.addition6.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.addition6.Name = "addition6";
            this.addition6.Size = new System.Drawing.Size(113, 23);
            this.addition6.TabIndex = 152;
            this.addition6.Text = "button23";
            this.addition6.UseVisualStyleBackColor = false;
            this.addition6.Click += new System.EventHandler(this.addition6_Click);
            // 
            // addition7
            // 
            this.addition7.BackColor = System.Drawing.Color.White;
            this.addition7.Cursor = System.Windows.Forms.Cursors.Hand;
            this.addition7.FlatAppearance.BorderColor = System.Drawing.Color.Maroon;
            this.addition7.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.addition7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addition7.ForeColor = System.Drawing.Color.Maroon;
            this.addition7.Location = new System.Drawing.Point(707, 503);
            this.addition7.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.addition7.Name = "addition7";
            this.addition7.Size = new System.Drawing.Size(113, 23);
            this.addition7.TabIndex = 151;
            this.addition7.Text = "button24";
            this.addition7.UseVisualStyleBackColor = false;
            this.addition7.Click += new System.EventHandler(this.addition7_Click);
            // 
            // addition8
            // 
            this.addition8.BackColor = System.Drawing.Color.White;
            this.addition8.Cursor = System.Windows.Forms.Cursors.Hand;
            this.addition8.FlatAppearance.BorderColor = System.Drawing.Color.Maroon;
            this.addition8.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.addition8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addition8.ForeColor = System.Drawing.Color.Maroon;
            this.addition8.Location = new System.Drawing.Point(821, 503);
            this.addition8.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.addition8.Name = "addition8";
            this.addition8.Size = new System.Drawing.Size(113, 23);
            this.addition8.TabIndex = 150;
            this.addition8.Text = "button25";
            this.addition8.UseVisualStyleBackColor = false;
            this.addition8.Click += new System.EventHandler(this.addition8_Click);
            // 
            // addition9
            // 
            this.addition9.BackColor = System.Drawing.Color.White;
            this.addition9.Cursor = System.Windows.Forms.Cursors.Hand;
            this.addition9.FlatAppearance.BorderColor = System.Drawing.Color.Maroon;
            this.addition9.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.addition9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addition9.ForeColor = System.Drawing.Color.Maroon;
            this.addition9.Location = new System.Drawing.Point(936, 503);
            this.addition9.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.addition9.Name = "addition9";
            this.addition9.Size = new System.Drawing.Size(113, 23);
            this.addition9.TabIndex = 149;
            this.addition9.Text = "button26";
            this.addition9.UseVisualStyleBackColor = false;
            this.addition9.Click += new System.EventHandler(this.addition9_Click);
            // 
            // addition5
            // 
            this.addition5.BackColor = System.Drawing.Color.White;
            this.addition5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.addition5.FlatAppearance.BorderColor = System.Drawing.Color.Maroon;
            this.addition5.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.addition5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addition5.ForeColor = System.Drawing.Color.Maroon;
            this.addition5.Location = new System.Drawing.Point(477, 503);
            this.addition5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.addition5.Name = "addition5";
            this.addition5.Size = new System.Drawing.Size(113, 23);
            this.addition5.TabIndex = 148;
            this.addition5.Text = "button3";
            this.addition5.UseVisualStyleBackColor = false;
            this.addition5.Click += new System.EventHandler(this.addition5_Click);
            // 
            // addition3
            // 
            this.addition3.BackColor = System.Drawing.Color.White;
            this.addition3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.addition3.FlatAppearance.BorderColor = System.Drawing.Color.Maroon;
            this.addition3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.addition3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addition3.ForeColor = System.Drawing.Color.Maroon;
            this.addition3.Location = new System.Drawing.Point(248, 503);
            this.addition3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.addition3.Name = "addition3";
            this.addition3.Size = new System.Drawing.Size(113, 23);
            this.addition3.TabIndex = 147;
            this.addition3.Text = "button28";
            this.addition3.UseVisualStyleBackColor = false;
            this.addition3.Click += new System.EventHandler(this.addition3_Click);
            // 
            // addition4
            // 
            this.addition4.BackColor = System.Drawing.Color.White;
            this.addition4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.addition4.FlatAppearance.BorderColor = System.Drawing.Color.Maroon;
            this.addition4.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Green;
            this.addition4.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.addition4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addition4.ForeColor = System.Drawing.Color.Maroon;
            this.addition4.Location = new System.Drawing.Point(363, 503);
            this.addition4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.addition4.Name = "addition4";
            this.addition4.Size = new System.Drawing.Size(113, 23);
            this.addition4.TabIndex = 146;
            this.addition4.Text = "button29";
            this.addition4.UseVisualStyleBackColor = false;
            this.addition4.Click += new System.EventHandler(this.addition4_Click);
            // 
            // addition1
            // 
            this.addition1.BackColor = System.Drawing.Color.White;
            this.addition1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.addition1.FlatAppearance.BorderColor = System.Drawing.Color.Maroon;
            this.addition1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Green;
            this.addition1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.addition1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addition1.ForeColor = System.Drawing.Color.Maroon;
            this.addition1.Location = new System.Drawing.Point(19, 503);
            this.addition1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.addition1.Name = "addition1";
            this.addition1.Size = new System.Drawing.Size(113, 23);
            this.addition1.TabIndex = 145;
            this.addition1.Text = "button30";
            this.addition1.UseVisualStyleBackColor = false;
            this.addition1.Click += new System.EventHandler(this.addition1_Click);
            // 
            // addition2
            // 
            this.addition2.BackColor = System.Drawing.Color.White;
            this.addition2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.addition2.FlatAppearance.BorderColor = System.Drawing.Color.Maroon;
            this.addition2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Green;
            this.addition2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.addition2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addition2.ForeColor = System.Drawing.Color.Maroon;
            this.addition2.Location = new System.Drawing.Point(133, 503);
            this.addition2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.addition2.Name = "addition2";
            this.addition2.Size = new System.Drawing.Size(113, 23);
            this.addition2.TabIndex = 176;
            this.addition2.Text = "button11";
            this.addition2.UseVisualStyleBackColor = false;
            this.addition2.Click += new System.EventHandler(this.addition2_Click);
            // 
            // addition12
            // 
            this.addition12.BackColor = System.Drawing.Color.White;
            this.addition12.Cursor = System.Windows.Forms.Cursors.Hand;
            this.addition12.FlatAppearance.BorderColor = System.Drawing.Color.Maroon;
            this.addition12.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Green;
            this.addition12.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.addition12.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addition12.ForeColor = System.Drawing.Color.Maroon;
            this.addition12.Location = new System.Drawing.Point(133, 528);
            this.addition12.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.addition12.Name = "addition12";
            this.addition12.Size = new System.Drawing.Size(113, 23);
            this.addition12.TabIndex = 186;
            this.addition12.Text = "button11";
            this.addition12.UseVisualStyleBackColor = false;
            this.addition12.Click += new System.EventHandler(this.addition12_Click);
            // 
            // addition20
            // 
            this.addition20.BackColor = System.Drawing.Color.White;
            this.addition20.Cursor = System.Windows.Forms.Cursors.Hand;
            this.addition20.FlatAppearance.BorderColor = System.Drawing.Color.Maroon;
            this.addition20.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.addition20.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addition20.ForeColor = System.Drawing.Color.Maroon;
            this.addition20.Location = new System.Drawing.Point(1051, 528);
            this.addition20.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.addition20.Name = "addition20";
            this.addition20.Size = new System.Drawing.Size(113, 23);
            this.addition20.TabIndex = 185;
            this.addition20.Text = "button22";
            this.addition20.UseVisualStyleBackColor = false;
            this.addition20.Click += new System.EventHandler(this.addition20_Click);
            // 
            // addition16
            // 
            this.addition16.BackColor = System.Drawing.Color.White;
            this.addition16.Cursor = System.Windows.Forms.Cursors.Hand;
            this.addition16.FlatAppearance.BorderColor = System.Drawing.Color.Maroon;
            this.addition16.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.addition16.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addition16.ForeColor = System.Drawing.Color.Maroon;
            this.addition16.Location = new System.Drawing.Point(592, 528);
            this.addition16.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.addition16.Name = "addition16";
            this.addition16.Size = new System.Drawing.Size(113, 23);
            this.addition16.TabIndex = 184;
            this.addition16.Text = "button23";
            this.addition16.UseVisualStyleBackColor = false;
            this.addition16.Click += new System.EventHandler(this.addition16_Click);
            // 
            // addition17
            // 
            this.addition17.BackColor = System.Drawing.Color.White;
            this.addition17.Cursor = System.Windows.Forms.Cursors.Hand;
            this.addition17.FlatAppearance.BorderColor = System.Drawing.Color.Maroon;
            this.addition17.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.addition17.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addition17.ForeColor = System.Drawing.Color.Maroon;
            this.addition17.Location = new System.Drawing.Point(707, 528);
            this.addition17.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.addition17.Name = "addition17";
            this.addition17.Size = new System.Drawing.Size(113, 23);
            this.addition17.TabIndex = 183;
            this.addition17.Text = "button24";
            this.addition17.UseVisualStyleBackColor = false;
            this.addition17.Click += new System.EventHandler(this.addition17_Click);
            // 
            // addition18
            // 
            this.addition18.BackColor = System.Drawing.Color.White;
            this.addition18.Cursor = System.Windows.Forms.Cursors.Hand;
            this.addition18.FlatAppearance.BorderColor = System.Drawing.Color.Maroon;
            this.addition18.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.addition18.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addition18.ForeColor = System.Drawing.Color.Maroon;
            this.addition18.Location = new System.Drawing.Point(821, 528);
            this.addition18.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.addition18.Name = "addition18";
            this.addition18.Size = new System.Drawing.Size(113, 23);
            this.addition18.TabIndex = 182;
            this.addition18.Text = "button25";
            this.addition18.UseVisualStyleBackColor = false;
            this.addition18.Click += new System.EventHandler(this.addition18_Click);
            // 
            // addition19
            // 
            this.addition19.BackColor = System.Drawing.Color.White;
            this.addition19.Cursor = System.Windows.Forms.Cursors.Hand;
            this.addition19.FlatAppearance.BorderColor = System.Drawing.Color.Maroon;
            this.addition19.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.addition19.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addition19.ForeColor = System.Drawing.Color.Maroon;
            this.addition19.Location = new System.Drawing.Point(936, 528);
            this.addition19.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.addition19.Name = "addition19";
            this.addition19.Size = new System.Drawing.Size(113, 23);
            this.addition19.TabIndex = 181;
            this.addition19.Text = "button26";
            this.addition19.UseVisualStyleBackColor = false;
            this.addition19.Click += new System.EventHandler(this.addition19_Click);
            // 
            // addition15
            // 
            this.addition15.BackColor = System.Drawing.Color.White;
            this.addition15.Cursor = System.Windows.Forms.Cursors.Hand;
            this.addition15.FlatAppearance.BorderColor = System.Drawing.Color.Maroon;
            this.addition15.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.addition15.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addition15.ForeColor = System.Drawing.Color.Maroon;
            this.addition15.Location = new System.Drawing.Point(477, 528);
            this.addition15.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.addition15.Name = "addition15";
            this.addition15.Size = new System.Drawing.Size(113, 23);
            this.addition15.TabIndex = 180;
            this.addition15.Text = "button3";
            this.addition15.UseVisualStyleBackColor = false;
            this.addition15.Click += new System.EventHandler(this.addition15_Click);
            // 
            // addition13
            // 
            this.addition13.BackColor = System.Drawing.Color.White;
            this.addition13.Cursor = System.Windows.Forms.Cursors.Hand;
            this.addition13.FlatAppearance.BorderColor = System.Drawing.Color.Maroon;
            this.addition13.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.addition13.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addition13.ForeColor = System.Drawing.Color.Maroon;
            this.addition13.Location = new System.Drawing.Point(248, 528);
            this.addition13.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.addition13.Name = "addition13";
            this.addition13.Size = new System.Drawing.Size(113, 23);
            this.addition13.TabIndex = 179;
            this.addition13.Text = "button28";
            this.addition13.UseVisualStyleBackColor = false;
            this.addition13.Click += new System.EventHandler(this.addition13_Click);
            // 
            // addition14
            // 
            this.addition14.BackColor = System.Drawing.Color.White;
            this.addition14.Cursor = System.Windows.Forms.Cursors.Hand;
            this.addition14.FlatAppearance.BorderColor = System.Drawing.Color.Maroon;
            this.addition14.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Green;
            this.addition14.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.addition14.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addition14.ForeColor = System.Drawing.Color.Maroon;
            this.addition14.Location = new System.Drawing.Point(363, 528);
            this.addition14.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.addition14.Name = "addition14";
            this.addition14.Size = new System.Drawing.Size(113, 23);
            this.addition14.TabIndex = 178;
            this.addition14.Text = "button29";
            this.addition14.UseVisualStyleBackColor = false;
            this.addition14.Click += new System.EventHandler(this.addition14_Click);
            // 
            // addition11
            // 
            this.addition11.BackColor = System.Drawing.Color.White;
            this.addition11.Cursor = System.Windows.Forms.Cursors.Hand;
            this.addition11.FlatAppearance.BorderColor = System.Drawing.Color.Maroon;
            this.addition11.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Green;
            this.addition11.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.addition11.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addition11.ForeColor = System.Drawing.Color.Maroon;
            this.addition11.Location = new System.Drawing.Point(19, 528);
            this.addition11.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.addition11.Name = "addition11";
            this.addition11.Size = new System.Drawing.Size(113, 23);
            this.addition11.TabIndex = 177;
            this.addition11.Text = "button30";
            this.addition11.UseVisualStyleBackColor = false;
            this.addition11.Click += new System.EventHandler(this.addition11_Click);
            // 
            // DepartmentClick
            // 
            this.DepartmentClick.Location = new System.Drawing.Point(1004, 436);
            this.DepartmentClick.Name = "DepartmentClick";
            this.DepartmentClick.Size = new System.Drawing.Size(75, 23);
            this.DepartmentClick.TabIndex = 187;
            this.DepartmentClick.Tag = "1";
            this.DepartmentClick.Text = "DepartmentClick";
            this.DepartmentClick.UseVisualStyleBackColor = true;
            this.DepartmentClick.Click += new System.EventHandler(this.departmentclick_Click);
            // 
            // GroupClick
            // 
            this.GroupClick.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.GroupClick.Cursor = System.Windows.Forms.Cursors.Hand;
            this.GroupClick.FlatAppearance.BorderColor = System.Drawing.Color.Maroon;
            this.GroupClick.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Green;
            this.GroupClick.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.GroupClick.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.GroupClick.Location = new System.Drawing.Point(1086, 459);
            this.GroupClick.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.GroupClick.Name = "GroupClick";
            this.GroupClick.Size = new System.Drawing.Size(72, 23);
            this.GroupClick.TabIndex = 189;
            this.GroupClick.Tag = "1";
            this.GroupClick.Text = "GroupClick";
            this.GroupClick.UseVisualStyleBackColor = false;
            this.GroupClick.Click += new System.EventHandler(this.GroupClick_Click);
            // 
            // AdditionClick
            // 
            this.AdditionClick.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.AdditionClick.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AdditionClick.FlatAppearance.BorderColor = System.Drawing.Color.Maroon;
            this.AdditionClick.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Green;
            this.AdditionClick.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.AdditionClick.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AdditionClick.Location = new System.Drawing.Point(1006, 459);
            this.AdditionClick.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.AdditionClick.Name = "AdditionClick";
            this.AdditionClick.Size = new System.Drawing.Size(72, 23);
            this.AdditionClick.TabIndex = 191;
            this.AdditionClick.Tag = "1";
            this.AdditionClick.Text = "AdditionClick";
            this.AdditionClick.UseVisualStyleBackColor = false;
            this.AdditionClick.Click += new System.EventHandler(this.AdditionClick_Click);
            // 
            // dataGridView3
            // 
            this.dataGridView3.AllowUserToAddRows = false;
            this.dataGridView3.AllowUserToDeleteRows = false;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridView3.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView3.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.dataGridView3.ColumnHeadersHeight = 4;
            this.dataGridView3.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn5});
            this.dataGridView3.Location = new System.Drawing.Point(2, 94);
            this.dataGridView3.Margin = new System.Windows.Forms.Padding(0);
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.ReadOnly = true;
            this.dataGridView3.RowHeadersWidth = 8;
            this.dataGridView3.RowTemplate.Height = 30;
            this.dataGridView3.RowTemplate.ReadOnly = true;
            this.dataGridView3.Size = new System.Drawing.Size(31, 362);
            this.dataGridView3.TabIndex = 192;
            this.dataGridView3.Tag = "-1";
            this.dataGridView3.Visible = false;
            this.dataGridView3.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView3_CellClick);
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.FillWeight = 10F;
            this.dataGridViewTextBoxColumn5.Frozen = true;
            this.dataGridViewTextBoxColumn5.HeaderText = "Column1";
            this.dataGridViewTextBoxColumn5.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn5.Width = 260;
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.label13.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(1170, 522);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(60, 23);
            this.label13.TabIndex = 196;
            this.label13.Text = "Tipmoney";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn,
            this.Column2});
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView1.Location = new System.Drawing.Point(442, 91);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 8;
            this.dataGridView1.RowTemplate.Height = 30;
            this.dataGridView1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridView1.Size = new System.Drawing.Size(341, 407);
            this.dataGridView1.TabIndex = 199;
            this.dataGridView1.Tag = "inorder";
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView1_CellFormatting);
            this.dataGridView1.MouseEnter += new System.EventHandler(this.dataGridView1_MouseEnter);
            // 
            // dataGridViewTextBoxColumn
            // 
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.dataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewTextBoxColumn.HeaderText = "Name";
            this.dataGridViewTextBoxColumn.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn.Name = "dataGridViewTextBoxColumn";
            this.dataGridViewTextBoxColumn.ReadOnly = true;
            this.dataGridViewTextBoxColumn.Width = 260;
            // 
            // Column2
            // 
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            this.Column2.DefaultCellStyle = dataGridViewCellStyle2;
            this.Column2.HeaderText = "Price";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 70;
            // 
            // ShtrichCode
            // 
            this.ShtrichCode.Location = new System.Drawing.Point(790, 94);
            this.ShtrichCode.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ShtrichCode.Name = "ShtrichCode";
            this.ShtrichCode.Size = new System.Drawing.Size(220, 22);
            this.ShtrichCode.TabIndex = 200;
            this.ShtrichCode.Text = "barcode";
            this.ShtrichCode.Enter += new System.EventHandler(this.ShtrichCode_Enter);
            this.ShtrichCode.Leave += new System.EventHandler(this.ShtrichCode_Leave);
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(1157, 69);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(67, 23);
            this.label12.TabIndex = 204;
            this.label12.Text = "Session";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Seans
            // 
            this.Seans.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Seans.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Seans.Location = new System.Drawing.Point(1163, 95);
            this.Seans.Name = "Seans";
            this.Seans.Size = new System.Drawing.Size(55, 20);
            this.Seans.TabIndex = 203;
            this.Seans.Text = "Seans";
            this.Seans.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panel1.Controls.Add(this.numericUpDown2);
            this.panel1.Controls.Add(this.label16);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Controls.Add(this.numericUpDown1);
            this.panel1.Controls.Add(this.PartnersComboBox);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Location = new System.Drawing.Point(1227, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(99, 116);
            this.panel1.TabIndex = 205;
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.BackColor = System.Drawing.Color.White;
            this.numericUpDown2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDown2.ForeColor = System.Drawing.Color.Black;
            this.numericUpDown2.Location = new System.Drawing.Point(46, 50);
            this.numericUpDown2.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDown2.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(49, 30);
            this.numericUpDown2.TabIndex = 239;
            this.numericUpDown2.Tag = "";
            this.numericUpDown2.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown2.Enter += new System.EventHandler(this.numericUpDown2_Enter);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.White;
            this.label16.Location = new System.Drawing.Point(7, 54);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(37, 18);
            this.label16.TabIndex = 238;
            this.label16.Text = "pers";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.White;
            this.label15.Location = new System.Drawing.Point(2, 88);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(43, 18);
            this.label15.TabIndex = 237;
            this.label15.Text = "guide";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.BackColor = System.Drawing.Color.White;
            this.numericUpDown1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDown1.ForeColor = System.Drawing.Color.Black;
            this.numericUpDown1.Location = new System.Drawing.Point(45, 82);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(49, 30);
            this.numericUpDown1.TabIndex = 236;
            this.numericUpDown1.Tag = "";
            this.numericUpDown1.Enter += new System.EventHandler(this.numericUpDown1_Enter);
            // 
            // PartnersComboBox
            // 
            this.PartnersComboBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.PartnersComboBox.Enabled = false;
            this.PartnersComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PartnersComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PartnersComboBox.FormattingEnabled = true;
            this.PartnersComboBox.Items.AddRange(new object[] {
            "",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31",
            "31",
            "33",
            "34",
            "35",
            "36",
            "37",
            "39",
            "40",
            "41",
            "42",
            "43",
            "44",
            "45",
            "46",
            "47",
            "48",
            "49",
            "50"});
            this.PartnersComboBox.Location = new System.Drawing.Point(10, 20);
            this.PartnersComboBox.Name = "PartnersComboBox";
            this.PartnersComboBox.Size = new System.Drawing.Size(83, 26);
            this.PartnersComboBox.TabIndex = 235;
            this.PartnersComboBox.SelectedValueChanged += new System.EventHandler(this.PartnersComboBox_SelectedValueChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.White;
            this.label14.Location = new System.Drawing.Point(2, 1);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(69, 18);
            this.label14.TabIndex = 234;
            this.label14.Text = "Order N#";
            // 
            // gid
            // 
            this.gid.BackColor = System.Drawing.Color.White;
            this.gid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.gid.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gid.Location = new System.Drawing.Point(1229, 470);
            this.gid.Name = "gid";
            this.gid.Size = new System.Drawing.Size(91, 23);
            this.gid.TabIndex = 206;
            this.gid.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.gid.Visible = false;
            // 
            // tab69
            // 
            this.tab69.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.tab69.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tab69.FlatAppearance.BorderColor = System.Drawing.Color.Maroon;
            this.tab69.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.tab69.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tab69.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tab69.ForeColor = System.Drawing.Color.Black;
            this.tab69.Location = new System.Drawing.Point(319, 459);
            this.tab69.Margin = new System.Windows.Forms.Padding(0);
            this.tab69.Name = "tab69";
            this.tab69.Size = new System.Drawing.Size(59, 39);
            this.tab69.TabIndex = 213;
            this.tab69.Text = "X";
            this.tab69.UseVisualStyleBackColor = false;
            this.tab69.Click += new System.EventHandler(this.tab69_Click);
            // 
            // tab70
            // 
            this.tab70.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.tab70.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tab70.FlatAppearance.BorderColor = System.Drawing.Color.Maroon;
            this.tab70.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.tab70.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tab70.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tab70.ForeColor = System.Drawing.Color.Black;
            this.tab70.Location = new System.Drawing.Point(379, 459);
            this.tab70.Margin = new System.Windows.Forms.Padding(0);
            this.tab70.Name = "tab70";
            this.tab70.Size = new System.Drawing.Size(60, 39);
            this.tab70.TabIndex = 212;
            this.tab70.Text = "=>";
            this.tab70.UseVisualStyleBackColor = false;
            this.tab70.Click += new System.EventHandler(this.tab70_Click);
            // 
            // tab68
            // 
            this.tab68.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.tab68.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tab68.FlatAppearance.BorderColor = System.Drawing.Color.Maroon;
            this.tab68.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.tab68.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tab68.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tab68.ForeColor = System.Drawing.Color.Black;
            this.tab68.Location = new System.Drawing.Point(256, 459);
            this.tab68.Margin = new System.Windows.Forms.Padding(0);
            this.tab68.Name = "tab68";
            this.tab68.Size = new System.Drawing.Size(60, 39);
            this.tab68.TabIndex = 211;
            this.tab68.Text = "68";
            this.tab68.UseVisualStyleBackColor = false;
            this.tab68.Click += new System.EventHandler(this.tab68_Click);
            this.tab68.MouseMove += new System.Windows.Forms.MouseEventHandler(this.tab68_MouseMove);
            // 
            // tab67
            // 
            this.tab67.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.tab67.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tab67.FlatAppearance.BorderColor = System.Drawing.Color.Maroon;
            this.tab67.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.tab67.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tab67.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tab67.ForeColor = System.Drawing.Color.Black;
            this.tab67.Location = new System.Drawing.Point(195, 459);
            this.tab67.Margin = new System.Windows.Forms.Padding(0);
            this.tab67.Name = "tab67";
            this.tab67.Size = new System.Drawing.Size(60, 39);
            this.tab67.TabIndex = 210;
            this.tab67.Text = "67";
            this.tab67.UseVisualStyleBackColor = false;
            this.tab67.Click += new System.EventHandler(this.tab67_Click);
            this.tab67.MouseMove += new System.Windows.Forms.MouseEventHandler(this.tab67_MouseMove);
            // 
            // tab66
            // 
            this.tab66.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.tab66.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tab66.FlatAppearance.BorderColor = System.Drawing.Color.Maroon;
            this.tab66.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.tab66.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tab66.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tab66.ForeColor = System.Drawing.Color.Black;
            this.tab66.Location = new System.Drawing.Point(133, 459);
            this.tab66.Margin = new System.Windows.Forms.Padding(0);
            this.tab66.Name = "tab66";
            this.tab66.Size = new System.Drawing.Size(60, 39);
            this.tab66.TabIndex = 209;
            this.tab66.Text = "66";
            this.tab66.UseVisualStyleBackColor = false;
            this.tab66.Click += new System.EventHandler(this.tab66_Click);
            this.tab66.MouseMove += new System.Windows.Forms.MouseEventHandler(this.tab66_MouseMove);
            // 
            // tab65
            // 
            this.tab65.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.tab65.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tab65.FlatAppearance.BorderColor = System.Drawing.Color.Maroon;
            this.tab65.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.tab65.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tab65.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tab65.ForeColor = System.Drawing.Color.Black;
            this.tab65.Location = new System.Drawing.Point(72, 459);
            this.tab65.Margin = new System.Windows.Forms.Padding(0);
            this.tab65.Name = "tab65";
            this.tab65.Size = new System.Drawing.Size(60, 39);
            this.tab65.TabIndex = 208;
            this.tab65.Text = "65";
            this.tab65.UseVisualStyleBackColor = false;
            this.tab65.Click += new System.EventHandler(this.tab65_Click);
            this.tab65.MouseMove += new System.Windows.Forms.MouseEventHandler(this.tab65_MouseMove);
            // 
            // tab64
            // 
            this.tab64.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.tab64.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tab64.FlatAppearance.BorderColor = System.Drawing.Color.Maroon;
            this.tab64.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.tab64.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tab64.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tab64.ForeColor = System.Drawing.Color.Black;
            this.tab64.Location = new System.Drawing.Point(11, 459);
            this.tab64.Margin = new System.Windows.Forms.Padding(0);
            this.tab64.Name = "tab64";
            this.tab64.Size = new System.Drawing.Size(60, 39);
            this.tab64.TabIndex = 207;
            this.tab64.Text = "64";
            this.tab64.UseVisualStyleBackColor = false;
            this.tab64.Click += new System.EventHandler(this.tab64_Click);
            this.tab64.MouseMove += new System.Windows.Forms.MouseEventHandler(this.tab64_MouseMove);
            // 
            // label18
            // 
            this.label18.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(1187, 470);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(40, 23);
            this.label18.TabIndex = 214;
            this.label18.Text = "-Gid";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // legend
            // 
            this.legend.BackColor = System.Drawing.Color.NavajoWhite;
            this.legend.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.legend.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.legend.Location = new System.Drawing.Point(806, 467);
            this.legend.Name = "legend";
            this.legend.Size = new System.Drawing.Size(91, 23);
            this.legend.TabIndex = 215;
            this.legend.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.legend.Visible = false;
            // 
            // cancel2
            // 
            this.cancel2.BackColor = System.Drawing.Color.White;
            this.cancel2.FlatAppearance.BorderColor = System.Drawing.Color.SaddleBrown;
            this.cancel2.FlatAppearance.BorderSize = 2;
            this.cancel2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancel2.ForeColor = System.Drawing.Color.Maroon;
            this.cancel2.Location = new System.Drawing.Point(854, 433);
            this.cancel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cancel2.Name = "cancel2";
            this.cancel2.Size = new System.Drawing.Size(80, 29);
            this.cancel2.TabIndex = 216;
            this.cancel2.Tag = "none";
            this.cancel2.Text = "release";
            this.cancel2.UseVisualStyleBackColor = false;
            this.cancel2.Visible = false;
            this.cancel2.Click += new System.EventHandler(this.cancel2_Click);
            // 
            // numericUpDown3
            // 
            this.numericUpDown3.BackColor = System.Drawing.Color.White;
            this.numericUpDown3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDown3.ForeColor = System.Drawing.Color.Black;
            this.numericUpDown3.Location = new System.Drawing.Point(1019, 63);
            this.numericUpDown3.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDown3.Name = "numericUpDown3";
            this.numericUpDown3.Size = new System.Drawing.Size(78, 30);
            this.numericUpDown3.TabIndex = 241;
            this.numericUpDown3.Tag = "";
            this.numericUpDown3.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown3.Enter += new System.EventHandler(this.numericUpDown3_Enter_1);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.White;
            this.label17.Location = new System.Drawing.Point(981, 67);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(41, 18);
            this.label17.TabIndex = 240;
            this.label17.Text = "pers.";
            // 
            // department5
            // 
            this.department5.BackColor = System.Drawing.Color.White;
            this.department5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.department5.FlatAppearance.BorderColor = System.Drawing.Color.Maroon;
            this.department5.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.department5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.department5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.department5.ForeColor = System.Drawing.Color.Maroon;
            this.department5.Location = new System.Drawing.Point(353, 62);
            this.department5.Margin = new System.Windows.Forms.Padding(0);
            this.department5.Name = "department5";
            this.department5.Size = new System.Drawing.Size(82, 25);
            this.department5.TabIndex = 190;
            this.department5.Text = "dep5";
            this.department5.UseVisualStyleBackColor = false;
            this.department5.Visible = false;
            this.department5.Click += new System.EventHandler(this.department5_Click);
            // 
            // HelpButton
            // 
            this.HelpButton.BackColor = System.Drawing.Color.Orange;
            this.HelpButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.HelpButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HelpButton.ForeColor = System.Drawing.Color.White;
            this.HelpButton.Location = new System.Drawing.Point(787, 403);
            this.HelpButton.Name = "HelpButton";
            this.HelpButton.Size = new System.Drawing.Size(35, 31);
            this.HelpButton.TabIndex = 242;
            this.HelpButton.Text = "?";
            this.HelpButton.UseVisualStyleBackColor = false;
            this.HelpButton.Click += new System.EventHandler(this.HelpButton_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Font = new System.Drawing.Font("Arial Unicode", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox1.Location = new System.Drawing.Point(738, 464);
            this.richTextBox1.Margin = new System.Windows.Forms.Padding(20, 3, 3, 3);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(29, 26);
            this.richTextBox1.TabIndex = 243;
            this.richTextBox1.Text = "";
            this.richTextBox1.Visible = false;
            // 
            // TipMoney
            // 
            this.TipMoney.BackColor = System.Drawing.Color.WhiteSmoke;
            this.TipMoney.Enabled = false;
            this.TipMoney.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TipMoney.Location = new System.Drawing.Point(1229, 520);
            this.TipMoney.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TipMoney.Multiline = true;
            this.TipMoney.Name = "TipMoney";
            this.TipMoney.Size = new System.Drawing.Size(91, 25);
            this.TipMoney.TabIndex = 244;
            this.TipMoney.Enter += new System.EventHandler(this.TipMoney_Enter);
            this.TipMoney.Leave += new System.EventHandler(this.TipMoney_Leave);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel2.Location = new System.Drawing.Point(-1, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1226, 56);
            this.panel2.TabIndex = 245;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.panel3.Location = new System.Drawing.Point(2, 61);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(437, 30);
            this.panel3.TabIndex = 246;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.RosyBrown;
            this.panel4.Location = new System.Drawing.Point(438, 59);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(347, 31);
            this.panel4.TabIndex = 247;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.panel5.Location = new System.Drawing.Point(-1, 501);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1169, 50);
            this.panel5.TabIndex = 247;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.panel6.Location = new System.Drawing.Point(1168, 400);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(158, 151);
            this.panel6.TabIndex = 248;
            // 
            // remove
            // 
            this.remove.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.remove.Cursor = System.Windows.Forms.Cursors.Hand;
            this.remove.FlatAppearance.BorderColor = System.Drawing.Color.Maroon;
            this.remove.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.remove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.remove.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.remove.Location = new System.Drawing.Point(691, 65);
            this.remove.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.remove.Name = "remove";
            this.remove.Size = new System.Drawing.Size(85, 25);
            this.remove.TabIndex = 52;
            this.remove.Text = "move";
            this.remove.UseVisualStyleBackColor = false;
            this.remove.Visible = false;
            this.remove.Click += new System.EventHandler(this.remove_Click);
            // 
            // radioButton1
            // 
            this.radioButton1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.radioButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radioButton1.Location = new System.Drawing.Point(451, 67);
            this.radioButton1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(77, 19);
            this.radioButton1.TabIndex = 53;
            this.radioButton1.TabStop = true;
            this.radioButton1.Tag = "0";
            this.radioButton1.Text = "there is";
            this.radioButton1.UseVisualStyleBackColor = false;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.BackColor = System.Drawing.Color.Yellow;
            this.radioButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radioButton2.Location = new System.Drawing.Point(537, 67);
            this.radioButton2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(63, 18);
            this.radioButton2.TabIndex = 143;
            this.radioButton2.TabStop = true;
            this.radioButton2.Tag = "0";
            this.radioButton2.Text = "none";
            this.radioButton2.UseVisualStyleBackColor = false;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // radioButton3
            // 
            this.radioButton3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.radioButton3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radioButton3.Location = new System.Drawing.Point(606, 66);
            this.radioButton3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(78, 19);
            this.radioButton3.TabIndex = 144;
            this.radioButton3.TabStop = true;
            this.radioButton3.Tag = "0";
            this.radioButton3.Text = "tosell";
            this.radioButton3.UseVisualStyleBackColor = false;
            this.radioButton3.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
            // 
            // order
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(1327, 552);
            this.Controls.Add(this.TipMoney);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.HelpButton);
            this.Controls.Add(this.numericUpDown3);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.cancel2);
            this.Controls.Add(this.legend);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.tab69);
            this.Controls.Add(this.tab70);
            this.Controls.Add(this.tab68);
            this.Controls.Add(this.tab67);
            this.Controls.Add(this.tab66);
            this.Controls.Add(this.tab65);
            this.Controls.Add(this.tab64);
            this.Controls.Add(this.gid);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.Seans);
            this.Controls.Add(this.ShtrichCode);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.dataGridView3);
            this.Controls.Add(this.AdditionClick);
            this.Controls.Add(this.department5);
            this.Controls.Add(this.GroupClick);
            this.Controls.Add(this.DepartmentClick);
            this.Controls.Add(this.addition12);
            this.Controls.Add(this.addition20);
            this.Controls.Add(this.addition16);
            this.Controls.Add(this.addition17);
            this.Controls.Add(this.addition18);
            this.Controls.Add(this.addition19);
            this.Controls.Add(this.addition15);
            this.Controls.Add(this.addition13);
            this.Controls.Add(this.addition14);
            this.Controls.Add(this.addition11);
            this.Controls.Add(this.addition2);
            this.Controls.Add(this.radioButton3);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.tab62);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.total);
            this.Controls.Add(this.discount);
            this.Controls.Add(this.service);
            this.Controls.Add(this.amount);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.printbutton2);
            this.Controls.Add(this.printbutton1);
            this.Controls.Add(this.accept);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.backspace);
            this.Controls.Add(this.open_nest);
            this.Controls.Add(this.number_delete);
            this.Controls.Add(this.number_point);
            this.Controls.Add(this.number_enter);
            this.Controls.Add(this.number9);
            this.Controls.Add(this.number7);
            this.Controls.Add(this.number6);
            this.Controls.Add(this.number5);
            this.Controls.Add(this.number4);
            this.Controls.Add(this.number0);
            this.Controls.Add(this.number2);
            this.Controls.Add(this.number1);
            this.Controls.Add(this.number3);
            this.Controls.Add(this.number8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tab63);
            this.Controls.Add(this.tab61);
            this.Controls.Add(this.tab60);
            this.Controls.Add(this.tab59);
            this.Controls.Add(this.tab58);
            this.Controls.Add(this.tab57);
            this.Controls.Add(this.tab56);
            this.Controls.Add(this.tab55);
            this.Controls.Add(this.tab54);
            this.Controls.Add(this.tab53);
            this.Controls.Add(this.tab52);
            this.Controls.Add(this.tab51);
            this.Controls.Add(this.tab50);
            this.Controls.Add(this.tab49);
            this.Controls.Add(this.tab48);
            this.Controls.Add(this.tab47);
            this.Controls.Add(this.tab46);
            this.Controls.Add(this.tab45);
            this.Controls.Add(this.tab44);
            this.Controls.Add(this.tab43);
            this.Controls.Add(this.tab42);
            this.Controls.Add(this.tab41);
            this.Controls.Add(this.tab40);
            this.Controls.Add(this.tab39);
            this.Controls.Add(this.tab38);
            this.Controls.Add(this.tab37);
            this.Controls.Add(this.tab36);
            this.Controls.Add(this.tab35);
            this.Controls.Add(this.tab34);
            this.Controls.Add(this.tab33);
            this.Controls.Add(this.tab32);
            this.Controls.Add(this.tab31);
            this.Controls.Add(this.tab30);
            this.Controls.Add(this.tab29);
            this.Controls.Add(this.tab28);
            this.Controls.Add(this.tab27);
            this.Controls.Add(this.tab26);
            this.Controls.Add(this.tab25);
            this.Controls.Add(this.tab24);
            this.Controls.Add(this.tab23);
            this.Controls.Add(this.tab22);
            this.Controls.Add(this.tab21);
            this.Controls.Add(this.tab20);
            this.Controls.Add(this.tab19);
            this.Controls.Add(this.tab18);
            this.Controls.Add(this.tab17);
            this.Controls.Add(this.tab16);
            this.Controls.Add(this.tab15);
            this.Controls.Add(this.tab14);
            this.Controls.Add(this.tab13);
            this.Controls.Add(this.tab12);
            this.Controls.Add(this.tab11);
            this.Controls.Add(this.tab10);
            this.Controls.Add(this.tab9);
            this.Controls.Add(this.tab8);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.remove);
            this.Controls.Add(this.tab7);
            this.Controls.Add(this.tab6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.department4);
            this.Controls.Add(this.department3);
            this.Controls.Add(this.department2);
            this.Controls.Add(this.department1);
            this.Controls.Add(this.ManagerBox);
            this.Controls.Add(this.tab5);
            this.Controls.Add(this.tab4);
            this.Controls.Add(this.tab3);
            this.Controls.Add(this.tab2);
            this.Controls.Add(this.command);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.bill);
            this.Controls.Add(this.nest);
            this.Controls.Add(this.tab1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.group16);
            this.Controls.Add(this.group17);
            this.Controls.Add(this.group18);
            this.Controls.Add(this.group19);
            this.Controls.Add(this.group20);
            this.Controls.Add(this.group21);
            this.Controls.Add(this.group22);
            this.Controls.Add(this.group23);
            this.Controls.Add(this.group24);
            this.Controls.Add(this.group25);
            this.Controls.Add(this.group26);
            this.Controls.Add(this.group27);
            this.Controls.Add(this.group28);
            this.Controls.Add(this.group29);
            this.Controls.Add(this.group30);
            this.Controls.Add(this.group11);
            this.Controls.Add(this.group12);
            this.Controls.Add(this.group13);
            this.Controls.Add(this.group14);
            this.Controls.Add(this.group15);
            this.Controls.Add(this.group9);
            this.Controls.Add(this.group10);
            this.Controls.Add(this.group5);
            this.Controls.Add(this.group6);
            this.Controls.Add(this.group7);
            this.Controls.Add(this.group8);
            this.Controls.Add(this.group3);
            this.Controls.Add(this.group4);
            this.Controls.Add(this.group2);
            this.Controls.Add(this.group1);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.addition10);
            this.Controls.Add(this.addition6);
            this.Controls.Add(this.addition7);
            this.Controls.Add(this.addition8);
            this.Controls.Add(this.addition9);
            this.Controls.Add(this.addition5);
            this.Controls.Add(this.addition3);
            this.Controls.Add(this.addition4);
            this.Controls.Add(this.addition1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel6);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "order";
            this.Load += new System.EventHandler(this.order_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        public void InitForm()
        {

            float screenWidth = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width;
            float screenHeight = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height;

            //   Screen primaryScreen = Screen.PrimaryScreen;
            //   int screenWidth = primaryScreen.Bounds.Width;
            //   int screenHeigh = primaryScreen.Bounds.Height;
            float kw = screenWidth / this.Width;
            float kh = screenHeight / this.Height;
            foreach (Control control in this.Controls)
            {
                // Փոփոխվում են օբյեկների չափն ու տեղադրությունը ** Objects are resized and positioned
                control.Left = (int)(control.Left * (double)kw);
                control.Top = (int)(control.Top * (double)kh);
                control.Width = (int)(control.Width * (double)kw);
                control.Height = (int)(control.Height * (double)kh);
            }
            dataGridView1.Columns[0].Width = (int)(dataGridView1.Columns[0].Width * 1.15);
            dataGridView1.Columns[1].Width = (int)(dataGridView1.Columns[1].Width * 1.15);
            dataGridView2.Columns[0].Width = (int)(dataGridView2.Columns[0].Width * 1.15);
            dataGridView2.Columns[1].Width = (int)(dataGridView2.Columns[1].Width * 1.15);
            dataGridView2.Columns[2].Width = (int)(dataGridView2.Columns[2].Width * 1.15);
            dataGridView2.Columns[3].Width = (int)(dataGridView2.Columns[3].Width * 1.15);

            foreach (Control control in panel1.Controls)
            {
                control.Width = (int)(control.Width * kw);
                control.Height = (int)(control.Height * kh);
                control.Top = (int)(control.Top * kh);
                control.Left = (int)(control.Left * kw);
            }

            this.Width = (int)screenWidth;
            this.Height = (int)screenHeight;
            this.Top = 0;
            this.Left = 0;
            /////////////////////////////////////////////// 
            //NestUpdate();

        }
        #endregion
        private System.Windows.Forms.Button group1;
        private System.Diagnostics.Process process1;
        private Button group16;
        private Button group17;
        private Button group18;
        private Button group19;
        private Button group20;
        private Button group21;
        private Button group22;
        private Button group23;
        private Button group24;
        private Button group25;
        private Button group26;
        private Button group27;
        private Button group28;
        private Button group29;
        private Button group30;
        private Button group11;
        private Button group12;
        private Button group13;
        private Button group14;
        private Button group15;
        private Button group9;
        private Button group10;
        private Button group5;
        private Button group6;
        private Button group7;
        private Button group8;
        private Button group3;
        private Button group4;
        private Button tab1;
        private Label label1;
        private Label nest;
        private Label label3;
        private Label bill;
        private Button command;
        private Button tab5;
        private Button tab4;
        private Button tab3;
        private Button tab2;
        private TextBox ManagerBox;
        private Button department4;
        private Button department3;
        private Button department2;
        private Button department1;
        private Label label5;
        private Label label4;
        private Button tab7;
        private Button tab6;
        private Button tab14;
        private Button tab13;
        private Button tab12;
        private Button tab11;
        private Button tab10;
        private Button tab9;
        private Button tab8;
        private Button tab28;
        private Button tab27;
        private Button tab26;
        private Button tab25;
        private Button tab24;
        private Button tab23;
        private Button tab22;
        private Button tab21;
        private Button tab20;
        private Button tab19;
        private Button tab18;
        private Button tab17;
        private Button tab16;
        private Button tab15;
        private Button tab35;
        private Button tab34;
        private Button tab33;
        private Button tab32;
        private Button tab31;
        private Button tab30;
        private Button tab29;
        private Button tab42;
        private Button tab41;
        private Button tab40;
        private Button tab39;
        private Button tab38;
        private Button tab37;
        private Button tab36;
        private Button tab49;
        private Button tab48;
        private Button tab47;
        private Button tab46;
        private Button tab45;
        private Button tab44;
        private Button tab43;
        private Button tab56;
        private Button tab55;
        private Button tab54;
        private Button tab53;
        private Button tab52;
        private Button tab51;
        private Button tab50;
        private Button tab63;
        private Button tab61;
        private Button tab60;
        private Button tab59;
        private Button tab58;
        private Button tab57;
        private Label label6;
        private Button backspace;
        private Button open_nest;
        private Button number_delete;
        private Button number_point;
        private Button number_enter;
        private Button number9;
        private Button number7;
        private Button number6;
        private Button number5;
        private Button number4;
        private Button number0;
        private Button number2;
        private Button number1;
        private Button number3;
        private Button number8;
        private Label label7;
        private Button accept;
        private Button printbutton1;
        private Button cancel;
        private Button printbutton2;
        private DataGridView dataGridView2;
        private Label total;
        private Label discount;
        private Label service;
        private Label amount;
        private Label label10;
        private Label label9;
        private Label label8;
        private Label label2;
        private Button tab62;
        private Label label11;
        private Button addition10;
        private Button addition6;
        private Button addition7;
        private Button addition8;
        private Button addition9;
        private Button addition5;
        private Button addition3;
        private Button addition4;
        private Button addition1;
        private Button addition2;
        private Button addition12;
        private Button addition20;
        private Button addition16;
        private Button addition17;
        private Button addition18;
        private Button addition19;
        private Button addition15;
        private Button addition13;
        private Button addition14;
        private Button addition11;
        private Button DepartmentClick;
        private Button GroupClick;
        private Button AdditionClick;
        private DataGridView dataGridView3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private Label label13;
        private DataGridView dataGridView1;
        private TextBox ShtrichCode;
        private Label label12;
        private Label Seans;
        private Panel panel1;
        private Label label14;
        private ComboBox PartnersComboBox;
        private Label label15;
        private NumericUpDown numericUpDown1;
        private Label label16;
        private NumericUpDown numericUpDown2;
        private Label gid;
        private Button tab69;
        private Button tab70;
        private Button tab68;
        private Button tab67;
        private Button tab66;
        private Button tab65;
        private Button tab64;
        private Label label18;
        private Label legend;
        private Button cancel2;
        private NumericUpDown numericUpDown3;
        private Label label17;
        private Button HelpButton;
        private Button department5;
        private RichTextBox richTextBox1;
        private TextBox TipMoney;
        private Button group2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private Panel panel2;
        private Panel panel3;
        private Panel panel4;
        private Panel panel5;
        private Panel panel6;
        private RadioButton radioButton3;
        private RadioButton radioButton2;
        private RadioButton radioButton1;
        private Button remove;
    }
}