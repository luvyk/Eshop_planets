using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Eshop.Entities.shop
{
    [Table("TbRecenze")]
    public class Recenze
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("text_recenze")]
        public string? TextRecenze { get; set; }
        [Column("hodnoceni")]
        public int Hodnoceni { get; set; }
        [ForeignKey("Planeta")]
        [Column("id_planety")]
        public  int IdPlanety { get; set; }
        public virtual Planeta Planeta { get; set; }

        public Recenze()
        {
            Id = 0;
            TextRecenze = "";
            Hodnoceni = 0;
            IdPlanety = 0;
            Planeta = new Planeta();
        }
    }
}
