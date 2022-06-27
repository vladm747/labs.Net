using System;
using System.Collections.Generic;
using System.Text;

namespace lab4
{
    class Client
    {
        public void ShowDetails(Unit leaf)
        {
            Console.WriteLine($"RESULT: {leaf.ShowCurrentDetails()}\n");
            if (leaf.IsComposite())
            {
                Console.WriteLine(leaf.TotalChildrenDetails());
            }
        }

        public void Add(Unit unit1, Unit unit2)
        {
            if (unit1.IsComposite())
            {
                unit1.Add(unit2);
            }

            //Console.WriteLine($"RESULT:{unit1.ShowCurrentDetails()} {unit1.TotalChildrenDetails()}");
        }
        public void Remove(Unit unit1, Unit unit2)
        {
            if (unit1.IsComposite())
            {
                unit1.Remove(unit2);
            }

            //Console.WriteLine($"RESULT:{unit1.ShowCurrentDetails()} {unit1.TotalChildrenDetails()}");
        }
    }
}
