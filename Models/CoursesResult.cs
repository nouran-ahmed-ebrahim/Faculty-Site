using System.ComponentModel.DataAnnotations.Schema;

namespace Asp.net.Models
{
    public class CoursesResult
    {
        public int Id { get; set; }
        public decimal Grade { get; set; }

        [ForeignKey("Fk_CoursesResult_CourseId")]
        public int CourseId { get; set; }
        public Course Course { get; set; }

        [ForeignKey("Fk_CoursesResult_TraineeId")]
        public int TraineeId { get; set; }
        public Trainee Trainee { get; set; }
    }
}