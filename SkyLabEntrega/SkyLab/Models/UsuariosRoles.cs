#region MetallRose

// ***********************************************************************
// Ensamblado         		: SkyLab - SkyLab - UsuariosRoles.cs
// Autor					: Alex Mauricio Palacios Caicedo
// Creado          			: 28/06/2016
// 
// Ultima Modificación por 	: Alex Mauricio Palacios Caicedo
// Ultima Modificación en 	: 28/06/2016
// ***********************************************************************
// <copyright file="UsuariosRoles.cs" Compañia="MetallRose">
//     Copyright (c) MetallRose All rights reserved.
// </copyright>
// ***********************************************************************

#endregion

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SkyLab.Models
{
    [Table("AspNetUserRoles")]
    public class UsuariosRoles
    {
        #region Instance Properties

        [ForeignKey("RolId")]
        public Roles Roles { get; set; }

        [Key]
        [Column("RoleId", Order = 2)]
        public string RolId { get; set; }
        [Key]
        [Column("UserId", Order = 1)]
        public string UsuarioId { get; set; }

        #endregion
    }
}
