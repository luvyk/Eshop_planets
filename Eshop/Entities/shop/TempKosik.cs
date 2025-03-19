using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Eshop.Entities.shop
{
    [Table("TbTempKosiky")]
    public class TempKosik
    {
        [Key]
        [Column("uuid")]
        public string UUID { get; set; }
        [Column("datum_vytvoreni")]
        public DateTime? DateOfCreation { get; set; }
        [ForeignKey("Objednavky")]
        [Column("id_objednavky")]
        public int? IdObjednavky { get; set; }
        public virtual Objednavky Objednavky { get; set; }

        public TempKosik()
        {
            UUID = "";
            DateOfCreation = DateTime.Now;
            IdObjednavky = 0;
        }
    }
}
