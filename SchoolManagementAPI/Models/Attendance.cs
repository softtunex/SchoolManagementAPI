using System;

namespace SchoolManagementAPI.Models
{
    public class Attendance
    {
        public int AttendanceId { get; set; }
        public int StudentId { get; set; }
        public int ClassId { get; set; }
        public DateTime Date { get; set; }
        public string Status { get; set; }
    }
}
