using Json.Net;
using QuizApp_backend;
using QuizApp_backend.Converter;
using QuizApp_backend.Models;
using QuizApp_backend.Repository;
using QuizApp_backend.Util;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        
        builder.Services.AddSingleton<AccountRepo>();
        builder.Services.AddSingleton<QuestionRepo>();

        builder.Services.AddSingleton<PasswordEncoder>();
        builder.Services.AddSingleton<ReaderConverter>();
        var app = builder.Build();

        var QuestionRepo= app.Services.GetService<QuestionRepo>();
        
        //app.Run();
    }
}