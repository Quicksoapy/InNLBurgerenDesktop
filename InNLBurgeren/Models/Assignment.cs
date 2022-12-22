using InNLBurgeren.ViewModels;

namespace InNLBurgeren.Models;

public class Assignment
{
    public Assignment(int id, string question, int categoryId, string answer)
    {
        Id = id;
        Question = question;
        Answer = answer;
        CategoryId = categoryId;
    }

    public int Id { get; set; }

    public string Question { get; set; }

    public int CategoryId { get; set; }

    public string Answer { get; set; }
}
