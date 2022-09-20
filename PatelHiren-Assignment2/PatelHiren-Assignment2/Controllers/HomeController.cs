using Microsoft.AspNetCore.Mvc;
using PatelHiren_Assignment2.Models;
using System.Diagnostics;
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//	File Name:         HomeController.cs
//  Date:              March 3, 2022
//	Course:            CSCI 3110
//	Author:            Hiren Patel, East Tennessee State University
//
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
namespace PatelHiren_Assignment2.Controllers
{
    /// <summary>
    /// This class is the controller for the home page
    /// </summary>
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        /// <summary>
        /// Method for the home page logger
        /// </summary>
        /// <param name="logger"></param>
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// This method directs the action index to movie
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return RedirectToAction("Index", "Movie");
        }

        /// <summary>
        /// Method for privacy page
        /// </summary>
        /// <returns></returns>
        public IActionResult Privacy()
        {
            return View();
        }

        /// <summary>
        /// Method for error page
        /// </summary>
        /// <returns></returns>
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}