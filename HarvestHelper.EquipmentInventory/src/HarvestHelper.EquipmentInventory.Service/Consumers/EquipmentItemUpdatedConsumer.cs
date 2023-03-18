using System.Threading.Tasks;
using MassTransit;
using HarvestHelper.Equipment.Contracts;
using HarvestHelper.Common;
using HarvestHelper.EquipmentInventory.Service.Entities;

namespace Play.Inventory.Service.Consumers
{
    public class EquipmentItemUpdatedConsumer : IConsumer<EquipmentItemUpdated>
    {
        private readonly IRepository<EquipmentItem> repository;

        public EquipmentItemUpdatedConsumer(IRepository<EquipmentItem> repository)
        {
            this.repository = repository;
        }

        public async Task Consume(ConsumeContext<EquipmentItemUpdated> context)
        {
            var message = context.Message;

            var equipment = await repository.GetAsync(message.ItemId);

            if (equipment == null)
            {
                equipment = new EquipmentItem
                {
                    Id = message.ItemId,
                    Name = message.Name,
                };

                await repository.CreateAsync(equipment);
            }
            else
            {
                equipment.Name = message.Name;

                await repository.UpdateAsync(equipment);
            }
        }
    }
}