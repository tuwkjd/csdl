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
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void btn01_Click(object sender, EventArgs e)
        {
            Bai1 ob1=new Bai1();
            ob1.Show();
        }

        private void btn02_Click(object sender, EventArgs e)
        {
            _02 ob2 = new _02();
            ob2.Show();
        }

        private void btn03_Click(object sender, EventArgs e)
        {
            _03 ob3 = new _03();
            ob3.Show();
        }

        private void btn04_Click(object sender, EventArgs e)
        {
            _04 ob4 = new _04();
            ob4.Show();

        }

        private void btn05_Click(object sender, EventArgs e)
        {
            _05 ob4 = new _05();
            ob4.Show();
        }
    }
}
