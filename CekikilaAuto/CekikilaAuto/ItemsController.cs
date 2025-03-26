using CekikilaAuto.Data;
using CekikilaLib;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CekikilaAuto
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController(ApplicationDbContext Db) : ControllerBase
    {
        private Item LoadOwner(Item item)
        {
            Db.Entry(item).Reference(item => item.Owner).Load();
            return item;
        }

        private ActionResult CheckId(int id, Func<Item, ActionResult> process)
            => Db.Items.Find(id) is Item item ? process(LoadOwner(item)) : NotFound();

        private ActionResult CheckOwner(string owner, int id, ItemDto? dto, Func<Item, ItemDto?, ActionResult> process)
            => CheckId(id, item => item.Owner.Id == owner ? process(item, dto) : Forbid());

        [HttpGet]
        public IEnumerable<ItemDto> Get() => 
            Db.Items.Include(item => item.Owner).Select(item => item.ToDto());

        [HttpGet("{id}")]
        public ActionResult<ItemDto> Get(int id) 
            => CheckId(id, item => Ok(item.ToDto()));

        [HttpPost]
        public ActionResult Post([FromBody] ItemDto dto)
        {
            var item = Item.FromDto(dto, Db.Users.First());

            Db.Items.Add(item);
            Db.SaveChanges();
            return CreatedAtAction(nameof(Get), new { id = item.Id }, item.ToDto());
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] ItemDto dto)
            => CheckOwner("?", id, dto, (item, dto) => {
                if(dto is null) return BadRequest();
                item.Name = dto.Name;
                item.Description = dto.Description;
                item.Tags = string.Join(", ", dto.Tags);
                Db.SaveChanges();
                return Ok();
            });

        [HttpDelete("{id}"), Authorize]
        public ActionResult Delete(int id)
            => CheckOwner("?", id, null, (item, _) => { 
                Db.Items.Remove(item); 
                Db.SaveChanges(); 
                return NoContent(); 
            });
    }
}
