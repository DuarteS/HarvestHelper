using System;
using System.ComponentModel.DataAnnotations;

namespace HarvestHelper.Equipment.Service.Dtos
{
    public record EquipmentDto(Guid Id, string Name, DateTimeOffset DateAdded);

    public record CreateEquipmentDto([Required] string Name);

    public record UpdateEquipmentDto([Required] string Name);
}