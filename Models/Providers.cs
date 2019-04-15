using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TS.Models
{
    public class Providers
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        
        public ICollection <Brands> Brands { get; set; }
    }
}
