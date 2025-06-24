using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Models.Entities
{
    public class Invoice
    {
        [Key]
        public long Id { get; set; }
        public string InvoiceNumber { get; set; }
        [ForeignKey("PurchaseOrders")]
        public long PurchaseOrderId { get; set; }
        public DateTime InvoiceDate { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal? PaidAmount { get; set; }
        public string PaymentTerms { get; set; }
        public DateTime? InvoiceClearedDate { get; set; }
        public string? InvoiceClearedBy { get; set; }
        [ForeignKey("Statuses")]
        public int Status { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string? ModifiedBy { get; set; }
        public string? ModifiedAt { get; set; }
        public PurchaseOrder PurchaseOrders { get; set; }
        public Status Statuses { get; set; }
    }
}
