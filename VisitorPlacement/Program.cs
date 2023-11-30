namespace VisitorPlacement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SeatingManager seatingManager = new SeatingManager();

            Sector sectorA = new Sector('A');
            sectorA.Rows.Add(new Row(1,5));
            sectorA.Rows.Add(new Row(2,5));

            Sector sectorB = new Sector('B');
            sectorB.Rows.Add(new Row(1,3));
            sectorB.Rows.Add(new Row(2,4));
            sectorB.Rows.Add(new Row(3,6));

            List<Visitor> visitors = new List<Visitor>();
            Visitor visitor = new Visitor(1, "Visitor 1", DateTime.Now);
            Visitor visitor2 = new Visitor(2, "Visitor 2", DateTime.Now);
            Visitor visitor3 = new Visitor(3, "Visitor 3", DateTime.Now);
            visitors.Add(visitor);
            visitors.Add(visitor2);
            visitors.Add(visitor3);

            seatingManager.AssignSeats(sectorA, visitors);
            seatingManager.AssignSeats(sectorB, visitors);

            UIHelper.DisplaySectors(new List<Sector> {  sectorA,sectorB }); //ini new list populated with obj sector

            RegistrationManager registrationManager = new RegistrationManager();

            Visitor visitor1 = new Visitor(1, "Test Name", new DateTime(1990, 1, 1));
            bool isRegistered = registrationManager.RegisterVisitor(visitor1);

            Console.WriteLine(isRegistered ? "Registration successful." : "Registration failed.");

        }

    }
}