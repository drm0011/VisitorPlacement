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
        public void NewSector_ShouldBeEmpty()
        {
            // Arrange & Act
            Sector sector = new Sector('A');

            // Assert
            Assert.AreEqual(0, sector.Rows.Count);
        }
    }

}
