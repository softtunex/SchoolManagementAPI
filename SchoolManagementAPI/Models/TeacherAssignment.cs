using System.ComponentModel.DataAnnotations;

namespace SchoolManagementAPI.Models
{
    public class TeacherAssignment
    {
        [Key]
        public int AssignmentId { get; set; }
        public int TeacherId { get; set; }
        public int SubjectId { get; set; }
        public int ClassId { get; set; }
    }
}
