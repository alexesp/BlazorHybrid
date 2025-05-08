using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorHybrid.Api.Data.Entities
{
    public class StudentQuiz
    {
        [Key]
        public int Id { get; set; }
        public int StudentId { get; set; }
        public Guid QuizId { get; set; }

        public DateTime StartedOn { get; set; }

        public DateTime CompetedOn { get; set; }

        public int Score {  get; set; }

        [ForeignKey(nameof(StudentId))]
        public virtual User Student { get; set; }

        public Quiz Quiz { get; set; }

    }
}
