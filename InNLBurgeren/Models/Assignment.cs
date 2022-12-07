using InNLBurgeren.ViewModels;

namespace InNLBurgeren.Models;

public class Assignment
{
    public Assignment(int id, string question, int categoryId, int points)
    {
        Id = id;
        Question = question;
        CategoryId = categoryId;
        Points = points;
    }

    public int Id { get; set; }

    public string Question { get; set; }

    public int CategoryId { get; set; }

    public int Points { get; set; }

    //load DB
    //Foreach (item in DB) {assignments.Add(item);

    Assignment sample = new Assignment(1, "test", 3, 45);
    Assignment sample2 = new Assignment(2, "test2", 3, 45);
    
    }
