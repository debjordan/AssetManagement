using AssetManagement.Application.DTOs;
using AssetManagement.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AssetManagement.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EquipmentController : ControllerBase
    {
        private readonly IEquipmentAppService _equipmentAppService;

        public EquipmentController(IEquipmentAppService equipmentAppService)
        {
            _equipmentAppService = equipmentAppService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var equipments = await _equipmentAppService.GetAllAsync();
            return Ok(equipments);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                var equipment = await _equipmentAppService.GetByIdAsync(id);
                return Ok(equipment);
            }
            catch (EquipmentNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateEquipmentDto dto)
        {
            try
            {
                var equipmentId = await _equipmentAppService.CreateAsync(dto);
                return CreatedAtAction(nameof(GetById), new { id = equipmentId }, new { id = equipmentId });
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateEquipmentDto dto)
        {
            try
            {
                await _equipmentAppService.UpdateAsync(id, dto);
                return NoContent();
            }
            catch (EquipmentNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _equipmentAppService.DeleteAsync(id);
                return NoContent();
            }
            catch (EquipmentNotFoundException)
            {
                return NotFound();
            }
        }
    }
}
