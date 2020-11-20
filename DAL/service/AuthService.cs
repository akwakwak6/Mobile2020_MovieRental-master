using ADOLibrary;
using DAL.model;
using System.Data;
using System.Linq;

namespace DAL.service {
    public class AuthService {
        private Customer Convert(IDataReader reader) {
            return new Customer() {
                Id = (int)reader["CustomerId"],
                LastName = (string)reader["LastName"],
                FirstName = (string)reader["FirstName"],
                Email = (string)reader["Email"]
            };
        }

        private readonly Connection _connection;

        public AuthService(Connection connection) {
            _connection = connection;
        }

        public void Register(Customer c) {
            Command command = new Command("MVSP_RegisterUser", true);
            command.AddParameter("LastName", c.LastName);
            command.AddParameter("FirstName", c.FirstName);
            command.AddParameter("Email", c.Email);
            command.AddParameter("Passwd", c.Password);
            _connection.ExecuteNonQuery(command);
            c.Password = null;
        }

        public Customer Login(Customer c) {
            Command command = new Command("MVSP_CheckUser", true);
            command.AddParameter("Email", c.Email);
            command.AddParameter("Passwd", c.Password);
            return _connection.ExecuteReader(command, Convert).SingleOrDefault();
        }
    }
}
