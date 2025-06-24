using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Models.DTOs.Requests.RealEstate
{


    public class AddTenancyContractRequest
    {
        public AddTenancyRequest TenancyRequest { get; set; }
        public AddContractRequest contractRequest { get; set; }
    }
    public class AddTenancyRequest
    {
        public long? Id { get; set; }
        public string TenantsName { get; set; }      
        public string? TenantsEmiratedId { get; set; } = string.Empty;
        public string? TenantsPhone { get; set; }
        public string? TenantsEmail { get; set; }
        public long PropertyId { get; set; }
    }
}
