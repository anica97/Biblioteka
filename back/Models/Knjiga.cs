

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace back.Models
{
    [Table("knjiga")]
    public class Knjiga
    {
        
        [Key]
        [Column("Id")]
        public int Id { get; set; }
        [Column("Naziv")]
        public string Naziv { get; set; }
    }
}