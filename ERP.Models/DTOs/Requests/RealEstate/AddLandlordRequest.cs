using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Models.DTOs.Requests.RealEstate
{
    public class AddLandlordRequest
    {
        public long Id { get; set; }
        public string? OwnersName { get; set; }
        public string? LessorsName { get; set; }
        public string? LessorsEmiratesId { get; set; }
        public string? PhoneNo { get; set; }
        public string? Email { get; set; }
        public string? LicenseNo { get; set; }
        public string? LicensingAuthority { get; set; }   
        public long rePrapertyId { get; set; }
    }
}
