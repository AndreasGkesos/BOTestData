namespace BOTestData.Models
{
    public class CustomerQueryParams
    {
        public string CustomerId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MobileNumber { get; set; }
        public string Email { get; set; }
        public string PostalCode { get; set; }
        public string LandlineNumber { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
