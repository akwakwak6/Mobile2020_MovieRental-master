using ADOLibrary;
using DAL.model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DAL.service {
    public class InitialActorService {

        private readonly Connection _connection;

        private InitialActor Convert(SqlDataReader reader) {
            return new InitialActor() {
                Id = (int)reader["ActorID"],
                Initila = (string)reader["Initial"]
            };
        }

        public InitialActorService(Connection connection) {
            _connection = connection;
        }

        public InitialActor Get(int key) {
            Command cmd = new Command("select ActorId,CONCAT(LEFT(LastName,1), '.', LEFT(FirstName,1),'.' ) as Initial from Actor where ActorId = @id");
            cmd.AddParameter("Id", key);
            return _connection.ExecuteReader(cmd, Convert).SingleOrDefault();
        }

        public IEnumerable<InitialActor> GetAll() {
            Command cmd = new Command("select ActorId,CONCAT(LEFT(LastName,1), '.', LEFT(FirstName,1),'.' ) as Initial from Actor");
            return _connection.ExecuteReader(cmd, Convert);
        }
    }
}
