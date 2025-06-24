using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Models.DTOs.Requests.RealEstate
{
    public class PropertyRegisterRequest
    {
        public AddPropertyDetails? addPropertyDetails { get; set; }
        public AddLandlardDetails? addLandlardDetails { get; set; }
    }
    public class AddPropertyDetails
    {
        
             public string? BuildingName { get; set; }
        public string? PlotNo { get; set; }
        public string? MakaniNo { get; set; }
        public string? Location { get; set; }
        public string? BuildingArea { get; set; }
        public string? PremisesNo { get; set; }
        public string? PropertyUsage { get; set; }
        public string? LocationLL { get; set; }
        public string? BulidingName { get; set; }
    }
    public class AddLandlardDetails
    {
        public string? OwnersName { get; set; }
        public string? LessorsName { get; set; }
        public string? LessorsEmiratesId { get; set; }
        public string? PhoneNo { get; set; }
        public string? Email { get; set; }
        public string? LicenseNo { get; set; }
        public string? LicensingAuthority { get; set; }

    }
}
