using OfficeOpenXml.Style;
using OfficeOpenXml;
using QuizApp_backend.Exceptions;
using QuizApp_backend.Repository;
using QuizApp_backend.Models;
using System.Drawing;

namespace QuizApp_backend.Services
{
    public class FileService
    {
        private readonly ParticipantRepo _partRepo;
        private readonly QuestionRepo _questionRepo;
        private readonly QuizRepo _quizRepo;
        public FileService(ParticipantRepo partRepo,
                        QuestionRepo questionRepo,
                        QuizRepo quizRepo)
        {
            _partRepo = partRepo;
            _questionRepo = questionRepo;
            _quizRepo = quizRepo;
        }
        public void CreateExcelFile(MemoryStream stream, string accountId, string quizId)
        {
            var quiz = _quizRepo.FindById(quizId);
            if (!quiz.CreatorId.Equals(accountId))
                throw new RequestException("You do not have permissions to get summary from this quiz");
            var participants = _partRepo.FindWithResultsByQuizId(quiz.Id);
            var questions = _questionRepo.FindByQuizId(quiz.Id, true);
            using (var package = new ExcelPackage(stream))
            {
                var answerSheet = CreateAnswerSheet(package, questions);
                var scoreSheet = CreateScoreSheet(package, questions);
                int rowIndex = 2;
                foreach (var part in participants)
                {
                    answerSheet.Cells[rowIndex + 1, 1].Value = part.Name;
                    scoreSheet.Cells[rowIndex, 1].Value = part.Name;
                    int colIndex = 2;
                    foreach (var question in questions)
                    {
                        var result = part.Results.Find(r => r.QuestionId.Equals(question.Id));
                        if (result != null)
                        {
                            answerSheet.Cells[rowIndex + 1, colIndex].Value = result.ChoosedOption;
                            scoreSheet.Cells[rowIndex, colIndex].Value = result.IsCorrect ? "T" : "F";
                        }
                        else scoreSheet.Cells[rowIndex, colIndex].Value = "NA";
                        colIndex++;
                    }
                    scoreSheet.Cells[rowIndex, colIndex].Value = part.TotalScore;
                    rowIndex++;
                }
                package.SaveAs(stream);
            }
        }
        private void AddHeaderRow(ExcelWorksheet workSheet,List<Question> questions)
        {
            workSheet.Row(1).Height = 20;
            workSheet.Row(1).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            workSheet.Row(1).Style.Font.Bold = true;
            workSheet.Column(1).Width = 15;
            workSheet.Column(1).AutoFit();

            workSheet.Cells[1, 1].Value = "Name/Question";
            for (int i = 0; i < questions.Count; i++)
                workSheet.Cells[1, i + 2].Value = $"Q{i + 1}:{questions[i].QuestionText}";
        }
        private ExcelWorksheet CreateAnswerSheet(ExcelPackage package, List<Question> questions)
        {
            var answerSheet = package.Workbook.Worksheets.Add("Answer Sheet");
            answerSheet.TabColor = System.Drawing.Color.Black;
            answerSheet.DefaultRowHeight = 12;

            AddHeaderRow(answerSheet, questions);
            answerSheet.Cells[2, 1].Value = "Question Text";
            int colIndex = 2;
            foreach (Question question in questions)
            {
                answerSheet.Cells[2, colIndex].Value = question.QuestionText;
            }
            return answerSheet;
        }
        private ExcelWorksheet CreateScoreSheet(ExcelPackage package, List<Question> questions)
        {
            var scoreSheet = package.Workbook.Worksheets.Add("Score Sheet");
            scoreSheet.TabColor = System.Drawing.Color.Black;
            scoreSheet.DefaultRowHeight = 12;

            AddHeaderRow(scoreSheet, questions);
            scoreSheet.Cells[1,questions.Count + 2].Value = "Total Score";
            return scoreSheet;
        }
    }
}
