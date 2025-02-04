﻿using FilmDB.Data;
using FilmDB.Models;
using Microsoft.EntityFrameworkCore;

namespace FilmDB.Repository
{
    public class FilmManager
    {
        private readonly ApplicationDbContext _context;

        public FilmManager(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<bool> AddFilmAsync(FilmModel filmModel)
        {
            try 
            {
                await _context.AddAsync(filmModel);
                await _context.SaveChangesAsync();
            }
            catch (Exception e) 
            {
                filmModel.ID = 0;
                await _context.SaveChangesAsync();
            }
            return true;
        }

        public async Task<FilmManager> RemoveFilm(int id)
        {
            var filmToDelete=await GetFilm(id);
            if (filmToDelete != null)
            {
                _context.Films.Remove(filmToDelete);
                await _context.SaveChangesAsync();
            }
            return this;
        }

        public async Task<FilmManager> UpdateFilm(FilmModel filmModel)
        {
            _context.Films.Update(filmModel);
            await _context.SaveChangesAsync();
            return this;
        }

        public async Task<FilmManager> ChangeTitle(int id, string newTitle)
        {
            var filmToChangeTitle = await GetFilm(id);
            if(filmToChangeTitle != null)
            {
                filmToChangeTitle.Title = newTitle;
                await _context.SaveChangesAsync();
            }
            return this;
        }

        public async Task<FilmModel> GetFilm(int id)
        {
            return await _context.Films.SingleOrDefaultAsync(f => f.ID == id);
        }

        public async Task<List<FilmModel>> GetFilms()
        {
            var films = await _context.Films.ToListAsync();
            return films;
        }
    }
}
