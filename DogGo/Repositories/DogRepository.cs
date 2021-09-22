﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DogGo.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace DogGo.Repositories
{
    public class DogRepository : IDogRepository
    {
        private readonly IConfiguration _config;

        public DogRepository(IConfiguration config)
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
        public List<Dog>Get()
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT d.Id AS DogId, d.Name AS DogName, Breed, o.Id AS OwnerId
                                      FROM DOG d
                                      JOIN Owner o ON d.OwnerId = o.Id";

                    using SqlDataReader reader = cmd.ExecuteReader();
                    {
                    List<Dog> dogs = new List<Dog>();
                    while (reader.Read())
                    {
                        Dog dog = new Dog
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("DogId")),
                            Name = reader.GetString(reader.GetOrdinal("DogName")),
                            Breed = reader.GetString(reader.GetOrdinal("Breed")),
                            Owner = new Owner { Id = reader.GetOrdinal("OwnerId") }
                        };
                        dogs.Add(dog);
                    }
                    return dogs;
                    }
                }
            }
        }
        public Dog Get(int id)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                                      SELECT d.Id AS DogId, d.Name AS DogName, Breed, o.Id AS OwnerId
                                      FROM DOG d
                                      JOIN Owner o ON D.OwnerId = o.Id
                                      WHERE d.Id = @DogId";

                    cmd.Parameters.AddWithValue("@DogId", id);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Dog dog = new Dog
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("DogId")),
                                Name = reader.GetString(reader.GetOrdinal("DogName")),
                                Breed = reader.GetString(reader.GetOrdinal("Breed")),
                                Owner = new Owner { Id = reader.GetOrdinal("OwnerId") }
                            };
                            return dog;
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
            }
        }
        public void Delete(int dogId)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();

                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                                      DELETE FROM Dog
                                      WHERE Id = @id";

                    cmd.Parameters.AddWithValue("@id", dogId);

                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void Add(Dog dog)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                                      INSERT INTO Dog ([Name], Breed, OwnerId
                                      OUTPUT INSERTED.Id
                                      VALUES (@name, @breed, @ownerId);
                                      ";

                    cmd.Parameters.AddWithValue("@name", dog.Name);
                    cmd.Parameters.AddWithValue("@breed", dog.Breed);
                    cmd.Parameters.AddWithValue("@ownerId", dog.Owner.Id);

                    int id = (int)cmd.ExecuteScalar();

                    dog.Id = id;
                }
            }
        }
        public void Update(Dog dog)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                                      UPDATE Dog
                                      SET [Name] = @name
                                      Breed = @breed,
                                      OwnerId = @ownerId
                                      ImageUrl = @imageUrl
                                      Notes = @notes
                    WHERE Id = @id";

                    cmd.Parameters.AddWithValue("@name", dog.Name);
                    cmd.Parameters.AddWithValue("@breed", dog.Breed);
                    cmd.Parameters.AddWithValue("@ownerId", dog.Owner.Id);
                    cmd.Parameters.AddWithValue("@imageUrl", dog.ImageUrl);
                    cmd.Parameters.AddWithValue("@ownerId", dog.Owner.Id);
                    cmd.Parameters.AddWithValue("notes", dog.Notes);
                }
            }
        }
    }
}