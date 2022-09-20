using Microsoft.EntityFrameworkCore;
using PatelHiren_Assignment2.Models.Entities;
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//	File Name:         DBMovieRepository.cs
//  Date:              March 3, 2022
//	Course:            CSCI 3110
//	Author:            Hiren Patel, East Tennessee State University
//
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
namespace PatelHiren_Assignment2.Services
{
    /// <summary>
    /// Database repository for the movies. IMovie is a child class
    /// </summary>
    public class DbMovieRepository : IMovieRepository
    {
        private readonly MovieDbContext _db;            //Read only variable for the database context

        /// <summary>
        /// Method to initialize  
        /// </summary>
        /// <param name="db"></param>
        public DbMovieRepository(MovieDbContext db)
        {
            _db = db;
        }

        /// <summary>
        /// This method adds a movie to the database and saves it.
        /// </summary>
        /// <param name="movie"></param>
        /// <returns></returns>
        public Movie Create(Movie movie)
        {
            _db.Movies.Add(movie);
            _db.SaveChanges();
            return movie;
        }

        /// <summary>
        /// This method adds a actor to the database and saves it.
        /// </summary>
        /// <param name="movieId"></param>
        /// <param name="actor"></param>
        /// <returns></returns>
        public Actor CreateActor(int movieId, Actor actor)
        {
            var movie = Read(movieId);
            if (movie != null)
            {
                movie.Actors.Add(actor);
                actor.Movie = movie;
                _db.SaveChanges();
            }
            return actor;
        }

        /// <summary>
        /// This method reads the Movie database using the id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Movie Read(int id)
        {
            return _db.Movies
                .Include(b => b.Actors)
                .FirstOrDefault(b => b.Id == id);
        }

        /// <summary>
        /// This method reads all the Movies in the list/database
        /// </summary>
        /// <returns></returns>
        public ICollection<Movie> ReadAll()
        {
            return _db.Movies
                .Include(b => b.Actors)
                .ToList();
        }

        /// <summary>
        /// This method edits a movie to the database and saves it.
        /// </summary>
        /// <param name="oldId"></param>
        /// <param name="movie"></param>
        public void Edit(int oldId, Movie movie)
        {
            Movie movieEdited = Read(oldId);
            if (movieEdited != null)
                movieEdited.MovieName = movie.MovieName;
            movieEdited.Genre = movie.Genre;
            movieEdited.ReleaseDate = movie.ReleaseDate;
            _db.SaveChanges();
        }

        /// <summary>
        /// This method edits a actor to the database and saves it.
        /// </summary>
        /// <param name="oldId"></param>
        /// <param name="actor"></param>
        public void EditActor(int oldId, Actor actor)
        {
            var movie = Read(oldId);
            if(movie != null)
            {
                var actorUpdating = movie.Actors
                .FirstOrDefault(r => r.Id == actor.Id);
                if (actorUpdating != null)
                {
                    actorUpdating.FirstName = actor.FirstName;
                    actorUpdating.LastName = actor.LastName;
                    _db.SaveChanges();
                }
            }
        }

        /// <summary>
        /// This method deletes a movie to the database and saves it.
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
            Movie movieDeleted = Read(id);
            if (movieDeleted != null)
                _db.Movies.Remove(movieDeleted);
            _db.SaveChanges();
        }

        /// <summary>
        /// This method deletes a actor to the database and saves it.
        /// </summary>
        /// <param name="movieId"></param>
        /// <param name="actorId"></param>
        public void DeleteActor(int movieId, int actorId)
        {
            var movie = Read(movieId);
            if (movie != null)
            {
                var actor = movie.Actors
                   .FirstOrDefault(r => r.Id == actorId);
                if (actor != null)
                {
                    movie.Actors.Remove(actor);
                    _db.SaveChanges();
                }
            }
        }
    }
}
