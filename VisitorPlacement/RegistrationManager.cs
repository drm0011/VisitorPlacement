using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisitorPlacement
{
    public class RegistrationManager
    {
        private List<Visitor> registeredVisitors = new List<Visitor>();

        public bool RegisterVisitor(Visitor visitor)
        {
            if (!IsAlreadyRegistered(visitor))
            {
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
                    return true; //a matching ID is found; the visitor is already registered.
                }
            }
            return false; //no matching ID is found; the visitor is not yet registered.
        }

    }

}
