using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lista6
{
    public class Rejestr
    {
        
            public int Id { get; set; }

            public string ActionT{ get; set; }

            public string Date{ get; set; }

            public Rejestr(int id, string type, string data)
            {
                Id = id;
                ActionT = type;
                Date = data;
            }

            public Rejestr()
            {
                Id = 0;
                ActionT = "INSERT";
                Date = "16/12/2020";
            }
        
    }
}
