using ERP.Models.DTOs.Requests;
using ERP.Models.DTOs.Requests.RealEstate;
using ERP.Models.DTOs.Responses.RealEstate;
using ERP.Models.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.BusinessLogic.IBusinessLogics.RealEstate
{
    public interface IRealestateBl
    {
        Task<long> AddPropertydetialsAsync(AddPropertyRequest AddProperty);
        Task<long> AddLandlorddetialsAsync(AddLandlordRequest AddLandlord);
        Task<long> AddTenancyContractdetialsAsync(AddTenancyContractRequest AddLandlord);
        

        Task<List<RePropertyResponse>>  GetAllProperty();
        Task<PropertyDetailResponse> GetPropertyDetailsById(long PropertyId);
        Task<Landlord> GetLandlordDetailsById(long LandlordId);

        Task PropertyRegistration(PropertyRegisterRequest propertyRegister);
        Task<List<ReTenantsResponse>> GetAllTenants();
    }
}
