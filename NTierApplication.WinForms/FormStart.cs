using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NTierApplication.WinForms
{
    public partial class FormStart : Form
    {
        public FormStart()
        {
            InitializeComponent();
        }

         
        private void buttonProduct_Click(object sender, EventArgs e)
        {
            ProductForm frm = new ProductForm();
            frm.Show();
        }

        private void buttonCategory_Click(object sender, EventArgs e)
        {
            CategoryForm frm = new CategoryForm();
            frm.Show();
        }
    }
}
