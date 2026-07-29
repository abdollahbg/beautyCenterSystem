using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace beautyCenterSystem
{
    public class Safe
    {
        public int SafeID { get; set; }
        public string SafeName { get; set; }
        public decimal Balance { get; set; }
        public bool IsActive { get; set; }
        public override string ToString()
        {
            return SafeName;
        }
    }
}
