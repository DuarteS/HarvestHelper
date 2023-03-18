using System;

namespace HarvestHelper.Equipment.Contracts
{
    public record EquipmentItemCreated(Guid ItemId, string Name);

    public record EquipmentItemUpdated(Guid ItemId, string Name);

    public record EquipmentItemDeleted(Guid ItemId);
}