#region MetallRose

// ***********************************************************************
// Ensamblado         		: SkyLab - SkyLab - IdentityModels.cs
// Autor					: Alex Mauricio Palacios Caicedo
// Creado          			: 28/03/2016
// 
// Ultima Modificación por 	: Alex Mauricio Palacios Caicedo
// Ultima Modificación en 	: 28/06/2016
// ***********************************************************************
// <copyright file="IdentityModels.cs" Compañia="MetallRose">
//     Copyright (c) MetallRose All rights reserved.
// </copyright>
// ***********************************************************************

#endregion

#region Using

using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

#endregion

namespace SkyLab.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        #region Instance Methods

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        #endregion
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        #region C'tors

        public ApplicationDbContext()
            : base("SkyLab", false) {}

        #endregion

        #region Class Methods

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        #endregion
    }
}
