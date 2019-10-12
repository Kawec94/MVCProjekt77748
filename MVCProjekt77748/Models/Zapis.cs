using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace MVCProjekt77748.Models
{
    public class Zapis
    {
        [Key]
        public int IDZapisu { get; set; }
        public int IDKursu { get; set; }
        public string Id { get; set; }
    }

    public class ZapisDBContext : DbContext
    {
        public DbSet<Zapis> Zapisy { get; set; }
    }

}