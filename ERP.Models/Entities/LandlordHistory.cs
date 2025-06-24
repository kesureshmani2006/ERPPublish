using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Models.Entities
{
    public class LandlordHistory
    {
        public long Id { get; set; }
        [ForeignKey("Landlord")]
        public long LandlordId { get; set; }

        public string? OwnersName { get; set; }
        public string LessorsName { get; set; }
        public string LessorsEmiratesId { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string LicenseNo { get; set; }
        public string LicensingAuthority { get; set; }       
        public long rePrapertyId { get; set; }
        public bool IsActive { get; set; }
        public string? CreatedBy { get; set; } = string.Empty;
        public DateTime? CreatedAt { get; set; } = DateTime.UtcNow;
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedAt { get; set; } = DateTime.UtcNow;
    }
}
