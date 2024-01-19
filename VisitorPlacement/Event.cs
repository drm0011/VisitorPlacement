using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisitorPlacement
{
    public class Event
    {
        public DateTime EventDate { get; set; }
        private List<Visitor> registeredVisitors = new List<Visitor>();
        public List<Group> Groups { get; set; }
        public List<Sector> Sectors { get; private set; } 
        public Event(DateTime eventDate)
        {
            EventDate = eventDate;
            Groups = new List<Group>();
            Sectors = new List<Sector>(); 
        }

        public void OrganizeVisitorsIntoSectors()
        {
            Sectors.Clear(); 
            char sectorId = 'A';
            int visitorsPerSector = 30;

            int numberOfBatches = (int)Math.Ceiling(registeredVisitors.Count / (double)visitorsPerSector);

            for (int i = 0; i < numberOfBatches; i++)
            {
                List<Visitor> batch = registeredVisitors
                    .Skip(i * visitorsPerSector)
                    .Take(visitorsPerSector)
                    .ToList();

                Sector sector = new Sector(sectorId++);
                sector.AssignSeats(batch);
                Sectors.Add(sector);
            }
        }
        //public void RegisterVisitors(List<Visitor> visitors)
        //{
        //    foreach (Visitor visitor in visitors)
        //    {
        //        RegisterVisitor(visitor);
        //    }
        //}
        public bool RegisterGroup(Group group)
        {
            if (Groups.Any(g => g.ID == group.ID))
            {
                return false;
            }

            if (group.HasAdult())
            {
                foreach (Visitor visitor in group.GroupMembers)
                {
                    RegisterVisitor(visitor);
                }
                Groups.Add(group);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool RegisterVisitor(Visitor visitor)
        {
            if (!IsAlreadyRegistered(visitor))
            {
                visitor.UpdateChildStatus(EventDate);
                registeredVisitors.Add(visitor);
                return true;
            }
            return false;
        }

        private bool IsAlreadyRegistered(Visitor visitor)
        {
            foreach (Visitor registeredVisitor in registeredVisitors)
            {
                if (registeredVisitor.ID == visitor.ID)
                {
                    return true;
                }
            }
            return false;
        }


        //public List<Visitor> GetRegisteredVisitors()
        //{
        //    return registeredVisitors.ToList();
        //}
    }
}

