﻿namespace Peabux.API.Models
{
    public class GetMerchant
    {
        public string? BusinessId { get; set; }
        public string? BusinessName { get; set; }
        public string? ContactName { get; set; }
        public string? ContactSurname { get; set; }
        public DateTime? EstablishmentDate { get; set; }
        public string? MerchantNumber { get; set; }
        public decimal? AverageTransaction { get; set; }
        public int CustomerId { get; set; }
    }
}
