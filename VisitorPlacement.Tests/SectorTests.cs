using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisitorPlacement.Tests
{
    [TestClass]
    public class SectorTests
    {
        [TestMethod]
        public void AssignSeats_ShouldPlaceKidsFirst()
        {
            Sector sector = new Sector('A');
            List<Visitor> visitors = new List<Visitor>
            {
                new Visitor(1, "Adult 1", new DateTime(1980, 1, 1)),
                new Visitor(2, "Child 1", new DateTime(2015, 1, 1)),
                new Visitor(3, "Adult 2", new DateTime(1985, 1, 1)),
                new Visitor(4, "Child 2", new DateTime(2016, 1, 1))
            };

            sector.AssignSeats(visitors);

            List<Seat> firstRowSeats = sector.Rows.First().Seats;
            Assert.IsTrue(firstRowSeats.Count > 0, "The first row should have seats assigned.");

            bool kidsFirst = true;
            bool adultFound = false;
            foreach (Seat seat in firstRowSeats)
            {
                if (seat.IsOccupied)
                {
                    if (adultFound && seat.Occupant.IsChild)
                    {
                        kidsFirst = false;
                        break;
                    }
                    if (!seat.Occupant.IsChild)
                    {
                        adultFound = true;
                    }
                }
            }
            Assert.IsTrue(kidsFirst, "Kids should be placed in seats before adults.");
        }

        [TestMethod]
        public void NewSector_ShouldBeEmpty()
        {
            // Arrange & Act
            Sector sector = new Sector('A');

            // Assert
            Assert.AreEqual(0, sector.Rows.Count);
        }
    }

}
