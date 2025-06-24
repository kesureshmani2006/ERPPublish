using ERP.BusinessLogic.IBusinessLogics.RealEstate;
using ERP.Models.DTOs.Requests.RealEstate;
using ERP.Models.DTOs.Responses.RealEstate;
using ERP.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ERP.API.Controllers.RealEstate
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChequeController(IChequeBl chequeBl) : ControllerBase
    {
        [HttpPost]
        [Route("AddChequedetials")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddChequedetials([FromBody] List<AddChequeRequest> chequeRequest)
        {
            try
            {
                if (chequeRequest != null)
                {
                    long id = await chequeBl.AddchequedetialsAsync(chequeRequest);
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
		[Route("UpdatechequeDetails")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<ChequeResponse>> UpdatechequeDetails([FromBody] UpdateChequeRequest chequeRequest)
		{
			var entity = await chequeBl.UpdatechequeDetails(chequeRequest);
			if (entity == null) return NotFound();
			return Ok(entity);
		}


		[HttpGet]
        [Route("GetchequeDetailsById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ChequeResponse>> GetchequeDetailsById([FromQuery] long chequeId)
        {
            var entity = await chequeBl.GetchequeDetailsById(chequeId); 
            if (entity == null) return NotFound();
            return Ok(entity);
        }

        [HttpPost]
        [Route("GetAllchequesByConstractId")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<List<ChequeResponse>>> GetAllchequesByConstractId(ChequeRequest chequeRequest)
        {
            var entity = await chequeBl.GetAllchequesByConstractId(chequeRequest);
            if (entity == null) return NotFound();
            return Ok(entity);
        }
    }
}