using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Eshop.Entities.shop
{
    [Table("TbUcet")]
    public class Ucet
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("uzivatelske_jmeno")]
        public string? UzivatelskeJmeno { get; set; }
        [Column("jmeno")]
        public string? Jmeno { get; set; }
        [Column("prijmeni")]
        public string? Prijmeni { get; set; }
        [Column("slunecni_Soustava")]
        public string? SlunecniSoustava { get; set; }
        [Column("planeta")]
        public string? Planeta { get; set; }
        [Column("mesto")]
        public string? Mesto { get; set; }
        [Column("cislo_domu")]
        public string? CisloDomu {  get; set; }
        [Column("psc")]
        public string? PSC {  get; set; }
        [Column("soustava_doruceni")]
        public string? SoustavaDoruceni { get; set; }
        [Column("heslo")]
        public string? Heslo {  get; set; }

        public Ucet()
        {
            Id = 0;
            UzivatelskeJmeno = "";
            Jmeno = "";
            Prijmeni = "";
            SlunecniSoustava = "";
            Planeta = "";
            Mesto = "";
            CisloDomu = "";
            PSC = "";
            SoustavaDoruceni = "";
            Heslo = "";
        }
    }
}
