using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Models.DTOs.Requests
{
    public class CreateInvoiceRequest
    {
        public string PONumber { get; set; }
        public DateTime InvoiceDate { get; set; }
        public string PaymentTerms { get; set; }
        public decimal InvoiceTotalAmount { get; set; }
        public List<InvoiceItems> Items { get; set; }
        public string UserId { get; set; }
    }

    public class InvoiceItems
    {
        public long PurchaseOrderItemId { get; set; }
        public int InvoiceQuantity { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
