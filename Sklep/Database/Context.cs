using Sklep.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Sklep.Database
{
    public class Context : DbContext
    {
        public DbSet<Artykul> Artykul { get; set; }
        public DbSet<Transakcja> Transkacja { get; set; }

        //public System.Data.Entity.DbSet<Sklep.Models.Plik> Pliks { get; set; }
    }
}