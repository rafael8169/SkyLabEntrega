#region MetallRose
// ***********************************************************************
// Ensamblado         		: SkyLab - SkyLab - Pregrados.cs
// Autor					: Alex Mauricio Palacios Caicedo
// Creado          			: 28/03/2016
// 
// Ultima Modificación por 	: Alex Mauricio Palacios Caicedo
// Ultima Modificación en 	: 28/03/2016
// ***********************************************************************
// <copyright file="Pregrados.cs" Compañia="MetallRose">
//     Copyright (c) MetallRose All rights reserved.
// </copyright>
// ***********************************************************************
#endregion

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SkyLab.Models
{
    [DisplayColumn("Descripcion")]
    public class Pregrados
    {
        [Key]
        [Column("PregradoId")]
        public int Id { get; set; }
        [Display(Name = "Pre Grado")]
        public string Descripcion { get; set; }
        public int UniversidadId { get; set; }
        public int HorarioId { get; set; }

        [ForeignKey("UniversidadId")]
        public Universidades Universidades { get; set; }
        [ForeignKey("HorarioId")]
        public Horarios Horarios { get; set; }

        public virtual ICollection<Docentes> Docentes { get; set; }
        public virtual ICollection<Alumnos> Alumnos { get; set; }
    }
}