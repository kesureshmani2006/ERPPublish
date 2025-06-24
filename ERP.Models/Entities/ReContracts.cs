using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Models.Entities
{
    public class ReContracts
    {
        public long Id { get; set; }
        [ForeignKey("ReTenants")]
        public long TenantId { get; set; }

        [ForeignKey("ReProperty")]
        public long PropertyId { get; set; }


        public DateTimeOffset ContractFromDate { get; set; }
        public DateTimeOffset ContractToDate { get; set; }
        public DateTimeOffset ContractDate { get; set; }
        public double AnnualRent {  get; set; }
        public double ContractRent { get; set; }
        public double SecurityDepositAmount { get; set; }
        public string? ModeOfPayment { get; set; }
        public string? ContractStatus { get; set; }
        public bool IsActive { get; set; }
        public string? CreatedBy { get; set; } = string.Empty;
        public DateTime? CreatedAt { get; set; } = DateTime.UtcNow;
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedAt { get; set; }
    }
}
