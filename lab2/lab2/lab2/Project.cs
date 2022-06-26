using System;
using System.Collections.Generic;
using System.Text;

namespace lab2
{
    public class Project
    {
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public decimal Cost { get; set; }
        public DateTime Start { get; set; }
        public DateTime Finish { get; set; }
        public ICollection<Employee> Employees { get; set; }
        /// <param name="projectId">projectId</param>
        /// <param name="projectName">projectName</param>
        /// <param name="cost">cost</param>
        /// <param name="start">start</param>
        /// <param name="finish">finish</param>
        /// <param name="employees">employees</param>
        public Project(int projectId, string projectName, decimal cost, DateTime start, DateTime finish, ICollection<Employee> employees)
        {
            ProjectId = projectId;
            ProjectName = projectName;
            Cost = cost;
            Start = start;
            Finish = finish;
            Employees = employees;
        }
    }
}
