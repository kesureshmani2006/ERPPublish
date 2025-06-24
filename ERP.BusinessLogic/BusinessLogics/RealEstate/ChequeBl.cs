using ERP.BusinessLogic.IBusinessLogics.RealEstate;
using ERP.BusinessRepository.BusinessRepository.RealEstate;
using ERP.BusinessRepository.IBusinessRepository.RealEstate;
using ERP.Models.DTOs.Requests.RealEstate;
using ERP.Models.DTOs.Responses.RealEstate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.BusinessLogic.BusinessLogics.RealEstate
{
    public class ChequeBl:IChequeBl
    {
        private readonly IChequeBr chequeBr;
        public ChequeBl(IChequeBr Chequebr) => chequeBr = Chequebr;

        public  async Task<long> AddchequedetialsAsync(List<AddChequeRequest> chequeRequest)
        {
            return await chequeBr.AddchequedetialsAsync(chequeRequest);
        }



        Task<List<ChequeResponse>> IChequeBl.GetAllchequesByConstractId(ChequeRequest chequeRequest)
        {
            return  chequeBr.GetAllchequesByConstractId(chequeRequest);
        }

        Task<ChequeResponse>  IChequeBl.GetchequeDetailsById(long chequeId)
        {
            return  chequeBr.GetchequeDetailsById(chequeId);
        }
        Task<long> IChequeBl.UpdatechequeDetails(UpdateChequeRequest chequeRequest)
        {
            return chequeBr.UpdatechequeDetails(chequeRequest);
        }

      
    }
}
