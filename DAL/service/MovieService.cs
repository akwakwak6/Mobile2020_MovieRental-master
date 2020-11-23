using ADOLibrary;
using DAL.model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DAL.service {
    public class MovieService {

        private readonly Connection _connection;
        private readonly ActorService _actorService;
        private readonly CategoryService _categoryService;

        private Movie Convert(SqlDataReader reader) {
            int id = (int)reader["FilmID"];
            Movie m = new Movie() {
                Id = id,
                Title = (string)reader["Title"],
                Description = (string)reader["Description"],
                ReleaseYear = (int)reader["ReleaseYear"],
                Language = (string)reader["Name"],
                Price = (decimal)reader["RentalPrice"],
                RentalDuration = (int)reader["RentalDuration"],
                Length = (int)reader["Length"],
                ReplacementCost = (decimal)reader["ReplacementCost"],
                Rating = (string)reader["Rating"],
                Actors = _actorService.getActorsInMovies(id),
                Category = _categoryService.GetCategoryInMovie(id)
            };
            return m;
        }

        private MovieList ConvertList(SqlDataReader reader) {
            return new MovieList() {
                Id = (int)reader["FilmID"],
                Title = (string)reader["Title"],
                Price = (decimal)reader["RentalPrice"],
            };
        }

        public MovieService(Connection connection, ActorService actorService, CategoryService categoryService) {
            this._connection = connection;
            _actorService = actorService;
            _categoryService = categoryService;
        }

        public Movie Get(int key) {
            Command cmd = new Command("SELECT * FROM V_Film WHERE FilmId = @id");
            cmd.AddParameter("Id", key);
            return _connection.ExecuteReader(cmd, Convert).SingleOrDefault();
        }

        public IEnumerable<MovieList> GetAllMovieStartedBy(char initial) {
            Command cmd = new Command("SELECT FilmID,Title,RentalPrice FROM V_Film where Title LIKE @i+'%'");
            cmd.AddParameter("i", initial);
            return _connection.ExecuteReader(cmd, ConvertList);
        }

        public IEnumerable<MovieList> GetMovieListFillted(FilterMovie fm) {
            Command cmd = new Command("GetFilletedMovieList",true);

            if( fm.Category != null )
                cmd.AddParameter("Category", fm.Category);

            if (fm.Actor != null)
                cmd.AddParameter("Actor", fm.Actor);

            if (fm.Title != null)
                cmd.AddParameter("Title", fm.Title);

            if (fm.Langage != null)
                cmd.AddParameter("Langage", fm.Langage);

            if (fm.KeyWord != null)
                cmd.AddParameter("KeyWord", fm.KeyWord);

            return _connection.ExecuteReader(cmd, ConvertList);

        }

    }
}
