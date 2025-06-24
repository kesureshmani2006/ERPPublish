using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Models.Entities
{
    public class RePropertyHistory
    {
        [Key]
        public long Id { get; set; }
        [ForeignKey("ReProperty")]
        public long PlotId { get; set; }
        public string? PlotNo { get; set; }
        public string? MakaniNo { get; set; }
        public string? Location { get; set; }
        public string? PropertyArea { get; set; }
        public string? PropertyType { get; set; }
        public string? PremisesNo { get; set; }
        public string? PropertyUsage { get; set; }
        public string? BulidingName { get; set; }
        public string? LocationLL { get; set; }
        public bool IsActive { get; set; }
        public string? CreatedBy { get; set; } = string.Empty;
        public DateTime? CreatedAt { get; set; } = DateTime.UtcNow;
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedAt { get; set; } = DateTime.UtcNow;
    }
}
