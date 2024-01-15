using System;
using System.Collections.Generic;

namespace VisitorPlacement
{
    public class Sector
    {
        public char ID { get; set; }
        public List<Row> Rows { get; set; }
        public int SectorMaxRows { get; private set; }

        public Sector(char id)
        {
            ID = id;
            SectorMaxRows = 3;
            Rows = new List<Row>();
        }

        public bool TryAddRow(Row row)
        {
            if (Rows.Count < SectorMaxRows)
            {
                Rows.Add(row);
                return true;
            }
            return false;
        }

        public void AssignSeats(List<Visitor> visitors)
        { 
            List<Visitor> children = visitors.Where(v => v.IsChild).ToList();
            List<Visitor> adults = visitors.Where(v => !v.IsChild).ToList();

            Row currentRow = InitializeRow();

            foreach (Visitor child in children)
            {
                if (!AddSeatToRow(currentRow, child))
                {
                    HandleFullFirstRowForChildren();
                    AddSeatToRow(currentRow, child);
                }
            }

            foreach (Visitor adult in adults)
            {
                if (!AddSeatToRow(currentRow, adult))
                {
                    currentRow = CreateNewRow() ?? HandleSectorOverflow();
                    AddSeatToRow(currentRow, adult);
                }
            }
        }

        private Row InitializeRow()
        {
            Row newRow = new Row(1);
            this.TryAddRow(newRow);
            return newRow;
        }

        private bool AddSeatToRow(Row row, Visitor visitor)
        {
            Seat newSeat = new Seat(row.Seats.Count + 1)
            {
                IsOccupied = true,
                Occupant = visitor
            };
            return row.TryAddSeat(newSeat);
        }

        private Row? CreateNewRow()
        {
            Row newRow = new Row(this.Rows.Count + 1);
            if (this.TryAddRow(newRow))
            {
                return newRow;
            }
            return null;
        }

        private Row HandleSectorOverflow()
        {
            throw new Exception("Sector row limit reached");
        }

        private void HandleFullFirstRowForChildren()
        {
            // logic for first row being too full for more children
            // move to second row or first row next sector
            throw new Exception("First row for children is full");
        }
    }

}
