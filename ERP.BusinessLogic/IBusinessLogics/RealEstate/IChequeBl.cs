using ERP.Models.DTOs.Requests.RealEstate;
using ERP.Models.DTOs.Responses.RealEstate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.BusinessLogic.IBusinessLogics.RealEstate
{
    public interface IChequeBl
    {
      public Task<long> AddchequedetialsAsync(List<AddChequeRequest> chequeRequest);
       public Task<ChequeResponse> GetchequeDetailsById(long chequeId);
      
        public Task<List<ChequeResponse>> GetAllchequesByConstractId(ChequeRequest chequeRequest);

        public Task<long> UpdatechequeDetails(UpdateChequeRequest chequeRequest);

	}
}
