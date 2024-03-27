using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuizApp_frontend.FormNguoichoi
{
    public partial class formHangCho : Form
    {
        public formHangCho()
        {
            InitializeComponent();
        }
        public formHangCho(string t, string s)
        {
            InitializeComponent();
            textBox1.Text = s;
            textBox2.Text = t;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
