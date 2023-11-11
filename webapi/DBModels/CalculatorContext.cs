
using Microsoft.EntityFrameworkCore;
using Calc.Models;
using System;
using System.Collections.Generic;

namespace EF_1.Models;


public class MathRequestContext : DbContext
{
    public MathRequestContext()
    {
        DbPath = "/home/fizlrock/code/hobby/EF/EF_1/requests.db";
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    => options.UseSqlite($"Data Source={DbPath}");

    public DbSet<MathRequest> MathRequests { get; set; }
    public string DbPath { get; }


}


