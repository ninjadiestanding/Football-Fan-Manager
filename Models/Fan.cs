using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Football_Fan_Manager.Models
{
    public class Fan
    {
        public Fan(int id, string name, string surname, string patronymic)
        {
            Id = id;
            Name = name;
            Surname = surname;
            Patronymic = patronymic;
        }

        public Fan(string name, string surname, string patronymic)
        {
            Name = name;
            Surname = surname;
            Patronymic = patronymic;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
    }
}
