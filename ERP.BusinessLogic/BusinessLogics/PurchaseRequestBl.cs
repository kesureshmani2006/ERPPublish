using ERP.BusinessLogic.IBusinessLogics;
using ERP.BusinessRepository.IBusinessRepository;
using ERP.Models.DTOs.Requests;
using ERP.Models.DTOs.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.BusinessLogic.BusinessLogics
{
    public class PurchaseRequestBl : IPurchaseRequestBl
    {
        private readonly IPurchaseRequestBr _purchaseRequestBr;
        public PurchaseRequestBl(IPurchaseRequestBr purchaseRequestBr)
        {
            _purchaseRequestBr = purchaseRequestBr;
        }

        public async Task<string> CreatePurchaseRequest(AddPurchaseRequest request)
        {
            return await _purchaseRequestBr.CreatePurchaseRequest(request);
        }

        public async Task<GetPurchaseRequest> GetPurchaseRequestsAsync(string prNumber)
        {
            return await _purchaseRequestBr.GetPurchaseRequestsAsync(prNumber);
        }
        public async Task<List<GetAllPurchaseRequest>> GetAllPurchaseRequestsAsync()
        {
            return await _purchaseRequestBr.GetAllPurchaseRequestsAsync();
        }
        public async Task<string> DeletePRAsync(string prNumber)
        {
            return await _purchaseRequestBr.DeletePRAsync(prNumber);
        }

        public async Task<string> UpdatePR(AddPurchaseRequest request)
        {
            return await _purchaseRequestBr.UpdatePR(request);
        }

        public async Task<bool> ConvertToPO(string prNumber, string userId)
        {
            return await _purchaseRequestBr.ConvertToPO(prNumber,userId);
        }

        public async Task<List<GetAllPurchaseOrders>> GetAllPurchaseOrdersAsync()
        {
            return await _purchaseRequestBr.GetAllPurchaseOrdersAsync();
        }
        public async Task<string> DeletePOAsync(string poNumber)
        {
            return await _purchaseRequestBr.DeletePOAsync(poNumber);
        }

        public async Task<string> CreateInvoice(CreateInvoiceRequest createInvoiceRequest)
        {
            return await _purchaseRequestBr.CreateInvoice(createInvoiceRequest);
        }
        public async Task<string> UpdateReceivedQuantity(UpdateReceivedQuantity updateReceivedQuantity)
        {
            return await _purchaseRequestBr.UpdateReceivedQuantity(updateReceivedQuantity);
        }
        public async Task<GetPOResponse> GetPurchaseOrderAsync(string poNumber)
        {
            return await _purchaseRequestBr.GetPurchaseOrderAsync(poNumber);
        }
        public async Task<GetInvoiceResponse> GetInvoice(string ponumber)
        {
            return await _purchaseRequestBr.GetInvoice(ponumber);
        }
        public async Task<List<GetInvoiceListResponse>> GetInvoicesByVendorAsync(string vendorId, int statusFilter)
        {
            return await _purchaseRequestBr.GetInvoicesByVendorAsync(vendorId, statusFilter);
        }
        public async Task<bool> ClearInvoiceAsync(ClearInvoiceRequest invoiceRequest)
        {
            return await _purchaseRequestBr.ClearInvoiceAsync(invoiceRequest);
        }
    }
}
