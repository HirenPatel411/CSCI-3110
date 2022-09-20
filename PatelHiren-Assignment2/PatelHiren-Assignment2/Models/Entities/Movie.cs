///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//	File Name:         Movie.cs
//  Date:              March 3, 2022
//	Course:            CSCI 3110
//	Author:            Hiren Patel, East Tennessee State University
//
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
namespace PatelHiren_Assignment2.Models.Entities
{
    /// <summary>
    /// This class is the movie entities class
    /// </summary>
    public class Movie
    {
        public int Id { get; set; }                         //Getter and setter for movie Id entity                         
        public string? MovieName { get; set; }               //Getter and setter for movie name entity
        public string? Genre { get; set; }                   //Getter and setter for movie genre entity
        public string? ReleaseDate { get; set; }             //Getter and setter for movie release date entity

        public ICollection<Actor> Actors { get; set; }      //Getter and setter for the new list of Actors
            = new List<Actor>();

    }
}
