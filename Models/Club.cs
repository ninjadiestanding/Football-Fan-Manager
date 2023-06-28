using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Football_Fan_Manager.Models
{
    public class Club
    {
        public Club(int id, string name, string city)
        {
            Id = id;
            Name = name;
            City = city;
        }

        public Club(string name, string city)
        {
            Name = name;
            City = city;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
    }
}
