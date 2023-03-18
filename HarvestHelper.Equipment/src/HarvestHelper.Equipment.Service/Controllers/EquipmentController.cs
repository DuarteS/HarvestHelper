using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HarvestHelper.Common;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using HarvestHelper.Equipment.Service.Dtos;
using HarvestHelper.Equipment.Service.Entities;
using HarvestHelper.Equipment.Contracts;

namespace HarvestHelper.Equipment.Service.Controllers
{
    [ApiController]
    [Route("equipment")]
    public class EquipmentController : ControllerBase
    {
        private readonly IRepository<EquipmentItem> equipmentRepository;
        private readonly IPublishEndpoint publishEndpoint;

        public EquipmentController(IRepository<EquipmentItem> equipmentRepository, IPublishEndpoint publishEndpoint)
        {
            this.equipmentRepository = equipmentRepository;
            this.publishEndpoint = publishEndpoint;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EquipmentDto>>> GetAsync()
        {
            var items = (await equipmentRepository.GetAllAsync())
                        .Select(item => item.AsDto());

            return Ok(items);
        }

        // GET /items/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<EquipmentDto>> GetByIdAsync(Guid id)
        {
            var item = await equipmentRepository.GetAsync(id);

            if (item == null)
            {
                return NotFound();
            }

            return item.AsDto();
        }

        // POST /items
        [HttpPost]
        public async Task<ActionResult<EquipmentDto>> PostAsync(CreateEquipmentDto createEquipmentDto)
        {
            var equipment = new EquipmentItem
            {
                Name = createEquipmentDto.Name,
            };

            await equipmentRepository.CreateAsync(equipment);

            await publishEndpoint.Publish(new EquipmentItemCreated(equipment.Id, equipment.Name));

            return CreatedAtAction(nameof(GetByIdAsync), new { id = equipment.Id }, equipment);
        }

        // PUT /items/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(Guid id, UpdateEquipmentDto updateEquipmentDto)
        {
            var existingEquipment = await equipmentRepository.GetAsync(id);

            if (existingEquipment == null)
            {
                return NotFound();
            }

            existingEquipment.Name = updateEquipmentDto.Name;

            await equipmentRepository.UpdateAsync(existingEquipment);

            await publishEndpoint.Publish(new EquipmentItemUpdated(existingEquipment.Id, existingEquipment.Name));

            return NoContent();
        }

        // DELETE /items/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            var equipment = await equipmentRepository.GetAsync(id);

            if (equipment == null)
            {
                return NotFound();
            }

            await equipmentRepository.RemoveAsync(equipment.Id);

            await publishEndpoint.Publish(new EquipmentItemDeleted(id));

            return NoContent();
        }
    }
}