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
    public partial class formcontrol : Form
    {
        public formcontrol()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MainForm f = new MainForm();
            f.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            formJoin f=new formJoin();
            f.Show();
        }
    }
}
