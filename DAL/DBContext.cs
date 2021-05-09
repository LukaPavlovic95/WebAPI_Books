using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public class DBContext : DbContext
    {
        public DbSet<BooksEntity> Books { get; set; }
        public DbSet<AuthorsEntity> Authors { get; set; }
        public DbSet<AccountEntity> Account { get; set; }
        public DBContext(DbContextOptions<DBContext> options) : base(options) { }
        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<BooksEntity>().ToTable("BooksEntity");
        //    modelBuilder.Entity<AuthorsEntity>().ToTable("AuthorsEntity");
        //    modelBuilder.Entity<AccountEntity>().ToTable("AccountEntity");
        //}
    }
}
