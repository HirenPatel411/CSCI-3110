using System.ComponentModel.DataAnnotations;

namespace PatelHiren_Assignment3.Models.Entities
{
    public class Class
    {
        public int Id { get; set; }
        public string ClassName { get; set; } = String.Empty;
        public string InstructorName { get; set; } = String.Empty;
        public ICollection<MemberClassCompleted> MemberCompletion { get; set; }
       = new List<MemberClassCompleted>();
    }
}
