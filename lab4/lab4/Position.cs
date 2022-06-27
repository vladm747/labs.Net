using System;
using System.Collections.Generic;
using System.Text;

namespace lab4
{
    public class Position
    {
        public string PositionName { get; set; }
        /// <summary>
        /// Ставка
        /// </summary>
        public double Rate { get; set; }
        public decimal Salary { get; set; }
        public Position(string positionName, double rate, decimal salary)
        {
            PositionName = positionName;
            Rate = rate;
            Salary = salary;
        }
    }
}
