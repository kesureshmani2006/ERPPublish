using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Models.DTOs.Requests.RealEstate
{
    public class ChequeRequest
    {
        public long? TenantId { get; set; }
        public long? ContractId { get; set; }
    }
}
