using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSDL_CSharp
{
    public partial class _03 : Form
    {
        SqlConnection conn = null;
        SqlCommand cmd = null;
        public _03()
        {
            InitializeComponent();
        }

        private void _03_Load(object sender, EventArgs e)
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

        private void dgvCustomer_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            int idx = e.RowIndex;
            txtId.Text = dgvCustomer.Rows[idx].Cells[0].Value.ToString();
            txtname.Text = dgvCustomer.Rows[idx].Cells[1].Value.ToString();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=TUPHAM\SQLEXPRESS;Initial Catalog=sale;User ID=sa;Password=sa";
            conn.Open();
            cmd = new SqlCommand("insert into customer values(@id,@name)", conn);
            cmd.Parameters.Add(new SqlParameter("@id", txtId.Text));
            cmd.Parameters.Add(new SqlParameter("@name", txtname.Text));
            cmd.ExecuteNonQuery();
            conn.Close();
            dgvCustomer.Rows.Add(txtId.Text, txtname.Text);

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=TUPHAM\SQLEXPRESS;Initial Catalog=sale;User ID=sa;Password=sa";
            conn.Open();
            cmd = new SqlCommand("update customer set name = @name where id= @id" , conn);
            cmd.Parameters.Add(new SqlParameter("@id", txtId.Text));
            cmd.Parameters.Add(new SqlParameter("@name", txtname.Text));

            cmd.ExecuteNonQuery();
            conn.Close();
            int idx = dgvCustomer.CurrentCell.RowIndex;
            dgvCustomer.Rows[idx].Cells[1].Value = txtname.Text;
            dgvCustomer.Rows[idx].Cells[0].Value = txtId.Text;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=TUPHAM\SQLEXPRESS;Initial Catalog=sale;User ID=sa;Password=sa";
            conn.Open();
            cmd = new SqlCommand("delete from customer where id= @id" , conn);
            cmd.Parameters.Add(new SqlParameter("@id", txtId.Text));

            cmd.ExecuteNonQuery();
            conn.Close();

            int idx = dgvCustomer.CurrentCell.RowIndex;
            dgvCustomer.Rows.RemoveAt(idx);
        }
    }
}
