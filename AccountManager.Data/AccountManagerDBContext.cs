﻿using AccountManager.Data.Models;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccountManager.Data
{
   public class AccountManagerDBContext: DbContext
    {
        public AccountManagerDBContext(
            
           DbContextOptions<AccountManagerDBContext> options) : base(options)
        {
        }

        public DbSet<AccountType> AccountType { get; set; }
        public DbSet<AccountType> Account { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccountType>()
                .HasKey(r => r.Id);

            modelBuilder.Entity<Account>()
                .HasKey(r => r.Id);

            modelBuilder.Entity<Account>()
                .HasOne(r => r.AccountType)
                .WithMany(r => r.Accounts)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
