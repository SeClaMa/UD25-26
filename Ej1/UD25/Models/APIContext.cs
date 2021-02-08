using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace UD25.Models
{
    public class APIContext : DbContext
    {
        public APIContext(DbContextOptions<APIContext> options) : base(options)
        {

        }

        public DbSet<Fabricantes> Fabricante { get; set; }
        public DbSet<Articulos> Articulo { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            

            

            modelBuilder.Entity<Fabricantes>(entity => {
                entity.ToTable("Fabricantes");
                entity.Property(e => e.Nombre).IsRequired();
                entity.HasKey(c => c.Codigo);
                
                
                });

            modelBuilder.Entity<Articulos>(entity => {

                entity.ToTable("Articulos");
                entity.HasKey(c => c.Codigo);

                entity.HasOne(a => a.Fabricante).WithMany(f => f.Articulos).HasForeignKey(a => a.Fabricante_Id).OnDelete(DeleteBehavior.ClientSetNull);


            });

            

        }
        

    }
}
