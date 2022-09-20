using PatelHiren_Assignment3.Models.Entities;
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//	File Name:         IMemberClassRepository.cs
//  Date:              March 31, 2022
//	Course:            CSCI 3110
//	Author:            Hiren Patel, East Tennessee State University
//
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

namespace PatelHiren_Assignment3.Services

{
    /// <summary>
    /// Interface for the member class repo
    /// </summary>
    public interface IMemberClassRepository
    {
        MemberClassCompleted? Read(int id);                                 //Reads a class completed by a member in database
        ICollection<MemberClassCompleted> ReadAll();                        //Reads all the classes completed in database
        MemberClassCompleted? Create(string memberId, int classId);         //Creates a class in database
        void UpdateMemberSessions(int memberClassId, string completion);    //Updates the number of sessions in database
        void Delete(string memberId, int memberClassId);                    //Deletes a class in database
    }
}
