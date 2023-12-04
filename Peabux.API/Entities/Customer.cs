
namespace Peabux.API.Entities
{
    public class Customer : BaseEntity
    {
        public int CustomerId { get; set; }
        public string? NationalID { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public DateTime? DOB { get; set; }
        public string? CustomerNumber { get; set; }
        public string? TransactionHistory { get; set; }

        


    }
}
