using ERP.BusinessLogic.IBusinessLogics;
using ERP.BusinessRepository.IBusinessRepository;
using ERP.Models.DTOs.Requests;
using ERP.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.BusinessLogic.BusinessLogics
{
    public class VendorBl : IVendorBl
    {
        private readonly IVendorBr _vendorBr;
        public VendorBl(IVendorBr vendorBr)
        {
            _vendorBr = vendorBr;
        }
        public async Task AddVendorAsync(AddVendorRequest request)
        {
            await _vendorBr.AddVendorAsync(request);
        }

        public async Task<Vendor> GetVendorDetailsById(string id)
        {
            return await _vendorBr.GetVendorDetailsById(id);
        }
        public async Task<IEnumerable<Vendor>> GetAllVendors()
        {
            return await _vendorBr.GetAllVendors();
        }

        public async Task UpdateVendorAsync(UpdateVendorRequest request)
        {
            await _vendorBr.UpdateVendorAsync(request);
        }

        public async Task DeleteVendor(string vendorId)
        {
            await _vendorBr.DeleteVendor(vendorId);
        }
        public async Task<List<Vendor>> SearchVendor(string searchableString)
        {
            return await _vendorBr.SearchVendor(searchableString);
        }
    }
}
