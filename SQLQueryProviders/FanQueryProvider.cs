using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Football_Fan_Manager.SQLQueryProviders
{
    class FanQueryProvider
    {
        public string GetFans => "SELECT * FROM Fans";
        public string AddFan => "INSERT INTO Fans (Name, Surname, Patronymic) VALUES (@Name, @Surname, @Patronymic)";
        public string UpdateFan => "UPDATE Fans SET Name = @Name, Surname = @Surname, Patronymic = @Patronymic WHERE Id = @Id";
        public string DeleteFan => "DELETE FROM Fans WHERE Id = @Id";
        public string AddFavoriteClub => "INSERT INTO ClubFan (ClubId, FanId) VALUES (@ClubId, @FanId)";
        public string ExcludeFavoriteClub => "DELETE FROM ClubFan WHERE ClubId = @ClubId AND FanId = @FanId";
        public string GetFavoriteClubs => "SELECT c.* " +
                                          "FROM Clubs c " +
                                          "JOIN ClubFan cf ON c.Id = cf.ClubId " +
                                          "JOIN Fans f ON f.Id = cf.FanId " +
                                          "WHERE f.Id = @FanId";
    }
}
