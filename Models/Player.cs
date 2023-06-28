using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Football_Fan_Manager.Models
{
    public class Player
    {
        public Player(int id, string name, string surname, string patronymic, DateTime date, long snils, string clubName)
        {
            Id = id;
            Name = name;
            Surname = surname;
            Patronymic = patronymic;
            DateOfBirth = date;
            Snils = snils;
            ClubName = clubName;
        }

        public Player(string name, string surname, string patronymic, DateTime date, long snils, int? clubId)
        {
            Name = name;
            Surname = surname;
            Patronymic = patronymic;
            DateOfBirth = date;
            Snils = snils;
            ClubId = clubId;
        }

        public Player(int id,string name, string surname, string patronymic, DateTime date, long snils)
        {
            Id = id;
            Name = name;
            Surname = surname;
            Patronymic = patronymic;
            DateOfBirth = date;
            Snils = snils;
        }

        public Player()
        {

        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public DateTime DateOfBirth { get; set; }
        public long Snils { get; set; }
        public int? ClubId { get; set; }
        public string ClubName { get; set; }
    }
}
