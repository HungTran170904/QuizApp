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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
           
        }

         string _userName;
         string _categoryName;

        public string ShowListContent
        {
            get { return rtbshowlist.Text; }
        }
        public Form1(FormData formData)
        {
            InitializeComponent();
            _userName = formData.UserName;
            _categoryName = formData.CategoryName;
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

        private void txtback_Click(object sender, EventArgs e)
        {
            Hide();
            Form NameCategory = new NameCategory();
            NameCategory.Show();
        }

        private void txtnext_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form Confirm = new Confirm(this.ShowListContent,_userName,_categoryName);
            Confirm.Show();
        }

        private void txttime_TextChanged(object sender, EventArgs e)
        {

        }

        private void rtbshowlist_TextChanged(object sender, EventArgs e)
        {

        }
        public int dem = 1;
        private void btnadd_Click(object sender, EventArgs e)
        {

            
                // Lấy câu hỏi từ TextBox
                string question = txtquestion.Text;

                // Lấy đáp án từ ComboBox
                string answer = comboBox1.SelectedItem.ToString();
            
                // Kiểm tra xem câu hỏi và đáp án có được nhập đầy đủ hay không
                if (!string.IsNullOrEmpty(question) && !string.IsNullOrEmpty(answer))
                {
                    // Tạo chuỗi mới chứa câu hỏi và đáp án
                    string newQuestion = $"Question:{dem}\n{question} Answer: {answer}\n";

                    // Thêm chuỗi mới vào RichTextBox
                    rtbshowlist.AppendText(newQuestion);

                    // Xóa nội dung trong TextBox và ComboBox sau khi đã thêm vào RichTextBox
                    txtquestion.Text = "Type question here";
                    comboBox1.SelectedIndex = -1; // Reset ComboBox về trạng thái không chọn
                dem++;
            }
                else
                {
                    // Hiển thị thông báo yêu cầu nhập đầy đủ thông tin
                    MessageBox.Show("Please fill in all fields.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}