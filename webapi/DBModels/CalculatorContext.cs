
using Microsoft.EntityFrameworkCore;
using Calc.Models;
using System;
using System.Collections.Generic;



public class MathRequestContext : DbContext
{

    public MathRequestContext(DbContextOptions<MathRequestContext> options)

        : base(options)
    {
        Database.EnsureCreated();   // создаем базу данных при первом обращении
    }

    public DbSet<MathRequest> MathRequests { get; set; } = null!;


}


