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
        public int SectorMaxRows { get; private set; }
        public Sector(char id)
        {
            ID = id;
            SectorMaxRows = 3;
            Rows = new List<Row>();
        }

        public bool TryAddRow(Row row)
        {
            if (Rows.Count < SectorMaxRows)
            {
                Rows.Add(row);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
