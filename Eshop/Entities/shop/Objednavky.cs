using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Eshop.Entities.shop
{
    [Table("TbObjednavky")]
    public class Objednavky
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("jmeno")]
        public string Jmeno { get; set; }
        [Column("prijmeni")]
        public string Prijmeni { get; set; }
        [Column("slunecni_soustava")]
        public string SlunecniSoustava { get; set; }
        [Column("planeta")]
        public string Planeta { get; set; }
        [Column("mesto")]
        public string Mesto { get; set; }
        [Column("ulice")]
        public string Ulice { get; set; }
        [Column("cislo_domu")]
        public string CisloDomu { get; set; }
        [Column("psc")]
        public string? PSC {  get; set; }
        [Column("soustava_doruceni")]
        public string? SoustavaDoruceni { get; set; }
        [Column("zpusob_placeni")]
        public string ZpusobPlatba { get; set; }

        public Objednavky()
        {
            Id = 0;
            Jmeno = "";
            Prijmeni = "";
            SlunecniSoustava = "";
            Planeta = "";
            Mesto = "";
            Ulice = "";
            CisloDomu = "";
            PSC = "";
            SoustavaDoruceni = "";
            ZpusobPlatba = "";
        }
    }
}
