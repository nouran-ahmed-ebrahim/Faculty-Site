﻿namespace Asp.net.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Manager { get; set; }

        public List<Instructore>? Instructors { get; set; }
        public List<Trainee>? Trainees { get; set; }
        public List<Course>? Courses { get; set; }
    }
}