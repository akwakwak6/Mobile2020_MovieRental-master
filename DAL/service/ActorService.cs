using ADOLibrary;
using DAL.model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DAL.service {
    public class ActorService {

        private readonly Connection _connection;

        private Actor Convert(SqlDataReader reader) {
            Actor m = new Actor() {
                Id = (int)reader["ActorID"],
                FirstName = (string)reader["FirstName"],
                LastName = (string)reader["LastName"]
            };
            return m;
        }

        public ActorService(Connection connection) {
            _connection = connection;
        }

        public IEnumerable<Actor> getActorsInMovies(int moviesId) {
            Command cmd = new Command("select * from Actor AS A JOIN FilmActor AS FA ON A.ActorId = FA.ActorId WHERE FA.FilmId = @Id");
            cmd.AddParameter("Id", moviesId);
            return _connection.ExecuteReader(cmd, Convert);
        }

        public IEnumerable<Actor> GetAllStartedBy(char initial) {
            Command cmd = new Command("SELECT * FROM Actor where LastName LIKE @i+'%'");
            cmd.AddParameter("i", initial);
            return _connection.ExecuteReader(cmd, Convert);
        }

    }
}
