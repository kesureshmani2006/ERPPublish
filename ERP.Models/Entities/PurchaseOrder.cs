using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Models.Entities
{
    public class PurchaseOrder
    {
        [Key]
        public long Id { get; set; }
        public string PONumber { get; set; }

        [ForeignKey("PurchaseRequests")]
        public long PRId { get; set; }
        public DateTime POConvertedDate { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public PurchaseRequest PurchaseRequests { get; set; }
        public ICollection<PurchaseOrderItems> PurchaseOrderItems { get; set; }
    }
}
