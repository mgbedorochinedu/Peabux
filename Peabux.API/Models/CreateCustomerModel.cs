using System.ComponentModel.DataAnnotations;

namespace Peabux.API.Models
{
    public class CreateCustomerModel
    {
        [Required(ErrorMessage = "National Identification field required")]
        public string? NationalID { get; set; }

        [Required(ErrorMessage = "Name field required")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Surname field required")]
        public string? Surname { get; set; }

        [Required(ErrorMessage = "Name Date of Birth field required")]
        public DateTime DOB { get; set; }

        [Required(ErrorMessage = "Customer Identification Number field required")]
        public string? CustomerNumber { get; set; }

        public string? TransactionHistory { get; set; }
    }
}
