use master 
go
create database QuizDB
go
use QuizDB
create table Account(
	Id uniqueidentifier primary key default newid(),
	Name varchar(255),
	Email varchar(255) not null unique,
	Password varchar(255) not null,
);
create table Quiz(
	Id uniqueidentifier primary key default newid(),
	Title varchar(255),
	CreatedAt smalldatetime,
	CreatorId uniqueidentifier,
	Status varchar(255),
	IsBlocked bit,
	constraint FK_ACCOUNT_QUIZ foreign key(CreatorId) references Account(Id)
);
create table Question(
	Id uniqueidentifier primary key default newid(),
	QuestionText text not null,
	CorrectAnswer text,
	TimeOut int,
	Options text,
	QuizId uniqueidentifier,
	constraint FK_QUIZ_QUESTION foreign key(QuizId) references Quiz(Id)
);
create table Participant(
	Id uniqueidentifier primary key default newid(),
	Name varchar(255),
	QuizId uniqueidentifier,
	AttendedAt smalldatetime,
	FinishedAt smalldatetime,
	TotalScore int,
	constraint FK_QUIZ_PARTICIPANT foreign key(QuizId) references Quiz(Id)
)
create table Result(
	ParticipantId uniqueidentifier,
	QuestionId uniqueidentifier,
	ChoosedOption text, 
	IsCorrect bit,
	primary key(ParticipantId, QuestionId),
	constraint FK_PARTICIPANT_RESULT foreign key(ParticipantId) references Participant(Id),
	constraint FK_QUESTION_RESULT foreign key(QuestionId) references Question(Id)
)
create type dbo.IdListType as table
(
    Id uniqueidentifier
)
go
create procedure dbo.GetParticipantsByIdList
    @IdList dbo.IdListType readonly,
	@QuizId uniqueidentifier
as
begin
    select * from Participant 
	where Id in (select Id from @IdList)
	and QuizId=@QuizId
end;