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
            sector.Rows.Add(new Row(1));

            List<Visitor> visitors = new List<Visitor> 
            {
                new Visitor(1, "Visitor", DateTime.Now),
                new Visitor(2, "Visitor 2", DateTime.Now)
            };

            SeatingManager seatingManager = new SeatingManager();

            // Act
            List<Sector> sectors= seatingManager.CreateAndAssignSeats(visitors); 

            // Assert
            Assert.IsTrue(sectors.Any());
            Assert.IsTrue(sectors.First().Rows.Any());

            foreach(Visitor visitor in visitors)
            {
                bool isAssigned = sectors.SelectMany(s=>s.Rows)
                                         .SelectMany(r=>r.Seats)
                                         .Any(seat=>seat.IsOccupied && seat.VisitorId==visitor.ID);
                Assert.IsTrue(isAssigned, $"{visitor.Name} is not assigned.");
            }
        }
    }

}
