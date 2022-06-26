using System;
using System.Collections.Generic;
using System.Text;

namespace lab2
{
    public class Employee : Person
    {
        public string Position { get; set; }
        /// <param name="id">Employee ID</param>
        /// <param name="name">Employee name</param>
        /// <param name="position">Employee position</param>
        public Employee(int id, string name, string position) : base(id, name)
        {
            Position = position;
        }

        public ICollection<Project> Projects { get; set; } = new List<Project>();
    }
}
