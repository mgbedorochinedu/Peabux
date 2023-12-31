﻿using System.ComponentModel.DataAnnotations.Schema;

namespace Peabux.API.Entities
{
    public class Merchant : BaseEntity
    {
        public int MerchantId { get; set; }
        public string?  BusinessId { get; set; }
        public string? BusinessName { get; set; }
        public string? ContactName { get; set; }
        public string? ContactSurname { get; set; }
        public DateTime? EstablishmentDate { get; set; }
        public string? MerchantNumber { get; set; }
        public decimal? AverageTransaction { get; set; }


    }
}
