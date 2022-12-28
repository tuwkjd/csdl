using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CSDL_CSharp
{
    public partial class Bai1 : Form
    {
        SqlConnection conn = null;
        SqlCommand cmd = null;
        public Bai1()
        {
            InitializeComponent();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=TUPHAM\SQLEXPRESS;Initial Catalog=sale;User ID=sa;Password=sa";
            conn.Open();
            cmd = new SqlCommand();
            cmd.CommandText = "insert into customer values(3,'Nguyen Van C')";
            cmd.Connection = conn;
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=TUPHAM\SQLEXPRESS;Initial Catalog=sale;User ID=sa;Password=sa";
            conn.Open();
            cmd = new SqlCommand("delete from customer where id=2",conn);
            
          
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=TUPHAM\SQLEXPRESS;Initial Catalog=sale;User ID=sa;Password=sa";
            conn.Open();
            cmd = new SqlCommand("update customer set name ='Nguyen Van Z' where id=5", conn);


            cmd.ExecuteNonQuery();
            conn.Close();
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=TUPHAM\SQLEXPRESS;Initial Catalog=sale;User ID=sa;Password=sa";
            conn.Open();
            cmd = new SqlCommand("select *from customer", conn);
            SqlDataReader read = cmd.ExecuteReader();
            if (read.HasRows)
            {
                while (read.Read())
                {
                    dgvCustomer.Rows.Add(read.GetInt32(0), read.GetString(1));
                }
            }
            conn.Close();


        } 
        
    }
}
