using PatelHiren_Assignment2.Models.Entities;
using System.ComponentModel;
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//	File Name:         CreateActorViewModel.cs
//  Date:              March 3, 2022
//	Course:            CSCI 3110
//	Author:            Hiren Patel, East Tennessee State University
//
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

namespace PatelHiren_Assignment2.Models.ViewModels
{
    /// <summary>
    /// This class is the view model for creating a actor 
    /// </summary>
    public class CreateActorViewModel
    {
        [DisplayName("First Name")]
        public string FirstName { get; set; }       //Getter and setter for the Actors first name
        [DisplayName("Last Name")]
        public string LastName { get; set; }        //Getter and setter for the Actors last name

        /// <summary>
        /// This method gets an instance of the Actor
        /// </summary>
        /// <returns>the first and last name</returns>
        public Actor GetActorInstance()
        {
            return new Actor
            {
                Id = 0,
                FirstName = this.FirstName,
                LastName = this.LastName ?? ""
            };
        }
    }
}
