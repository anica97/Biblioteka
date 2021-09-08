using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace back.Models
{
    [Table("red")]
    public class Red
    {
        
        [Key]
        [Column("Id")]
        public int Id { get; set; }
        [Column("Zanr")]
        public string Zanr { get; set; }

        public virtual List<Knjiga> knjige { get; set; }
    }
}