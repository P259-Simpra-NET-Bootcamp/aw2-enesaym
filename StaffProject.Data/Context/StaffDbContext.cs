using Microsoft.EntityFrameworkCore;
using StaffProject.Data.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using StaffProject.Data.Domain;

namespace StaffProject.Data.Context;

public class StaffDbContext: DbContext
{
    public StaffDbContext(DbContextOptions<StaffDbContext> options):base(options)
    {
        
    }
    public DbSet<Staff> Staff { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new StaffConfiguration());
        base.OnModelCreating(modelBuilder);
    }

}




