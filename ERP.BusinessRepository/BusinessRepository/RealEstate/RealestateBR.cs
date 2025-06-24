using ERP.BusinessRepository.IBusinessRepository.RealEstate;
using ERP.BusinessRepository.Services;
using ERP.Database.ERPDbContext;
using ERP.Models.DTOs.Requests;
using ERP.Models.DTOs.Requests.RealEstate;
using ERP.Models.DTOs.Responses.RealEstate;
using ERP.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Npgsql.Internal.Postgres;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ERP.BusinessRepository.BusinessRepository.RealEstate
{
    public class RealestateBR:IRealestateBr
    {
        private readonly ERPDBContext _dbContext;
        public RealestateBR(ERPDBContext eRPDBContext)
        {
            _dbContext = eRPDBContext;
        
            
        }
        public async Task<long>  AddPropertydetialsAsync(AddPropertyRequest AddProperty)
        {
            long pid = 0;
            try
            {
                if (AddProperty.Id == 0)
                {
                    using (var transaction = await _dbContext.Database.BeginTransactionAsync())
                    {
                        try
                        {
                            ReProperty objproperty = new ReProperty
                            {
                                BulidingName = AddProperty.BuildingName,
                                PlotNo = AddProperty.PlotNo,
                                MakaniNo = AddProperty.MakaniNo,
                                Location = AddProperty.Location,
                                PropertyArea = AddProperty.PropertyArea,
                                PremisesNo = AddProperty.PremisesNo,
                                PropertyUsage = AddProperty.PropertyUsage,
                                PropertyType = AddProperty.PropertyType,
                                PropertyNo = AddProperty.PropertyNo,
                                LocationLL = AddProperty.LocationLL,
                                IsActive = true,
                                CreatedBy = "Admin",
                                CreatedAt = DateTime.UtcNow
                            };

                            await _dbContext.ReProperty.AddAsync(objproperty);
                            await _dbContext.SaveChangesAsync();
                            RePropertyHistory propertyHistory = new RePropertyHistory
                            {
                                PlotId = objproperty.Id,
                                BulidingName = AddProperty.BuildingName,
                                PlotNo = AddProperty.PlotNo,
                                MakaniNo = AddProperty.MakaniNo,
                                Location = AddProperty.Location,
                                PropertyArea = AddProperty.PropertyArea,
                                PropertyType = AddProperty.PropertyType,
                                PremisesNo = AddProperty.PremisesNo,
                                PropertyUsage = AddProperty.PropertyUsage,
                                LocationLL = AddProperty.LocationLL,
                                IsActive = true,
                                CreatedBy = "Admin",
                                CreatedAt = DateTime.UtcNow
                            };
                            await _dbContext.RePropertyHistory.AddAsync(propertyHistory);
                            await _dbContext.SaveChangesAsync();

                            pid = objproperty.Id;
                            string label = string.Empty;
                            bool _Iscompl = false;
                            for (Int32 i = 1; i <= 3; i++)
                            {
                                if (i == 1)
                                {
                                    label = "Plot";
                                    _Iscompl = true;
                                }
                                else if (i == 2)
                                {
                                    label = "Owner";
                                    _Iscompl = false;
                                }
                                else if (i == 3)
                                {
                                    label = "Tenant";
                                    _Iscompl = false;
                                }
                                REStatus objstatus = new REStatus
                                {
                                    Id = i,
                                    Label = label,
                                    IsCompleted = _Iscompl,
                                    IsActive = true,
                                    CreatedBy = "Admin",
                                    CreatedAt = DateTime.UtcNow,
                                    PropertyId = objproperty.Id
                                };
                                await _dbContext.REStatus.AddAsync(objstatus);
                                await _dbContext.SaveChangesAsync();
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
                else
                {
                    if (AddProperty.Id > 0)
                    {
                        ReProperty propertyobj = await _dbContext.ReProperty.Where(x => x.Id == AddProperty.Id).FirstOrDefaultAsync();
                        if (propertyobj != null)
                        {
                            propertyobj.BulidingName = AddProperty.BuildingName;
                            propertyobj.PlotNo = AddProperty.PlotNo;
                            propertyobj.MakaniNo = AddProperty.MakaniNo;
                            propertyobj.Location = AddProperty.Location;
                            propertyobj.PropertyArea = AddProperty.PropertyArea;
                            propertyobj.PremisesNo = AddProperty.PremisesNo;
                            propertyobj.PropertyUsage = AddProperty.PropertyUsage;
                            propertyobj.PropertyType = AddProperty.PropertyType;
                            propertyobj.PropertyNo = AddProperty.PropertyNo;
                            propertyobj.LocationLL = AddProperty.LocationLL;
                            propertyobj.ModifiedBy = "Admin";
                            propertyobj.ModifiedAt = DateTime.Now;
                            _dbContext.ReProperty.Update(propertyobj);
                            await _dbContext.SaveChangesAsync();
                        }
                        RePropertyHistory propertyHistory = new RePropertyHistory
                        {
                            PlotId = propertyobj.Id,
                            BulidingName = AddProperty.BuildingName,
                            PlotNo = AddProperty.PlotNo,
                            MakaniNo = AddProperty.MakaniNo,
                            Location = AddProperty.Location,
                            PropertyArea = AddProperty.PropertyArea,
                            PropertyType = AddProperty.PropertyType,
                            PremisesNo = AddProperty.PremisesNo,
                            PropertyUsage = AddProperty.PropertyUsage,
                            LocationLL = AddProperty.LocationLL,
                            IsActive = true,
                            CreatedBy = "Admin",
                            CreatedAt = DateTime.UtcNow
                        };
                        await _dbContext.RePropertyHistory.AddAsync(propertyHistory);
                        await _dbContext.SaveChangesAsync();
                        pid = propertyobj.Id;

                    }
                }
                
            }
            catch { throw; }         

            return pid;

        }

        public async Task<long> AddLandlorddetialsAsync(AddLandlordRequest AddLandlord)
        {
            REStatus? plotStatus = new REStatus();
            long Lid = 0;
            try {
                plotStatus = _dbContext.REStatus.Where(x=>x.PropertyId==AddLandlord.rePrapertyId &&
            x.Id==2).FirstOrDefault();

                if (AddLandlord.Id == 0)
                {
                    using (var transaction = await _dbContext.Database.BeginTransactionAsync())
                    {
                        try
                        {

                            Landlord objLandlord = new Landlord
                            {
                                rePrapertyId = AddLandlord.rePrapertyId,
                                OwnersName = AddLandlord.OwnersName,
                                LessorsName = AddLandlord.LessorsName,
                                LessorsEmiratesId = AddLandlord.LessorsEmiratesId,
                                PhoneNo = AddLandlord.PhoneNo,
                                Email = AddLandlord.Email,
                                LicenseNo = AddLandlord.LicenseNo,
                                LicensingAuthority = AddLandlord.LicensingAuthority,
                                IsActive = true,
                                CreatedBy = "Admin",
                                CreatedAt = DateTime.UtcNow
                            };

                            await _dbContext.Landlord.AddAsync(objLandlord);
                            await _dbContext.SaveChangesAsync();
                            LandlordHistory landlordhis = new LandlordHistory
                            {
                                LandlordId = objLandlord.Id,
                                rePrapertyId = AddLandlord.rePrapertyId,
                                OwnersName = AddLandlord.OwnersName,
                                LessorsName = AddLandlord.LessorsName,
                                LessorsEmiratesId = AddLandlord.LessorsEmiratesId,
                                Phone = AddLandlord.PhoneNo,
                                Email = AddLandlord.Email,
                                LicenseNo = AddLandlord.LicenseNo,
                                LicensingAuthority = AddLandlord.LicensingAuthority,
                                IsActive = true,
                                CreatedBy = "Admin",
                                CreatedAt = DateTime.UtcNow
                            };
                            await _dbContext.LandlordHistory.AddAsync(landlordhis);
                            await _dbContext.SaveChangesAsync();

                            if (plotStatus != null)
                            {
                                plotStatus.IsCompleted = true;
                                plotStatus.ModifiedAt = DateTime.UtcNow;
                                plotStatus.ModifiedBy = "Admin";
                            }
                            _dbContext.REStatus.Update(plotStatus);
                            await _dbContext.SaveChangesAsync();
                            await transaction.CommitAsync();
                            Lid = objLandlord.Id;
                        }
                        catch (Exception ex)
                        {
                            await transaction.RollbackAsync();
                            throw new Exception(ex.Message);
                        }
                    }
                }
                else
                {
                    if (AddLandlord.Id > 0)
                    {
                        Landlord landlordObj = await _dbContext.Landlord.Where(x => x.Id == AddLandlord.Id).FirstOrDefaultAsync();
                        if (landlordObj != null)
                        {
                            landlordObj.rePrapertyId = AddLandlord.rePrapertyId;
                            landlordObj.OwnersName = AddLandlord.OwnersName;
                            landlordObj.LessorsName = AddLandlord.LessorsName;
                            landlordObj.LessorsEmiratesId = AddLandlord.LessorsEmiratesId;
                            landlordObj.PhoneNo = AddLandlord.PhoneNo;
                            landlordObj.Email = AddLandlord.Email;
                            landlordObj.LicenseNo = AddLandlord.LicenseNo;
                            landlordObj.LicensingAuthority = AddLandlord.LicensingAuthority;
                            landlordObj.ModifiedBy = "Admin";
                            landlordObj.ModifiedAt = DateTime.UtcNow;
                            }
                         _dbContext.Landlord.Update(landlordObj);
                        await _dbContext.SaveChangesAsync();


                        LandlordHistory landlordhis = new LandlordHistory
                        {
                            LandlordId = landlordObj.Id,
                            rePrapertyId = AddLandlord.rePrapertyId,
                            OwnersName = AddLandlord.OwnersName,
                            LessorsName = AddLandlord.LessorsName,
                            LessorsEmiratesId = AddLandlord.LessorsEmiratesId,
                            Phone = AddLandlord.PhoneNo,
                            Email = AddLandlord.Email,
                            LicenseNo = AddLandlord.LicenseNo,
                            LicensingAuthority = AddLandlord.LicensingAuthority,
                            IsActive = true,
                            CreatedBy = "Admin",
                            CreatedAt = DateTime.UtcNow
                        };
                        await _dbContext.LandlordHistory.AddAsync(landlordhis);
                        await _dbContext.SaveChangesAsync();
                        Lid = landlordObj.Id;
                    }
                }
            }
            catch (Exception ex)
            { throw; } 
            return Lid;

        }

        public async Task<long> AddTenancyContractdetialsAsync(AddTenancyContractRequest contRequest)
        {
            long TCid = 0;
            REStatus? plotStatus = new REStatus();
            long Lid = 0;
            try
            {
                plotStatus = _dbContext.REStatus.Where(x => x.PropertyId == contRequest.TenancyRequest.PropertyId &&
            x.Id == 3).FirstOrDefault();
                if (contRequest.TenancyRequest.Id > 0)
                {
                    ReTenants reTenants = await _dbContext.ReTenants.Where(x => x.Id == contRequest.TenancyRequest.Id).FirstOrDefaultAsync();
                    ReContracts reContracts = await _dbContext.ReContracts.Where(x => x.TenantId == contRequest.TenancyRequest.Id).FirstOrDefaultAsync();

                    reTenants.TenantEmail = contRequest.TenancyRequest.TenantsEmail;
                    reTenants.TenantPhone = contRequest.TenancyRequest.TenantsPhone;
                    reTenants.TenantEmiratedId = contRequest.TenancyRequest.TenantsEmiratedId;
                    reTenants.TenantName = contRequest.TenancyRequest.TenantsName;
                    reTenants.ModifiedBy = "Admin";
                    reTenants.ModifiedAt = DateTime.UtcNow;
                    reTenants.PropertyId = contRequest.TenancyRequest.PropertyId;
                            
                

                 _dbContext.ReTenants.Update(reTenants);
                    await _dbContext.SaveChangesAsync();

                    reContracts.TenantId = reTenants.Id;
                    reContracts.PropertyId = (long)contRequest.contractRequest.PropertyId;
                    reContracts.ContractFromDate = contRequest.contractRequest.ContractPeriodFrom;
                    reContracts.ContractToDate = contRequest.contractRequest.ContractPeriodTo;
                    reContracts.ContractDate = contRequest.contractRequest.ContractDate;
                    reContracts.AnnualRent = contRequest.contractRequest.AnnualRent;
                    reContracts.ContractRent = contRequest.contractRequest.ContractValue;
                    reContracts.SecurityDepositAmount = contRequest.contractRequest.SecurityDepositAmount;
                    reContracts.ModeOfPayment = contRequest.contractRequest.ModeOfPayment;
                    //reContracts.ContractStatus = contRequest.contractRequest.ContractStatus;
                    reContracts.ContractStatus = "Active";

                    reContracts.ModifiedBy = "Admin";
                    reContracts.ModifiedAt = DateTime.UtcNow;


                    _dbContext.ReContracts.Update(reContracts);
                    await _dbContext.SaveChangesAsync();
                    TCid = reTenants.Id;
                }
                else
                {
                    using (var transaction = await _dbContext.Database.BeginTransactionAsync())
                    {
                        try
                        {

                            ReTenants tenants = new ReTenants
                            {
                                TenantEmail = contRequest.TenancyRequest.TenantsEmail,
                                TenantPhone = contRequest.TenancyRequest.TenantsPhone,
                                TenantEmiratedId = contRequest.TenancyRequest.TenantsEmiratedId,
                                TenantName = contRequest.TenancyRequest.TenantsName,
                                IsActive = true,
                                CreatedBy = "Admin",
                                CreatedAt = DateTime.UtcNow,
                                PropertyId = contRequest.TenancyRequest.PropertyId,
                            };

                            await _dbContext.ReTenants.AddAsync(tenants);
                            await _dbContext.SaveChangesAsync();
                            ReContracts contracts = new ReContracts
                            {
                                TenantId = tenants.Id,
                                PropertyId = (long)contRequest.contractRequest.PropertyId,
                                ContractFromDate = contRequest.contractRequest.ContractPeriodFrom,
                                ContractToDate = contRequest.contractRequest.ContractPeriodTo,
                                ContractDate = contRequest.contractRequest.ContractDate,
                                AnnualRent = contRequest.contractRequest.AnnualRent,
                                ContractRent = contRequest.contractRequest.ContractValue,
                                SecurityDepositAmount = contRequest.contractRequest.SecurityDepositAmount,
                                ModeOfPayment = contRequest.contractRequest.ModeOfPayment,
                                //ContractStatus = contRequest.contractRequest.ContractStatus,
                                ContractStatus = "Active",
                                IsActive = true,
                                CreatedBy = "Admin",
                                CreatedAt = DateTime.UtcNow
                            };

                            await _dbContext.ReContracts.AddAsync(contracts);
                            await _dbContext.SaveChangesAsync();
                            if (plotStatus != null)
                            {
                                plotStatus.IsCompleted = true;
                                plotStatus.ModifiedAt = DateTime.UtcNow;
                                plotStatus.ModifiedBy = "Admin";
                            }
                            _dbContext.REStatus.Update(plotStatus);
                            await _dbContext.SaveChangesAsync();
                            await transaction.CommitAsync();
                            TCid = tenants.Id;

                        }
                        catch (Exception ex)
                        {
                            transaction.RollbackAsync();
                            throw new Exception(ex.Message);
                        }
                    }
                }

            }
            catch (Exception ex)
            { throw; }
           
            return TCid;
        }
        //public async Task<long> AddContractdetialsAsync(AddContractRequest contractRequest)
        //{
        //    long Cid = 0;
        //    using (var transaction = await _dbContext.Database.BeginTransactionAsync())
        //    {
        //        try
        //        {

                   

        //        }
        //        catch (Exception ex)
        //        {
        //            await transaction.RollbackAsync();
        //            throw new Exception(ex.Message);
        //        }
        //    }
        //    return Cid;
        //}

        //public async Task<long> AddChequedetialsAsync(AddChequeRequest chequeRequest)
        //{
        //    long Cid = 0;
        //    using (var transaction = await _dbContext.Database.BeginTransactionAsync())
        //    {
        //        try
        //        {

        //            ReCheque chq = new ReCheque
        //            {

        //                ChequeNo = chequeRequest.ChequeNo,
        //                BankName = chequeRequest.BankName,
        //                ChequeDate = chequeRequest.ChequeDate,
        //                ChequeAmount = chequeRequest.ChequeAmount,
        //                ChqStatus = chequeRequest.ChqStatus,
        //                TenantId = chequeRequest.TenantId,
        //                ContractId = chequeRequest.ContractId,
        //                IsActive = true,
        //                CreatedBy = "Admin",
        //                CreatedAt = DateTime.UtcNow
        //            };

        //            await _dbContext.ReCheque.AddAsync(chq);
        //            await _dbContext.SaveChangesAsync();
        //            await transaction.CommitAsync();
        //            Cid = chq.Id;

        //        }
        //        catch (Exception ex)
        //        {
        //            await transaction.RollbackAsync();
        //            throw new Exception(ex.Message);
        //        }
        //    }
        //    return Cid;
        //}

   
        public async Task<List<RePropertyResponse>> GetAllProperty()
        {
           List<RePropertyResponse>? reProperty = new List<RePropertyResponse>();
            try
            {
                reProperty = await (from r in _dbContext.ReProperty

                                    where r.IsActive == true
                                    select new RePropertyResponse
                                    {
                                        Id=r.Id,
                                        PlotNo = r.PlotNo,
                                        MakaniNo = r.MakaniNo,
                                        Location = r.Location,
                                        PropertyArea = r.PropertyArea,
                                        PropertyType = r.PropertyType,
                                        PremisesNo = r.PremisesNo,
                                        PropertyUsage = r.PropertyUsage,
                                        PropertyNo= r.PropertyNo,
                                        BulidingName = r.BulidingName,
                                        LocationLL = r.LocationLL,
                                        IsActive = r.IsActive,
                                        CreatedBy = r.CreatedBy,
                                        CreatedAt = r.CreatedAt,
                                        PlotStatus = (from r2 in _dbContext.ReProperty
                                                      join res in _dbContext.REStatus on r2.Id equals res.PropertyId
                                                      where r.IsActive == true && r2.Id ==r.Id
                                                      orderby r.Id,res.Id 
                                                      select new PlotStatus
                                                      {
                                                          Id = res.Id,
                                                          Label = res.Label,
                                                          IsCompleted = res.IsCompleted
                                                      }).ToList()
                                    }).ToListAsync();
                   
                    
                    
                  
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return reProperty;
        }

        public async Task<List<ReTenantsResponse>> GetAllTenants()
        {
            List<ReTenantsResponse>? ReTenantsRes = new List<ReTenantsResponse>();
            try
            {
                ReTenantsRes = await (
                                    from pr in _dbContext.ReProperty
                                    join t in _dbContext.ReTenants on pr.Id equals t.PropertyId
                                    join c in _dbContext.ReContracts on t.Id equals c.TenantId into Tempten
                                    from tp in Tempten.DefaultIfEmpty()
                                    where tp == null || tp.IsActive == true
                                    select new ReTenantsResponse
                                    {
                                        Id = t.Id,
                                        TenantName = t.TenantName,
                                        Email = t.TenantEmail,
                                        PhoneNo = t.TenantPhone,
                                        PlotNo = pr.PlotNo,
                                        AnnualRent = tp != null ? tp.AnnualRent : null,
                                        MoveInDate = tp != null ? tp.ContractFromDate : (DateTime?)null,
                                        //Status = tp != null ? tp.ContractStatus : null
                                        Status="Active"
                                    }
                                ).ToListAsync();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return ReTenantsRes;
        }


        public async  Task<PropertyDetailResponse> GetPropertyDetailsById(long PropertyId)
        {
            PropertyDetailResponse detailResponse= new PropertyDetailResponse();

            try
            {
                PropertyResponse? rePro = await _dbContext.ReProperty.Where(x => x.Id == PropertyId && x.IsActive == true).Select(x => new PropertyResponse
                {
                    Id = x.Id,
                    PlotNo = x.PlotNo,
                    MakaniNo = x.MakaniNo,
                    Location = x.Location,
                    PropertyArea = x.PropertyArea,
                    PropertyType = x.PropertyType,
                    PremisesNo = x.PremisesNo,
                    PropertyUsage = x.PropertyUsage,
                    PropertyNo= x.PropertyNo,
                    BulidingName = x.BulidingName,
                    LocationLL = x.LocationLL,
                    IsActive = x.IsActive,
                    CreatedBy = x.CreatedBy,
                    CreatedAt = x.CreatedAt,
                    ModifiedBy = x.ModifiedBy,
                    ModifiedAt = x.ModifiedAt,
                }).FirstOrDefaultAsync();

                LandlordResponse? landlord = await _dbContext.Landlord.Where(x => x.rePrapertyId == PropertyId && x.IsActive == true).Select(
                    x => new LandlordResponse
                    {
                        Id = x.Id,
                        OwnersName = x.OwnersName,
                        LessorsName = x.LessorsName,
                        LessorsEmiratesId = x.LessorsEmiratesId,
                        LessorsPhone = x.PhoneNo,
                        LessorsEmail = x.Email,
                        LicenseNo = x.LicenseNo,
                        LicensingAuthority = x.LicensingAuthority,
                        rePrapertyId = x.rePrapertyId,
                        IsActive = x.IsActive,
                        CreatedBy = x.CreatedBy,
                        CreatedAt = x.CreatedAt,
                        ModifiedBy = x.ModifiedBy,
                        ModifiedAt = x.ModifiedAt,
                    }).FirstOrDefaultAsync();

                TenantsReponse? dts = await _dbContext.ReTenants.Where(x => x.PropertyId == PropertyId && x.IsActive == true).Select(
                    x => new TenantsReponse
                    {
                        Id = x.Id,
                        TenantsName = x.TenantName,
                        TenantsEmiratedId = x.TenantEmiratedId,
                        TenantsPhone = x.TenantPhone,
                        TenantsEmail = x.TenantEmail,
                        IsActive = x.IsActive,
                        CreatedBy = x.CreatedBy,
                        CreatedAt = x.CreatedAt,
                        ModifiedBy = x.ModifiedBy,
                        ModifiedAt = x.ModifiedAt,
                        PropertyId = x.PropertyId,
                    }).FirstOrDefaultAsync();

                ContractsResponse? cres = await _dbContext.ReContracts.Where(x => x.PropertyId == PropertyId && x.IsActive == true).Select(x => new ContractsResponse
                {
                    Id = x.Id,
                    TenantId = x.TenantId,
                    PropertyId = x.PropertyId,
                    ContractPeriodFrom = x.ContractFromDate,
                    ContractPeriodTo = x.ContractToDate,
                    ContractDate = x.ContractDate,
                    AnnualRent = x.AnnualRent,
                    ContractValue = x.ContractRent,
                    SecurityDepositAmount = x.SecurityDepositAmount,
                    ModeOfPayment = x.ModeOfPayment,
                    ContractStatus = x.ContractStatus,
                    IsActive = x.IsActive,
                    CreatedBy = x.CreatedBy,
                    CreatedAt = x.CreatedAt,
                    ModifiedBy = x.ModifiedBy,
                    ModifiedAt = x.ModifiedAt
                }).FirstOrDefaultAsync();


               List<PlotStatus>? dStatus = await _dbContext.REStatus.Where(x => x.PropertyId == PropertyId).Select(x => new PlotStatus
                {
                    Id = x.Id,
                    Label = x.Label,
                    IsCompleted = x.IsCompleted
                }).ToListAsync();
                detailResponse.reProperty = rePro;
                detailResponse.landlord = landlord;
                detailResponse.Tenants = dts;
                detailResponse.Contracts = cres;
                detailResponse.PlotStatus = dStatus;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return detailResponse;
        }

        public async Task<Landlord> GetLandlordDetailsById(long LandlordId)
        {
            Landlord? landlord = null;
            try
            {
                landlord = await _dbContext.Landlord.Where(x => x.Id == LandlordId).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return landlord;
        }
       
        public async Task PropertyRegistration(PropertyRegisterRequest propertyRegister)
        {
            using (var transaction = await _dbContext.Database.BeginTransactionAsync())
            {
                try
                {

                    ReProperty objproperty = new ReProperty
                    {
                        PlotNo = propertyRegister?.addPropertyDetails?.PlotNo,
                        MakaniNo = propertyRegister?.addPropertyDetails?.MakaniNo,
                        Location = propertyRegister?.addPropertyDetails?.Location,
                        PropertyArea = propertyRegister?.addPropertyDetails?.BuildingArea,
                        PremisesNo = propertyRegister?.addPropertyDetails?.PremisesNo,
                        PropertyUsage = propertyRegister?.addPropertyDetails?.PropertyUsage,
                        BulidingName = propertyRegister?.addPropertyDetails?.BuildingName,
                        LocationLL = propertyRegister?.addPropertyDetails?.LocationLL,
                        IsActive = true,
                        CreatedBy = "Admin",
                        CreatedAt = DateTime.UtcNow
                    };

                    await _dbContext.ReProperty.AddAsync(objproperty);
                    await _dbContext.SaveChangesAsync();
                    RePropertyHistory propertyHistory = new RePropertyHistory
                    {
                        PlotId = objproperty.Id,
                        PlotNo = propertyRegister?.addPropertyDetails?.PlotNo,
                        MakaniNo = propertyRegister?.addPropertyDetails?.MakaniNo,
                        Location = propertyRegister?.addPropertyDetails?.Location,
                        PropertyArea = propertyRegister?.addPropertyDetails?.BuildingArea,
                        PremisesNo = propertyRegister?.addPropertyDetails?.PremisesNo,
                        PropertyUsage = propertyRegister?.addPropertyDetails?.PropertyUsage,
                        BulidingName = propertyRegister?.addPropertyDetails?.BuildingName,
                        LocationLL = propertyRegister?.addPropertyDetails?.LocationLL,
                        IsActive = true,
                        CreatedBy = "Admin",
                        CreatedAt = DateTime.UtcNow
                    };
                    await _dbContext.RePropertyHistory.AddAsync(propertyHistory);
                    await _dbContext.SaveChangesAsync();

                        Landlord objLandlord = new Landlord
                        {
                            rePrapertyId = objproperty.Id,
                            OwnersName =  propertyRegister.addLandlardDetails.OwnersName,
                            LessorsName =  propertyRegister.addLandlardDetails.LessorsName,
                            LessorsEmiratesId =  propertyRegister.addLandlardDetails.LessorsEmiratesId,
                            PhoneNo =  propertyRegister.addLandlardDetails.PhoneNo,
                            Email =  propertyRegister.addLandlardDetails.Email,
                            LicenseNo =  propertyRegister.addLandlardDetails.LicenseNo,
                            LicensingAuthority =  propertyRegister.addLandlardDetails.LicensingAuthority,
                            IsActive = true,
                            CreatedBy = "Admin",
                            CreatedAt = DateTime.UtcNow
                        };

                        await _dbContext.Landlord.AddAsync(objLandlord);
                        await _dbContext.SaveChangesAsync();
                        LandlordHistory landlordhis = new LandlordHistory
                        {
                            LandlordId = objLandlord.Id,
                            rePrapertyId = objproperty.Id,
                            OwnersName = propertyRegister.addLandlardDetails.OwnersName,
                            LessorsName = propertyRegister.addLandlardDetails.LessorsName,
                            LessorsEmiratesId = propertyRegister.addLandlardDetails.LessorsEmiratesId,
                            Phone = propertyRegister.addLandlardDetails.PhoneNo,
                            Email = propertyRegister.addLandlardDetails.Email,
                            LicenseNo = propertyRegister.addLandlardDetails.LicenseNo,
                            LicensingAuthority = propertyRegister.addLandlardDetails.LicensingAuthority,
                            IsActive = true,
                            CreatedBy = "Admin",
                            CreatedAt = DateTime.UtcNow
                        };
                        await _dbContext.LandlordHistory.AddAsync(landlordhis);
                        await _dbContext.SaveChangesAsync();

                    await transaction.CommitAsync();



                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    throw new Exception(ex.Message);
                }
            }

        }
    }
}
