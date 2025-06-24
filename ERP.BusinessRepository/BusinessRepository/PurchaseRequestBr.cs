using Azure.Core;
using ERP.BusinessRepository.IBusinessRepository;
using ERP.Database.ERPDbContext;
using ERP.Models.DTOs.Requests;
using ERP.Models.DTOs.Responses;
using ERP.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.BusinessRepository.BusinessRepository
{
    public class PurchaseRequestBr : IPurchaseRequestBr
    {
        private readonly ERPDBContext _eRPDBContext;
        public PurchaseRequestBr(ERPDBContext eRPDBContext)
        {
            _eRPDBContext = eRPDBContext;
        }

        public async Task<string> CreatePurchaseRequest(AddPurchaseRequest request)
        {
            using var transaction = await _eRPDBContext.Database.BeginTransactionAsync();
            {
                try
                {
                    if (request != null)
                    {
                        var prNumber = await GenerateNextPRNumberAsync(_eRPDBContext);
                        var vendor = await _eRPDBContext.Vendor.Where(x => x.VendorId == request.VendorId).FirstOrDefaultAsync();
                        PurchaseRequest purchaseRequest = new PurchaseRequest()
                        {
                            PRNumber = prNumber,
                            VendorId = vendor.Id,
                            SubTotal = request.SubTotal,
                            Status = 1,
                            CreatedBy = request.UserId,
                            CreatedAt = request.PRDate
                        };
                        await _eRPDBContext.PurchaseRequests.AddAsync(purchaseRequest);
                        await _eRPDBContext.SaveChangesAsync();
                        foreach (var items in request.PrItems)
                        {
                            PurchaseRequestItems purchaseRequestItems = new PurchaseRequestItems()
                            {
                                PurchaseRequestId = purchaseRequest.Id,
                                ProductName = items.ProductName,
                                UOM = items.UOM,
                                Quantity = items.Quantity,
                                Rate = items.Rate,
                                Amount = items.Amount
                            };
                            await _eRPDBContext.PurchaseRequestItems.AddRangeAsync(purchaseRequestItems);

                        }
                        await _eRPDBContext.SaveChangesAsync();
                        await transaction.CommitAsync();
                    }
                    return "Purchase reqest created successfully";
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    throw;
                }
            }
        }

        public async Task<string> GenerateNextPRNumberAsync(ERPDBContext context)
        {
            var lastVendor = await context.PurchaseRequests
                .OrderByDescending(v => v.Id)
                .FirstOrDefaultAsync();

            if (lastVendor == null)
                return "PR0001";

            var lastNumber = int.Parse(lastVendor.PRNumber.Substring(2)); // remove "V"
            var nextNumber = lastNumber + 1;

            return $"PR{nextNumber:D4}"; // D4 formats number with 4 digits
        }

        public async Task<GetPurchaseRequest> GetPurchaseRequestsAsync(string prNumber)
        {
            try
            {
                var result = await (
                from pr in _eRPDBContext.PurchaseRequests
                where pr.PRNumber == prNumber
                join item in _eRPDBContext.PurchaseRequestItems
                    on pr.Id equals item.PurchaseRequestId into prItems
                join vendor in _eRPDBContext.Vendor
                on pr.VendorId equals vendor.Id
                select new GetPurchaseRequest
                {
                    PRNumber = pr.PRNumber,
                    PRDate = (DateTime)pr.CreatedAt,
                    VendorId = vendor.VendorId,
                    VendorName = vendor.CompanyName,
                    //POId = pr.POId,
                    //POConvertedDate = pr.POConvertedDate,
                    IsPOConverted = pr.IsPOConverted,
                    SubTotal = pr.SubTotal,
                    PRItems = prItems.Select(i => new PRItemsList
                    {
                        Id = i.Id,
                        ProductName = i.ProductName,
                        Quantity = i.Quantity,
                        UOM = i.UOM,
                        Rate = i.Rate,
                        //ReceivedQuantity = i.ReceivedQuantity,
                        Amount = i.Amount
                    }).ToList()
                }
            ).FirstOrDefaultAsync();

                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<List<GetAllPurchaseRequest>> GetAllPurchaseRequestsAsync()
        {
            try
            {
                var results = await (from pr in _eRPDBContext.PurchaseRequests
                                     join vendor in _eRPDBContext.Vendor
                                     on pr.VendorId equals vendor.Id
                                     select new GetAllPurchaseRequest
                                     {
                                         VendorName = vendor.CompanyName,
                                         VerndorId = vendor.VendorId,
                                         PRNumber = pr.PRNumber,
                                         PRDate = (DateTime)pr.CreatedAt,
                                         PRTotalAmount = pr.SubTotal,
                                         IsPOConverted = pr.IsPOConverted
                                     }).ToListAsync();
                return results;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<string> DeletePRAsync(string prNumber)
        {
            try
            {
                var purchaseRequests = await _eRPDBContext.PurchaseRequests
                                      .Include(p => p.PurchaseRequestItems)
                                      .FirstOrDefaultAsync(p => p.PRNumber == prNumber);
                if (purchaseRequests != null)
                {
                    _eRPDBContext.PurchaseRequests.Remove(purchaseRequests);
                    await _eRPDBContext.SaveChangesAsync();
                }
                return "PR deleted successfully!!!";

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<string> UpdatePR(AddPurchaseRequest request)
        {
            try
            {
                // Fetch the existing purchase request (assumes you identify it by UserId or another key)
                var existingPR = await _eRPDBContext.PurchaseRequests
                    .Include(pr => pr.PurchaseRequestItems)
                    .FirstOrDefaultAsync(pr => pr.PRNumber == request.PRNumber); // change this to your actual identifier

                // Update purchase request fields
                existingPR.SubTotal = request.SubTotal;

                // Handle PR Items
                foreach (var item in request.PrItems)
                {
                    var existingItem = existingPR.PurchaseRequestItems.FirstOrDefault(i => i.Id == item.Id);

                    if (item.IsDeleted)
                    {
                        // Delete the item if it exists
                        if (existingItem != null)
                        {
                            _eRPDBContext.PurchaseRequestItems.Remove(existingItem);
                        }
                    }
                    else
                    {
                        if (existingItem != null)
                        {
                            // Update the existing item
                            existingItem.Quantity = item.Quantity;
                            existingItem.Rate = item.Rate;
                            existingItem.Amount = item.Amount;
                            existingItem.UOM = item.UOM;
                        }
                        else
                        {
                            // Add new item
                            existingPR.PurchaseRequestItems.Add(new PurchaseRequestItems
                            {
                                ProductName = item.ProductName,
                                Quantity = item.Quantity,
                                Rate = item.Rate,
                                Amount = item.Amount,
                                UOM = item.UOM,
                            });
                        }
                    }
                }
                await _eRPDBContext.SaveChangesAsync();
                return "PR updated successfully";
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> ConvertToPO(string prNumber, string userId)
        {
            try
            {
                if (string.IsNullOrEmpty(prNumber))
                    return false;

                // Fetch Purchase Request and Items
                var purchaseRequest = await _eRPDBContext.PurchaseRequests
                    .Include(pr => pr.PurchaseRequestItems) // Include the related items
                    .FirstOrDefaultAsync(pr => pr.PRNumber == prNumber);

                if (purchaseRequest == null)
                    return false;

                // Generate PO Number
                string poNumber = await GenerateNextPONumberAsync(_eRPDBContext);
                var purchaseOrder = new PurchaseOrder
                {
                    PONumber = poNumber,
                    PRId = purchaseRequest.Id,
                    POConvertedDate = DateTime.UtcNow,
                    CreatedBy = userId,
                    CreatedAt = DateTime.UtcNow,
                    PurchaseOrderItems = new List<PurchaseOrderItems>()
                };
                // Mark Purchase Request as Converted
                purchaseRequest.IsPOConverted = true;

                // Map Purchase Request Items to Purchase Order Items
                foreach (var prItem in purchaseRequest.PurchaseRequestItems)
                {
                    var poItem = new PurchaseOrderItems
                    {
                         PurchaseRequestItemId = prItem.Id,
                         ReceivedQuantity = 0
                        // Other fields mapping if required
                    };

                    purchaseOrder.PurchaseOrderItems.Add(poItem);
                }
                _eRPDBContext.PurchaseOrder.Add(purchaseOrder);
                await _eRPDBContext.SaveChangesAsync();

                return true;
            }
            catch
            {
                throw;
            }
        }
        public async Task<List<GetAllPurchaseOrders>> GetAllPurchaseOrdersAsync()
        {
            try
            {
                var results = await (from po in _eRPDBContext.PurchaseOrder
                                     join pr in _eRPDBContext.PurchaseRequests
                                     on po.PRId equals pr.Id
                                     join vendor in _eRPDBContext.Vendor
                                     on pr.VendorId equals vendor.Id
                                     select new GetAllPurchaseOrders
                                     {
                                         VendorName = vendor.CompanyName,
                                         VerndorId = vendor.VendorId,
                                         PRNumber = pr.PRNumber,
                                         PONumber = po.PONumber,
                                         PODate = po.POConvertedDate,
                                         POTotalAmount = pr.SubTotal, 
                                         IsPOConverted = true // Always true if it's already in PurchaseOrders
                                     }).ToListAsync();
                return results;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<GetPOResponse> GetPurchaseOrderAsync(string poNumber)
        {
            try
            {
                var result = await (
                    from po in _eRPDBContext.PurchaseOrder
                    join pr in _eRPDBContext.PurchaseRequests
                        on po.PRId equals pr.Id
                    join vendor in _eRPDBContext.Vendor
                        on pr.VendorId equals vendor.Id
                    where po.PONumber == poNumber && pr.IsPOConverted == true
                    select new GetPOResponse
                    {
                        PONumber = po.PONumber,
                        PODate = po.POConvertedDate,
                        VendorId = vendor.VendorId,
                        VendorName = vendor.CompanyName,
                        PRNumber = pr.PRNumber,
                        SubTotal = pr.SubTotal,
                        POItems = (
                            from pri in _eRPDBContext.PurchaseRequestItems
                            join poi in _eRPDBContext.PurchaseOrderItems
                                on pri.Id equals poi.PurchaseRequestItemId
                            where pri.PurchaseRequestId == pr.Id && poi.POId == po.Id
                            select new POItemsList
                            {
                                Id = poi.Id,
                                ProductName = pri.ProductName,
                                UOM = pri.UOM,
                                Rate = pri.Rate,
                                Quantity = pri.Quantity,
                                Amount = pri.Amount,
                                ReceivedQuantity = poi.ReceivedQuantity,

                                InvoicedQuantity = (
                                    (from poi in _eRPDBContext.PurchaseOrderItems
                                     join ii in _eRPDBContext.InvoiceItem
                                        on poi.Id equals ii.PurchaseOrderItemId
                                     join inv in _eRPDBContext.Invoice
                                        on ii.InvoiceId equals inv.Id
                                     where poi.PurchaseRequestItemId == pri.Id
                                           && inv.PurchaseOrderId == po.Id
                                     select (int?)ii.InvoiceQuantity
                                    ).Sum() ?? 0
                                ),
                                InvoicedAmount = (
                            (from poi in _eRPDBContext.PurchaseOrderItems
                             join ii in _eRPDBContext.InvoiceItem
                                on poi.Id equals ii.PurchaseOrderItemId
                             join inv in _eRPDBContext.Invoice
                                on ii.InvoiceId equals inv.Id
                             where poi.PurchaseRequestItemId == pri.Id
                                   && inv.PurchaseOrderId == po.Id
                             select (decimal?)ii.TotalAmount
                            ).Sum() ?? 0
                            ),
                            }
                        ).ToList()
                    }
                ).FirstOrDefaultAsync();

                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        private async Task<string> GenerateNextPONumberAsync(ERPDBContext context)
        {
            var lastVendor = await context.PurchaseOrder
                .OrderByDescending(v => v.Id)
                .FirstOrDefaultAsync();

            if (lastVendor == null)
                return "PO0001";

            var lastNumber = int.Parse(lastVendor.PONumber.Substring(2)); // remove "PO"
            var nextNumber = lastNumber + 1;

            return $"PO{nextNumber:D4}"; // D4 formats number with 4 digits
        }

        public async Task<string> DeletePOAsync(string poNumber)
        {
            try
            {
                var purchaseOrder = await _eRPDBContext.PurchaseOrder
                    .Include(po => po.PurchaseOrderItems)
                    .FirstOrDefaultAsync(po => po.PONumber == poNumber);

                if (purchaseOrder != null)
                {
                    _eRPDBContext.PurchaseOrder.Remove(purchaseOrder);
                    await _eRPDBContext.SaveChangesAsync();
                    return "PO deleted successfully!!!";
                }

                return "PO not found!";
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        private async Task<string> GenerateNextInvoiceNumberAsync(ERPDBContext context)
        {
            var lastVendor = await context.Invoice
                .OrderByDescending(v => v.Id)
                .FirstOrDefaultAsync();

            if (lastVendor == null)
                return "I0001";

            var lastNumber = int.Parse(lastVendor.InvoiceNumber.Substring(1)); // remove "I"
            var nextNumber = lastNumber + 1;

            return $"I{nextNumber:D4}"; // D4 formats number with 4 digits
        }

        public async Task<string> CreateInvoice(CreateInvoiceRequest createInvoiceRequest)
        {
            using var transaction = await _eRPDBContext.Database.BeginTransactionAsync();
            {
                try
                {
                    if (createInvoiceRequest != null)
                    {
                        var purchaseOrder = await _eRPDBContext.PurchaseOrder.Where(x => x.PONumber == createInvoiceRequest.PONumber).FirstOrDefaultAsync();
                        var invoiceNumber = await GenerateNextInvoiceNumberAsync(_eRPDBContext);
                        Invoice invoice = new Invoice()
                        {
                            InvoiceNumber = invoiceNumber,
                            PurchaseOrderId = purchaseOrder.Id,
                            InvoiceDate = createInvoiceRequest.InvoiceDate,
                            TotalAmount = createInvoiceRequest.InvoiceTotalAmount,
                            PaymentTerms = createInvoiceRequest.PaymentTerms,
                            Status = 3,
                            CreatedBy = createInvoiceRequest.UserId,
                            CreatedAt = DateTime.UtcNow,
                        };
                        await _eRPDBContext.Invoice.AddAsync(invoice);
                        await _eRPDBContext.SaveChangesAsync();
                        foreach (var items in createInvoiceRequest.Items)
                        {
                            if (!_eRPDBContext.PurchaseOrderItems.Any(x => x.Id == items.PurchaseOrderItemId))
                            {
                                throw new Exception("Invalid PurchaseOrderItemId: " + items.PurchaseOrderItemId);
                            }
                            InvoiceItem invoiceItems = new InvoiceItem()
                            {
                                PurchaseOrderItemId = items.PurchaseOrderItemId,
                                InvoiceId = invoice.Id,
                                InvoiceQuantity = items.InvoiceQuantity,
                                TotalAmount = items.TotalAmount

                            };
                            await _eRPDBContext.InvoiceItem.AddRangeAsync(invoiceItems);

                        }
                        await _eRPDBContext.SaveChangesAsync();
                        await transaction.CommitAsync();
                    }
                    return "Invoice created successfully";
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    throw;
                }
            }
        }

        public async Task<string> UpdateReceivedQuantity(UpdateReceivedQuantity updateReceivedQuantity)
        {
            try
            {
                var poitems = await (from po in _eRPDBContext.PurchaseOrder
                                     join poi in _eRPDBContext.PurchaseOrderItems
                                     on po.Id equals poi.POId
                                     where po.PONumber == updateReceivedQuantity.PONumber
                                     select poi).ToListAsync();
                foreach (var item in poitems)
                {
                    var receivedItem = updateReceivedQuantity.ReceivedQuantityLists
                                       .FirstOrDefault(r => r.ProductId == item.Id);

                    if (receivedItem != null)
                    {
                        item.ReceivedQuantity = receivedItem.Quantity;
                    }
                }
                await _eRPDBContext.SaveChangesAsync();
                return "updated";

            }
            catch
            {
                throw;
            }
        }

        public async Task<GetInvoiceResponse> GetInvoice(string poNumber)
        {
            try
            {
                // Step 1: Find the Purchase Order
                var purchaseOrder = await _eRPDBContext.PurchaseOrder
                    .FirstOrDefaultAsync(po => po.PONumber == poNumber);

                if (purchaseOrder == null)
                    return null;

                // Step 2: Find the Invoice based on PurchaseOrder
                var invoice = await _eRPDBContext.Invoice
                    .FirstOrDefaultAsync(inv => inv.PurchaseOrderId == purchaseOrder.Id);

                if (invoice == null)
                    return null;

                // Step 3: Find Invoice Items
                var invoiceItems = await (
                    from invItem in _eRPDBContext.InvoiceItem
                    join poItem in _eRPDBContext.PurchaseOrderItems
                        on invItem.PurchaseOrderItemId equals poItem.Id
                    join po in _eRPDBContext.PurchaseOrder
                        on poItem.POId equals po.Id
                    join pr in _eRPDBContext.PurchaseRequests
                        on po.PRId equals pr.Id
                    join pri in _eRPDBContext.PurchaseRequestItems
                        on poItem.PurchaseRequestItemId equals pri.Id
                    where invItem.InvoiceId == invoice.Id
                    select new GetInvoiceItems
                    {
                        Id = invItem.Id,
                        POItemId = poItem.Id,
                        ProductName = pri.ProductName,
                        OrderedQuantity = pri.Quantity,
                        InvoicedQuantity = invItem.InvoiceQuantity,
                        Amount = invItem.TotalAmount,
                        UOM = pri.UOM,
                        Rate = pri.Rate,
                        ReceivedQuantity = poItem.ReceivedQuantity
                    }).ToListAsync();

                // Step 4: Prepare the final Invoice Response
                var response = new GetInvoiceResponse
                {
                    PONumber = poNumber,
                    Items = invoiceItems
                };

                return response;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<GetInvoiceListResponse>> GetInvoicesByVendorAsync(string vendorId, int statusFilter)
        {
            try
            {
                var query = from inv in _eRPDBContext.Invoice
                            join po in _eRPDBContext.PurchaseOrder
                                on inv.PurchaseOrderId equals po.Id
                            join pr in _eRPDBContext.PurchaseRequests
                                on po.PRId equals pr.Id
                            join ven in _eRPDBContext.Vendor
                                on pr.VendorId equals ven.Id
                            where ven.VendorId == vendorId
                            select new
                            {
                                InvoiceNo = inv.InvoiceNumber,
                                CompanyName = ven.CompanyName,
                                InvoiceAmount = inv.TotalAmount,
                                PaidAmount = inv.PaidAmount,
                                Country = ven.Country,
                                StatusCode = inv.Status
                            };

                // Apply filter before projecting to response
                if (statusFilter == 3) // Only Open
                {
                    query = query.Where(x => x.StatusCode == 3);
                }
                else if (statusFilter == 4) // Open + Cleared
                {
                    query = query.Where(x => x.StatusCode == 3 || x.StatusCode == 4);
                }

                var result = await query
                    .Select(x => new GetInvoiceListResponse
                    {
                        InvoiceNo = x.InvoiceNo,
                        CompanyName = x.CompanyName,
                        InvoiceAmount = x.InvoiceAmount,
                        PaidAmount = x.PaidAmount ?? 0,
                        Country = x.Country,
                        Status = x.StatusCode == 3 ? "Open" : x.StatusCode == 4 ? "Cleared" : "NIL"
                    })
                    .ToListAsync();

                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<bool> ClearInvoiceAsync(ClearInvoiceRequest invoiceRequest)
        {
            try
            {
                foreach(var items in invoiceRequest.InvoiceClearingItems)
                {
                    Invoice? invoice = await _eRPDBContext.Invoice.FirstOrDefaultAsync(x => x.InvoiceNumber == items.InvoiceId);

                    if (invoice == null)
                    {
                        return false; // Not found
                    }

                    invoice.Status = 4; // Cleared
                    invoice.InvoiceClearedDate = invoiceRequest.ClearedDate;
                    invoice.InvoiceClearedBy = invoiceRequest.ClearedBy;
                    invoice.PaidAmount = invoice.PaidAmount + items.PaymentAmount;
                    _eRPDBContext.Invoice.UpdateRange(invoice);
                }
                
                await _eRPDBContext.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}
