﻿using System;
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

        private bool CanSeatBeAdded(Seat seat)
        {
            if (Seats.Count >= MaxSeats)
            {
                return false;
            }
            else
            {
                return true;
            }
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
