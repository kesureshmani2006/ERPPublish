using ERP.BusinessLogic.IBusinessLogics;
using ERP.BusinessLogic.IBusinessLogics.RealEstate;
using ERP.Models.DTOs.Requests;
using ERP.Models.DTOs.Requests.RealEstate;
using ERP.Models.DTOs.Responses.RealEstate;
using ERP.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace ERP.API.Controllers.RealEstate
{
    [Route("api/[controller]")]
    [ApiController]
    public class RealEstateController(IRealestateBl _realEstateBl) : ControllerBase
    {
        //plot details
        [HttpPost]
        [Route("AddPropertydetials")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddPropertydetials([FromBody] AddPropertyRequest AddProperty)
        {
            try
            {
                if (AddProperty != null)
                {
                long id=    await _realEstateBl.AddPropertydetialsAsync(AddProperty);
                    if (id == 0)
                        return BadRequest(new { id });
                   return Ok(new {  id });
                  //  return CreatedAtAction(nameof(GetPropertyById), new { id = AddProperty }, AddProperty);
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

        [HttpPost]
        [Route("AddLandlorddetialsdetials")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddLandlorddetialsAsync(AddLandlordRequest AddLandlord)
        {
            try
            {
                if (AddLandlord != null)
                {
                  long id=  await _realEstateBl.AddLandlorddetialsAsync(AddLandlord);
                    if (id == 0)
                        return BadRequest(new { id });
                    return Ok(new { id });
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



        [HttpPost]
        [Route("AddTenancyContractdetials")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddTenancyContractdetialsAsync(AddTenancyContractRequest tenancyContractRequest)
        {
            try
            {
                if (tenancyContractRequest != null)
                {
                    long id = await _realEstateBl.AddTenancyContractdetialsAsync(tenancyContractRequest);
                    if (id == 0)
                        return BadRequest(new { id });
                    return Ok(new { id });
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



        //[HttpPost]
        //[Route("AddContractdetials")]
        //[ProducesResponseType(StatusCodes.Status201Created)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //public async Task<IActionResult> AddContractdetialsAsync(AddContractRequest contractRequest)
           
        //{
        //    try
        //    {
        //        if (contractRequest != null)
        //        {
        //            long id = await _realEstateBl.AddContractdetialsAsync(contractRequest);
        //            if (id == 0)
        //                return BadRequest(new { id });
        //            return Ok(new { id });
        //        }
        //        else
        //        {
        //            return BadRequest();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw;
        //    }
        //}
       
        [HttpGet]
        [Route("GetAllProperty")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<RePropertyResponse>> GetAllProperty()
        {
            var entity = await _realEstateBl.GetAllProperty();
            if (entity == null) return NotFound();
            return Ok(entity);
        }
        [HttpGet]
        [Route("GetAllTenants")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<List<ReTenantsResponse>>> GetAllTenants()
        {
            var entity = await _realEstateBl.GetAllTenants();
            if (entity == null) return NotFound();
            return Ok(entity);
        }

       

        [HttpGet]
        [Route("GetPropertyById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PropertyDetailResponse>> GetPropertyById([FromQuery] long PropertyId)
        {
            var entity = await _realEstateBl.GetPropertyDetailsById(PropertyId);
            if (entity == null) return NotFound();
            return Ok(entity);
        }
        [HttpGet]
        [Route("GetLandlordDetailsById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ReProperty>> GetLandlordDetailsById([FromQuery] long LandlordId)
        {
            var entity = await _realEstateBl.GetLandlordDetailsById(LandlordId);
            if (entity == null) return NotFound();
            return Ok(entity);
        }

        [HttpPost]
        [Route("PropertyRegistration")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PropertyRegistration([FromBody] PropertyRegisterRequest propertyRegister)
        {
            try
            {
                if (propertyRegister != null)
                {
                    await _realEstateBl.PropertyRegistration(propertyRegister);
                    return CreatedAtAction(nameof(GetLandlordDetailsById), new { id = propertyRegister }, propertyRegister);
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


    }
}
