using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisitorPlacement.Tests
{
    [TestClass]
    public class RowTests
    {
        [TestMethod]
        public void NewRow_ShouldHaveCorrectNumberOfSeats()
        {
            // Arrange & Act
            Row row = new Row(1);
            Seat seat = new Seat(1);
            row.TryAddSeat(seat);

            // Assert
            Assert.AreEqual(1, row.Seats.Count);
        }
    }
}