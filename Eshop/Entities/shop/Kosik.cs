using System.ComponentModel.DataAnnotations.Schema;

namespace Eshop.Entities.shop
{
    [Table("TbKosiky")]
    public class Kosik
    {
        [Column("id")]
        public int Id { get; set; }
        [ForeignKey("Ucet")]
        [Column("id_ucet")]
        public int IdUctet { get; set; }
        [Column("id_objednavky")]
        public int? IdObjednavky { get; set; }
        //public virtual List<Planeta> Planeta { get; set; }
        public virtual Ucet Ucet { get; set; }


        public Kosik()
        {
            Id = 0;
            IdUctet = 0;
            IdObjednavky = 0;
            //Planeta = new List<Planeta>();
        }
    }
}
