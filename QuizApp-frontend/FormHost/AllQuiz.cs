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
    public partial class AllQuiz : Form
    {
        public AllQuiz()
        {
            InitializeComponent();
        }
        private string _userName;

        // Constructor mới nhận giá trị txtname từ Form thứ ba
        public AllQuiz(string userName)
        {
            InitializeComponent();
            _userName = userName;

            // Tạo nút với văn bản là giá trị của txtname từ Form thứ ba
            Button newButton = new Button();
            newButton.Text = _userName;
            // Thiết lập vị trí và kích thước của nút
            newButton.Location = new Point(100, 150); // Ví dụ: Thiết lập vị trí mới của nút
            newButton.Size = new Size(100, 30); // Ví dụ: Thiết lập kích thước mới cho nút

            // Thêm nút vào Form thứ tư (AllQuiz)
            this.Controls.Add(newButton);
        }
    }
}
