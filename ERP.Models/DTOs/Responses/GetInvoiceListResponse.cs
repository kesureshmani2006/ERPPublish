using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Models.DTOs.Responses
{
    public class GetInvoiceListResponse
    {
        public string InvoiceNo { get; set; }
        public string CompanyName { get; set; }
        public decimal InvoiceAmount { get; set; }
        public decimal PaidAmount { get; set; }
        public string Country { get; set; }
        public string Status { get; set; }
    }
}
