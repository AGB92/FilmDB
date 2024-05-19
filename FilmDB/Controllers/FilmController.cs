using FilmDB.Models;
using FilmDB.Repository;
using Microsoft.AspNetCore.Mvc;

namespace FilmDB.Controllers
{
    public class FilmController : Controller
    {
        private readonly FilmManager _manager;
        public FilmController(FilmManager manager)
        {
            _manager = manager;
        }

        public async Task<IActionResult> Index()
        {
            //wywoania testowe
                //var film = new FilmModel()
                //{
                //    // blad - nie mogę tak ale mamy to obsluzone ID = 2,
                //    Title = "Mała Syrenka",
                //    Year = 1990
                //};
                //await _manager.AddFilmAsync(film);
                //await _manager.RemoveFilm(10);
                //var filmByID = _manager.GetFilm(13);
                //await _manager.ChangeTitle(13, "Rambo2");
                //var filmByID = _manager.GetFilm(16);
                //filmByID.Year = 2023;
                //await _manager.UpdateFilm(filmByID);
                //var films=_manager.GetFilms();
            return View();
        }

        [HttpGet]
        public IActionResult Add() 
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(FilmModel film) 
        {
            try
            {
                await _manager.AddFilmAsync(film);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return View(film);
            }

        }
    }
}
