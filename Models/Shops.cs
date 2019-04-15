using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TS.Models
{
    public class Shops
    {
        public int ID { get; set; } 
        public string Name { get; set; }
        public string Address { get; set; }
        public int OwnersID { get; set; }

        public Owners Owners { get; set; }
    }
}
