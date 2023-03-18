using System.Threading.Tasks;
using MassTransit;
using HarvestHelper.Equipment.Contracts;
using HarvestHelper.Common;
using HarvestHelper.EquipmentInventory.Service.Entities;

namespace Play.Inventory.Service.Consumers
{
    public class EquipmentItemDeletedConsumer : IConsumer<EquipmentItemDeleted>
    {
        private readonly IRepository<EquipmentItem> repository;

        public EquipmentItemDeletedConsumer(IRepository<EquipmentItem> repository)
        {
            this.repository = repository;
        }

        public async Task Consume(ConsumeContext<EquipmentItemDeleted> context)
        {
            var message = context.Message;

            var equipment = await repository.GetAsync(message.ItemId);

            if (equipment == null)
            {
                return;
            }

            await repository.RemoveAsync(message.ItemId);
        }
    }
}