using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace beautyCenterSystem
{
    public class Material
    {
        public int MaterialID { get; set; }
        public string MaterialName { get; set; }
        public bool IsAvailable { get; set; }
        public bool IsActive { get; set; } 
    }
}
