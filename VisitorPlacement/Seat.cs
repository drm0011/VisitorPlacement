using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisitorPlacement
{
    public class Seat
    {
        public int Number { get; set; }
        public bool IsOccupied { get; set; }
        public Visitor Occupant { get; set; } 
        public Seat(int number)
        {
            Number = number;    
            IsOccupied = false;
            Occupant = null;
        }
    }
}
