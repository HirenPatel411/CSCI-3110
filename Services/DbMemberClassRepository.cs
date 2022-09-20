using Microsoft.EntityFrameworkCore;
using PatelHiren_Assignment3.Models.Entities;
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//	File Name:         DbMemberClassRepository.cs
//  Date:              March 31, 2022
//	Course:            CSCI 3110
//	Author:            Hiren Patel, East Tennessee State University
//
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

namespace PatelHiren_Assignment3.Services
{
    /// <summary>
    /// Database repository for the members classes
    /// </summary>
    public class DbMemberClassRepository : IMemberClassRepository
    {
        private readonly ApplicationDbContext _db;          //Private read only variable for the database context    
        private readonly IMemberRepository _memberRepo;     //Private read only variable for member repo 
        private readonly IClassRepository _classRepo;       //Private read only varibale for the class repo

        /// <summary>
        /// Parameterized constructor for the MemberCLassRepository
        /// </summary>
        /// <param name="db"></param>
        /// <param name="memberRepo"></param>
        /// <param name="classRepo"></param>
        public DbMemberClassRepository(ApplicationDbContext db, IMemberRepository memberRepo, IClassRepository classRepo)
        {
            _db = db;
            _memberRepo = memberRepo;
            _classRepo = classRepo;
        }

        /// <summary>
        /// Read method for the classes the member has completed
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public MemberClassCompleted? Read(int id)
        {
            return _db.MemberClassCompletions
               .Include(scg => scg.Member)
               .Include(scg => scg.Class)
               .FirstOrDefault(scg => scg.Id == id);
        }

        /// <summary>
        /// Collection of the classes the member has completed
        /// </summary>
        /// <returns></returns>
        public ICollection<MemberClassCompleted> ReadAll()
        {
            return _db.MemberClassCompletions
               .Include(scg => scg.Member)
               .Include(scg => scg.Class)
               .ToList();
        }

        /// <summary>
        /// This method creates a class completed by the member
        /// </summary>
        /// <param name="memberId"></param>
        /// <param name="classId"></param>
        /// <returns></returns>
        public MemberClassCompleted? Create(string memberId, int classId)
        {
            var member = _memberRepo.Read(memberId);
            if (member == null)
            {
                return null;
            }
            var classComplete = member.ClassCompletion
                .FirstOrDefault(scg => scg.ClassId == classId);
            if (classComplete != null)
            {
              
                return null;
            }
            var @class = _classRepo.Read(classId);
            if (@class == null)
            {
                return null;
            }
            var memberClassCompletion = new MemberClassCompleted
            {
                Member = member,
                Class = @class
            };
            member.ClassCompletion.Add(memberClassCompletion);
            @class.MemberCompletion.Add(memberClassCompletion);
            _db.SaveChanges();
            return memberClassCompletion;
        }

        /// <summary>
        /// This method updates a the number of class sessions completed by the member
        /// </summary>
        /// <param name="memberClassId"></param>
        /// <param name="completion"></param>
        public void UpdateMemberSessions(int memberClassId, string completion)
        {
            var memberClass = Read(memberClassId);
            if (memberClass != null)
            {
                memberClass.Sessions = completion;
                _db.SaveChanges();
            }
        }

        /// <summary>
        /// This method deletes a class completed by the member
        /// </summary>
        /// <param name="memberId"></param>
        /// <param name="memberClassId"></param>
        public void Delete(string memberId, int memberClassId)
        {
            var member = _memberRepo.Read(memberId);
            var memberClass = member!.ClassCompletion
                .FirstOrDefault(scg => scg.Id == memberClassId);
            var @class = memberClass!.Class;
            member!.ClassCompletion.Remove(memberClass);
            @class!.MemberCompletion.Remove(memberClass);
            _db.SaveChanges();
        }
    }
}
