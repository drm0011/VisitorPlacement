using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisitorPlacement
{
    public class Sector
    {
        public char ID { get; set; }
        public List<Row> Rows { get; set; }
        public Sector(char id)
        {
            ID = id;
            Rows = new List<Row>();
        }
    }
}
