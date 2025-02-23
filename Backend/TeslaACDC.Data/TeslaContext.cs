using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TeslaACDC.Data.Models;

namespace TeslaACDC.Data;

public class TeslaContext : IdentityDbContext<ApplicationUser>
{
    public TeslaContext(DbContextOptions<TeslaContext> options) : base(options)
    {
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
    }
    public DbSet<Autor> Autores { get; set; }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        if (builder == null)
        {
            return;
        }

        builder.Entity<Autor>().ToTable("autor").HasKey(k => k.Id);
        base.OnModelCreating(builder);
    }
}
