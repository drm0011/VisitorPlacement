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


            seatingManager.AssignSeats(sectorA, 7);
            seatingManager.AssignSeats(sectorB, 10);

            UIHelper.DisplaySectors(new List<Sector> {  sectorA,sectorB }); //ini new list populated with obj sector
        }

    }
}