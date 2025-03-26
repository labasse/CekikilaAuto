namespace CekikilaLib
{
    public interface IItemsService
    {
        public Task<IEnumerable<ItemDto>?> GetAllItemsAsync();
        public Task<ItemDto?> GetItemAsync(int id);
    }
}
