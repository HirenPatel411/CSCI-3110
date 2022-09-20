using System.ComponentModel.DataAnnotations;

namespace PatelHiren_Assignment3.Models.Entities
{
    public class MemberClassCompleted
    {
        public int Id { get; set; }
        [StringLength(2, MinimumLength = 1)]
        public string Sessions { get; set; } = String.Empty;

        public string MemberId { get; set; } = String.Empty;
        public Member? Member { get; set; }

        public int ClassId { get; set; }
        public Class? Class { get; set; }
    }
}
