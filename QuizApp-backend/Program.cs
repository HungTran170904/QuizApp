using Json.Net;
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
        builder.Services.AddSingleton<QuizRepo>();
        builder.Services.AddSingleton<ParticipantRepo>();

        builder.Services.AddSingleton<PasswordEncoder>();
        builder.Services.AddSingleton<ReaderConverter>();
        var app=builder.Build();
        var ParticipantRepo= app.Services.GetService<ParticipantRepo>();
        var part = new Participant();
        part.QuizId = "11208AA2-99DC-42C5-ACB7-6B2DB5206F1A";
        part.Name ="Hai";
        part.AttendedAt = DateTime.Now;
        ParticipantRepo.AddParticipant(part);
        //app.Run();
    }
}