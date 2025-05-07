using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorHybrid.Api.Data.Entities
{
    public class Quiz
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public int TotalQuestions { get; set; }
        public int  TimeInMinutes { get; set; }
        public bool IsActive { get; set; }
        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; }

        public ICollection<Question> Questions { get; set; }
    }

    public class Question
    {
        public int Id { get; set; }
        public string Text { get; set; }

        public Guid QuizId { get; set; }
        [ForeignKey(nameof(QuizId))] 
        public Quiz Quiz { get; set; }
    }

    public class Option
    {
        public int Id { get; set; }
        public int QuestionId { get; set; }
    }
}
