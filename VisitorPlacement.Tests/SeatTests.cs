using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisitorPlacement.Tests
{
    [TestClass]
    public class SeatTests
    {
        [TestMethod]
        public void NewSeat_ShouldBeUnoccupied()
        {
            // Arrange & Act
            Seat seat = new Seat(1);

            // Assert
            Assert.IsFalse(seat.IsOccupied);
        }
    }
}
