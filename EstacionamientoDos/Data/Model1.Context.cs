﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EstacionamientoDos.Data
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DashboardEntities : DbContext
    {
        public DashboardEntities()
            : base("name=DashboardEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<adm_Module> adm_Module { get; set; }
        public virtual DbSet<adm_Rol> adm_Rol { get; set; }
        public virtual DbSet<adm_RolModule> adm_RolModule { get; set; }
        public virtual DbSet<adm_RolUser> adm_RolUser { get; set; }
        public virtual DbSet<adm_User> adm_User { get; set; }
        public virtual DbSet<report_data> report_data { get; set; }
    }
}
