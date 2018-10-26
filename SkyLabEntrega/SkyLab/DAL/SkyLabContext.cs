#region MetallRose

// ***********************************************************************
// Ensamblado         		: SkyLab - SkyLab - SkyLabContext.cs
// Autor					: Alex Mauricio Palacios Caicedo
// Creado          			: 28/03/2016
// 
// Ultima Modificación por 	: Alex Mauricio Palacios Caicedo
// Ultima Modificación en 	: 29/06/2016
// ***********************************************************************
// <copyright file="SkyLabContext.cs" Compañia="MetallRose">
//     Copyright (c) MetallRose All rights reserved.
// </copyright>
// ***********************************************************************

#endregion

#region Using

using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using SkyLab.Models;

#endregion

namespace SkyLab.DAL
{
    public class SkyLabContext : DbContext
    {
        #region C'tors

        public SkyLabContext() : base("SkyLab") {}

        #endregion

        #region Instance Properties

        public DbSet<Contratos> Contratos { get; set; }

        public DbSet<Directivos> Directivos { get; set; }
        public DbSet<Docentes> Docentes { get; set; }
        public DbSet<Horarios> Horarios { get; set; }
        public DbSet<Personas> Personas { get; set; }
        public DbSet<Pregrados> Pregrados { get; set; }
        public DbSet<Alumnos> Alumnos { get; set; }

        public DbSet<Roles> Roles { get; set; }
        public DbSet<TipoDocumento> TipoDocumento { get; set; }
        public DbSet<Universidades> Universidades { get; set; }
        public DbSet<UsuariosRoles> UsuariosRoles { get; set; }

        #endregion

        #region Instance Methods

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        #endregion
    }
}
