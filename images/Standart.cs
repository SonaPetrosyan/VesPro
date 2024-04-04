using Amazon.DynamoDBv2;
using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using MySqlX.XDevAPI.Relational;
using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Windows.Forms;



namespace WindowsFormsApp4.images
{
    public partial class Standart : Form
    {
        private int _restaurant;

        private MySQLDatabaseHelper dbHelper;

        private BindingSource bindingSource = new BindingSource();

        private DataTable Table_215 = new DataTable(); 

        private DataTable FoodGroupp = new DataTable();

        private DataTable Department = new DataTable();

        private DataTable CurrentOrder = new DataTable();   

        private DataTable Table_Restaurants = new DataTable();  
        public Standart(int restaurant)
        {
            InitializeComponent();
            _restaurant = restaurant;
        }
    }
}
