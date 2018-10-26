#region MetallRose

// ***********************************************************************
// Ensamblado         		: SkyLab - SkyLab - Docentes.cs
// Autor					: Alex Mauricio Palacios Caicedo
// Creado          			: 29/06/2016
// 
// Ultima Modificación por 	: Alex Mauricio Palacios Caicedo
// Ultima Modificación en 	: 29/06/2016
// ***********************************************************************
// <copyright file="Docentes.cs" Compañia="MetallRose">
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
    public class Docentes
    {
        #region Instance Properties

        public int ContratoId { get; set; }

        [ForeignKey("ContratoId")]
        public Contratos Contratos { get; set; }

        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime FechaIngreso { get; set; }

        [Key]
        [Column("DocenteId")]
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

        #endregion
    }
}
