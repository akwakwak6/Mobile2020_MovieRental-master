using ADOLibrary;
using DAL.model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DAL.service {
    public class CategoryService {

        private readonly Connection _connection;

        private Category Convert(SqlDataReader reader) {
            return new Category() {
                Id = (int)reader["CategoryID"],
                Name = (string)reader["Name"]
            };
        }

        public CategoryService(Connection connection) {
            _connection = connection;
        }

        public IEnumerable<Category> GetCategoryInMovie(int movieId) {
            Command cmd = new Command("select * from Category AS C JOIN FilmCategory AS FC ON C.CategoryId = FC.CategoryId WHERE FC.FilmId = @Id");
            cmd.AddParameter("Id", movieId);
            return _connection.ExecuteReader(cmd, Convert);
        }

        public Category Get(int key) {
            Command cmd = new Command("SELECT * FROM Category WHERE CategoryId = @id");
            cmd.AddParameter("Id", key);
            return _connection.ExecuteReader(cmd, Convert).SingleOrDefault();
        }

        public IEnumerable<Category> GetAll() {
            Command cmd = new Command("SELECT * FROM Category");
            return _connection.ExecuteReader(cmd, Convert);
        }

    }
}
