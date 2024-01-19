using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisitorPlacement.Tests
{
    [TestClass]
    internal class VisitorTests
    {
        [TestMethod]
        public void Age_ShouldBeDeterminedBasedOnEventDate()
        {
            Visitor visitor = new Visitor(1, "John Doe", new DateTime(2012, 1, 1)); // 12 years old at event date
            DateTime eventDate = new DateTime(2024, 1, 1);

            visitor.UpdateChildStatus(eventDate);

            Assert.IsTrue(visitor.IsChild, "Visitor should be classified as child based on event date.");
        }

    }
}
