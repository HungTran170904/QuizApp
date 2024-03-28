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
    public partial class FormEnd : Form
    {
        public FormEnd()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            podiumForm form = new podiumForm(); 
            form.ShowDialog();  
        }
    }
}
