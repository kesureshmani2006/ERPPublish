using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Models.DTOs.Requests.RealEstate
{
    public class AddContractRequest
    {
        public long? TenantId { get; set; }
        public long? PropertyId { get; set; }
        public DateTimeOffset ContractPeriodFrom { get; set; }
        public DateTimeOffset ContractPeriodTo { get; set; }
        public DateTimeOffset ContractDate { get; set; }
        public double AnnualRent { get; set; }
        public double ContractValue { get; set; }
        public double SecurityDepositAmount { get; set; }
        public string? ModeOfPayment { get; set; }
        public string? ContractStatus { get; set; }
    

    }
}
