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

            SeatingManager seatingManager = new SeatingManager();
            List<Sector> sectors = seatingManager.CreateAndAssignSeats(visitors);

            UIHelper.DisplaySectors(sectors);

            //RegistrationManager registrationManager = new RegistrationManager();

            //Visitor visitor1 = new Visitor(1, "Test Name", new DateTime(1990, 1, 1));
            //bool isRegistered = registrationManager.RegisterVisitor(visitor1);

            //Console.WriteLine(isRegistered ? "Registration successful." : "Registration failed.");
        }

        public static List<Visitor> CreateVisitors(int amountOfVisitors)
        {
            List<Visitor> visitors = new List<Visitor>();

            for(int i = 1; i <= amountOfVisitors; i++)
            {
                visitors.Add(new Visitor(i, $"Visitor {i}", DateTime.Now.AddYears(-30)));
            }

            return visitors;
        }
    }
}