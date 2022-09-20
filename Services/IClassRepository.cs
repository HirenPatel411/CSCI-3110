using PatelHiren_Assignment3.Models.Entities;
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//	File Name:         IClassRepository.cs
//  Date:              March 31, 2022
//	Course:            CSCI 3110
//	Author:            Hiren Patel, East Tennessee State University
//
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

namespace PatelHiren_Assignment3.Services
{
    /// <summary>
    /// Interface for Class repo
    /// </summary>
    public interface IClassRepository
    {
        Class? Read(int id);                //Reads the classes in the database
        ICollection<Class> ReadAll();       //Reads the whole collection of classes

    }
}
