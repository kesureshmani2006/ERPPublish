using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Models.Entities
{
    public class ReTenants
    {
        public long Id { get; set; }
        public string TenantName { get; set; }
        = string.Empty;
        public string? TenantEmiratedId { get; set; } = string.Empty;
        public string? TenantPhone { get; set; }
        public string? TenantEmail{ get; set; }
        public bool IsActive { get; set; }
        public string? CreatedBy { get; set; } = string.Empty;
        public DateTime? CreatedAt { get; set; } = DateTime.UtcNow;
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public long? PropertyId { get; set; }

    }
}
