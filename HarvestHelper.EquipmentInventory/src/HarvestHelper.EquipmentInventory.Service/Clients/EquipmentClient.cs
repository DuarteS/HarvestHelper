using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using HarvestHelper.EquipmentInventory.Service.Dtos;

namespace HarvestHelper.EquipmentInventory.Service.Clients
{
    public class EquipmentClient
    {
        private readonly HttpClient httpClient;

        public EquipmentClient(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<IReadOnlyCollection<EquipmentItemDto>> GetEquipmentItemsAsync()
        {
            var equipment = await httpClient.GetFromJsonAsync<IReadOnlyCollection<EquipmentItemDto>>("/equipment");
            return equipment;
        }
    }
}