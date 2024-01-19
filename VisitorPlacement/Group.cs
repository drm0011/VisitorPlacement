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
        public List<Visitor> GroupMembers { get; set; }

        public Group(int id)
        {
            ID = id;
            GroupMembers = new List<Visitor>();
        }

        public void AddToGroup(Visitor visitor)
        {
            if (!visitor.IsChild || HasAdult())
            {
                visitor.GroupId = this.ID;
                GroupMembers.Add(visitor);
            }
            else
            {
                throw new InvalidOperationException("Cannot add a child to a group without an adult.");
            }
        }

        public bool HasAdult()
        {
            return GroupMembers.Any(visitor => !visitor.IsChild);
        }
    }
}
