using Football_Fan_Manager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Football_Fan_Manager.Services.Interfaces
{
    interface IFanRepository
    {
        List<Fan> GetFans();
        void AddFan(Fan fan);
        void UpdateFan(Fan fan);
        void DeleteFan(int id);

        void AddFavoriteClub(int fanId, int clubId);
        void ExcludeFavoriteClub(int fanId, int clubId);
        List<Club> GetFavoriteClubs(int fanId);
    }
}
