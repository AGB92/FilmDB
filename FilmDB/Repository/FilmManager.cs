using FilmDB.Data;
using FilmDB.Models;

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
            var filmToDelete=_context.Films.SingleOrDefault(f=>f.ID == id);
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
            var filmToChangeTitle = GetFilm(id);
            if(filmToChangeTitle != null)
            {
                filmToChangeTitle.Title = newTitle;
                await _context.SaveChangesAsync();
            }
            return this;
        }

        public FilmModel GetFilm(int id)
        {
            var film = _context.Films.SingleOrDefault(f => f.ID == id);
            return film;
        }

        public List<FilmModel> GetFilms()
        {
            var films = _context.Films.ToList();
            return films;
        }
    }
}
