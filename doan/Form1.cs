using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace doan
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
           
        }



        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void txtA_Enter(object sender, EventArgs e)
        {
            if (txtA.Text == "Answer A")
            {
                txtA.Text = "";
            }
        }
        private void txtA_Leave(object sender, EventArgs e)
        {
            if (txtA.Text == "")
            {
                txtA.Text = "Answer A";
            }
        }
     

        private void txtB_Enter(object sender, EventArgs e)
        {
            if(txtB.Text == "Answer B")
            {
                txtB.Text = "";
            }
        }

        private void txtB_Leave(object sender, EventArgs e)
        {
            if (txtB.Text == "")
            {
                txtB.Text = "Answer B";
            }
        }

        private void txtC_Enter(object sender, EventArgs e)
        {
            if(txtC.Text == "Answer C")
            {
                txtC.Text = "";
            }
        }

        private void txtC_Leave(object sender, EventArgs e)
        {
            if (txtC.Text == "")
            {
                txtC.Text = "Answer C";
            }
        }

        private void txtD_Enter(object sender, EventArgs e)
        {
            if(txtD.Text == "Answer D")
            {
                txtD.Text = "";
            }
        }

        private void txtD_Leave(object sender, EventArgs e)
        {
            if (txtD.Text == "")
            {
                txtD.Text = "Answer D";
            }
        }

        private void txtquestion_Enter(object sender, EventArgs e)
        {
            if(txtquestion.Text == "Type question here")
            {
                txtquestion.Text = "";
            }
        }

        private void txtquestion_Leave(object sender, EventArgs e)
        {
            if (txtquestion.Text == "")
            {
                txtquestion.Text = "Type question here";
            }
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if(txttime.Text=="Enter timeout here")
            {
                txttime.Text = "";
            }
        }

        private void txttime_Leave(object sender, EventArgs e)
        {
            if(txttime.Text == "")
            {
                txttime.Text = "Enter timeout here";
            }
        }

        private void txttime_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}