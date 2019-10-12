using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace MVCProjekt77748.Models
{
    public class Kurs
    {
        [Key]
        public int IDKursu { get; set; }
        public string Tytul { get; set; }
        public DateTime DataRozpoczecia { get; set; }
        public string Poziom { get; set; }
        public decimal Cena { get; set; }
        public int LiczbaMiejsc { get; set; }
        public int LiczbaWolnychMiejsc { get; set; }
    }

    public class KursDBContext : DbContext
    {
        public DbSet<Kurs> Kursy { get; set; }
    }
}