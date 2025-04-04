﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Eshop.Entities.shop
{
    [Table("TbKategorie")]
    public class Kategorie
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("nazev")]
        public string Nazev { get; set; }
        public virtual PlanetyKategorie PlanetaKat { get; set; }

        public Kategorie()
        {
            Id = 0;
            Nazev = "";
            PlanetaKat = new PlanetyKategorie();
        }
    }
}
