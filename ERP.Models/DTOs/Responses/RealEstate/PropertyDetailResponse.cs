using ERP.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Models.DTOs.Responses.RealEstate
{
    public class PropertyDetailResponse
    {
       public PropertyResponse? reProperty { get; set; }
        public LandlordResponse? landlord { get; set; }
        public TenantsReponse? Tenants { get; set; }
        public ContractsResponse? Contracts { get; set; }
        public List<PlotStatus>? PlotStatus { get; set; }
    }
    public class PropertyResponse
    {
        public long Id { get; set; }
        public string? PlotNo { get; set; }
        public string? MakaniNo { get; set; }
        public string? Location { get; set; }
        public string? PropertyArea { get; set; }
        public string? PropertyType { get; set; }
        public string? PremisesNo { get; set; }
        public string? PropertyUsage { get; set; }
        public string? PropertyNo { get; set; }
        public string? BulidingName { get; set; }
        public string? LocationLL { get; set; }
        public bool IsActive { get; set; }
        public string? CreatedBy { get; set; } 
        public DateTime? CreatedAt { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedAt { get; set; }

    }
    public class LandlordResponse
    {
        public long Id { get; set; }

        public string? OwnersName { get; set; }
        public string? LessorsName { get; set; }
        public string? LessorsEmiratesId { get; set; }
        public string? LessorsPhone { get; set; }
        public string? LessorsEmail { get; set; }
        public string? LicenseNo { get; set; }
        public string? LicensingAuthority { get; set; }
        
        public long rePrapertyId { get; set; }
        public bool IsActive { get; set; }
        public string? CreatedBy { get; set; } 
        public DateTime? CreatedAt { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedAt { get; set; }

    }
    public class TenantsReponse
    {
        public long Id { get; set; }
        public string TenantsName { get; set; }
        public string? TenantsEmiratedId { get; set; } 
        public string? TenantsPhone { get; set; }
        public string? TenantsEmail { get; set; }
        public bool IsActive { get; set; }
        public string? CreatedBy { get; set; } 
        public DateTime? CreatedAt { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public long? PropertyId { get; set; }

    }
    public class ContractsResponse
    {
        public long Id { get; set; }       
        public long TenantId { get; set; }       
        public long PropertyId { get; set; }
        public DateTimeOffset ContractPeriodFrom { get; set; }
        public DateTimeOffset ContractPeriodTo { get; set; }
        public DateTimeOffset ContractDate { get; set; }
        public double AnnualRent { get; set; }
        public double ContractValue { get; set; }
        public double SecurityDepositAmount { get; set; }
        public string? ModeOfPayment { get; set; }
        public string? ContractStatus { get; set; }
        public bool IsActive { get; set; }
        public string? CreatedBy { get; set; } 
        public DateTime? CreatedAt { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedAt { get; set; }

    }
}
