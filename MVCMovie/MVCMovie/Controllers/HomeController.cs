using MVCMovie.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLibrary.DataAccess;
using System.IO;

namespace MVCMovie.Controllers
{
    public class HomeController : Controller
    {
        //Showing list of movies in Home page.
        public ActionResult Index()
        {

            List<MovieModel> movies = new List<MovieModel>();
            try
            {
                //Calling GetMovies method in DataLibrary to get all movie details from database.
                var movielist = DataLibrary.DataAccess.MoviesHandler.GetMovies();
                foreach (var data in movielist)
                {
                    MovieModel m = new MovieModel
                    {
                        MovieId = data.MovieId,
                        MovieName = data.MovieName,
                        Plot = data.Plot,
                        ReleaseDate = data.ReleaseDate,
                        Producer = data.Producer,
                        ImgPath = data.ImgPath,
                        Actors = data.Actors
                    };
                    //If path is null then show default poster.
                    if (m.ImgPath == null)
                        m.ImgPath = "~/Images/MoviePoster.png";
                    movies.Add(m);
                }
            }
            catch(Exception ex)
            {
                string message = ex.Message;
                ModelState.AddModelError(string.Empty,message);
            }
            return View(movies);
        }

        //Get request for adding a new movie.
        public ActionResult AddNewMovie()
        {
            MovieModel movieModel = new MovieModel();
            try
            {
                var producers = MoviesHandler.GetProducers();
                List<SelectListItem> selectListItemsProducers = new List<SelectListItem>();
                var actors = MoviesHandler.GetActors();
                List<SelectListItem> selectListItemsActors = new List<SelectListItem>();
                foreach (var data in actors)
                {
                    SelectListItem a = new SelectListItem();
                    a.Text = data.ActorName;
                    a.Value = data.ActorId.ToString();
                    selectListItemsActors.Add(a);
                }
                movieModel.ActorList = selectListItemsActors;
                movieModel.ProducerList = new SelectList(producers, "ProducerId", "ProducerName");
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                ModelState.AddModelError(string.Empty, message);
            }
            return View(movieModel);
        }

        //Post request for adding a new movie, redirects user to Home page.
        [HttpPost]
        public ActionResult AddNewMovie(MovieModel movie)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    DataLibrary.BusinessLogic.MovieModel movieData = new DataLibrary.BusinessLogic.MovieModel();
                    movieData.MovieName = movie.MovieName;
                    movieData.Plot = movie.Plot;
                    movieData.ReleaseDate = movie.ReleaseDate;
                    movieData.Producer = movie.SelectedProducer;
                    movieData.Actors = string.Join(",", movie.ActorNames);
                    if (movie.ImageFile != null)
                    {
                        string filename = Path.GetFileNameWithoutExtension(movie.ImageFile.FileName);
                        string extension = Path.GetExtension(movie.ImageFile.FileName);
                        filename = filename + DateTime.Now.ToString("yymmssfff") + extension;
                        movieData.ImgPath = "~/Images/" + filename;
                        filename = Path.Combine(Server.MapPath("~/Images/"), filename);
                        movie.ImageFile.SaveAs(filename);
                    }
                    DataLibrary.DataAccess.MoviesHandler.AddMovie(movieData);
                    return RedirectToAction("index");
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                ModelState.AddModelError(string.Empty, message);
            }
            return View();
        }

        //Displays partial content for adding a new actor.
        public ActionResult _PartialAddActor()
        {
            try
            {
                List<SelectListItem> sex_items = new List<SelectListItem>();
                sex_items.Add(new SelectListItem() { Text = "FEMALE", Value = "FEMALE" });
                sex_items.Add(new SelectListItem() { Text = "MALE", Value = "MALE" });
                ViewBag.Sex = sex_items;
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                ModelState.AddModelError(string.Empty, message);
            }
            return View();
        }

        [HttpPost]
        public ActionResult _PartialAddActor(ActorModel actor)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    DataLibrary.BusinessLogic.ActorModel actordata = new DataLibrary.BusinessLogic.ActorModel();
                    actordata.ActorName = actor.ActorName;
                    actordata.Sex = actor.Sex;
                    actordata.DOB = actor.DOB;
                    actordata.Bio = actor.Bio;
                    DataLibrary.DataAccess.MoviesHandler.AddActor(actordata);
                    return RedirectToAction("AddNewMovie");
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                ModelState.AddModelError(string.Empty, message);
            }
            return View();
        }

        //Displays partial content for adding a new producer.
        public ActionResult _PartialAddProducer()
        {
            try
            {
                List<SelectListItem> sex_items = new List<SelectListItem>();
                sex_items.Add(new SelectListItem() { Text = "FEMALE", Value = "FEMALE" });
                sex_items.Add(new SelectListItem() { Text = "MALE", Value = "MALE" });
                ViewBag.Sex = sex_items;
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                ModelState.AddModelError(string.Empty, message);
            }
            return View();
        }

        [HttpPost]
        public ActionResult _PartialAddProducer(ProducerModel producer)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    DataLibrary.BusinessLogic.ProducerModel producerdata = new DataLibrary.BusinessLogic.ProducerModel();
                    producerdata.ProducerName = producer.ProducerName;
                    producerdata.Sex = producer.Sex;
                    producerdata.DOB = producer.DOB.Date;
                    producerdata.Bio = producer.Bio;
                    DataLibrary.DataAccess.MoviesHandler.AddProducer(producerdata);
                    return RedirectToAction("AddNewMovie");
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                ModelState.AddModelError(string.Empty, message);
            }
            return View();
        }


        //Get request to edit a particular movie detail.
        [HttpGet]
        public ActionResult Edit(int id)
        {
            try
            {
                var moviedata = DataLibrary.DataAccess.MoviesHandler.GetMovie(id);
                var producers = MoviesHandler.GetProducers();
                List<SelectListItem> selectListItemsProducers = new List<SelectListItem>();
                var actors = MoviesHandler.GetActors();
                List<SelectListItem> selectListItemsActors = new List<SelectListItem>();
                foreach (var data in actors)
                {
                    SelectListItem a = new SelectListItem();
                    a.Text = data.ActorName;
                    a.Value = data.ActorId.ToString();
                    selectListItemsActors.Add(a);
                }
                MovieModel movie = new MovieModel
                {
                    MovieId = moviedata.MovieId,
                    MovieName = moviedata.MovieName,
                    ReleaseDate = moviedata.ReleaseDate,
                    Plot = moviedata.Plot,
                    ActorList = selectListItemsActors,
                    ProducerList = new SelectList(producers, "ProducerId", "ProducerName")
                };
                return View(movie);
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                ModelState.AddModelError(string.Empty, message);
            }
            return View();
        }


        //Post request to edit a particular movie details.
        [HttpPost]
        public ActionResult Edit(MovieModel movie)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    DataLibrary.BusinessLogic.MovieModel moviedata = new DataLibrary.BusinessLogic.MovieModel();
                    moviedata.MovieName = movie.MovieName;
                    moviedata.Plot = movie.Plot;
                    moviedata.Producer = movie.SelectedProducer;
                    moviedata.ReleaseDate = movie.ReleaseDate;
                    moviedata.Actors = string.Join(",", movie.ActorNames);
                    moviedata.MovieId = movie.MovieId;
                    DataLibrary.DataAccess.MoviesHandler.UpdateMovie(moviedata);
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    string message = ex.Message;
                    ModelState.AddModelError(string.Empty, message);
                }
            }
            return View();
        }


    }
}