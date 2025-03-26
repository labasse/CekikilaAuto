using CekikilaLib;
using System.Net.Http.Json;

namespace CekikilaAuto.Client.Models
{
    public class ClientItemService(HttpClient Http) : IItemsService
    {
        public async Task<IEnumerable<ItemDto>?> GetAllItemsAsync() 
            => await Http.GetFromJsonAsync<ItemDto[]>("/api/items");

        public async Task<ItemDto?> GetItemAsync(int id)
            => await Http.GetFromJsonAsync<ItemDto>($"/api/items/{id}");
    }
}
