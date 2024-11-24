using PetPals.Model;
using PetPals.Util;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace PetPals.Repository
{
    internal class PetRepository : IPetRepository
    {
        private readonly string connectionString;
        private SqlCommand _cmd;

        public PetRepository()
        {
            // Assuming you have a method that retrieves your connection string from configuration
            connectionString = DBPropertyUtil.GetConnectionString(); 
            _cmd = new SqlCommand();
        }

        public void AddPet(Pet pet)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    _cmd.CommandText = @"INSERT INTO Pets (Name, Age, Breed, AvailableForAdoption) 
                                         VALUES (@Name, @Age, @Breed, @AvailableForAdoption)";
                    _cmd.Parameters.Clear();
                    _cmd.Connection = conn;

                    // Add parameters for the Pet
                    _cmd.Parameters.AddWithValue("@Name", pet.Name);
                    _cmd.Parameters.AddWithValue("@Age", pet.Age);
                    _cmd.Parameters.AddWithValue("@Breed", pet.Breed);
                    _cmd.Parameters.AddWithValue("@AvailableForAdoption", pet.AvailableForAdoption);  // Assuming there's an AvailableForAdoption flag

                    conn.Open();
                    _cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error adding pet: {ex.Message}");
                }
            }
        }

        public Pet GetPetById(int petId)
        {
            Pet pet = null;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    _cmd.CommandText = "SELECT * FROM Pets WHERE PetID = @PetID";
                    _cmd.Parameters.Clear();
                    _cmd.Parameters.AddWithValue("@PetID", petId);
                    _cmd.Connection = conn;

                    conn.Open();
                    SqlDataReader reader = _cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        pet = ExtractPet(reader);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error retrieving pet by ID: {ex.Message}");
                }
            }

            return pet;
        }

        public List<Pet> GetAvailablePets()
        {
            List<Pet> pets = new List<Pet>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    _cmd.CommandText = "SELECT * FROM Pets WHERE AvailableForAdoption = 1";  // Assuming 1 means available
                    _cmd.Parameters.Clear();
                    _cmd.Connection = conn;

                    conn.Open();
                    SqlDataReader reader = _cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        pets.Add(ExtractPet(reader));
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error retrieving available pets: {ex.Message}");
                }
            }

            return pets;
        }

        public void UpdatePet(Pet pet)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    _cmd.CommandText = @"UPDATE Pets SET 
                                         Name = @Name, 
                                         Age = @Age, 
                                         Breed = @Breed, 
                                         AvailableForAdoption = @AvailableForAdoption 
                                         WHERE PetID = @PetID";
                    _cmd.Parameters.Clear();
                    _cmd.Connection = conn;

                    // Add parameters for the Pet
                    _cmd.Parameters.AddWithValue("@PetID", pet.PetID);
                    _cmd.Parameters.AddWithValue("@Name", pet.Name);
                    _cmd.Parameters.AddWithValue("@Age", pet.Age);
                    _cmd.Parameters.AddWithValue("@Breed", pet.Breed);
                    _cmd.Parameters.AddWithValue("@AvailableForAdoption", pet.AvailableForAdoption);

                    conn.Open();
                    _cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error updating pet: {ex.Message}");
                }
            }
        }

        public void DeletePet(int petId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    _cmd.CommandText = "DELETE FROM Pets WHERE PetID = @PetID";
                    _cmd.Parameters.Clear();
                    _cmd.Parameters.AddWithValue("@PetID", petId);
                    _cmd.Connection = conn;

                    conn.Open();
                    _cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error deleting pet: {ex.Message}");
                }
            }
        }

        private Pet ExtractPet(SqlDataReader reader)
        {
            return new Pet
            {
                PetID = (int)reader["PetID"],
                Name = (string)reader["Name"],
                Age = (int)reader["Age"],
                Breed = (string)reader["Breed"],
                AvailableForAdoption = (int)reader["AvailableForAdoption"]
            };
        }
    }
}
