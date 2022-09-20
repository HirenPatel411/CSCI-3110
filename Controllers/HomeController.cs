using Microsoft.AspNetCore.Mvc;
using PatelHiren_Assignment3.Models;
using PatelHiren_Assignment3.Services;
using System.Diagnostics;
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//	File Name:         HomeController.cs
//  Date:              March 31, 2022
//	Course:            CSCI 3110
//	Author:            Hiren Patel, East Tennessee State University
//
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
namespace PatelHiren_Assignment3.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMemberRepository _memberRepo;             //Private readonly variable for IMemberRepository
        private readonly IMemberClassRepository _memberClassRepo;   //Private readonly variable for IMemberClassRepository
        private readonly IClassRepository _classRepo;               //Private readonly variable for IClassRepository

        /// <summary>
        /// Non-Parameterized contructor for HomeController
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="classRepo"></param>
        /// <param name="memberClassRepo"></param>
        /// <param name="memberRepo"></param>
        public HomeController(ILogger<HomeController> logger,
            IClassRepository classRepo,
            IMemberClassRepository memberClassRepo,
            IMemberRepository memberRepo)
        {
            _logger = logger;
            _memberRepo = memberRepo;
            _memberClassRepo = memberClassRepo;
            _classRepo = classRepo;
        }

        /// <summary>
        /// Action to direct to the Member page
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return RedirectToAction("Index", "Member");
        }

        /// <summary>
        /// Action to view the Privacy tab
        /// </summary>
        /// <returns></returns>
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]

        /// <summary>
        /// Action to show error
        /// </summary>
        /// <returns></returns>
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}