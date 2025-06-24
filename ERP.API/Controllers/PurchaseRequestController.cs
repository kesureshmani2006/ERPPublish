using ERP.BusinessLogic.IBusinessLogics;
using ERP.Models.DTOs.Requests;
using ERP.Models.DTOs.Responses;
using ERP.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace ERP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseRequestController(IPurchaseRequestBl _purchaseRequestBl) : ControllerBase
    {

        [HttpPost]
        [Route("CreatePurchaseRequest")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreatePurchaseRequest([FromBody] AddPurchaseRequest request)
        {
            try
            {
                if (request != null)
                {
                    var response = await _purchaseRequestBl.CreatePurchaseRequest(request);
                    return CreatedAtAction(nameof(GetPurchaseRequestByPRNumber), new { id = request }, request);
                }
                return BadRequest();
            }
            catch
            {
                throw;
            }
        }

        [HttpGet]
        [Route("GetPRByPRNumber")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetPurchaseRequestByPRNumber([FromQuery] string pRNumber)
        {
            try
            {
                if (!string.IsNullOrEmpty(pRNumber))
                {
                    GetPurchaseRequest purchaseRequest = await _purchaseRequestBl.GetPurchaseRequestsAsync(pRNumber);
                    return Ok(purchaseRequest);
                }
                return BadRequest();
            }
            catch
            {
                throw;
            }
        }

        [HttpGet]
        [Route("GetAllPRs")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllPurchaseRequestsAsync()
        {
            try
            {
                List<GetAllPurchaseRequest> purchaseRequest = await _purchaseRequestBl.GetAllPurchaseRequestsAsync();
                return Ok(purchaseRequest);
            }
            catch
            {
                throw;
            }
        }

        [HttpDelete]
        [Route("DeletePR")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeletePRAsync([FromQuery] string prNumber)
        {
            try
            {
                if (!string.IsNullOrEmpty(prNumber))
                {
                    string response = await _purchaseRequestBl.DeletePRAsync(prNumber);
                    return Ok(response);
                }
                return BadRequest();
            }
            catch
            {
                throw;
            }
        }
        [HttpPut]
        [Route("UpdatePR")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdatePR([FromBody] AddPurchaseRequest request)
        {
            try
            {
                var response = await _purchaseRequestBl.UpdatePR(request);
                return Ok(response);
            }
            catch
            {
                throw;
            }
        }

        [HttpPut]
        [Route("ConvertToPO")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ConvertToPO([FromQuery] string prNumber,string userId)
        {
            try
            {
                var response = await _purchaseRequestBl.ConvertToPO(prNumber, userId);
                return Ok(response);
            }
            catch
            {
                throw;
            }
        }

        [HttpGet]
        [Route("GetAllPOs")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllPurchaseOrdersAsync()
        {
            try
            {
                List<GetAllPurchaseOrders> purchaseOrders = await _purchaseRequestBl.GetAllPurchaseOrdersAsync();
                return Ok(purchaseOrders);
            }
            catch
            {
                throw;
            }
        }

        [HttpDelete]
        [Route("DeletePO")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeletePOAsync([FromQuery] string poNumber)
        {
            try
            {
                if (!string.IsNullOrEmpty(poNumber))
                {
                    string response = await _purchaseRequestBl.DeletePOAsync(poNumber);
                    return Ok(response);
                }
                return BadRequest();
            }
            catch
            {
                throw;
            }
        }

        [HttpPost]
        [Route("CreateInvoice")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateInvoice([FromBody] CreateInvoiceRequest request)
        {
            try
            {
                if (request != null)
                {
                    var response = await _purchaseRequestBl.CreateInvoice(request);
                    return Ok(response);
                }
                return BadRequest();
            }
            catch
            {
                throw;
            }
        }

        [HttpPut]
        [Route("UpdateReceivedQuantity")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateReceivedQuantity([FromBody] UpdateReceivedQuantity request)
        {
            try
            {
                var response = await _purchaseRequestBl.UpdateReceivedQuantity(request);
                return Ok(response);
            }
            catch
            {
                throw;
            }
        }

        [HttpGet]
        [Route("GetPOByPONumber")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetPurchaseOrderByPONumber([FromQuery] string pONumber)
        {
            try
            {
                if (!string.IsNullOrEmpty(pONumber))
                {
                    GetPOResponse pOResponse = await _purchaseRequestBl.GetPurchaseOrderAsync(pONumber);
                    return Ok(pOResponse);
                }
                return BadRequest();
            }
            catch
            {
                throw;
            }
        }

        [HttpGet]
        [Route("GetInvoiceByPONumber")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetInvoiceByPONumber([FromQuery] string pONumber)
        {
            try
            {
                if (!string.IsNullOrEmpty(pONumber))
                {
                    GetInvoiceResponse pOResponse = await _purchaseRequestBl.GetInvoice(pONumber);
                    return Ok(pOResponse);
                }
                return BadRequest();
            }
            catch
            {
                throw;
            }
        }

        [HttpGet]
        [Route("GetInvoiceByVendorId")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetInvoiceByVendor([FromQuery] string vendorId, int statusFilter)
        {
            try
            {
                    List<GetInvoiceListResponse> response = await _purchaseRequestBl.GetInvoicesByVendorAsync(vendorId,statusFilter);
                    return Ok(response);
            }
            catch
            {
                throw;
            }
        }

        [HttpPut]
        [Route("ClearInvoice")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ClearInvoice([FromBody] ClearInvoiceRequest invoiceRequest)
        {
            try
            {
                bool response = await _purchaseRequestBl.ClearInvoiceAsync(invoiceRequest);
                return Ok(response);
            }
            catch
            {
                throw;
            }
        }

        //[HttpGet]
        //[Route("GetInvoiceByInvoiceId")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //public async Task<IActionResult> GetInvoiceByInvoiceId([FromQuery] string invoiceId)
        //{
        //    try
        //    {
        //        List<GetInvoiceListResponse> response = await _purchaseRequestBl.GetInvoiceByInvoiceId(invoiceId);
        //        return Ok(response);
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //}
    }
}
