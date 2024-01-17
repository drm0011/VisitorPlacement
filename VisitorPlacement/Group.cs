using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisitorPlacement
{
	public class Group
	{
		public int ID { get; set; }
		public List<Visitor> GroupMembers { get; set;}

        public Group(int id)
        {
            ID = id;
            GroupMembers = new List<Visitor>();
        }
        public void AddToGroup(Visitor visitor)
		{
			GroupMembers.Add(visitor);
		}
		public bool CheckForAdult(Visitor visitor, Event @event)
		{
            return GroupMembers.Any(visitor => !visitor.IsChild);
        }
	}
}
