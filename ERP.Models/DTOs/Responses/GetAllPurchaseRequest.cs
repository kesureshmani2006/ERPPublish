using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Models.DTOs.Responses
{
    public class GetAllPurchaseRequest
    {
        public string PRNumber { get; set; }
        public string VendorName { get; set; }
        public string VerndorId { get; set; }
        public DateTime PRDate { get; set; }
        public decimal PRTotalAmount { get; set; }
        public bool IsPOConverted { get; set; }
    }
}
