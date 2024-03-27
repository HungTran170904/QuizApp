using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuizApp_frontend
{
    public partial class formJoin : Form
    {
        public formJoin()
        {
            InitializeComponent();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            FormNguoichoi.formHangCho f1=new FormNguoichoi.formHangCho(richTextBox1.Text,richTextBox2.Text);
            f1.ShowDialog();
            
        }
    }
}
