using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using QuizApp_frontend.API;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuizApp_frontend.Podium
{
    public partial class podium : Form
    {
        public podium()
        {
            InitializeComponent();
        }

        private void podium_Load(object sender, EventArgs e)
        {
            //APIConfig.AddTopic("/quesion/updateLeaderBoard");
        }
    }
}
