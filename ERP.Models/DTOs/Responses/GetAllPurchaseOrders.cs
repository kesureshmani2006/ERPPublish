using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Models.DTOs.Responses
{
    public class GetAllPurchaseOrders
    {
        public string PONumber { get; set; }
        public string PRNumber { get; set; }
        public string VendorName { get; set; }
        public string VerndorId { get; set; }
        public DateTime? PODate { get; set; }
        public decimal POTotalAmount { get; set; }
        public bool IsPOConverted { get; set; }
    }
}
