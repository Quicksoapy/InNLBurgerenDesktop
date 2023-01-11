using InNLBurgeren.ViewModels;

namespace InNLBurgeren.Models;

public class Assignment
{
    public Assignment(int id, string question, int subjectId, string answer)
    {
        Id = id;
        Question = question;
        Answer = answer;
        SubjectId = subjectId;
    }

    public int Id { get; set; }

    public string Question { get; set; }

    public int SubjectId { get; set; }

    public string Answer { get; set; }
}
