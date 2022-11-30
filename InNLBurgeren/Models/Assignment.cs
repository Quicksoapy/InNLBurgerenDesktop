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
    
    }
