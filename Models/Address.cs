using System;

namespace PersonnelApi.Models
{
    public class Address
    {
        public int AddressID { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Zip { get; set; }
        public DateTime? Deleted { get; set; }

        //This is required to form a 1-many relationship with Person
        public int PersonID { get; set; }
        public Person Person { get; set; }
    }
}