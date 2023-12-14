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
        public int MaxSeats { get; private set; }
        public Row(int number)
        {
            Number = number;
            MaxSeats = 10;
            Seats = new List<Seat>();
        }

        public bool CanSeatBeAdded(Seat seat)
        {
            if(Seats.Count < MaxSeats)
            {
                if(this.Number==1 && seat.Occupant.IsChild == true)
                {
                    return true;
                }
                else if(this.Number>=2 && seat.Occupant.IsChild == false)
                {
                    return true;
                }
            }
            return false;
        }
        public bool TryAddSeat(Seat seat)
        {
            if (CanSeatBeAdded(seat))
            {
                Seats.Add(seat);
                return true;
            }
            return false;
        }
    }
}
