using System;

namespace SchoolManagementAPI.Models
{
    public class Grade
    {
        public int GradeId { get; set; } // This is the primary key
        public int StudentId { get; set; }
        public int SubjectId { get; set; }
        public string GradeValue { get; set; }
        public DateTime DateRecorded { get; set; }
    }
}
