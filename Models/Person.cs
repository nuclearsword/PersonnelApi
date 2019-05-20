using System;
using System.Collections.Generic;

namespace PersonnelApi.Models
{
    public class Person
    {
        public int PersonID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Age { get; set; }
        public DateTime? Deleted { get; set; }

        //This is required to form a 1-many relationship with Address
        public List<Address> Address { get; set; }
    }
}