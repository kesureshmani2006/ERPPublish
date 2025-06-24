using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Models.DTOs.Responses.RealEstate
{
    public class ReTenantsResponse
    {
        public long Id { get; set; }
        public string TenantName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNo { get; set; }
        public string? PlotNo { get; set; }
        public double? AnnualRent { get; set; }
        public DateTimeOffset? MoveInDate { get; set; }
        public string? Status { get; set; }


    }
}
