using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisitorPlacement
{
    public class Visitor
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime Birthdate { get; set; }
        public bool IsChild { get; set; }
        public Visitor(int id, string name, DateTime birthdate)
        {
            ID = id;
            Name = name;
            Birthdate = birthdate;
            IsChild = CalculateAge(birthdate) <= 12;
        }

        private int CalculateAge(DateTime birthdate)
        {
            DateTime today = DateTime.Today;
            int age = today.Year - birthdate.Year;
            if (birthdate.Date > today.AddYears(-age)) age--;
            return age;
        }
    }
}
