using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DogGo.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;


namespace DogGo.Repositories
{
    public class WalkRepository : IWalkRepository
    {
        private readonly IConfiguration _config;

        public WalkRepository(IConfiguration config)
        {
            _config = config;
        }
        public SqlConnection Connection
        {
            get
            {
                return new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            }
        }
        public void Add(Walk walk, int dogId )
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"INSERT INTO Walks (Date, Duration, WalkerId, DogId)
                                        VALUES (@date, @duration, @walkerId, @dogId);";

                    cmd.Parameters.AddWithValue("@date", walk.Datetime);
                    cmd.Parameters.AddWithValue("@duration", walk.DurationInSeconds);
                    cmd.Parameters.AddWithValue("@walkerId", walk.WalkerId);
                    cmd.Parameters.AddWithValue("@dogId", dogId);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
