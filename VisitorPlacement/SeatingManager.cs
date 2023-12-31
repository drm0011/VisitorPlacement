﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisitorPlacement
{
    public class SeatingManager //no managers, add thought process, what i learned, what i would do diff
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
                Seat newSeat = new(currentRow.Seats.Count + 1)
                {
                    IsOccupied = true,
                    Occupant = visitor
                };
                newSeat.Occupant.ID = visitor.ID;

                if (!currentRow.TryAddSeat(newSeat))
                {
                    currentRow = new Row(currentSector.Rows.Count + 1);
                    if (!currentSector.TryAddRow(currentRow))
                    {
                        currentSector = new Sector((char)(currentSector.ID + 1));
                        if (currentSector.ID > 'Z')
                        {
                            currentSector.ID = 'A';
                        }
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


