
using SQLite;

namespace DiasCRUD5363922
{
    [Table("calculoD")]
    public class CalculoD
    {
        [PrimaryKey]
        [AutoIncrement]
        [Column ("id")]
        public int Id { get; set; }
        [Column ("dias")]
        public string? Dias { get; set; }
        [Column ("resegundos")]
        public string? ReSegundos { get; set; }
    }
}
