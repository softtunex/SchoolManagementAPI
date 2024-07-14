namespace SchoolManagementAPI.Models
{
    public class Class
    {
        public int ClassId { get; set; }
        public string ClassName { get; set; }
        public int MainTeacherId { get; set; }
        public int? AssistantTeacherId { get; set; }
        public string Level { get; set; }
    }
}
