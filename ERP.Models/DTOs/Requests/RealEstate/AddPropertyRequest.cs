using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Models.DTOs.Requests.RealEstate
{
    public class AddPropertyRequest
    {
        public long Id { get; set; }
        public string? BuildingName { get; set; }
        public string? PlotNo { get; set; }
        public string? MakaniNo { get; set; }
        public string? Location { get; set; }
        public string? PropertyArea { get; set; }
        public string? PremisesNo { get; set; }
        public string? PropertyUsage { get; set; }
        public string? PropertyNo { get; set; }        
        public string? PropertyType { get; set; }
        public string? LocationLL { get; set; }     

    }
}
