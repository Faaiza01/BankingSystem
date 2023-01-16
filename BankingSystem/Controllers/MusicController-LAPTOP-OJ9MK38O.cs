using Forest.Services.IService;
using Forest.Services.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Forest.Controllers
{
    public class MusicController : Controller
    {
        private IMusicService musicService;
        private IGenreService genreService = new GenreService();

        public MusicController()
        {
            musicService = new MusicService();
        }

        public ActionResult GetMusic(int id)
        {
            ViewBag.GenreID = genreService.GetGenres().Where(b => b.Musics.Where(m => m.ID == id) == musicService.GetMusic(id));
            return View(musicService.GetMusic(id));
        }

        // GET: Music
        public ActionResult Index()
        {
            return View();
        }
    }
}