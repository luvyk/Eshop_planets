using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Eshop.Entities.shop
{
    [Table("TbPlanetyKategorie")]
    public class PlanetyKategorie
    {
        [Key]
        [ForeignKey("KategorieOdkaz")]
        [Column("id_kategorie")]
        public int KategorieId { get; set; }
        [ForeignKey("PlanetaOdkaz")]
        [Column("id_planety")]
        public int PlanetyId { get; set; }
        public virtual Kategorie KategorieOdkaz { get; set; }
        public virtual Planeta PlanetaOdkaz { get; set; }


        public PlanetyKategorie()
        {
            KategorieId = 0;
            PlanetyId = 0;
        }
    }
}
