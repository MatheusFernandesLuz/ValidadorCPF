using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using ValidadorCPF.Dominio;

namespace ValidadorCPF.Repo
{
    public class AppContext : DbContext
    {
        public AppContext(DbContextOptions<AppContext> options) : base(options) { }

        public DbSet<CPF> CPF { get; set; }

        // Sobrepondo o saveChanges para adicionar as colunas de criação e atualização do registro automaticamente
        public override int SaveChanges()
        {
            var newEntities = this.ChangeTracker.Entries()
                    .Where(
                        x => x.State == EntityState.Added &&
                        x.Entity != null &&
                        x.Entity as ITimeStampedModel != null
                        )
                    .Select(x => x.Entity as ITimeStampedModel);

            var modifiedEntities = this.ChangeTracker.Entries()
                .Where(
                    x => x.State == EntityState.Modified &&
                    x.Entity != null &&
                    x.Entity as ITimeStampedModel != null
                    )
                .Select(x => x.Entity as ITimeStampedModel);

            foreach (var newEntity in newEntities)
            {
                newEntity.CreatedAt = DateTime.UtcNow;
                newEntity.LastModified = DateTime.UtcNow;
            }

            foreach (var modifiedEntity in modifiedEntities)
            {
                modifiedEntity.LastModified = DateTime.UtcNow;
            }

            return base.SaveChanges();
        }
    }
}
