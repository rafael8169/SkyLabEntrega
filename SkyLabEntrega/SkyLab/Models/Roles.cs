#region MetallRose
// ***********************************************************************
// Ensamblado         		: SkyLab - SkyLab - Roles.cs
// Autor					: Alex Mauricio Palacios Caicedo
// Creado          			: 28/03/2016
// 
// Ultima Modificación por 	: Alex Mauricio Palacios Caicedo
// Ultima Modificación en 	: 28/03/2016
// ***********************************************************************
// <copyright file="Roles.cs" Compañia="MetallRose">
//     Copyright (c) MetallRose All rights reserved.
// </copyright>
// ***********************************************************************
#endregion

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SkyLab.Models
{
    [Table("AspNetRoles")]
    public class Roles
    {
        [Key]
        [Column("Id")]
        public string Id { get; set; }
        [Column("Name")]
        public string Nombre { get; set; }

        public virtual ICollection<UsuariosRoles> UsuariosRoles { get; set; }
    }
}