using ERP.Models.DTOs.Requests;
using ERP.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.BusinessLogic.IBusinessLogics
{
    public interface IVendorBl
    {
        Task AddVendorAsync(AddVendorRequest request);
        Task<Vendor> GetVendorDetailsById(string id);
        Task<IEnumerable<Vendor>> GetAllVendors();
        Task UpdateVendorAsync(UpdateVendorRequest request);
        Task DeleteVendor(string vendorId);
        Task<List<Vendor>> SearchVendor(string searchableString);
    }
}
