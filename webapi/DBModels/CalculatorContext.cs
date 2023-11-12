
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


}


