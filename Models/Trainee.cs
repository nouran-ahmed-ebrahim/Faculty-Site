using System.ComponentModel.DataAnnotations.Schema;

namespace Asp.net.Models
{
    public class Trainee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Image { get; set; }
        public decimal Grade { get; set; }

        [ForeignKey("Fk_Trainee_DepartmentId")]
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public List<CoursesResult> CrsResults { get; set; }
    }
}