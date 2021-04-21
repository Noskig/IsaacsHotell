using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IsaacsHotell.Models
{
    public class Gäst
    {
        public int Id { get; set; }
        public string Förnamn { get; set; }
        public string Efternamn { get; set; }
        public int? BokningId { get; set; }
        public Bokning Bokning { get; set; }
        public int? OrderId { get; set; }
        public Order Order{ get; set; }

    }
}
