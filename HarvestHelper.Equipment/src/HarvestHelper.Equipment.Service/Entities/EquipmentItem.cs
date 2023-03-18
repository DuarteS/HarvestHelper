using System;
using HarvestHelper.Common;

namespace HarvestHelper.Equipment.Service.Entities
{
    public class EquipmentItem : IEntity
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public DateTimeOffset DateAdded { get; set; }
    }
}