using QuizApp_frontend.API;
using QuizApp_frontend.FormHost;

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