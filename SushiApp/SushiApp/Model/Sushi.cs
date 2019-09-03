
using SQLite;
using SushiApp.interfaces;

namespace SushiApp.Model
{
    [Table("Sushi")]
    public class Sushi : ISushi
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; } 
    }
}
