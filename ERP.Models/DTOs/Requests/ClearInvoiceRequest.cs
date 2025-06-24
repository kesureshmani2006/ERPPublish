    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Models.DTOs.Requests
{
    public class ClearInvoiceRequest
    {
        public DateTime ClearedDate { get; set; }
        public string ClearedBy { get; set; }
        public List<InvoiceClearingItems> InvoiceClearingItems { get; set; }
    }
    public class InvoiceClearingItems
    {
        public string InvoiceId { get; set; }
        public decimal PaymentAmount { get; set; }
    }
}
