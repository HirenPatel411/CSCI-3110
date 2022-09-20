using PatelHiren_Assignment3.Models.Entities;
using Microsoft.EntityFrameworkCore;
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//	File Name:         ApplicationDbContext.cs
//  Date:              March 31, 2022
//	Course:            CSCI 3110
//	Author:            Hiren Patel, East Tennessee State University
//
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
namespace PatelHiren_Assignment3.Services

{
    /// <summary>
    /// Databases context class
    /// </summary>
    public class ApplicationDbContext : DbContext
    {
        /// <summary>
        /// Constructor for the context
        /// </summary>
        /// <param name="options"></param>
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Member> Members => Set<Member>();                                            //Database set for Members
        public DbSet<Class> Classes => Set<Class>();                                              //Database set for Classes
        public DbSet<MemberClassCompleted> MemberClassCompletions => Set<MemberClassCompleted>(); //Database set for the members classes
    }
}
