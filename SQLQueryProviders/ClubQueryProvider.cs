using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Football_Fan_Manager.SQLQueryProviders
{
    internal class ClubQueryProvider
    {
        public string GetClubs => "SELECT * FROM Clubs";
        //public string GetClubById => "SELECT * FROM Clubs WHERE Id = @Id";
        public string GetPlayersForClub => "SELECT * FROM Players WHERE ClubId = @ClubId";

        public string GetFavoriteClubForFan => "SELECT * FROM ClubFan WHERE ClubId = @ClubId";
        public string AddClub => "INSERT INTO Clubs (Name, City) VALUES (@Name, @City)";
        public string UpdateClub => "UPDATE Clubs SET Name = @Name, City = @City WHERE Id = @Id";
        public string DeleteClub => "DELETE FROM Clubs WHERE Id = @Id";
    }
}
