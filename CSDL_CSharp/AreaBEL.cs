using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSDL_CSharp
{
    public class AreaBEL
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List< CustomerBEL> Customers { get; set; }
    


    }
}
