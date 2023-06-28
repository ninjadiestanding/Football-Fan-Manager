using Football_Fan_Manager.Database;
using Football_Fan_Manager.Models;
using Football_Fan_Manager.Services.Interfaces;
using Football_Fan_Manager.SQLQueryProviders;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Football_Fan_Manager.Services.Implementation
{
    internal class ClubRepository : IClubRepository
    {
        private readonly string connectionString;
        private ClubQueryProvider clubQueryProvider;

        public ClubRepository()
        {
            connectionString = DatabaseHelper.GetConnectionString();

            clubQueryProvider = new ClubQueryProvider();
        }

        public List<Club> GetClubs()
        {
            var clubs = new List<Club>();

            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                using (var command = new SQLiteCommand(clubQueryProvider.GetClubs, connection))
                {
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

        public void AddClub(Club club)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                using (var command = new SQLiteCommand(clubQueryProvider.AddClub, connection))
                {
                    command.Parameters.AddWithValue("@Name", club.Name);
                    command.Parameters.AddWithValue("@City", club.City);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void UpdateClub(Club club)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                using (var command = new SQLiteCommand(clubQueryProvider.UpdateClub, connection))
                {
                    command.Parameters.AddWithValue("@Name", club.Name);
                    command.Parameters.AddWithValue("@City", club.City);
                    command.Parameters.AddWithValue("@Id", club.Id);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeleteClub(int id)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                using (var command = new SQLiteCommand(clubQueryProvider.DeleteClub, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    command.ExecuteNonQuery();
                }
            }
        }

        public List<Player> GetPlayersForClub(int clubId)
        {
            var players = new List<Player>();

            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                using (var command = new SQLiteCommand(clubQueryProvider.GetPlayersForClub, connection))
                {
                    command.Parameters.AddWithValue("@ClubId", clubId);
                    command.ExecuteNonQuery();

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = reader.GetInt32(0);
                            string name = reader.GetString(1);
                            string surname = reader.GetString(2);
                            string patronymic = reader.GetString(3);
                            DateTime date = reader.GetDateTime(4);
                            int snils = reader.GetInt32(5);

                            Player player = new Player(id, name, surname, patronymic, date, snils);
                            players.Add(player);
                        }
                    }
                }
            }

            return players;
        }
    }
}
