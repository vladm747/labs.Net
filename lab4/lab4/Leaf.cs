using System;
using System.Collections.Generic;
using System.Text;

namespace lab4
{
    class Leaf : Unit
    {
        public Leaf(int unitId, string unitName, List<Position> positions) :base(unitId, unitName, positions)
        {

        }
        public override bool IsComposite()
        {
            return false;
        }
    }
}
