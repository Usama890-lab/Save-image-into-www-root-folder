using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearnASPNETCoreMVCWithRealApps.Models
{
    public class Product
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public List<string> Photos { get; set; }
    }
}
