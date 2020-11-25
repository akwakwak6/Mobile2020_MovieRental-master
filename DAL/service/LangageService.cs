using ADOLibrary;
using DAL.model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DAL.service {
    public class LangageService {

        private readonly Connection _connection;

        private Langage Convert(SqlDataReader reader) {
            return new Langage() {
                Id = (int)reader["LanguageId"],
                Name = (string)reader["Name"]
            };
        }

        public LangageService(Connection connection) {
            _connection = connection;
        }

        public IEnumerable<Langage> GetAll() {
            Command cmd = new Command("SELECT * FROM Language");
            return _connection.ExecuteReader(cmd, Convert);
        }

    }
}
