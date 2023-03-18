using HarvestHelper.Equipment.Service.Dtos;
using HarvestHelper.Equipment.Service.Entities;

namespace HarvestHelper.Equipment.Service
{
    public static class Extensions
    {
        public static EquipmentDto AsDto(this HarvestHelper.Equipment.Service.Entities.EquipmentItem equipment)
        {
            return new EquipmentDto(equipment.Id, equipment.Name, equipment.DateAdded);
        }
    }
}