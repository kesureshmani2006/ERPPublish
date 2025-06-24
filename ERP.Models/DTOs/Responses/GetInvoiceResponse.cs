using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Models.DTOs.Responses
{
    public class GetInvoiceResponse
    {
        public string PONumber { get; set; }
        public List<GetInvoiceItems> Items { get; set; }

    }
    public class GetInvoiceItems
    {
        public long Id { get; set; }
        public long POItemId { get; set; }
        public string ProductName { get; set; }
        public string UOM { get; set; }
        public int OrderedQuantity { get; set; }
        public int ReceivedQuantity { get; set; }
        public decimal Rate { get; set; }
        public decimal Amount { get; set; }
        public int InvoicedQuantity { get; set; }
    }
}
