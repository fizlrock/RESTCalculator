
namespace Calc.Models;

using Microsoft.EntityFrameworkCore;
using Calc.Models;
using System;
using System.Collections.Generic;



public class MathRequestContext : DbContext
{

    public MathRequestContext(DbContextOptions<MathRequestContext> options)

        : base(options)
    {
        this.Database.EnsureCreated();
    }

    public DbSet<InfixPOLISPair> InfixPOLISPairs { get; set; } = null!;
    public DbSet<MathResult> MathResults { get; set; } = null!;


    protected override void OnModelCreating(ModelBuilder mb)
    {
        mb.Entity<InfixPOLISPair>()
            .HasKey(c => new { c.POLIS, c.Infix });
        mb.Entity<InfixPOLISPair>()
						.HasOne(e => e.Result);

						

    }


}


