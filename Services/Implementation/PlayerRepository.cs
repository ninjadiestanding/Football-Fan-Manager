using Football_Fan_Manager.Database;
using Football_Fan_Manager.Models;
using Football_Fan_Manager.Services.Interfaces;
using Football_Fan_Manager.SQLQueryProviders;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Football_Fan_Manager.Services.Implementation
{
    internal class PlayerRepository : IPlayerRepository
    {
        private readonly string connectionString;
        private PlayerQueryProvider playerQueryProvider;

        public PlayerRepository()
        {
            connectionString = DatabaseHelper.GetConnectionString();

            playerQueryProvider = new PlayerQueryProvider();
        }

        public List<Player> GetPlayers()
        {
            var players = new List<Player>();

            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                using (var command = new SQLiteCommand(playerQueryProvider.GetPlayers, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = reader.GetInt32(0);
                            string name = reader.GetString(1);
                            string surname = reader.GetString(2);
                            string patronymic = reader.GetString(3);
                            DateTime date = reader.GetDateTime(4);
                            long snils = reader.GetInt64(5);
                            string clubName = reader.IsDBNull(7) ? null : reader.GetString(7);

                            Player player = new Player(id, name, surname, patronymic, date, snils, clubName);
                            players.Add(player);
                        }
                    }
                }
            }

            return players;
        }

        public List<Player> GetPlayersWithoutClub()
        {
            var players = new List<Player>();

            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                using (var command = new SQLiteCommand(playerQueryProvider.GetPlayersWithoutClub, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = reader.GetInt32(0);
                            string name = reader.GetString(1);
                            string surname = reader.GetString(2);
                            string patronymic = reader.GetString(3);
                            DateTime date = reader.GetDateTime(4);
                            long snils = reader.GetInt64(5);

                            Player player = new Player()
                            {
                                Id = id,
                                Name = name,
                                Surname = surname,
                                Patronymic = patronymic,
                                DateOfBirth = date,
                                Snils = snils
                            };

                            players.Add(player);
                        }
                    }
                }
            }

            return players;
        }

        public void AddPlayer(Player player)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                using (var command = new SQLiteCommand(playerQueryProvider.AddPlayer, connection))
                {
                    command.Parameters.AddWithValue("@Name", player.Name);
                    command.Parameters.AddWithValue("@Surname", player.Surname);
                    command.Parameters.AddWithValue("@Patronymic", player.Patronymic);
                    command.Parameters.AddWithValue("@DateOfBirth", player.DateOfBirth);
                    command.Parameters.AddWithValue("@Snils", player.Snils);
                    command.Parameters.AddWithValue("@ClubId", player.ClubId);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void AddPlayerToClub(int playerId, int? clubId)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                using (var command = new SQLiteCommand(playerQueryProvider.AddPlayerToClub, connection))
                {
                    command.Parameters.AddWithValue("@Id", playerId);
                    command.Parameters.AddWithValue("@ClubId", clubId);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void UpdatePlayer(Player player)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                using (var command = new SQLiteCommand(playerQueryProvider.UpdatePlayer, connection))
                {
                    command.Parameters.AddWithValue("@Name", player.Name);
                    command.Parameters.AddWithValue("@Surname", player.Surname);
                    command.Parameters.AddWithValue("@Patronymic", player.Patronymic);
                    command.Parameters.AddWithValue("@DateOfBirth", player.DateOfBirth);
                    command.Parameters.AddWithValue("@Snils", player.Snils);
                    command.Parameters.AddWithValue("@Id", player.Id);
                    command.Parameters.AddWithValue("@ClubId", player.ClubId);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeletePlayer(int id)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                using (var command = new SQLiteCommand(playerQueryProvider.DeletePlayer, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void ExcludePlayerFromClub(int playerId)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                using (var command = new SQLiteCommand(playerQueryProvider.ExcludePlayerFromClub, connection))
                {
                    command.Parameters.AddWithValue("@Id", playerId);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
