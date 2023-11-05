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
            Row row = new Row(1, 5);

            // Assert
            Assert.AreEqual(5, row.Seats.Count);
        }
    }
}