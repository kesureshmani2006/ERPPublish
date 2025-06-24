using ERP.BusinessRepository.IBusinessRepository;
using ERP.BusinessRepository.Services;
using ERP.Database.ERPDbContext;
using ERP.Models.DTOs.Requests;
using ERP.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.BusinessRepository.BusinessRepository
{
    public class VendorBr : IVendorBr
    {
        private readonly ERPDBContext _dbContext;
        private readonly IGenericCRUDService<Vendor> _genericCRUDService;
        public VendorBr(ERPDBContext eRPDBContext, IGenericCRUDService<Vendor> genericCRUDService)
        {
            _dbContext = eRPDBContext;
            _genericCRUDService = genericCRUDService;
        }

        public async Task AddVendorAsync(AddVendorRequest request)
        {
            try
            {
                string newVendorId = await GenerateNextVendorIdAsync(_dbContext);

                Vendor vendor = new Vendor
                {
                    VendorId = newVendorId,
                    CompanyName = request.CompanyName,
                    ContactPerson = request.ContactPerson,
                    Address = request.Address,
                    State = request.State,
                    City = request.City,
                    Country = request.Country,
                    Status = 1,
                    Email = request.Email,
                    Phone = request.Phone,
                    CreatedBy = request.UserId
                };

                await _dbContext.Vendor.AddAsync(vendor);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public async Task<string> GenerateNextVendorIdAsync(ERPDBContext context)
        {
            var lastVendor = await context.Vendor
                .OrderByDescending(v => v.Id)
                .FirstOrDefaultAsync();

            if (lastVendor == null)
                return "V0001";

            var lastNumber = int.Parse(lastVendor.VendorId.Substring(1)); // remove "V"
            var nextNumber = lastNumber + 1;

            return $"V{nextNumber:D4}"; // D4 formats number with 4 digits
        }

        public async Task<Vendor> GetVendorDetailsById(string id)
        {
            try
            {
                Vendor vendor = new();
                if (id != null)
                {
                    var getVendor = await _dbContext.Vendor.Where(x => x.VendorId == id && x.Status == 1).FirstOrDefaultAsync();
                    return getVendor;
                    // await _genericCRUDService.GetByIdAsync(id);
                }
                else
                {
                    return vendor;
                }
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<Vendor>> GetAllVendors()
        {
            try
            {
                var vendorList = await _dbContext.Vendor.Where(x => x.Status == 1).ToListAsync();
                return vendorList;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task UpdateVendorAsync(UpdateVendorRequest request)
        {
            try
            {
                var vendor = await _dbContext.Vendor
                    .FirstOrDefaultAsync(v => v.VendorId == request.VendorId);

                if (vendor == null)
                    throw new Exception("Vendor not found.");

                // Only update fields that are provided (not null or empty)
                if (!string.IsNullOrWhiteSpace(request.CompanyName))
                    vendor.CompanyName = request.CompanyName;

                if (!string.IsNullOrWhiteSpace(request.ContactPerson))
                    vendor.ContactPerson = request.ContactPerson;

                if (!string.IsNullOrWhiteSpace(request.Address))
                    vendor.Address = request.Address;

                if (!string.IsNullOrWhiteSpace(request.State))
                    vendor.State = request.State;

                if (!string.IsNullOrWhiteSpace(request.City))
                    vendor.City = request.City;

                if (!string.IsNullOrWhiteSpace(request.Country))
                    vendor.Country = request.Country;

                if (!string.IsNullOrWhiteSpace(request.Email))
                    vendor.Email = request.Email;

                if (!string.IsNullOrWhiteSpace(request.Phone))
                    vendor.Phone = request.Phone;

                vendor.ModifiedBy = request.UserId;
                vendor.ModifiedAt = DateTime.UtcNow;
                _dbContext.Vendor.Update(vendor);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task DeleteVendor(string vendorId)
        {
            try
            {
                var vendor = await _dbContext.Vendor.Where(x => x.VendorId == vendorId).FirstOrDefaultAsync();
                if (vendor != null)
                {
                    vendor.Status = 2;
                }
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<Vendor>> SearchVendor(string searchableString)
        {
            try
            {
                var results = await (from vendor in _dbContext.Vendor
                                     where vendor.Status == 1 &&
                                           (vendor.VendorId.ToLower().Contains(searchableString.ToLower()) ||
                                            vendor.CompanyName.ToLower().Contains(searchableString.ToLower()))
                                     select vendor).ToListAsync();
                return results;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}
