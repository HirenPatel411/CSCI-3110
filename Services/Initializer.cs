using PatelHiren_Assignment3.Models.Entities;
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//	File Name:         Initializer.cs
//  Date:              March 31, 2022
//	Course:            CSCI 3110
//	Author:            Hiren Patel, East Tennessee State University
//
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
namespace PatelHiren_Assignment3.Services
{
    /// <summary>
    /// Initializes the values in databse
    /// </summary>
    public class Initializer
    {
        private readonly ApplicationDbContext _db;     //Read only variable for the database context 

        /// <summary>
        /// Parameterized constructor
        /// </summary>
        /// <param name="db"></param>
        public Initializer(ApplicationDbContext db)
        {
            _db = db;
        }

        /// <summary>
        /// This method seeds the data into the database
        /// </summary>
        public void SeedDatabase()
        {
            _db.Database.EnsureCreated();


            if (_db.Members.Any()) return;      //If members exsist, database is seeded

            var members = new List<Member>      //new list of members
            {
               new Member { MemberId = "AH0001", FirstName = "Peter", LastName = "LaFleur" },
               new Member { MemberId = "AH0002", FirstName = "Justin", LastName = "Redman" },
               new Member { MemberId = "AH0003", FirstName = "Katherine", LastName = "Veatch" },
               new Member { MemberId = "AH0004", FirstName = "Dwight", LastName = "Baumgarten" }
            };

            _db.Members.AddRange(members);
            _db.SaveChanges();

            var classes = new List<Class>       //new list of classes
            {
               new Class { ClassName = "Barre", InstructorName = "Kelly Ripa" },
               new Class { ClassName = "Boot Camp", InstructorName = "Kim Kardashian" },
               new Class { ClassName = "Boxing", InstructorName = "Anna Paquin" },
               new Class { ClassName = "Crossfit", InstructorName = " Kelly Clarkson" },
               new Class { ClassName = "Hot Yoga", InstructorName = "Jenny McCarthy" },
               new Class { ClassName = "Pilates", InstructorName = "Cameron Diaz" },
               new Class { ClassName = "Spinning", InstructorName = "Jessica Alba" },
               new Class { ClassName = "Zumba", InstructorName = "Jennifer Lopez" }
            };

            _db.Classes.AddRange(classes);
            _db.SaveChanges();
        }
    }
}
