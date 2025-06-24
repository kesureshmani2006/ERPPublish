using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Models.Entities
{
    public class PurchaseRequestItems
    {
        [Key]
        public long Id { get; set; }

        [ForeignKey("PurchaseRequest")]
        public long PurchaseRequestId { get; set; }
        public string ProductName { get; set; }
        public string UOM { get; set; }
        public int Quantity { get; set; }
        public decimal Rate { get; set; }
        public decimal Amount { get; set; }
        //public int ReceivedQuantity { get; set; }
        public PurchaseRequest PurchaseRequest { get; set; }
        public ICollection<PurchaseOrderItems> PurchaseOrderItems { get; set; }
    }
}
