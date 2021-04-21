using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IsaacsHotell.Models
{
    public class Bokning
    {
        public int Id { get; set; }

        public DateTime Incheckning { get; set; }
        public DateTime Utcheckning { get; set; }
        public int GästId { get; set; }
        public Gäst Gäst { get; set; }
        public int RumId { get; set; }
        public Rum Rum { get; set; }


    }
}
