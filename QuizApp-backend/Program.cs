using Json.Net;
using QuizApp_backend;
using QuizApp_backend.Controllers;
using QuizApp_backend.Models;
using QuizApp_backend.Repository;
using QuizApp_backend.Services;
using QuizApp_backend.Util;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddSingleton<PasswordEncoder>();
        builder.Services.AddSingleton<ReaderConverter>();

        builder.Services.AddSingleton<AccountRepo>();
        builder.Services.AddSingleton<QuestionRepo>();
        builder.Services.AddSingleton<QuizRepo>();
        builder.Services.AddSingleton<ParticipantRepo>();
        builder.Services.AddSingleton<ResultRepo>();

        builder.Services.AddSingleton<SocketService>();
        builder.Services.AddSingleton<AccountService>();
        builder.Services.AddSingleton<QuestionService>();
        builder.Services.AddSingleton<QuizService>();
        builder.Services.AddSingleton<ParticipantService>();

        builder.Services.AddSingleton<AccountController>();
        builder.Services.AddSingleton<QuestionController>();
        builder.Services.AddSingleton<AccountController>();
        builder.Services.AddSingleton<QuizController>();
        builder.Services.AddSingleton<ParticipantController>();

        builder.Services.AddSingleton<Server>();
        var app=builder.Build();

        Server server=app.Services.GetService<Server>();
        _=server.Run();
    }
}