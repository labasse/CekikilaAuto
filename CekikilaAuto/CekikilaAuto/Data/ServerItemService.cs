using CekikilaLib;
using Microsoft.EntityFrameworkCore;

namespace CekikilaAuto.Data
{
    public class ServerItemService(ApplicationDbContext Db) : IItemsService
    {
        public async Task<IEnumerable<ItemDto>?> GetAllItemsAsync() 
            => await Db.Items.Include(item => item.Owner).Select(item => item.ToDto()).ToListAsync();

        public async Task<ItemDto?> GetItemAsync(int id)
            => (await Db.Items
                    .Include(item => item.Owner)
                    .FirstOrDefaultAsync(item => id == item.Id)
                )?.ToDto();
    }
}
