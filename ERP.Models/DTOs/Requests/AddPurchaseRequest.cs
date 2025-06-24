using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Models.DTOs.Requests
{
    public class AddPurchaseRequest
    {
        public string? PRNumber { get; set; }
        public string VendorId { get; set; }
        public string UserId { get; set; }
        public decimal SubTotal { get; set; }
        public DateTime PRDate { get; set; }
        public List<PRItems> PrItems { get; set; }
    }
    public class PRItems
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string UOM { get; set; }
        public int Quantity { get; set; }
        public decimal Rate { get; set; }
        public decimal Amount { get; set; }
        public bool IsDeleted { get; set; }
    }
}
