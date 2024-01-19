namespace VisitorPlacement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter number of groups:");
            int numberOfGroups = Convert.ToInt32(Console.ReadLine());

            Event myEvent = new Event(new DateTime(2024, 1, 1));

            if (numberOfGroups > 0)
            {
                for (int i = 0; i < numberOfGroups; i++)
                {
                    Group group = CreateGroup(i + 1);
                    myEvent.RegisterGroup(group);
                }
            }
            else
            {
                List<Group> hardcodedGroups = CreateHardcodedGroups();
                foreach (Group group in hardcodedGroups)
                {
                    myEvent.RegisterGroup(group);
                }
            }

            myEvent.OrganizeVisitorsIntoSectors(); 

            UIHelper.DisplaySectors(myEvent.Sectors);
        }

        private static Group CreateGroup(int groupId)
        {
            Console.WriteLine($"Creating group {groupId}");
            Group group = new Group(groupId);

            Console.WriteLine("Enter the number of members in this group:");
            int memberCount = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < memberCount; i++)
            {
                Console.WriteLine($"Enter details for member {i + 1} of group {groupId}");

                Console.Write("Enter ID: ");
                int id = Convert.ToInt32(Console.ReadLine());

                Console.Write("Enter Name: ");
                string name = Console.ReadLine();

                Console.Write("Enter Birthdate (yyyy-mm-dd): ");
                DateTime birthdate = DateTime.Parse(Console.ReadLine());

                Visitor visitor = new Visitor(id, name, birthdate);
                group.AddToGroup(visitor);
            }

            return group;
        }


        private static List<Group> CreateHardcodedGroups()
        {
            List<Group> groups = new List<Group>();

            int visitorId = 1; 
            for (int groupId = 1; groupId <= 4; groupId++) 
            {
                Group group = new Group(groupId);

                for (int i = 0; i < 20; i++) 
                {
                    string visitorName = "Visitor" + visitorId;
                    DateTime birthdate = RandomBirthdate(); 
                    group.AddToGroup(new Visitor(visitorId, visitorName, birthdate));
                    visitorId++;
                }

                groups.Add(group);
            }

            return groups;
        }

        private static DateTime RandomBirthdate()
        {
            Random random = new Random();
            int year = random.Next(DateTime.Today.Year - 70, DateTime.Today.Year - 1);
            int month = random.Next(1, 13);
            int day = random.Next(1, 29); 
            return new DateTime(year, month, day);
        }
    }
}


