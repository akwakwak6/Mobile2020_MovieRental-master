using ADOLibrary;
using DAL.model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DAL.service {
    class MovieService {

        private readonly Connection _connection;

        private Movie Convert(SqlDataReader reader) {
            Movie m = new Movie();
            m.Id = (int)reader["Id"];

            return m;
        }

        public MovieService(Connection connection){
            this._connection = connection;
        }

        public Movie Get(int key) {
            Command cmd = new Command("SELECT * FROM V_Film WHERE Id = @id");
            cmd.AddParameter("Id", key);
            return _connection.ExecuteReader(cmd, Convert).SingleOrDefault();
        }

    }
}
