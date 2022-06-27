using System;
using System.Collections.Generic;
using System.Text;

namespace lab4
{
    class Composite : Unit
    {

        public Composite(int unitId, string unitName, List<Position> positions):base(unitId, unitName, positions)
        {

        }

        protected List<Unit> _children = new List<Unit>();

        public override void Add(Unit unit)
        {
            this._children.Add(unit);
        }

        public override void Remove(Unit unit)
        {
            this._children.Remove(unit);
        }

        public override string TotalChildrenDetails()
        {
            int staffCounter = 0;
            decimal salaryCounter = 0;
            string result = "Branch(";

            foreach (Unit unit in this._children)
            {
                result += unit.ShowCurrentDetails();
               
                staffCounter++;
                
                foreach (Position position in unit.Positions)
                {
                    salaryCounter += position.Salary;
                }
            }

            return result + $"Quantity of staff: {staffCounter+1}, Total salary: {salaryCounter} ) {System.Environment.NewLine}";
        }
    }
}
