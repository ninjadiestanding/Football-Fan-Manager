using Football_Fan_Manager.Database;
using Football_Fan_Manager.Models;
using Football_Fan_Manager.Services.Interfaces;
using Football_Fan_Manager.SQLQueryProviders;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Football_Fan_Manager.Services.Implementation
{
    class FanRepository : IFanRepository
    {
        private readonly string connectionString;
        private FanQueryProvider fanQueryProvider;

        public FanRepository()
        {
            connectionString = DatabaseHelper.GetConnectionString();

            fanQueryProvider = new FanQueryProvider();
        }

        public List<Fan> GetFans()
        {
            var fans = new List<Fan>();

            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                using (var command = new SQLiteCommand(fanQueryProvider.GetFans, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = reader.GetInt32(0);
                            string name = reader.GetString(1);
                            string surname = reader.GetString(2);
                            string patronymic = reader.GetString(3);

                            Fan fan = new Fan(id, name, surname, patronymic);
                            fans.Add(fan);
                        }
                    }
                }
            }

            return fans;
        }

        public void AddFan(Fan fan)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                using (var command = new SQLiteCommand(fanQueryProvider.AddFan, connection))
                {
                    command.Parameters.AddWithValue("@Name", fan.Name);
                    command.Parameters.AddWithValue("@Surname", fan.Surname);
                    command.Parameters.AddWithValue("@Patronymic", fan.Patronymic);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void UpdateFan(Fan fan)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                using (var command = new SQLiteCommand(fanQueryProvider.UpdateFan, connection))
                {
                    command.Parameters.AddWithValue("@Name", fan.Name);
                    command.Parameters.AddWithValue("@Surname", fan.Surname);
                    command.Parameters.AddWithValue("@Patronymic", fan.Patronymic);
                    command.Parameters.AddWithValue("@Id", fan.Id);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeleteFan(int id)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                using (var command = new SQLiteCommand(fanQueryProvider.DeleteFan, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void AddFavoriteClub(int fanId, int clubId)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                using (var command = new SQLiteCommand(fanQueryProvider.AddFavoriteClub, connection))
                {
                    command.Parameters.AddWithValue("@ClubId", clubId);
                    command.Parameters.AddWithValue("@FanId", fanId);
                    
                    command.ExecuteNonQuery();
                }
            }
        }

        public void ExcludeFavoriteClub(int fanId, int clubId)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                using (var command = new SQLiteCommand(fanQueryProvider.ExcludeFavoriteClub, connection))
                {
                    command.Parameters.AddWithValue("@ClubId", clubId);
                    command.Parameters.AddWithValue("@FanId", fanId);
                    
                    command.ExecuteNonQuery();
                }
            }
        }

        public List<Club> GetFavoriteClubs(int fanId)
        {
            var clubs = new List<Club>();

            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                using (var command = new SQLiteCommand(fanQueryProvider.GetFavoriteClubs, connection))
                {
                    command.Parameters.AddWithValue("@FanId", fanId);
                    command.ExecuteNonQuery();

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = reader.GetInt32(0);
                            string name = reader.GetString(1);
                            string city = reader.GetString(2);

                            Club club = new Club(id, name, city);
                            clubs.Add(club);
                        }
                    }
                }
            }
            return clubs;
        }
    }
}
