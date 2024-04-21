using OfficeOpenXml.Style;
using OfficeOpenXml;
using QuizApp_backend.Exceptions;
using QuizApp_backend.Repository;
using QuizApp_backend.Models;
using System;

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
                var scoreSheet = CreateSheet(package, questions.Count, participants.Count, 2);
                var answerSheet = CreateSheet(package, questions.Count, participants.Count,3);
                int rowIndex = 2;
                string dateFormat = "HH:mm:ss dd/MM/yyyy";
                foreach (var part in participants)
                {
                    scoreSheet.Cells[rowIndex, 1].Value = part.Name;
                    scoreSheet.Cells[rowIndex, 2].Value = part.TotalScore;

                    answerSheet.Cells[rowIndex, 1].Value = part.Name;
                    answerSheet.Cells[rowIndex, 2].Value = part.AttendedAt.Value.ToString(dateFormat);
                    if(part.FinishedAt.HasValue)
                        answerSheet.Cells[rowIndex + 1, 3].Value = part.FinishedAt.Value.ToString(dateFormat);

                    int colIndex = 3;
                    foreach (var question in questions)
                    {
                        var result = part.Results.Find(r => r.QuestionId.Equals(question.Id));
                        if (result != null)
                        {
                            scoreSheet.Cells[rowIndex, colIndex].Value = result.IsCorrect ? "T" : "F";
                            answerSheet.Cells[rowIndex, colIndex+1].Value = result.ChoosedOption;
                        }
                        else scoreSheet.Cells[rowIndex, colIndex].Value = "NA";
                        colIndex++;
                    }
                    rowIndex++;
                }
                package.SaveAs(stream);
            }
        }
        private ExcelWorksheet CreateSheet(ExcelPackage package,int questionsLen,int partsLen,int type)
        {
            string sheetName = (type ==2) ? "Score Sheet" : "Answer Sheet";
            var workSheet = package.Workbook.Worksheets.Add(sheetName);
            workSheet.TabColor = System.Drawing.Color.Black;
            workSheet.DefaultRowHeight = 13;
            workSheet.DefaultColWidth = 12;

            workSheet.Row(1).Height = 20;
            workSheet.Row(1).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            workSheet.Row(1).Style.Font.Bold = true;

            ExcelRange range = workSheet.Cells[1, 1, partsLen + 1, questionsLen + type];
            range.Style.Border.Top.Style = ExcelBorderStyle.Thin;
            range.Style.Border.Left.Style = ExcelBorderStyle.Thin;
            range.Style.Border.Right.Style = ExcelBorderStyle.Thin;
            range.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;

            workSheet.Cells[1, 1].Value = "Participant";
            if(type==2) workSheet.Cells[1, 2].Value = "TotalScore";
            else if (type == 3)
            {
                workSheet.Cells[1, 2].Value = "Attended at";
                workSheet.Cells[1, 3].Value = "Finished at";
            }
            for (int i = 1; i <=questionsLen; i++)
                workSheet.Cells[1, i+type].Value = $"Q{i}";
            return workSheet;
        }
    }
}
