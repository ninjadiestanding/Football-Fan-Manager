using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Football_Fan_Manager.SQLQueryProviders
{
    internal class PlayerQueryProvider
    {
        public string GetPlayers => "SELECT Players.*, Clubs.Name AS ClubName " +
                                    "FROM Players " +
                                    "LEFT JOIN Clubs ON Players.ClubId = Clubs.Id";

        public string GetPlayersWithoutClub => "SELECT * FROM Players WHERE ClubId IS NULL";

        public string AddPlayer => "INSERT INTO Players (Name, Surname, Patronymic, DateOfBirth, Snils, ClubId) " +
            "VALUES (@Name, @Surname, @Patronymic, @DateOfBirth, @Snils, @ClubId)";

        public string AddPlayerToClub => "UPDATE Players SET ClubId = @ClubId " +
             "WHERE Id = @Id";

        public string UpdatePlayer => "UPDATE Players SET Name = @Name, Surname = @Surname, Patronymic = @Patronymic, " +
            "DateOfBirth = @DateOfBirth, Snils = @Snils WHERE Id = @Id";

        public string DeletePlayer => "DELETE FROM Players WHERE Id = @Id";

        public string ExcludePlayerFromClub => "UPDATE Players SET ClubId = NULL WHERE Id = @Id";
    }
}
