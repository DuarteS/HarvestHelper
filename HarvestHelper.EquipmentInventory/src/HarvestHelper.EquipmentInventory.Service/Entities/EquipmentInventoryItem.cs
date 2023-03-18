using System;
using HarvestHelper.Common;

namespace HarvestHelper.EquipmentInventory.Service.Entities
{
    public class EquipmentInventoryItem : IEntity
    {
        public Guid Id { get; set; }

        public Guid FarmId { get; set; }

        public Guid EquipmentItemId { get; set; }

        public DateTimeOffset AcquiredDate { get; set; }
    }
}