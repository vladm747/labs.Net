using System;
using System.Collections.Generic;

namespace lab4
{
    /// <summary>
    /// For my lab4 i have chosen Composer (Компонувальник) pattern
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();   
            Client client = new Client();
            List<Position> positions = new List<Position>()
            {
                new Position("GeneralDirector", 1, 100000),
                new Position("DirectorAssistant", 1, 50000),
                new Position("Accountant", 1.5, 25000),
                new Position("TeamLeader", 0.5, 14000),
                new Position("Worker", 1, 12500)
            };
            // This way the client code can support the simple leaf
            // components...
            List<Position> leafEmp = new List<Position>();
            leafEmp.Add(positions[3]);
            leafEmp.Add(positions[4]);
            leafEmp.Add(positions[4]);
            leafEmp.Add(positions[4]);
            List<Position> leafEmp1 = new List<Position>();
            leafEmp1.Add(positions[3]);
            leafEmp1.Add(positions[4]);
            leafEmp1.Add(positions[4]);
            List<Position> leafEmp2 = new List<Position>();
            leafEmp2.Add(positions[3]);
            leafEmp2.Add(positions[4]);
            leafEmp2.Add(positions[4]);
            leafEmp2.Add(positions[4]);
            leafEmp2.Add(positions[4]);
            List<Position> rootEmp = new List<Position>();
            rootEmp.Add(positions[0]);
            rootEmp.Add(positions[1]);
            List<Position> branchEmp1 = new List<Position>();
            branchEmp1.Add(positions[2]);
            branchEmp1.Add(positions[3]);
            List<Position> branchEmp2 = new List<Position>();
            branchEmp2.Add(positions[2]);
            branchEmp2.Add(positions[3]);
            branchEmp2.Add(positions[3]);


            Leaf leaf = new Leaf(1, "Workers1", leafEmp);
            Leaf leaf1 = new Leaf(2, "Workers2", leafEmp1);
            Leaf leaf2 = new Leaf(3, "Workers3", leafEmp2);
            Console.WriteLine("--------DETAILS OF 3 LEAFS-------");
            client.ShowDetails(leaf);
            client.ShowDetails(leaf1);
            client.ShowDetails(leaf2);

            
            Composite tree = new Composite(4, "GeneralOffice", rootEmp);
            Composite branch1 = new Composite(5, "AccountantOffice1", branchEmp1);
            branch1.Add(leaf);
            branch1.Add(leaf1);

            Console.WriteLine("-------------BRANCH1 after adding 2 leafs--------");
            client.ShowDetails(branch1);
            Console.WriteLine("----------------------------------------------");

            Composite branch2 = new Composite(6, "AccountantOffice2", branchEmp1);
            branch2.Add(leaf2);
            tree.Add(branch1);
            tree.Add(branch2);

            Console.WriteLine("Client: Now I've got a composite tree:");
            Console.WriteLine();
            Console.WriteLine(tree.TotalChildrenDetails());
            Console.WriteLine("----------------------------------------------");

            Console.Write("Cheking RemoveFunc");
            Console.WriteLine();
            client.Remove(tree, branch2);
            client.ShowDetails(tree);
            Console.WriteLine("----------------------------------------------");
        }
    }
}
