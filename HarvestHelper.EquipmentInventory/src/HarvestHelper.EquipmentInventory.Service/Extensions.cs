using HarvestHelper.EquipmentInventory.Service.Dtos;
using HarvestHelper.EquipmentInventory.Service.Entities;

namespace HarvestHelper.EquipmentInventory.Service
{
    public static class Extensions
    {
        public static EquipmentInventoryItemDto AsDto(this EquipmentInventoryItem equipmentInventoryItem, string name)
        {
            return new EquipmentInventoryItemDto(equipmentInventoryItem.Id, name, equipmentInventoryItem.AcquiredDate);
        }
    }
}