using System.Linq.Expressions;

namespace QuizApp_frontend
{
    public partial class FormDangnhap : Form
    {
        public FormDangnhap()
        {
            InitializeComponent();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            try
            {
                FormDangKi dki = new FormDangKi();
                dki.ShowDialog();
            }

            catch (Exception ex)
            {
                MessageBox.Show("invalid");
            }

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            formJoin join=new formJoin();
            join.ShowDialog();
        }
    }
}
