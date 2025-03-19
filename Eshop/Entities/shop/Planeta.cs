using Microsoft.Extensions.Primitives;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Eshop.Entities.shop
{
    [Table("TbPlanety")]
    public class Planeta
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("nazev")]
        public string Nazev { get; set; }
        [Column("popis")]
        public string Popis { get; set; }
        [Column("pocet_mesicu")]
        public int? PocetMesicu { get; set; }
        [Column("prumer")]
        public int? Prumer { get; set; }
        [Column("delka_dne")]
        public TimeSpan? DelkaDne { get; set; }
        [Column("flora_pritomna")]
        public bool? FloraPritomna { get; set; }
        [Column("fauna_pritomna")]
        public bool? FaunaPritomna { get; set; }
        [Column("typ_planety")]
        public string? TypPlanety { get; set; }
        [Column("pocet_na_sklade")]
        public int? PocetNaSklade { get; set; }
        [Column("cena")]
        public int Cena { get; set; }
        public virtual PlanetyKategorie PlanetyKat { get; set; }
        public virtual List<Recenze> Recenze { get; set; }
        public virtual List<Kosik> Kosik { get; set; }

        public Planeta()
        {
            Id = 0;
            Nazev = "";
            Popis = "";
            PocetMesicu = 0;
            Prumer = 0;
            DelkaDne = new TimeSpan(0, 0, 0);
            FloraPritomna = false;
            FaunaPritomna = false;
            TypPlanety = "";
            PocetNaSklade = 0;
            Cena = 0;
            PlanetyKat = new PlanetyKategorie();
            Recenze = new List<Recenze>();
            Kosik = new List<Kosik>();
        }
    }
}
