#region MetallRose

// ***********************************************************************
// Ensamblado         		: SkyLab - SkyLab - TipoDocumento.cs
// Autor					: Alex Mauricio Palacios Caicedo
// Creado          			: 28/06/2016
// 
// Ultima Modificación por 	: Alex Mauricio Palacios Caicedo
// Ultima Modificación en 	: 28/06/2016
// ***********************************************************************
// <copyright file="TipoDocumento.cs" Compañia="MetallRose">
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
    public class TipoDocumento
    {
        #region Instance Properties
        [Display(Name = "Tipo Doc.")]
        public string Descripcion { get; set; }
        [Key]
        [Column("TipoDocumentoId")]
        public int Id { get; set; }

        public virtual ICollection<Personas> Personas { get; set; }

        #endregion
    }
}
