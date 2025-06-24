using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Models.DTOs.Requests.RealEstate
{
    public class ChequeRequest
    {
        public long? TenantsId { get; set; }
        public long? ConstractId { get; set; }
    }
}
