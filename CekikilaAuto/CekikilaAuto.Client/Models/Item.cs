namespace CekikilaWasm.Models
{
    public class Item
    {
        public int Id { get; init; }
        public required string Name { get; set; }
        public string? Description
        {
            get; init;
        }

        public required string[] Tags;
    }
}