using System;
using HarvestHelper.Common;

namespace HarvestHelper.EquipmentInventory.Service.Entities
{
    public class EquipmentItem : IEntity
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

    }
}