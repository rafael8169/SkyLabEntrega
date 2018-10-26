#region MetallRose
// ***********************************************************************
// Ensamblado         		: SkyLab - SkyLab - Personas.cs
// Autor					: Alex Mauricio Palacios Caicedo
// Creado          			: 28/03/2016
// 
// Ultima Modificación por 	: Alex Mauricio Palacios Caicedo
// Ultima Modificación en 	: 28/03/2016
// ***********************************************************************
// <copyright file="Personas.cs" Compañia="MetallRose">
//     Copyright (c) MetallRose All rights reserved.
// </copyright>
// ***********************************************************************
#endregion

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SkyLab.Models
{
    [DisplayColumn("Persona")]
    public class Personas
    {
        [Key]
        [Column("PersonaId")]
        public int Id { get; set; }
        [Display(Name = "Tipo Doc.")]
        public int TipoDocumentoId { get; set; }
        [Display(Name = "Num. Doc.")]
        public string NumeroDocumento { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }

        [Display(Name = "Persona")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public string Persona { get; set; }

        public string Sexo { get; set; }
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime FechaNacimiento { get; set; }
        public string Direccion { get; set; }
        public string CorreoElectronico { get; set; }
        public virtual ICollection<Directivos> Directivos { get; set; }
        public virtual ICollection<Docentes> Docentes { get; set; }
        public virtual ICollection<Alumnos> Alumnos { get; set; }
        public TipoDocumento TipoDocumento { get; set; }
    }
}