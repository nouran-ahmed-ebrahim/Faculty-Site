using System.ComponentModel.DataAnnotations.Schema;

namespace Asp.net.Models
{
    public class Instructore
    {
        public int Id { get; set; }
        public string Name { get; set; }    
        public string Address { get; set; }    
        public string Image { get; set; }
        public int Salary { get; set; }

        [ForeignKey("Fk_Istructore_DepartmentId")]
        public int DepartmentId { get; set; }
        public Department? Department { get; set; }

        [ForeignKey("Fk_Istructore_CourseId")]
        public int CourseId { get; set; }
        public Course? Course { get; set; }

    }
}