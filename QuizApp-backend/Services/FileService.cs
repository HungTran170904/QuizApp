using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using QuizApp_backend.Models;
using QuizApp_backend.Repository;
using System.Net.Sockets;
// https://stackoverflow.com/questions/13223200/how-can-i-send-an-excel-file-by-email
namespace QuizApp_backend.Services
{
    public class FileService
    {
        private readonly ParticipantRepo _partRepo;
        private readonly QuestionRepo _questionRepo;
        public FileService(ParticipantRepo partRepo,
                        QuestionRepo questionRepo) 
        {
            _partRepo = partRepo;
            _questionRepo = questionRepo;
        }
        public void CreateExcelFile(Quiz quiz)
        {
            var participants = _partRepo.FindWithResultsByQuizId(quiz.Id);
            var questions=_questionRepo.FindByQuizId(quiz.Id,true); 
            using (SpreadsheetDocument document = SpreadsheetDocument.Create("Score summary of Quiz " + quiz.Title
                , SpreadsheetDocumentType.Workbook)) 
            {
                WorkbookPart workbookPart = document.AddWorkbookPart();
                Row headerRow = new Row();
                for(int i=1;i<questions.Count;i++)
                {
                    var cell = new Cell
                    {
                        DataType = CellValues.String,
                        CellValue = new CellValue("Q"+i),
                        StyleIndex = 1 
                    };
                    headerRow.AddChild(cell);
                }
                WorksheetPart answersSheet = workbookPart.AddNewPart<WorksheetPart>("Student Answers");

            }
        }
        private void AddAnswersSheet(WorkbookPart workbookPart,List<Participant> participants)
        {
            WorksheetPart answersSheet = workbookPart.AddNewPart<WorksheetPart>("Student Answers");
            Row headerRow = new Row();
            
        }
    }
}
