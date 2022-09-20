using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PatelHiren_Assignment2.Models.Entities;
using PatelHiren_Assignment2.Services;
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//	File Name:         MovieController.cs
//  Date:              March 3, 2022
//	Course:            CSCI 3110
//	Author:            Hiren Patel, East Tennessee State University
//
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
namespace PatelHiren_Assignment2.Controllers
{
    /// <summary>
    /// This class is the controlller for the movie
    /// </summary>
    public class MovieController : Controller
    {
        private readonly IMovieRepository _movieRepo;           //Read only for the repository

        /// <summary>
        /// This method initializes a movie repository
        /// </summary>
        /// <param name="movieRepo"></param>
        public MovieController(IMovieRepository movieRepo)
        {
            _movieRepo = movieRepo;
        }

        /// <summary>
        /// This method uses the read all method to show the movies
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            var movieModel = _movieRepo.ReadAll();
            return View(movieModel);
        }

        /// <summary>
        /// This method shows the details of a certain movie
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult Details(int id)
        {
            var movie = _movieRepo.Read(id);
            if (movie == null)
            {
                return RedirectToAction("Index");
            }
            return View(movie);
        }

        /// <summary>
        /// This method shows the create movie page
        /// </summary>
        /// <returns></returns>
        public IActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// This method returns a certain view of the create page depending on the action
        /// </summary>
        /// <param name="movie"></param>
        /// <returns></returns>
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Create(Movie movie)
        {
            if (ModelState.IsValid)
            {
                _movieRepo.Create(movie);
                return RedirectToAction("Index");
            }
            return View(movie);
        }

        /// <summary>
        /// This method shows the edit movie page
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult Edit(int id)
        {
            var movie = _movieRepo.Read(id);
            if (movie != null)
            {
                return View(movie);
            }

            return RedirectToAction("Index");

        }

        /// <summary>
        /// This method returns a certain view of the edit page depending on the action
        /// </summary>
        /// <param name="movie"></param>
        /// <returns></returns>
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Edit(Movie movie)
        {
            if (ModelState.IsValid)
            {
                _movieRepo.Edit(movie.Id, movie);
                return RedirectToAction("Index");
            }

            return View(movie);
        }

        /// <summary>
        /// This method shows the delete movie page
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult Delete(int id)
        {
            var book = _movieRepo.Read(id);
            if (book == null)
            {
                return RedirectToAction("Index");
            }
            return View(book);
        }

        /// <summary>
        /// This method returns a certain view of the delete page depending on the action
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost, ActionName("Delete"), ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _movieRepo.Delete(id);
            return RedirectToAction("index");
        }
    }
}
