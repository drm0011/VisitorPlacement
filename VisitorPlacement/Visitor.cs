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
        public int GroupId { get; set; }
        public Visitor(int id, string name, DateTime birthDate)
        {
            ID = id;
            Name = name;
            Birthdate = birthDate;
        }
        public void UpdateChildStatus(DateTime eventDate)
        {
            IsChild = CalculateAge(Birthdate, eventDate) <= 12;
        }
        private int CalculateAge(DateTime birthDate, DateTime eventDate)
        {
            int age = eventDate.Year - birthDate.Year;
            if (birthDate.Date > eventDate.AddYears(-age)) age--;
            return age;
        }
    }
}