using FilmDB.Models;
using FilmDB.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;

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
            var filmList=await _manager.GetFilms();
            return View(filmList);
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
        [HttpGet]
        public async Task<IActionResult> Remove(int id)
        {
            var filmToDelete = await _manager.GetFilm(id);
            if(filmToDelete != null)
            {
                return View(filmToDelete);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
        [HttpPost]
        public async Task<IActionResult> RemoveConfirm(int id) 
        {
            try 
            {
                await _manager.RemoveFilm(id);
                return RedirectToAction("Index");
            }   
            catch (Exception e) 
            {
                return RedirectToAction("Remove",id);
            }
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var filmToEdit=await _manager.GetFilm(id);
            if(filmToEdit != null)
            {
                return View(filmToEdit);
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> Edit(FilmModel film)
        {
            await _manager.UpdateFilm(film);
            return RedirectToAction("Index");
        }
        
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var film = await _manager.GetFilm(id);
            return View(film);
        }
    }
}
