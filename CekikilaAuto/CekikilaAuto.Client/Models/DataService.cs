namespace CekikilaWasm.Models
{
    public class DataService
    {
        private readonly Item[] _items = {
            new() { Id=1, Name="Broyeur de végétaux"      , Tags = [ "Jardin", "Electrique" ], Description = "Broyeur électrique d'une puissance de 2800W et d'un diamètre de coupe maximum de 45 mm convient parfaitement à un usage régulier." },
            new() { Id=4, Name="Paddle gonflable"         , Tags = [ "Sport" ], Description = "Idéal pour amener partout avec soit, les planches de paddle gonflable vous surprendront par leur rigidité une fois gonflée et leur compacité dans leur sac de rangement." },
            new() { Id=3, Name="Taille haies électrique"  , Tags = [ "Jardin", "Electrique" ], Description = "Taille haies filaire idéal pour tailler de grandes haies avec facilité et en silence." },
            new() { Id=6, Name="Combinaison néoprenne T40", Tags = [ "Sport" ], Description = "Cette combinaison vous permettra de nager toute l'année ! Conçue en néoprène spécial pour plus de résistance pour l'enfilage et une glisse idéale !" }
        };

        public IEnumerable<Item> AllItems => _items;

        public IEnumerable<Item> ItemsByTag(string tag) => _items.Where(item => item.Tags.Contains(tag));
    }
}
