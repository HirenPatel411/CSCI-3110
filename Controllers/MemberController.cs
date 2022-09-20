using PatelHiren_Assignment3.Services;
using Microsoft.AspNetCore.Mvc;
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//	File Name:         MemberController.cs
//  Date:              March 31, 2022
//	Course:            CSCI 3110
//	Author:            Hiren Patel, East Tennessee State University
//
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
namespace PatelHiren_Assignment3.Controllers
{
    /// <summary>
    /// This is the member class which shows all the members
    /// </summary>
    public class MemberController : Controller
    {
        private IMemberRepository _memberRepo;      //Private member repository variable

        /// <summary>
        /// Parameterized contructor for MemberController
        /// </summary>
        /// <param name="memberRepo"></param>
        public MemberController(IMemberRepository memberRepo)
        {
            _memberRepo = memberRepo;
        }

        /// <summary>
        /// This action reads all of the data in the repo
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return View(_memberRepo.ReadAll());
        }

        /// <summary>
        /// This action shows the members (details)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult Details(string id)
        {
            var member = _memberRepo.Read(id);
            if (member == null)
            {
                return RedirectToAction("Index");
            }
            return View(member);
        }
    }
}
