using CekikilaLib;

namespace CekikilaAuto.Data
{
    public class Item
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? Description
        {
            get; set;
        }

        public required string Tags { get; set; }

        public required ApplicationUser Owner { get; set; }

        public ItemDto ToDto() => new ItemDto
        {
            Id = Id,
            Name = Name,
            Description = Description,
            Tags = Tags.Split(", "),
            Owner = Owner?.UserName ?? "?"
        };

        public static Item FromDto(ItemDto dto, ApplicationUser owner) => new Item
        {
            Id = dto.Id,
            Name = dto.Name,
            Description = dto.Description,
            Tags = string.Join(", ", dto.Tags),
            Owner = owner
        };
    }
}