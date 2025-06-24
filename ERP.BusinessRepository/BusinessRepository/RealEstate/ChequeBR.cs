using ERP.BusinessRepository.IBusinessRepository.RealEstate;
using ERP.Database.ERPDbContext;
using ERP.Models.DTOs.Requests.RealEstate;
using ERP.Models.DTOs.Responses.RealEstate;
using ERP.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.BusinessRepository.BusinessRepository.RealEstate
{
    public class ChequeBR:IChequeBr
    {
        private readonly ERPDBContext _dbContext;
        public ChequeBR(ERPDBContext eRPDBContext)
        {
            _dbContext = eRPDBContext;

        }
        public async  Task<long> AddchequedetialsAsync(List<AddChequeRequest> chequeRequest)
        {
            long cid = 0;
            try
            {
                using (var transaction = await _dbContext.Database.BeginTransactionAsync())
                {
                    try
                    {
                        foreach (var item in chequeRequest)
                        {
                            ReCheque objCheque = new ReCheque
                            {
                                ChequeNo = item.ChequeNumber,
                                BankName = item.BankName,
                                ChequeDate = item.ChequeDate,
                                ChequeAmount = item.ChequeAmount,
                                ChqStatus = item.Status,
                                TenantId = item.TenantId,
                                ContractId = item.ContractId,
                                IsActive = true,
                                CreatedBy = "Admin",
                                CreatedAt = DateTime.UtcNow
                            };

                            await _dbContext.ReCheque.AddAsync(objCheque);
                            await _dbContext.SaveChangesAsync();
                            cid = item.ContractId;
                        }
                        
                        await transaction.CommitAsync();
                        
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw new Exception(ex.Message);
                    }
                }
            }
            catch (Exception ex) { }
            return cid;
        }

        public async Task<List<ChequeResponse>> GetAllchequesByConstractId(ChequeRequest chequeRequest)
        {
            List<ChequeResponse>? chequeResponse = new List<ChequeResponse>();
            try
            {
                if ((chequeRequest.ContractId > 0) && (chequeRequest.TenantId > 0))
                {
                    chequeResponse = await _dbContext.ReCheque.Where(x => x.IsActive == true && x.TenantId==chequeRequest.TenantId &&
                    x.ContractId==chequeRequest.ContractId).Select(x => new ChequeResponse
                    {
                        Id = x.Id,
                        BankName = x.BankName,
                        ChequeAmount = x.ChequeAmount,
                        ChequeDate = x.ChequeDate,
                        ChequeNumber = x.ChequeNo,
                        ContractId = x.ContractId,
                        Status = x.ChqStatus,
                        TenantId = x.TenantId,
                        Remarks = x.Remarks

                    }).ToListAsync();
                }
                else 
                {
                    if (chequeRequest.ContractId > 0)
                    {
                        chequeResponse = await _dbContext.ReCheque.Where(x => x.IsActive == true && x.ContractId== chequeRequest.ContractId).Select(x => new ChequeResponse
                        {
                            Id = x.Id,
                            BankName = x.BankName,
                            ChequeAmount = x.ChequeAmount,
                            ChequeDate = x.ChequeDate,
                            ChequeNumber = x.ChequeNo,
                            ContractId = x.ContractId,
                            Status = x.ChqStatus,
                            TenantId = x.TenantId,
                            Remarks = x.Remarks


                        }).ToListAsync();
                    }
                }
               

            }
            catch (Exception ex)
            { throw; }
            return chequeResponse;
        }
       public async Task<ChequeResponse> GetchequeDetailsById(long chequeId)
        {
            ChequeResponse? chequeResponse=new ChequeResponse();
            try {
                chequeResponse = await _dbContext.ReCheque.Where(x => x.IsActive == true && x.Id == chequeId).Select(x => new ChequeResponse
                {
                    Id = x.Id,
                    BankName = x.BankName,
                    ChequeAmount = x.ChequeAmount,
                    ChequeDate = x.ChequeDate,
                    ChequeNumber = x.ChequeNo,
                    ContractId = x.ContractId,
                    Status = x.ChqStatus,
                    TenantId = x.TenantId,
                    Remarks = x.Remarks

                }).FirstOrDefaultAsync();

            }
            catch (Exception ex)
            { throw; }
            return chequeResponse;
        }

      public async Task<long> UpdatechequeDetails(UpdateChequeRequest chequeRequest)
        {

            try {
               ReCheque reCheque=new ReCheque();
                reCheque=  await _dbContext.ReCheque.Where(x=>x.IsActive==true && x.Id==chequeRequest.Id).FirstOrDefaultAsync();
                reCheque.ChequeNo=chequeRequest.ChequeNumber;
                reCheque.ChequeDate=chequeRequest.ChequeDate;
                reCheque.ChqStatus=chequeRequest.Status;
                reCheque.BankName=chequeRequest.BankName;
                reCheque.ChequeAmount=chequeRequest.ChequeAmount;
                reCheque.Remarks=chequeRequest.Remarks;
                reCheque.ContractId=chequeRequest.ContractId;
                reCheque.TenantId=chequeRequest.TenantId;
                reCheque.ModifiedBy = "Admin";
                reCheque.ModifiedAt=DateTime.UtcNow;
                 _dbContext.ReCheque.Update(reCheque);
                await _dbContext.SaveChangesAsync();

            }
            catch (Exception ex) { throw; }
          return  chequeRequest.Id;

        }






    }
}
