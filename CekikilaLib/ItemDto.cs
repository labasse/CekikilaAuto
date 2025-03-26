namespace CekikilaLib
{
    public class ItemDto
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? Description
        {
            get; set;
        }

        public required string[] Tags { get; set; }

        public required string Owner { get; set; }
    }
}