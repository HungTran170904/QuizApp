using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuizApp_frontend.FormHost
{
    public partial class NameCategory : Form
    {
        public NameCategory()
        {
            InitializeComponent();
        }

        private void txtname_Enter(object sender, EventArgs e)
        {
            if (txtname.Text == "Name")
            {
                txtname.Text = "";
            }
            txtname.ForeColor = Color.Black;
        }

        private void txtname_Leave(object sender, EventArgs e)
        {
            if (txtname.Text == "")
            {
                txtname.Text = "Name";
                txtname.ForeColor = Color.Silver;
            }

        }

        private void txtcategory_Enter(object sender, EventArgs e)
        {
            if (txtcategory.Text == "Category")
            {
                txtcategory.Text = "";
            }
            txtcategory.ForeColor = Color.Black;
        }

        private void txtcategory_Leave(object sender, EventArgs e)
        {
            if (txtcategory.Text == "")
            {
                txtcategory.Text = "Category";
                txtcategory.ForeColor = Color.Silver;
            }

        }

        private void btnnext_Click(object sender, EventArgs e)
        {
            FormData formData = new FormData();
            formData.UserName = txtname.Text;
            formData.CategoryName = txtcategory.Text;

            this.Hide();
            Form form1 = new Form1(formData);
            form1.Show();
        }

        private void txtname_TextChanged(object sender, EventArgs e)
        {

        }
    }
    public class FormData
    {
        public string UserName { get; set; }
        public string CategoryName { get; set; }
    }

}
