using ERP.Models.DTOs.Requests;
using ERP.Models.DTOs.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.BusinessLogic.IBusinessLogics
{
    public interface IPurchaseRequestBl
    {
        Task<string> CreatePurchaseRequest(AddPurchaseRequest request);
        Task<GetPurchaseRequest> GetPurchaseRequestsAsync(string prNumber);
        Task<List<GetAllPurchaseRequest>> GetAllPurchaseRequestsAsync();
        Task<string> DeletePRAsync(string prNumber);
        Task<string> UpdatePR(AddPurchaseRequest request);
        Task<bool> ConvertToPO(string prNumber, string userId);
        Task<List<GetAllPurchaseOrders>> GetAllPurchaseOrdersAsync();
        Task<string> DeletePOAsync(string poNumber);
        Task<string> CreateInvoice(CreateInvoiceRequest createInvoiceRequest);
        Task<string> UpdateReceivedQuantity(UpdateReceivedQuantity updateReceivedQuantity);
        Task<GetPOResponse> GetPurchaseOrderAsync(string poNumber);
        Task<GetInvoiceResponse> GetInvoice(string ponumber);
        Task<List<GetInvoiceListResponse>> GetInvoicesByVendorAsync(string vendorId, int statusFilter);
        Task<bool> ClearInvoiceAsync(ClearInvoiceRequest invoiceRequest);
    }
}
