using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Models.Entities
{
    public class PurchaseOrderItems
    {
        [Key]
        public long Id { get; set; }
        [ForeignKey("PurchaseOrders")]
        public long POId { get; set; }
        [ForeignKey("PurchaseRequestItems")]
        public long PurchaseRequestItemId { get; set; }
        public int ReceivedQuantity { get; set; }
        public PurchaseOrder PurchaseOrders { get; set; }
        public PurchaseRequestItems PurchaseRequestItems { get; set; }
        public ICollection<InvoiceItem> InvoiceItems { get; set; }
    }
}
