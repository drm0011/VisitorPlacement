using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisitorPlacement
{
    public class SeatingManager
    {
        public void AssignSeats(Sector sector, List<Visitor> visitors)
        {
            int visitorIndex = 0;
            foreach (Row row in sector.Rows)
            {
                foreach (Seat seat in row.Seats)
                {
                    if (visitorIndex >= visitors.Count)
                    {
                        return;
                    }
                    if (!seat.IsOccupied)
                    {
                        seat.IsOccupied = true;
                        seat.VisitorId = visitors[visitorIndex].ID;
                        visitorIndex++;
                    }
                    else
                    {
                        return;
                    }
                }
            }
        }
    }
}
