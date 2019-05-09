using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using DataLibrary.BusinessLogic;

namespace DataLibrary.DataAccess
{
    public class MoviesHandler
    {
        public static string GetConnectionString(string con = "IMDB")
        {
            return ConfigurationManager.ConnectionStrings["IMDB"].ConnectionString;
        }

        public static List<MovieModel> GetMovies()
        {
            string sp = "sp_get_all_movies";
            using (IDbConnection connection = new SqlConnection(GetConnectionString()))
            {
                List<MovieModel> movieslist = connection.Query<MovieModel>(sp, commandType: CommandType.StoredProcedure).ToList();
                return movieslist;
            }
        }

        public static List<ProducerModel> GetProducers()
        {
            string sql = "Select * from Producers";
            using (IDbConnection connection = new SqlConnection(GetConnectionString()))
            {
                List<ProducerModel> producers = connection.Query<ProducerModel>(sql).ToList();
                return producers;
            }
        }

        public static List<ActorModel> GetActors()
        {
            string sql = "Select * from Actors";
            using (IDbConnection connection = new SqlConnection(GetConnectionString()))
            {
                List<ActorModel> actors = connection.Query<ActorModel>(sql).ToList();
                return actors;
            }
        }

        public static void AddMovie(MovieModel movie)
        {
            string sql = "sp_add_movie";
            using (IDbConnection connection = new SqlConnection(GetConnectionString()))
            {
                var rows = connection.Execute(sql,
                    new { MovieName = movie.MovieName, Plot = movie.Plot,
                        ReleaseDate = movie.ReleaseDate, Producer = movie.Producer,
                        Actors = movie.Actors, ImgPath = movie.ImgPath }, commandType:CommandType.StoredProcedure);
            }
        }

        public static void AddActor(ActorModel actor)
        {
            string sql = "sp_add_actor";
            using (IDbConnection connection = new SqlConnection(GetConnectionString()))
            {
                var rows = connection.Execute(sql,
                    new
                    {
                        ActorName = actor.ActorName,
                        Sex = actor.Sex,
                        DOB = actor.DOB,
                        Bio = actor.Bio
                    }, commandType: CommandType.StoredProcedure);
            }
        }

        public static void AddProducer(ProducerModel producer)
        {
            string sql = "sp_add_producer";
            using (IDbConnection connection = new SqlConnection(GetConnectionString()))
            {
                var rows = connection.Execute(sql,
                    new
                    {
                        ProducerName = producer.ProducerName,
                        Sex = producer.Sex,
                        DOB = producer.DOB,
                        Bio = producer.Bio
                    }, commandType: CommandType.StoredProcedure);
            }
        }

        public static MovieModel GetMovie(int id)
        {
            string sql = "sp_get_movie";
            using (IDbConnection connection = new SqlConnection(GetConnectionString()))
            {
                MovieModel data = connection.Query<MovieModel>(sql, new { Id = id }, commandType: CommandType.StoredProcedure).SingleOrDefault();
                MovieModel movie = new MovieModel
                {
                    MovieId = data.MovieId,
                    MovieName = data.MovieName,
                    Plot = data.Plot,
                    ReleaseDate = data.ReleaseDate
                };
                return movie;
            }
        }

        public static void UpdateMovie(MovieModel movie)
        {
            string sql = "sp_update_movie_details";
            using(IDbConnection connection = new SqlConnection(GetConnectionString()))
            {
                var rows = connection.Execute(sql,
                    new
                    {
                        MovieName = movie.MovieName,
                        Plot = movie.Plot,
                        ReleaseDate = movie.ReleaseDate,
                        Producer = movie.Producer,
                        Actors = movie.Actors,
                        Id = movie.MovieId
                    }, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
