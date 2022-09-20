using Microsoft.AspNetCore.Mvc;
using PatelHiren_Assignment3.Services;
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//	File Name:         ClassController.cs
//  Date:              March 31, 2022
//	Course:            CSCI 3110
//	Author:            Hiren Patel, East Tennessee State University
//
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

namespace PatelHiren_Assignment3.Controllers
{
    /// <summary>
    /// This class is a controller to sign up for classes offered in the database
    /// </summary>
    public class ClassController : Controller
    {
        private IMemberRepository _memberRepo;              //Private Member repository variable
        private readonly IClassRepository _classRepo;       //Private Class repository variable
        

        /// <summary>
        /// Parameterized constructor for the ClassController
        /// </summary>
        /// <param name="memberRepo"></param>
        /// <param name="classRepo"></param>
        public ClassController(IMemberRepository memberRepo, IClassRepository classRepo)
        {
            _memberRepo = memberRepo;       
            _classRepo = classRepo;         
        }


        /// <summary>
        /// This is the action method to sign up for a gym class
        /// </summary>
        /// <param name="memberId"></param>
        /// <returns></returns>
        public IActionResult Signup([Bind(Prefix = "id")] string memberId)
        {
            var member = _memberRepo.Read(memberId);
            if (member == null)
            {
                return RedirectToAction("Index", "Member");
            }
            var allClasses = _classRepo.ReadAll();
            var classSignedUp = member.ClassCompletion
                .Select(scg => scg.Class).ToList();
            var classNotSignedUp = allClasses.Except(classSignedUp);

            ViewData["Member"] = member;

            return View(classNotSignedUp);
        }
    }
}
