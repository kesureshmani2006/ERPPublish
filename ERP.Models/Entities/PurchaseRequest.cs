using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Models.Entities
{
    public class PurchaseRequest
    {
        public long Id { get; set; }
        public string PRNumber { get; set; }

        [ForeignKey("Vendor")]
        public long VendorId { get; set; }
        public decimal SubTotal { get; set; }

        [ForeignKey("Statuses")]
        public int Status { get; set; }
        public bool IsPOConverted { get; set; }
        //public string? POId { get; set; }
        //public DateTime? POConvertedDate { get; set; } = DateTime.UtcNow;
        public string? CreatedBy { get; set; } = string.Empty;
        public DateTime? CreatedAt { get; set; } = DateTime.UtcNow;
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedAt { get; set; } = DateTime.UtcNow;
        public ICollection<PurchaseRequestItems> PurchaseRequestItems { get; set; }
        public Vendor Vendor { get; set; }
        public Status Statuses { get; set; }
        public PurchaseOrder PurchaseOrders { get; set; }
    }
}
