using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Models.Entities
{
    public class Status
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public ICollection<PurchaseRequest> PurchaseRequests { get; set; }
        public ICollection<Vendor> Vendors { get; set; }
        public ICollection<Invoice> Invoice { get; set; }
    }
}
