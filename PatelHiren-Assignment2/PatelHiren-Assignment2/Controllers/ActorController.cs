using Microsoft.AspNetCore.Mvc;
using PatelHiren_Assignment2.Models.Entities;
using PatelHiren_Assignment2.Models.ViewModels;
using PatelHiren_Assignment2.Services;
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//	File Name:         ActorController.cs
//  Date:              March 3, 2022
//	Course:            CSCI 3110
//	Author:            Hiren Patel, East Tennessee State University
//
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

namespace PatelHiren_Assignment2.Controllers
{
    /// <summary>
    /// This class is the controlller for the actor
    /// </summary>
    public class ActorController : Controller
    {
        private readonly IMovieRepository _movieRepo;           //Read only for the repository

        /// <summary>
        /// This method initializes a movie repository
        /// </summary>
        /// <param name="movieRepo"></param>
        public ActorController(IMovieRepository movieRepo)
        {
            _movieRepo = movieRepo;
        }

        /// <summary>
        /// This method shows the create actor page if a movie is also created
        /// </summary>
        /// <param name="movieId"></param>
        /// <returns></returns>
        public IActionResult Create([Bind(Prefix = "id")] int movieId)
        {
            var movie = _movieRepo.Read(movieId);
            if (movie == null)
            {
                return RedirectToAction("Index", "Movie");
            }
            ViewData["Movie"] = movie;
            return View();
        }

        /// <summary>
        /// This method returns a certain view of the create page depending on the action
        /// </summary>
        /// <param name="movieId"></param>
        /// <param name="actorViewModel"></param>
        /// <returns></returns>
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Create(int movieId, CreateActorViewModel actorViewModel)
        {
            if (ModelState.IsValid)
            {
                var actor = actorViewModel.GetActorInstance();
                _movieRepo.CreateActor(movieId, actor);
                return RedirectToAction("Details", "Movie", new { id = movieId });
            }
            ViewData["Movie"] = _movieRepo.Read(movieId);
            return View(actorViewModel);
        }

        /// <summary>
        /// This method shows the edit actor page if a movie is also created
        /// </summary>
        /// <param name="movieId"></param>
        /// <param name="actorId"></param>
        /// <returns></returns>
        public IActionResult Edit([Bind(Prefix = "id")] int movieId, int actorId)
        {
            var movie = _movieRepo.Read(movieId);
            if (movie == null)
            {
                return RedirectToAction("Index", "Movie");
            }
            var actor = movie.Actors.FirstOrDefault(r => r.Id == actorId);
            if (actor == null)
            {
                return RedirectToAction("Details", "Movie", new { id = movieId });
            }
            ViewData["Movie"] = movie;
            return View(actor);
        }

        /// <summary>
        /// This method returns a certain view of the edit page depending on the action
        /// </summary>
        /// <param name="movieId"></param>
        /// <param name="actor"></param>
        /// <returns></returns>
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Edit(int movieId, Actor actor)
        {
            if (ModelState.IsValid)
            {
                _movieRepo.EditActor(movieId, actor);
                return RedirectToAction("Details", "Movie", new { id = movieId });
            }
            ViewData["Movie"] = _movieRepo.Read(movieId);
            return View(actor);
        }

        /// <summary>
        /// This method shows the delete actor page if a movie is also created
        /// </summary>
        /// <param name="movieId"></param>
        /// <param name="actorId"></param>
        /// <returns></returns>
        public IActionResult Delete([Bind(Prefix = "id")] int movieId, int actorId)
        {
            var movie = _movieRepo.Read(movieId);
            if (movie == null)
            {
                return RedirectToAction("Index", "Movie");
            }
            var actor = movie.Actors.FirstOrDefault(r => r.Id ==
         actorId);
            if (actor == null)
            {
                return RedirectToAction("Details", "Movie", new { id = movieId });
            }
            ViewData["Movie"] = movie;
            return View(actor);
        }

        /// <summary>
        /// This method returns a certain view of the delete page depending on the action
        /// </summary>
        /// <param name="id"></param>
        /// <param name="movieId"></param>
        /// <returns></returns>
        [HttpPost, ActionName("Delete"), ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id, int movieId)
        {
            _movieRepo.DeleteActor(movieId, id);
            return RedirectToAction("Details", "Movie", new { id = movieId });
        }


    }
}
