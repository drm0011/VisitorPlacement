using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisitorPlacement
{
    public class UIHelper
    {
        public static void DisplaySectors(List<Sector> sectors)
        {
            foreach (Sector sector in sectors)
            {
                Console.WriteLine($"Sector {sector.ID}:");
                foreach (Row row in sector.Rows)
                {
                    Console.Write($"Row {row.Number}: ");
                    foreach (Seat seat in row.Seats)
                    {
                        if (seat.IsOccupied)
                        {
                            string visitorType = seat.Occupant.IsChild ? "C" : "A";
                            Console.Write($"[G{seat.Occupant.GroupId} {visitorType}{seat.Occupant.ID}] ");
                        }
                        else
                        {
                            Console.Write("[Empty] ");
                        }
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
            }
        }
    }

}
