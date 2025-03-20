using System.ComponentModel.DataAnnotations.Schema;

namespace Eshop.Models
{
    public class PlanetToKosikModel
    {
        public int Id { get; set; }
      
        public string Nazev { get; set; }
 
        public string Popis { get; set; }

        public int? PocetMesicu { get; set; }

        public int? Prumer { get; set; }

        public TimeSpan? DelkaDne { get; set; }

        public bool? FloraPritomna { get; set; }

        public bool? FaunaPritomna { get; set; }

        public string? TypPlanety { get; set; }

        public int? PocetNaSklade { get; set; }

        public PlanetToKosikModel(int id, string nazev, string popis, int? pocetMesicu, int? prumer, TimeSpan? delkaDne, bool? floraPritomna, bool? faunaPritomna, string? typPlanety, int? pocetNaSklade)
        {
            Id = id;
            Nazev = nazev;
            Popis = popis;
            PocetMesicu = pocetMesicu;
            Prumer = prumer;
            DelkaDne = delkaDne;
            FloraPritomna = floraPritomna;
            FaunaPritomna = faunaPritomna;
            TypPlanety = typPlanety;
            PocetNaSklade = pocetNaSklade;
        }
    }
}
