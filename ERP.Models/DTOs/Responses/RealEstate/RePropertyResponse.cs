using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Models.DTOs.Responses.RealEstate
{
    public class RePropertyResponse
    {
        public long Id { get; set; }
        public string? PlotNo { get; set; }
        public string? MakaniNo { get; set; }
        public string? Location { get; set; }
        public string? PropertyArea { get; set; }
        public string? PropertyType { get; set; }
        public string? PremisesNo { get; set; }
        public string? PropertyNo { get; set; }
        public string? PropertyUsage { get; set; }
        public string? BulidingName { get; set; }
        public string? LocationLL { get; set; }
        public bool IsActive { get; set; }
        public string? CreatedBy { get; set; } 
        public DateTime? CreatedAt { get; set; }
        public List<PlotStatus> PlotStatus { get; set; }
    }
    public class PlotStatus
    {
        
        public int Id { get; set; }
        public string? Label { get; set; }
        public bool IsCompleted { get; set; }
       
    }
}
