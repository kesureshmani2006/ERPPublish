using ERP.BusinessLogic.IBusinessLogics.RealEstate;
using ERP.BusinessRepository.BusinessRepository.RealEstate;
using ERP.BusinessRepository.IBusinessRepository.RealEstate;
using ERP.Models.DTOs.Requests;
using ERP.Models.DTOs.Requests.RealEstate;
using ERP.Models.DTOs.Responses.RealEstate;
using ERP.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.BusinessLogic.BusinessLogics.RealEstate
{
    public class RealestateBl:IRealestateBl
    {
        private readonly IRealestateBr realestateBr;
        public RealestateBl(IRealestateBr _realestateBr)
        {
            realestateBr= _realestateBr;
        }

        public async Task<long> AddPropertydetialsAsync(AddPropertyRequest AddProperty)
        {
           return await realestateBr.AddPropertydetialsAsync(AddProperty);
        }
        public async Task<long> AddLandlorddetialsAsync(AddLandlordRequest AddLandlord)
        {
           return await realestateBr.AddLandlorddetialsAsync(AddLandlord);
        }
        public async Task<long> AddTenancyContractdetialsAsync(AddTenancyContractRequest contractRequest)
        {
            return await realestateBr.AddTenancyContractdetialsAsync(contractRequest);
        }

      
        public async Task<List<RePropertyResponse>> GetAllProperty()
        {
            return await realestateBr.GetAllProperty();
        }
       
      

        public async Task<PropertyDetailResponse> GetPropertyDetailsById(long PropertyId)
        {
          return  await realestateBr.GetPropertyDetailsById(PropertyId);
        }
        public async Task<Landlord> GetLandlordDetailsById(long LandlordId)
        {
            return await realestateBr.GetLandlordDetailsById(LandlordId);
        }
        public async Task<List<ReTenantsResponse>> GetAllTenants()
        {
            return await realestateBr.GetAllTenants();
        }
      
        public async Task PropertyRegistration(PropertyRegisterRequest propertyRegister)
        {
             await realestateBr.PropertyRegistration(propertyRegister);
        }


        


    }
}
