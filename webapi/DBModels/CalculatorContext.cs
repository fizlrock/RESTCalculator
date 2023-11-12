
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

    public DbSet<MathRequest> MathRequests { get; set; } = null!;


    protected override void OnModelCreating(ModelBuilder mb)
    {
			mb.Entity<InfixPOLISPair>()
				.HasKey(c => new { c.POLIS, c.Infix});
    }


}


