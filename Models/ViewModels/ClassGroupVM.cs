using PatelHiren_Assignment3.Models.Entities;

namespace PatelHiren_Assignment3.Models.ViewModels
{
    public class ClassGroupVM
    {
        public string? ClassName { get; set; }
        public IEnumerable<MemberClassCompleted> MemberClassCompletions { get; set; }
            = new List<MemberClassCompleted>();
    }
}
