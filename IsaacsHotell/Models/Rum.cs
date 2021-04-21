using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IsaacsHotell.Models
{
    public class Rum
    {
        public int Id { get; set; }
        public string Namn { get; set; }
        public int Antalsovplatser { get; set; }
        public bool Smutsigt { get; set; }
        public int? BokningId { get; set; }
        public List<Bokning> Bokningar { get; set; }
    }
}
