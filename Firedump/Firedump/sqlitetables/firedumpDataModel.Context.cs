﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Firedump
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    public partial class firedumpdbEntities1 : DbContext
    {
        public firedumpdbEntities1()
            : base("name=firedumpdbEntities1")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }

        public virtual DbSet<backup_locations> backup_locations { get; set; }
        public virtual DbSet<logs> logs { get; set; }
        public virtual DbSet<sqlservers> sqlservers { get; set; }
        public virtual DbSet<schedule_save_locations> schedule_save_locations { get; set; }
        public virtual DbSet<schedules> schedules { get; set; }
        public virtual DbSet<userinfo> userinfo { get; set; }
    }
}
