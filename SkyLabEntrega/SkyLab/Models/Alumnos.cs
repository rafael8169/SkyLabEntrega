#region MetallRose

// ***********************************************************************
// Ensamblado         		: SkyLab - SkyLab - Alumnos.cs
// Autor					: Alex Mauricio Palacios Caicedo
// Creado          			: 29/06/2016
// 
// Ultima Modificación por 	: Alex Mauricio Palacios Caicedo
// Ultima Modificación en 	: 29/06/2016
// ***********************************************************************
// <copyright file="Alumnos.cs" Compañia="MetallRose">
//     Copyright (c) MetallRose All rights reserved.
// </copyright>
// ***********************************************************************

#endregion

#region Using

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#endregion

namespace SkyLab.Models
{
    public class Alumnos
    {
        #region Instance Properties

        [Key]
        [Column("AlumnoId")]
        public int Id { get; set; }

        public int PersonaId { get; set; }

        [ForeignKey("PersonaId")]
        public Personas Personas { get; set; }

        public int PregradoId { get; set; }

        [ForeignKey("PregradoId")]
        public Pregrados Pregrados { get; set; }

        [ForeignKey("UniversidadId")]
        public Universidades Universidades { get; set; }

        public int UniversidadId { get; set; }

        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime FechaIngreso { get; set; }

        #endregion
    }
}
