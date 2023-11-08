using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Asp.net.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [Remote(action: "CheckDegree", controller: "CoursesController", ErrorMessage = "Degree must be greater than 0")]
        public int Degree { get; set; }

        [CompareMinDegreeAttribute]
        public int MinDegree { get; set; }

        [ForeignKey("Fk_Course_DepartmentId")]
        [Display(Name ="Department")]
        [NotZero]
        public int DepartmentId { get; set; }
        public Department? Department { get; set; }

        public List<Instructore>? Instructores { get; set; }
        public List<CoursesResult>? CoursesResults { get; set; }

    }
}
