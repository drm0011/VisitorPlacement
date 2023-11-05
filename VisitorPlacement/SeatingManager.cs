using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisitorPlacement
{
    public class SeatingManager
    {
        public void AssignSeats(Sector sector, int numberOfVisitors)
        {
            foreach (Row row in sector.Rows)
            {
                foreach (Seat seat in row.Seats)
                {
                    if (numberOfVisitors == 0)
                        return; //return at 0

                    if (!seat.IsOccupied)
                    {
                        seat.IsOccupied = true;
                        numberOfVisitors--; //minus 1 until its 0
                    }
                }
            }
        }
    }
}
