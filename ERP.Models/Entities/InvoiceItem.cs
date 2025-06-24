using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Models.Entities
{
    public class InvoiceItem
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Invoices")]
        public long InvoiceId { get; set; }
        [ForeignKey("PurchaseOrderItems")]
        public long PurchaseOrderItemId { get; set; }
        public int InvoiceQuantity { get; set; }
        [Column(TypeName = "decimal(12,2)")]
        public decimal TotalAmount { get; set; }
        public Invoice Invoices { get; set; }
        public PurchaseOrderItems PurchaseOrderItems { get; set; }
    }
}
