using Football_Fan_Manager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Football_Fan_Manager.Services.Interfaces
{
    internal interface IClubRepository
    {
        List<Club> GetClubs();
        List<Player> GetPlayersForClub(int clubId);
        void AddClub(Club club);
        void UpdateClub(Club club);
        void DeleteClub(int id);
    }
}
