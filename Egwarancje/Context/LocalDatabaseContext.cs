﻿using Egwarancje.Models;
using Egwarancje.Utils;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Egwarancje.Context;

public class LocalDatabaseContext : DbContext
{
    //public DbSet<Attachment> Attachments { get; set; }
    public DbSet<User> Users { get; set; }


    public LocalDatabaseContext() { }
    public LocalDatabaseContext(DbContextOptions<LocalDatabaseContext> options) : base(options)
    {
        //Database.Migrate();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string srvrdbname = "egwarancje";
        string srvrname = "192.168.0.165";
        string srvrusername = "fanim";
        string srvrpassword = "fanim123";

        string sqlconn = $"Data Source={srvrname};Initial Catalog={srvrdbname};User ID={srvrusername};Password={srvrpassword}";
        optionsBuilder.UseSqlServer(sqlconn);
        Database.Migrate();
    }
}
