using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace VisitorPlacement.Tests
{
    [TestClass]
    public class EventTests
    {
        [TestMethod]
        public void Group_WithKids_ShouldHaveAtLeastOneAdult()
        {
            Group group = new Group(1);
            group.AddToGroup(new Visitor(1, "Child 1", new DateTime(2020, 1, 1))); 
            group.AddToGroup(new Visitor(2, "Child 2", new DateTime(2020, 1, 1))); 

            DateTime eventDate = new DateTime(2024, 1, 1);
            Event myEvent = new Event(eventDate);

            bool registrationResult = myEvent.RegisterGroup(group);

            Assert.IsFalse(registrationResult, "Group with only children should not be registered.");
        }

        [TestMethod]
        public void Visitor_CannotBeRegisteredTwice()
        {
            Visitor visitor = new Visitor(1, "Test Visitor", new DateTime(1985, 1, 1));
            DateTime eventDate = new DateTime(2024, 1, 1);
            Event myEvent = new Event(eventDate);

            myEvent.RegisterVisitor(visitor);
            bool secondRegistrationResult = myEvent.RegisterVisitor(visitor);
            
            Assert.IsFalse(secondRegistrationResult, "Visitor should not be registered twice.");
        }

        [TestMethod]
        public void EachGroup_ShouldHaveUniqueID()
        {
            DateTime eventDate = new DateTime(2024, 1, 1);
            Event myEvent = new Event(eventDate);

            Group group1 = new Group(1);
            group1.AddToGroup(new Visitor(1, "Adult 1", new DateTime(1980, 1, 1))); 
            myEvent.RegisterGroup(group1);

            Group group2 = new Group(2);
            group2.AddToGroup(new Visitor(2, "Adult 2", new DateTime(1980, 1, 2))); 
            myEvent.RegisterGroup(group2);

            int groupIDs = myEvent.Groups.Select(g => g.ID).Distinct().Count();
            Assert.AreEqual(2, groupIDs, "Each group should have a unique ID.");
        }


        [TestMethod]
        public void Visitors_CanRegisterInGroups()
        {
            Group group = new Group(1);
            group.AddToGroup(new Visitor(1, "Adult 1", new DateTime(1980, 1, 1)));
            group.AddToGroup(new Visitor(2, "Child 1", new DateTime(2015, 1, 1)));

            DateTime eventDate = new DateTime(2024, 1, 1);
            Event myEvent = new Event(eventDate);

            bool registrationResult = myEvent.RegisterGroup(group);

            Assert.IsTrue(registrationResult, "Visitors should be able to register in groups.");
        }

    }
}
