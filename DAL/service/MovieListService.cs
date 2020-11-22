using ADOLibrary;
using DAL.model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DAL.service {
    public class MovieListService {

        private readonly Connection _connection;

        private MovieList Convert(SqlDataReader reader) {
            MovieList m = new MovieList() {
                Id = (int)reader["FilmID"],
                Title = (string)reader["Title"],
                ReleaseYear = (int)reader["ReleaseYear"]
            };
            return m;
        }

        public MovieListService(Connection connection) {
            this._connection = connection;
        }

        public MovieList Get(int key) {
            Command cmd = new Command("SELECT * FROM V_Film WHERE FilmId = @id");
            cmd.AddParameter("Id", key);
            return _connection.ExecuteReader(cmd, Convert).SingleOrDefault();
        }
    }
}
