using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Models.DTOs.Responses
{
    public class GetPurchaseRequest
    {
        public string VendorId { get; set; }
        public string PRNumber { get; set; }
        public DateTime PRDate { get; set; }
        public string VendorName { get; set; }
        public bool IsPOConverted { get; set; }
        public DateTime? POConvertedDate { get; set; }
        public string? POId { get;set; }
        //public string ShippingAddress { get; set; }
        //public string BillingAddress { get; set; }
        public decimal SubTotal { get; set; }
        public List<PRItemsList> PRItems { get; set; }
    }
    public class PRItemsList
    {
        public long Id { get; set; }
        public string ProductName { get; set; }
        public string UOM { get; set; }
        public int ReceivedQuantity { get; set; }
        public decimal Quantity { get; set; }
        public decimal Rate { get; set; }
        public decimal Amount { get; set; }
    }
}
