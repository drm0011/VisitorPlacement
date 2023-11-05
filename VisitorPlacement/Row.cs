using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisitorPlacement
{
    public class Row
    {
        public int Number { get; set; }
        public List<Seat> Seats { get; set; }
        public Row(int number, int numberOfSeats)
        {
            Number = number;
            Seats = new List<Seat>(numberOfSeats);
            for(int i = 0; i < numberOfSeats; i++)
            {
                Seats.Add(new Seat(i+1));
            }
        }
    }
}
