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
		private List<Visitor> registeredVisitors=new List<Visitor>();
		public List<Group> Groups { get; set; }

		public Event(DateTime eventDate) 
		{
			EventDate = eventDate;
			Groups = new List<Group>();
		}
        public void RegisterVisitors(List<Visitor> visitors)
        {
            foreach (Visitor visitor in visitors)
            {
                RegisterVisitor(visitor);
            }
        }
        public bool RegisterGroup(Group group)
		{
			foreach(Visitor visitor in group.GroupMembers)
			{
				if (!IsAlreadyRegistered(visitor))
				{
                    visitor.UpdateChildStatus(EventDate);
                    registeredVisitors.Add(visitor);
				}
				Groups.Add(group);
				return true;
			}
			return false;
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
        public List<Visitor> GetRegisteredVisitors()
        {
            return registeredVisitors.ToList(); 
        }
    }
}
