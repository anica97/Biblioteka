using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace back.Models
{
    [Table("biblioteka")]
    public class Biblioteka
    {
        
        [Key]
        [Column("Id")]
        public int Id { get; set; }
        [Column("Naziv")]
        public string Naziv { get; set; }

        
        public virtual List<Red> redovi { get; set; }
    }
}