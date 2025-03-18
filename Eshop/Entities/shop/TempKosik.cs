using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Eshop.Entities.shop
{
    [Table("account")]
    public class TempKosik
    {
        [Key]
        [Column("uuid")]
        public string UUID { get; set; }
        [Column("datum_vytvoreni")]
        public DateTime? DateOfCreation { get; set; }
        [Column("id_objednavky")]
        public int? IdObjednavky { get; set; }

        public TempKosik()
        {
            UUID = "";
            DateOfCreation = DateTime.Now;
            IdObjednavky = 0;
        }
    }
}
