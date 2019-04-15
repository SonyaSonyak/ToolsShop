using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TS.Models
{
    public class Brands
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Info { get; set; }
        public int ProvidersID { get; set; }

        public Providers Providers { get; set; }
        public ICollection <Owners> Owners { get; set; }
        public ICollection<Products> Products { get; set; }
    }
}
