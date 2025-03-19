using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Eshop.Entities.shop
{
    [Table("TbPlanetyVKosiku")]
    public class PlanetyVKosiku
    {
        [Key]
        [ForeignKey("Planeta")]
        [Column("id_planety")]
        public int IdPlanety { get; set; }
        [ForeignKey("Kosik")]
        [Column("id_kosiku")]
        public int? IdKosiky { get; set; }
        [ForeignKey("TempKosik")]
        [Column("uuid_temp_kosiku")]
        public string? UUIDTempKosiku { get; set; }
        public virtual Planeta Planeta { get; set; }
        public virtual Kosik Kosik { get; set; }
        public virtual TempKosik TempKosik { get; set; }

        public PlanetyVKosiku()
        {
            IdPlanety = 0;
            IdKosiky = 0;
            UUIDTempKosiku = "";
        }
    }
}
