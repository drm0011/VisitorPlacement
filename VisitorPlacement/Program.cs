namespace VisitorPlacement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int amountOfVisitors;
            Console.WriteLine("Visitor amount:");
            amountOfVisitors = Convert.ToInt32(Console.ReadLine());

            List<Visitor> visitors = CreateVisitors(amountOfVisitors);

            List<Sector> sectors = new List<Sector>();
            char sectorId = 'A';
            int visitorsPerSector = 30; 

            int numberOfBatches = (int)Math.Ceiling(visitors.Count / (double)visitorsPerSector);

            for (int i = 0; i < numberOfBatches; i++)
            {
                List<Visitor> batch = visitors.Skip(i * visitorsPerSector).Take(visitorsPerSector).ToList();
                Sector sector = new Sector(sectorId++);
                sector.AssignSeats(batch);
                sectors.Add(sector);
            }

            UIHelper.DisplaySectors(sectors);
        }


        public static List<Visitor> CreateVisitors(int amountOfVisitors)
        {
            List<Visitor> visitors = new List<Visitor>();
            Random random = new Random();

            for (int i = 1; i <= amountOfVisitors; i++)
            {
                int age = random.Next(1, 70);
                DateTime birthdate = DateTime.Today.AddYears(-age);

                visitors.Add(new Visitor(i, $"Visitor {i}", birthdate));
            }

            return visitors;
        }
    }
}
