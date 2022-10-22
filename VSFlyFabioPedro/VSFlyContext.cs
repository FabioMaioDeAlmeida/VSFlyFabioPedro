using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VSFlyFabioPedro.Models;

namespace VSFlyFabioPedro
{
    public class VSFlyContext:DbContext
    {
        public DbSet<Compagnie> CompagnieSet { get; set; }
        public DbSet<Passager> PassagerSet { get; set; }    
        public DbSet<Réservation> RéservationSet { get; set; }
        public DbSet<Vol> VolSet { get; set; }
        public VSFlyContext() { }
        public static string ConnectionString { get; set; } = @"Data Source=153.109.124.35;Initial Catalog=VSFlyFabioPedro;Integrated Security=False;User Id=6231db;Password=Pwd46231.;MultipleActiveResultSets=True";
        protected override void OnConfiguring (DbContextOptionsBuilder builder)
        {
            builder.UseLazyLoadingProxies();
            builder.UseSqlServer(ConnectionString);
        }
    }
}
