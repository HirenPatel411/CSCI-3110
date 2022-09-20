using Microsoft.EntityFrameworkCore;
using PatelHiren_Assignment2.Models.Entities;
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//	File Name:         MovieDbContext.cs
//  Date:              March 3, 2022
//	Course:            CSCI 3110
//	Author:            Hiren Patel, East Tennessee State University
//
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

namespace PatelHiren_Assignment2.Services

{
    /// <summary>
    /// Database Context class
    /// </summary>
    public class MovieDbContext : DbContext
    {
            /// <summary>
            /// Construtor for the context
            /// </summary>
            /// <param name="options"></param>
            public MovieDbContext(DbContextOptions options) : base(options)
            {

            }
            public DbSet<Movie> Movies => Set<Movie>();         //Database set for the Movies
            public DbSet<Actor> Actors => Set<Actor>();         //Database set for the Actors in teh movie
    }
    
}
