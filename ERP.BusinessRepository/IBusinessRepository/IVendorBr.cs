using ERP.Models.DTOs.Requests;
using ERP.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.BusinessRepository.IBusinessRepository
{
    public interface IVendorBr
    {
        Task AddVendorAsync(AddVendorRequest request);
        Task<Vendor> GetVendorDetailsById(string id);
        Task<IEnumerable<Vendor>> GetAllVendors();
        Task UpdateVendorAsync(UpdateVendorRequest request);
        Task DeleteVendor(string vendorId);
        Task<List<Vendor>> SearchVendor(string searchableString);
    }
}
