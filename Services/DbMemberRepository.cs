using Microsoft.EntityFrameworkCore;
using PatelHiren_Assignment3.Models.Entities;
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//	File Name:         DbMemberRepository.cs
//  Date:              March 31, 2022
//	Course:            CSCI 3110
//	Author:            Hiren Patel, East Tennessee State University
//
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

namespace PatelHiren_Assignment3.Services
{
    /// <summary>
    /// Database repository for the members
    /// </summary>
    public class DbMemberRepository : IMemberRepository
    {
        private readonly ApplicationDbContext _db;   //Private read only varibale for database context   

        /// <summary>
        /// Parameterized constructor
        /// </summary>
        /// <param name="db"></param>
        public DbMemberRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        
        /// <summary>
        /// This method reads a member in the database
        /// </summary>
        /// <param name="memberid"></param>
        /// <returns></returns>
        public Member? Read(string memberid)
        {
            return _db.Members
               .Include(s => s.ClassCompletion)
                  .ThenInclude(scg => scg.Class)
               .FirstOrDefault(s => s.MemberId == memberid);

        }

        /// <summary>
        /// This method reads all the members in the database
        /// </summary>
        /// <returns></returns>
        public ICollection<Member> ReadAll()
        {
            return _db.Members
               .Include(s => s.ClassCompletion)
                  .ThenInclude(scg => scg.Class)
               .ToList();
        }
    }
}
