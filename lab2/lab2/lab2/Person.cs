using System;
using System.Collections.Generic;
using System.Text;

namespace lab2
{
    public class Person
    {
        public int PersonId { get; set; }
        public string PersonName { get; set; }
        /// <param name="personId">PersonID</param>
        /// <param name="personName">PersonName</param>
        public Person(int personId, string personName)
        {
            PersonId = personId;
            PersonName = personName;
        }


    }
}
