using ERP.Models.DTOs.Requests.RealEstate;
using ERP.Models.DTOs.Responses.RealEstate;
using ERP.Models.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.BusinessRepository.IBusinessRepository.RealEstate
{
    public interface IRealestateBr
    {
        Task<long> AddPropertydetialsAsync(AddPropertyRequest AddProperty);
        Task<long> AddLandlorddetialsAsync(AddLandlordRequest AddLandlord);
        Task<long> AddTenancyContractdetialsAsync(AddTenancyContractRequest contractRequest);
        //Task<long> AddChequedetialsAsync(AddChequeRequest chequeRequest);
        //Task<long> AddContractdetialsAsync(AddContractRequest contractRequest);
        Task<PropertyDetailResponse> GetPropertyDetailsById(long PropertyId);
        Task<Landlord> GetLandlordDetailsById(long LandlordId);
       Task<List<ReTenantsResponse>> GetAllTenants();
        Task PropertyRegistration(PropertyRegisterRequest propertyRegister);
        Task<List<RePropertyResponse>> GetAllProperty();
    }
}
