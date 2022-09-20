using PatelHiren_Assignment2.Models.Entities;
using System.ComponentModel;
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//	File Name:         MovieDetailsViewModel.cs
//  Date:              March 3, 2022
//	Course:            CSCI 3110
//	Author:            Hiren Patel, East Tennessee State University
//
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
namespace PatelHiren_Assignment2.Models.ViewModels
{
    /// <summary>
    /// This class is the view model for the movie databse details
    /// </summary>
    public class MovieDetailsViewModel
    {
        public int Id { get; set; }                             //getter and setter for the Id         
        public string? MovieName { get; set; }                  //getter and setter for the MovieName
        [DisplayName("Release Date")]
        public string? ReleaseDate { get; set; }                 //getter and setter for the ReleaseDate
        [DisplayName("Number of Actors")]
        public int NumberOfAuthors { get; set; }                //getter and setter for the NumberOfAuthors
        public ICollection<Actor> Actors { get; set; }          //getter and setter for the collection of Actors
            = new List<Actor>();
    }
}
