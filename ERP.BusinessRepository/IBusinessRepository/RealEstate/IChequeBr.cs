using ERP.Models.DTOs.Requests.RealEstate;
using ERP.Models.DTOs.Responses.RealEstate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.BusinessRepository.IBusinessRepository.RealEstate
{
    public interface IChequeBr
    {
        Task<long> AddchequedetialsAsync(List<AddChequeRequest> chequeRequest);
        Task<ChequeResponse> GetchequeDetailsById(long chequeId);
        Task<List<ChequeResponse>> GetAllchequesByConstractId(ChequeRequest chequeRequest);
        Task<long> UpdatechequeDetails(UpdateChequeRequest chequeRequest);
    }
}
