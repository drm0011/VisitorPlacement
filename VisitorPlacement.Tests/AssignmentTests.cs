using Microsoft.VisualStudio.TestPlatform.TestHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisitorPlacement.Tests
{
    [TestClass]
    public class AssignmentTests
    {
        [TestMethod]
        public void AssignSeats_ShouldCorrectlyAssignSeats()
        {
            // Arrange
            Sector sector = new Sector('A');
            sector.Rows.Add(new Row(1, 5));
            sector.Rows.Add(new Row(2, 5));

            SeatingManager seatingManager = new SeatingManager();
            // Act
            seatingManager.AssignSeats(sector, 7); 

            // Assert
            Assert.IsTrue(sector.Rows[0].Seats.All(s => s.IsOccupied));
            Assert.AreEqual(2, sector.Rows[1].Seats.Count(s => s.IsOccupied));
        }
    }

}
