using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Models.DTOs.Responses
{
    public class GetPOResponse
    {
        public string PONumber { get; set; }
        public DateTime PODate { get; set; }
        public string VendorId { get; set; }
        public string VendorName { get; set; }
        public string PRNumber { get; set; }
        public decimal SubTotal { get; set; }
        public List<POItemsList> POItems { get; set; }
    }
    public class POItemsList
    {
        public long Id { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public int ReceivedQuantity { get; set; }
        public int InvoicedQuantity { get; set; }
        public decimal InvoicedAmount { get; set; }
        public string UOM { get; set; }
        public decimal Rate { get; set; }
        public decimal Amount { get; set; }
    }
}
