using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSDL_CSharp
{
    public partial class _04 : Form
    {
        CustomerBAL cusBAL = new CustomerBAL();
        public _04()
        {
            InitializeComponent();
        }

        private void _04_Load(object sender, EventArgs e)
        {
            List<CustomerBEL> lstCus = cusBAL.ReadCus();
            foreach(CustomerBEL cus in lstCus)
            {
                dgvCustomer.Rows.Add(cus.Id, cus.Name);
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            CustomerBEL cus = new CustomerBEL();
            cus.Id = int.Parse(txtId.Text);
            cus.Name= txtname.Text;
            cusBAL.NewCustomer(cus);
            dgvCustomer.Rows.Add(cus.Id, cus.Name);

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            CustomerBEL cus = new CustomerBEL();
            cus.Id = int.Parse(txtId.Text);
            cus.Name = txtname.Text;
            cusBAL.DeleteCus(cus);

            int idx = dgvCustomer.CurrentCell.RowIndex;
            dgvCustomer.Rows.RemoveAt(idx);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

            CustomerBEL cus = new CustomerBEL();
            cus.Id = int.Parse(txtId.Text);
            cus.Name = txtname.Text;
            cusBAL.EditCus(cus);

            DataGridViewRow row = dgvCustomer.CurrentRow;
            row.Cells[0].Value = cus.Id;
            row.Cells[1].Value = cus.Name;
        }

        private void dgvCustomer_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            int idx = e.RowIndex;
            txtId.Text = dgvCustomer.Rows[idx].Cells[0].Value.ToString();
            txtname.Text = dgvCustomer.Rows[idx].Cells[1].Value.ToString();
        }
    }
}
