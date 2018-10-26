#region MetallRose

// ***********************************************************************
// Ensamblado         		: SkyLab - SkyLab - Universidades.cs
// Autor					: Alex Mauricio Palacios Caicedo
// Creado          			: 28/03/2016
// 
// Ultima Modificación por 	: Alex Mauricio Palacios Caicedo
// Ultima Modificación en 	: 29/06/2016
// ***********************************************************************
// <copyright file="Universidades.cs" Compañia="MetallRose">
//     Copyright (c) MetallRose All rights reserved.
// </copyright>
// ***********************************************************************

#endregion

#region Using

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#endregion

namespace SkyLab.Models
{
    [DisplayColumn("Nombre")]
    public class Universidades
    {
        #region Instance Properties

        public virtual ICollection<Alumnos> Alumnos { get; set; }

        public virtual ICollection<Directivos> Directivos { get; set; }
        public virtual ICollection<Docentes> Docentes { get; set; }
        public virtual ICollection<Pregrados> Pregrados { get; set; }
        public string Direccion { get; set; }

        [Key]
        [Column("UniversidadId")]
        public int Id { get; set; }

        [Display(Name = "Universidad")]
        public string Nombre { get; set; }

        #endregion
    }
}
