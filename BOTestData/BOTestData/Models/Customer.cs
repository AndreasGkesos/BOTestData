using System.Collections;

namespace BOTestData.Models
{
    public class Customer
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DateOfBirth { get; set; }
        public string TaxNumber { get; set; }
        public string Status { get; set; }
        public string Cellphone { get; set; }
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
}
