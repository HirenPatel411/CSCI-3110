using PatelHiren_Assignment2.Models.Entities;
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//	File Name:         IMovieRepository.cs
//  Date:              March 3, 2022
//	Course:            CSCI 3110
//	Author:            Hiren Patel, East Tennessee State University
//
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

namespace PatelHiren_Assignment2.Services
{
    /// <summary>
    /// Interface for Movie repository
    /// </summary>
    public interface IMovieRepository
    {
        Movie Read(int id);                                 //Reads the Movie database
        ICollection<Movie> ReadAll();                       //Reads the whole collection in the Movie database
        Movie Create(Movie movie);                          //Creates a Movie in the database
        void Delete(int id);                                //Deletes a Movie in the database
        void Edit(int oldId, Movie movie);                  //Edits a current Movie in the database
        Actor CreateActor(int movieId, Actor actor);        //Creates a Actor in the database
        void EditActor(int movieId, Actor actor);           //Edits a current Actor in the database
        void DeleteActor(int movieId, int actorId);         //Deletes a Actor in the database
    }
}
