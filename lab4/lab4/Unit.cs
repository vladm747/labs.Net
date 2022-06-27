using System;
using System.Collections.Generic;
using System.Text;

namespace lab4
{
    class Unit
    {
        public int UnitID { get; set; }
        public string UnitName { get; set; }
        public List<Position> Positions { get; set; }
        public Unit() { }
        public Unit(int unitId, string unitName, List<Position> positions)
        {
            UnitID = unitId;
            UnitName = unitName;
            Positions = positions;
        }
        public string ShowCurrentDetails()
        {
            string result = string.Empty;
            result += $"Unit: {UnitID}, Name: {UnitName} {System.Environment.NewLine}";
            foreach (Position position in Positions)
            {
                result += $"{position.PositionName}: Rate:{position.Rate} Salary:{position.Salary} {System.Environment.NewLine}";
            }
            return result;
        }
        public virtual string TotalChildrenDetails()
        {
            throw new NotImplementedException();
        }
        public virtual void Add(Unit unit)
        {
            throw new NotImplementedException();
        }

        public virtual void Remove(Unit unit)
        {
            throw new NotImplementedException();
        }

        public virtual bool IsComposite()
        {
            return true;
        }
    }
}
