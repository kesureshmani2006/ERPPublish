using ERP.BusinessLogic.IBusinessLogics;
using ERP.BusinessRepository.Services;
using ERP.Models.DTOs.Requests;
using ERP.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks.Dataflow;

namespace ERP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendorController(IVendorBl _vendorBl) : ControllerBase
    {

        [HttpPost]
        [Route("AddVendor")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddVendor([FromBody] AddVendorRequest vendor)
        {
            try
            {
                if (vendor != null)
                {
                    await _vendorBl.AddVendorAsync(vendor);
                    return CreatedAtAction(nameof(GetById), new { id = vendor }, vendor);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpGet]
        [Route("GetVendorById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Vendor>> GetById([FromQuery] string vendorId)
        {
            var entity = await _vendorBl.GetVendorDetailsById(vendorId);
            if (entity == null) return NotFound();
            return Ok(entity);
        }

        [HttpGet]
        [Route("GetAllVendors")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IEnumerable<Vendor>> GetAllVendors()
        {
            try
            {
                return await _vendorBl.GetAllVendors();
            }
            catch
            {
                throw;
            }
        }


        [HttpPut]
        [Route("UpdateVendor")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateVendor([FromBody] UpdateVendorRequest request)
        {
            try
            {
                if (request != null)
                {
                    await _vendorBl.UpdateVendorAsync(request);
                    return CreatedAtAction(nameof(GetById), new { id = request }, request);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpDelete]
        [Route("DeleteVendor")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteVendor([FromQuery] string vendorId)
        {
            try
            {
                if (vendorId != null)
                {
                    await _vendorBl.DeleteVendor(vendorId);
                }
                else
                {
                    return BadRequest();
                }
                return Ok();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpGet]
        [Route("SearchVendors")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> SearchVendord([FromQuery] string keyword)
        {
            try
            {
                if (!string.IsNullOrEmpty(keyword))
                {
                    List<Vendor> response = await _vendorBl.SearchVendor(keyword);
                    return Ok(response);
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
