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
    public partial class _05 : Form
    {
        CustomerBAL cusBAL = new CustomerBAL();
        AreaBAL areaBAL = new AreaBAL();

        public _05()
        {
            InitializeComponent();
        }

        private void _05_Load(object sender, EventArgs e)
        {
            List<CustomerBEL> lstCus = cusBAL.ReadCus();
            foreach(CustomerBEL cus in lstCus)
            {
                dgvCustomer.Rows.Add(cus.Id, cus.Name, cus.AreaName);
            }
            List<AreaBEL> lstArea = areaBAL.ReadAreaList();
            foreach(AreaBEL areaBEL in lstArea)
            {
                cbKhuVuc.Items.Add(areaBEL);
            }
            cbKhuVuc.DisplayMember = "name";
        }

        private void dgvCustomer_RowEnter(object sender, DataGridViewCellEventArgs e)
        {

            int idx = e.RowIndex;
            DataGridViewRow row=dgvCustomer.Rows[idx];
            if (row.Cells[0].Value !=null)
            {
                txtId.Text = row.Cells[0].Value.ToString();
                txtname.Text = row.Cells[1].Value.ToString();
                cbKhuVuc.Text =row.Cells[2].Value.ToString();

            }
            
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            CustomerBEL cus=new CustomerBEL();
            cus.Id = int.Parse(txtId.Text);
            cus.Name = txtname.Text;
            cus.Area = (AreaBEL)cbKhuVuc.SelectedItem;
            cusBAL.NewCustomer(cus);

            dgvCustomer.Rows.Add(cus.Id, cus.Name, cus.Area.Name);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            CustomerBEL cus = new CustomerBEL();
            cus.Id = int.Parse(txtId.Text);
            cus.Name = txtname.Text;
            cus.Area = (AreaBEL)cbKhuVuc.SelectedItem;
            cusBAL.EditCus(cus);

            DataGridViewRow row = dgvCustomer.CurrentRow;
            row.Cells[0].Value = cus.Id;
            row.Cells[1].Value = cus.Name;
            row.Cells[2].Value = cus.AreaName;
        }
    }
}
