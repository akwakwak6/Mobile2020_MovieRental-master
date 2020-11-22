using ADOLibrary;
using DAL.model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace DAL.service {
    public class RentalService {

        private readonly Connection _connection;

        public RentalService(Connection connection) {
            _connection = connection;
        }

        private Rental Convert(SqlDataReader reader) {
            int id = (int)reader["RentalId"];
            return new Rental() {
                Id = id,
                Date = (DateTime)reader["RentalDate"],
                TotalPrice = (decimal)reader["TotalPrice"],
                Movies = getMovies(id)
            };
        }

        private RentalMovie ConvertRentalMovie(SqlDataReader reader) {
            return new RentalMovie() {
                IdMovie = (int)reader["FilmId"],
                Title = (string)reader["Title"],
                Price = (decimal)reader["RentalPrice"]
            };
        }

        private  IEnumerable<RentalMovie> getMovies(int idRental) {
            Command cmd = new Command("GetRentalMovies",true);
            cmd.AddParameter("RentalId", idRental);
            return _connection.ExecuteReader(cmd, ConvertRentalMovie);
        }

        public int Insert(IEnumerable<int> movieId,int idCustomer) {

            DataTable tvp = new DataTable();
            tvp.Columns.Add(new DataColumn("Id", typeof(int)));

            foreach (int id in movieId)
                tvp.Rows.Add(id);

            Command cmd = new Command("AddRental", true);
            cmd.AddParameter("MovieList", tvp);
            cmd.AddParameter("CostumerId", idCustomer);
            cmd.AddParameter("Date", DateTime.Now.ToString("s"));
            int r =  (int) _connection.ExecuteScalar(cmd);
            return r;

        }


        public Rental Get(int idRental, int idCustomer) {
            Command cmd = new Command("GetRentalByID",true);
            cmd.AddParameter("RentalID", idRental);

            //  => CHECK IF idCustomer CAN SEE THIS RENTAL
            //cmd.AddParameter("CostumerId", idCustomer);

            return _connection.ExecuteReader(cmd, Convert).SingleOrDefault();
        }

        public IEnumerable<Rental> GetAll(int idCustomer) {
            Command cmd = new Command("getRentalsByCostumerId",true);
            cmd.AddParameter("CostumerId", idCustomer);
            return _connection.ExecuteReader(cmd, Convert);
        }

    }
}
