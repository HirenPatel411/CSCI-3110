using PatelHiren_Assignment3.Models.Entities;
using Microsoft.EntityFrameworkCore;
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//	File Name:         DbClassRepository.cs
//  Date:              March 31, 2022
//	Course:            CSCI 3110
//	Author:            Hiren Patel, East Tennessee State University
//
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
namespace PatelHiren_Assignment3.Services
{
    /// <summary>
    /// Database repo for the classes
    /// </summary>
    public class DbClassRepository : IClassRepository
    {
        private readonly ApplicationDbContext _db;          //Read only varibale for the database context

        /// <summary>
        /// Initializing method
        /// </summary>
        /// <param name="db"></param>
        public DbClassRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        /// <summary>
        /// This method reads a class in the database
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Class? Read(int id)
        {
            return _db.Classes
               .Include(s => s.MemberCompletion)
                  .ThenInclude(scg => scg.Member)
               .FirstOrDefault(c => c.Id == id);
        }

        /// <summary>
        /// This method reads all the classes in the database
        /// </summary>
        /// <returns></returns>
        public ICollection<Class> ReadAll()
        {
            return _db.Classes
               .Include(s => s.MemberCompletion)
                  .ThenInclude(scg => scg.Member)
               .ToList();
        }
    }
}
