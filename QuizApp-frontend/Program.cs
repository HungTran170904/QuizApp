using QuizApp_frontend.API;
using QuizApp_frontend.FormNguoichoi;

namespace QuizApp_frontend
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new MainForm());
        }
    }
}