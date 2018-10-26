#region MetallRose
// ***********************************************************************
// Ensamblado         		: SkyLab - SkyLab - Horarios.cs
// Autor					: Alex Mauricio Palacios Caicedo
// Creado          			: 29/06/2016
// 
// Ultima Modificación por 	: Alex Mauricio Palacios Caicedo
// Ultima Modificación en 	: 29/06/2016
// ***********************************************************************
// <copyright file="Horarios.cs" Compañia="MetallRose">
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
    public class Horarios
    {
        [Key]
        [Column("HorarioId")]
        public int Id { get; set; }
        [Display(Name = "Horario")]
        public string Descripcion { get; set; }

        public virtual ICollection<Pregrados> Pregrados { get; set; }
    }
}