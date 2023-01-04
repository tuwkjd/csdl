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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace KT02
{
    public partial class KT : Form
    {

        SqlConnection conn = null;
       
        SqlCommand cmd = null;
        public KT()
        {
            InitializeComponent();
        }

        private void KT_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=TUPHAM\SQLEXPRESS;Initial Catalog=HR;Persist Security Info=True;User ID=sa; Password=sa";
            conn.Open();
             cmd = new SqlCommand("SELECT Employee.IdEmployee,Employee.Name, Employee.DateBirth,Employee.Gender,Employee.PlaceBirth,Department.Name FROM Employee " +
                "INNER JOIN Department ON Department.IdDepartment=Employee.IdDepartment", conn);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    dgvDanhSach.Rows.Add(reader.GetString(0), reader.GetString(1), reader.GetDateTime(2), reader.GetBoolean(3), reader.GetString(4), reader.GetString(5));
                }
            }
            conn.Close();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=TUPHAM\SQLEXPRESS;Initial Catalog=HR;Persist Security Info=True;User ID=sa; Password=sa";
            conn.Open();
             cmd = new SqlCommand("INSERT INTO Employee VALUES( @IdEmployee, @Name, @DateBirth, @Gender, @PlaceBirth,@NameDepartment)", conn);
            cmd.Parameters.Add(new SqlParameter("@IdEmployee", txtMa.Text));
            cmd.Parameters.Add(new SqlParameter("@Name", txtHoTen.Text));
            cmd.Parameters.Add(new SqlParameter("@DateBirth", dtpNgaySinh.Text));
            cmd.Parameters.Add(new SqlParameter("@Gender", chbGioiTinh.Checked));
            cmd.Parameters.Add(new SqlParameter("@PlaceBirth", txtNoiSinh.Text));
            cmd.Parameters.Add(new SqlParameter("@NameDepartment", cbDonVi.Text));
            cmd.ExecuteReader();
            conn.Close();
            dgvDanhSach.Rows.Add(txtMa.Text, txtHoTen.Text, dtpNgaySinh.Text, chbGioiTinh.Checked, txtNoiSinh.Text, cbDonVi.Text);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
             conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=TUPHAM\SQLEXPRESS;Initial Catalog=HR;Persist Security Info=True;User ID=sa; Password=sa";
            conn.Open();
             cmd = new SqlCommand("delete from Employee where IdEmployee=@IdEmployee", conn);
            cmd.Parameters.Add(new SqlParameter("@IdEmployee", txtMa.Text));
            cmd.ExecuteNonQuery();
            conn.Close();
            int idx = dgvDanhSach.CurrentCell.RowIndex;
            dgvDanhSach.Rows.RemoveAt(idx);

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
             conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=TUPHAM\SQLEXPRESS;Initial Catalog=HR;Persist Security Info=True;User ID=sa; Password=sa";
            conn.Open();
             cmd = new SqlCommand("update Employee set Name=@Name, DateBirth=@DateBirth,PlaceBirth=@PlaceBirth, Gender=@Gender, IdDepartment=@IdDepartment where IdEmployee=@IdEmployee", conn);
            cmd.Parameters.Add(new SqlParameter("@IdEmployee", txtMa.Text));
            cmd.Parameters.Add(new SqlParameter("@DateBirth", dtpNgaySinh.Text));
            cmd.Parameters.Add(new SqlParameter("@PlaceBirth", txtNoiSinh.Text));
            cmd.Parameters.Add(new SqlParameter("@Name", txtHoTen.Text));
            cmd.Parameters.Add(new SqlParameter("@Gender", chbGioiTinh.Checked));
            cmd.Parameters.Add(new SqlParameter("@IdDepartment", cbDonVi.Text));
            cmd.ExecuteNonQuery();
            conn.Close();
            int idx = dgvDanhSach.CurrentCell.RowIndex;
            dgvDanhSach.Rows[idx].Cells[0].Value = txtMa.Text;
            dgvDanhSach.Rows[idx].Cells[1].Value = txtHoTen.Text;
            dgvDanhSach.Rows[idx].Cells[2].Value = dtpNgaySinh.Text;
            dgvDanhSach.Rows[idx].Cells[3].Value = chbGioiTinh.Checked;
            dgvDanhSach.Rows[idx].Cells[4].Value = txtNoiSinh.Text;
            dgvDanhSach.Rows[idx].Cells[5].Value = cbDonVi.Text;

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {

            btnThoat.Enabled = true;
            DialogResult result = MessageBox.Show("Bạn có muốn đóng chương trình không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void dgvDanhSach_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            int idx = e.RowIndex;
            DataGridViewRow row = dgvDanhSach.Rows[idx];
            if (row.Cells[0].Value != null)
            {
                txtMa.Text = row.Cells[0].Value.ToString();
                txtHoTen.Text = row.Cells[1].Value.ToString();
                dtpNgaySinh.CustomFormat = row.Cells[2].Value.ToString();
                cbDonVi.Text = row.Cells[5].Value.ToString();
                txtNoiSinh.Text = row.Cells[4].Value.ToString();
                chbGioiTinh.Checked = bool.Parse(dgvDanhSach.Rows[idx].Cells[3].Value.ToString());
            }
        }
    }
}
