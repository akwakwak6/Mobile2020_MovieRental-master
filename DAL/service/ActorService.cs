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

        public Actor Get(int key) {
            Command cmd = new Command("SELECT * FROM Actor WHERE ActorId = @id");
            cmd.AddParameter("Id", key);
            return _connection.ExecuteReader(cmd, Convert).SingleOrDefault();
        }

        public IEnumerable<Actor> GetAll() {
            Command cmd = new Command("SELECT * FROM Actor");
            return _connection.ExecuteReader(cmd, Convert);
        }

    }
}
