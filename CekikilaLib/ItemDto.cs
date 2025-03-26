using System.ComponentModel.DataAnnotations;

namespace CekikilaLib
{
    public class ItemDto
    {
        public int Id { get; set; }

        [Required, StringLength(50, MinimumLength=2)]
        public required string Name { get; set; }

        [Display(Name="Description")]
        public string? Description
        {
            get; set;
        }

        public required string[] Tags { get; set; }

        public required string Owner { get; set; }
    }
}