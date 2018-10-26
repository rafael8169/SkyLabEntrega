#region MetallRose
// ***********************************************************************
// Ensamblado         		: SkyLab - SkyLab - Directivos.cs
// Autor					: Alex Mauricio Palacios Caicedo
// Creado          			: 28/03/2016
// 
// Ultima Modificación por 	: Alex Mauricio Palacios Caicedo
// Ultima Modificación en 	: 28/03/2016
// ***********************************************************************
// <copyright file="Directivos.cs" Compañia="MetallRose">
//     Copyright (c) MetallRose All rights reserved.
// </copyright>
// ***********************************************************************
#endregion

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SkyLab.Models
{
    public class Directivos
    {
        [Key]
        [Column("DirectivoId")]
        public int Id { get; set; }
        public int PersonaId { get; set; }
        public int UniversidadId { get; set; }

        [ForeignKey("UniversidadId")]
        public Universidades Universidades { get; set; }
        [ForeignKey("PersonaId")]
        public Personas Personas { get; set; }
    }
}