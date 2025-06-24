using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Models.DTOs.Responses
{
    public class GetInvoiceDetailsResponse
    {
        public string InvoiceNumber { get; set; }
        public DateTime InvoiceDate { get; set; }
        public DateTime? DueDate { get; set; }
        public string VendorName { get; set; }
        public string VendorAddress { get; set; }
        public string BillingAddress { get; set; }
        public string ShippingAddress { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Discount { get; set; }
        public decimal GST { get; set; }
        public decimal TotalAmount { get; set; }
        public List<InvoiceItemDto> Items { get; set; }
    }
    public class InvoiceItemDto
    {
        public string ProductName { get; set; }
        public string UOM { get; set; }
        public int Quantity { get; set; }
        public decimal Rate { get; set; }
        public decimal GST { get; set; }
        public decimal Discount { get; set; }
        public decimal Amount { get; set; }
    }
}
