using System.Threading.Tasks;
using MassTransit;
using HarvestHelper.Equipment.Contracts;
using HarvestHelper.Common;
using HarvestHelper.EquipmentInventory.Service.Entities;

namespace HarvestHelper.EquipmentInventory.Service.Consumers
{
    public class EquipmentItemCreatedConsumer : IConsumer<EquipmentItemCreated>
    {
        private readonly IRepository<EquipmentItem> repository;

        public EquipmentItemCreatedConsumer(IRepository<EquipmentItem> repository)
        {
            this.repository = repository;
        }

        public async Task Consume(ConsumeContext<EquipmentItemCreated> context)
        {
            var message = context.Message;

            var equipment = await repository.GetAsync(message.ItemId);

            if (equipment != null)
            {
                return;
            }

            equipment = new EquipmentItem
            {
                Id = message.ItemId,
                Name = message.Name,
            };

            await repository.CreateAsync(equipment);
        }
    }
}