using System.Collections;
using System.Collections.Generic;

namespace BOTestData.Models
{
    public class Customer
    {
        public string Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string BirthDateOrEstablishment { get; set; }
        public string FathersName { get; set; }
        public string VatNumber { get; set; }
        public string MobileNumber { get; set; }
        public string PostalCode { get; set; }
        public string Street { get; set; }
        public string StreetNumber { get; set; }
        public string City { get; set; }
        public string LandlineNumber { get; set; }
        public string BirthDate { get; set; }
        public string Email { get; set; }
        public int Status { get; set; }
        public int customerCategory { get; set; }
    }

    public class CustomerData
    {
        public ICollection Data { get; set; }
        public int Page { get; set; }
        public int TotalRecords { get; set; }
    }

    public class CustomerResponse
    {
        public CustomerData Customers { get; set; }
    }

    public class CustomerLookup
    {
        public List<CustomerLookupPairs> Status { get; set; }
        public List<CustomerLookupPairs> CategoryLookup { get; set; }
    }

    public class CustomerLookupPairs
    {
        public int Number { get; set; }
        public string Value { get; set; }
    }
}
