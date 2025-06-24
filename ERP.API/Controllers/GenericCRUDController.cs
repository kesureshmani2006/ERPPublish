using ERP.BusinessRepository.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ERP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenericCRUDController<T> : ControllerBase where T : class
    {
        private readonly IGenericCRUDService<T> _repository;

        public GenericCRUDController(IGenericCRUDService<T> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<T>>> GetAll()
        {
            return Ok(await _repository.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<T>> GetById(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null) return NotFound();
            return Ok(entity);
        }

        [HttpPost]
        public async Task<ActionResult> Add([FromBody] T entity)
        {
            await _repository.AddAsync(entity);
            return CreatedAtAction(nameof(GetById), new { id = entity }, entity);
        }

        [HttpPut]
        public async Task<ActionResult> Update([FromBody] T entity)
        {
            await _repository.UpdateAsync(entity);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _repository.DeleteAsync(id);
            return NoContent();
        }
    }
}
