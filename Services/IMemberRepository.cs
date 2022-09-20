using PatelHiren_Assignment3.Models.Entities;
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//	File Name:         IMemberRepository.cs
//  Date:              March 31, 2022
//	Course:            CSCI 3110
//	Author:            Hiren Patel, East Tennessee State University
//
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
namespace PatelHiren_Assignment3.Services
{
    /// <summary>
    /// Interface for the member repo
    /// </summary>
    public interface IMemberRepository
    {
        Member? Read(string memberid);          //Reads the member database
        ICollection<Member> ReadAll();          //REads all the members in the database
    }
}
