using DemoAPI.Models.Classes;
using Microsoft.EntityFrameworkCore;
using DemoAPI.Models;
using System;

namespace DemoAPI.Models.Data

{
    public class DbApontamentoHoras : DbContext
    {
        public DbApontamentoHoras(DbContextOptions<DbApontamentoHoras> options) : base(options)
        {

        }
        public DbSet<ApontamentoDeHoras> ApontamentoDeHoras { get; set; }
    }
}
