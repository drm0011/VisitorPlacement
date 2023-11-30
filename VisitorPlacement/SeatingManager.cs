using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisitorPlacement
{
    public class SeatingManager
    {
        public List<Sector> CreateAndAssignSeats(List<Visitor> visitors)
        {
            List<Sector> sectors = new List<Sector>();
            Sector currentSector = new Sector('A');
            sectors.Add(currentSector);

            Row currentRow = new Row(1);
            currentSector.TryAddRow(currentRow);

            foreach (Visitor visitor in visitors)
            {
                Seat newSeat = new Seat(currentRow.Seats.Count + 1);
                newSeat.IsOccupied = true;
                newSeat.VisitorId = visitor.ID;

                if (!currentRow.TryAddSeat(newSeat))
                {
                    currentRow = new Row(currentSector.Rows.Count + 1);
                    if (!currentSector.TryAddRow(currentRow))
                    {
                        currentSector = new Sector((char)(currentSector.ID + 1));
                        sectors.Add(currentSector);
                        currentRow = new Row(1);
                        currentSector.TryAddRow(currentRow);
                    }
                    currentRow.TryAddSeat(newSeat); 
                }
            }

            return sectors;
        }
    }

}


