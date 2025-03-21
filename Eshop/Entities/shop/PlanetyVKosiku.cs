using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Eshop.Entities.shop
{
    [Table("TbPlanetyVKosiku")]
    public class PlanetyVKosiku
    {
        [Key]
        [Column("id")]
        public int ID { get; set; }
        //[ForeignKey("Planeta")]
        [Column("id_planety")]
        public int IdPlanety { get; set; }
        //[ForeignKey("Kosik")]
        [Column("id_kosiku")]
        public int? IdKosiky { get; set; }
        //[ForeignKey("TempKosik")]
        [Column("uuid_temp_kosiku")]
        public string? UUIDTempKosiku { get; set; }
        //public virtual Planeta Planeta { get; set; }
        //public virtual Kosik? Kosik { get; set; }
        //public virtual TempKosik? TempKosik { get; set; }

        public PlanetyVKosiku()
        {
            IdPlanety = 0;
            IdKosiky = null;
            UUIDTempKosiku = null;
            //Planeta = new Planeta();
            //Kosik = new Kosik();
            //TempKosik = new TempKosik();
        }

        public PlanetyVKosiku(TempKosik T)
        {
            IdPlanety = 0;
            IdKosiky = 0;
            UUIDTempKosiku = T.UUID;
            /*
            Planeta = new Planeta();
            Kosik = new Kosik();
            TempKosik = T;
            */
        }
    }
}
