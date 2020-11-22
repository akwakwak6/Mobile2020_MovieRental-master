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

        private Movie Convert(SqlDataReader reader) {
            Movie m = new Movie() {
                Id = (int)reader["FilmID"],
                Title = (string)reader["Title"],
                Description = (string)reader["Description"],
                ReleaseYear = (int)reader["ReleaseYear"],
                Language = (string)reader["Name"],
                Price = (decimal)reader["RentalPrice"],
                RentalDuration = (int)reader["RentalDuration"],
                Length = (int)reader["Length"],
                ReplacementCost = (decimal)reader["ReplacementCost"],
                Rating = (string)reader["Rating"]
            };
            return m;
        }

        public MovieService(Connection connection){
            this._connection = connection;
        }

        public Movie Get(int key) {
            Command cmd = new Command("SELECT * FROM V_Film WHERE FilmId = @id");
            cmd.AddParameter("Id", key);
            return _connection.ExecuteReader(cmd, Convert).SingleOrDefault();
        }

    }
}
