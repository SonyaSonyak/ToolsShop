using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TS.Models
{
    public class Owners
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int BrandsID { get; set; }

        public Brands Brands { get; set; }
        public ICollection <Shops> Shops { get; set; }
    }
}
