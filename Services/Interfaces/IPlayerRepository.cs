using Football_Fan_Manager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Football_Fan_Manager.Services.Interfaces
{
    internal interface IPlayerRepository
    {
        List<Player> GetPlayers();
        List<Player> GetPlayersWithoutClub();
        void AddPlayer(Player player);
        void AddPlayerToClub(int playerId, int? clubId);
        void UpdatePlayer(Player player);
        void DeletePlayer(int id);
        void ExcludePlayerFromClub(int playerId);
    }
}
