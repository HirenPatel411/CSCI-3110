using System.ComponentModel.DataAnnotations;

namespace PatelHiren_Assignment3.Models.Entities
{
    public class Member
    {
        public string MemberId { get; set; } = String.Empty;
        public string FirstName { get; set; } = String.Empty;
        [StringLength(32)]
        public string LastName { get; set; } = String.Empty;

        public ICollection<MemberClassCompleted> ClassCompletion { get; set; }
       = new List<MemberClassCompleted>();
    }
}
