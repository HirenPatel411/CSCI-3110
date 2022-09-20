using System.ComponentModel.DataAnnotations;
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
    /// This class is the actors entities class
    /// </summary>
    public class Actor
    {
        public int Id { get; set; }                  //Getter and setter for the Actors Id
        public string FirstName { get; set; }       //Getter and setter for the Actors first name
        public string LastName { get; set; }        //Getter and setter for the Actors last name

        public int MovieId { get; set; }            //Getter and setter for the MovieId
        public Movie? Movie { get; set; }           //Getter and setter for the Movie entity

    }
}
