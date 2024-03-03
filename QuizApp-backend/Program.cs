using Json.Net;
using QuizApp_backend;
using QuizApp_backend.Models;
using QuizApp_backend.Repository;
using QuizApp_backend.Util;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddSingleton<PasswordEncoder>();
        builder.Services.AddSingleton<AccountRepo>();
        var app = builder.Build();
        var accountRepo = app.Services.GetService<AccountRepo>();
        if (accountRepo != null)
        {
            Account account = accountRepo.FindById("70CB65AA-238B-48B2-A9A1-87D1CF3C4551");
            Console.WriteLine(JsonNet.Serialize(account));
        }
        else Console.WriteLine("AccountRepo is null");
        //app.Run();
    }
}