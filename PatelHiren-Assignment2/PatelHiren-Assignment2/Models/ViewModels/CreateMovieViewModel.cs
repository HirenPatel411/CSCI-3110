using System.ComponentModel;
using PatelHiren_Assignment2.Models.Entities;
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//	File Name:         CreateMovieViewModel.cs
//  Date:              March 3, 2022
//	Course:            CSCI 3110
//	Author:            Hiren Patel, East Tennessee State University
//
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
namespace PatelHiren_Assignment2.Models.ViewModels
{
    /// <summary>
    /// This class is the view model for creating a movie 
    /// </summary>
    public class CreateMovieViewModel
    {
        public string? MovieName { get; set; }      //Getter and setter for the Movies name
        [DisplayName("Release Date")]
        public string ReleaseDate { get; set; }     //Getter and setter for the Movies release date

        /// <summary>
        /// This method gets an instance of the movie
        /// </summary>
        /// <returns>the name and release date</returns>
        public Movie GetMovieInstance()
        {
            return new Movie
            {
                Id = 0,
                MovieName = this.MovieName?? "",
                ReleaseDate = this.ReleaseDate
            };
        }
    }
}
