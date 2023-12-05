using System.ComponentModel.DataAnnotations;

namespace Peabux.API.Models
{
    public class AddMerchantModel
    {
        [Required(ErrorMessage = "Business Identification Number field required")]
        public string? BusinessIdNumber { get; set; }

        [Required(ErrorMessage = "Business Name field required")]
        public string? BusinessName { get; set; }

        [Required(ErrorMessage = "Contact Name field required")]
        public string? ContactName { get; set; }

        [Required(ErrorMessage = "Contact Surname field required")]
        public string? ContactSurname { get; set; }

        [Required(ErrorMessage = "Date of Establishment field required")]
        public DateTime EstablishmentDate { get; set; }

        [Required(ErrorMessage = "Merchant Number required")]
        public string? MerchantNumber { get; set; }
        public decimal? AverageTransaction { get; set; }

    }
}
