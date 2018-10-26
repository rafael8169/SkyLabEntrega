#region MetallRose

// ***********************************************************************
// Ensamblado         		: SkyLab - SkyLab - IdentityConfig.cs
// Autor					: Alex Mauricio Palacios Caicedo
// Creado          			: 28/03/2016
// 
// Ultima Modificación por 	: Alex Mauricio Palacios Caicedo
// Ultima Modificación en 	: 28/06/2016
// ***********************************************************************
// <copyright file="IdentityConfig.cs" Compañia="MetallRose">
//     Copyright (c) MetallRose All rights reserved.
// </copyright>
// ***********************************************************************

#endregion

#region Using

using System;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using SkyLab.Models;

#endregion

namespace SkyLab
{
    public class EmailService : IIdentityMessageService
    {
        #region Instance Methods

        public Task SendAsync(IdentityMessage message)
        {
            try
            {
                var mensaje = new MailMessage();
                var smtp = new SmtpClient
                           {
                               Host = "smtp-mail.outlook.com",
                               Port = 587, //587,
                               EnableSsl = true, //true,
                               UseDefaultCredentials = false,
                               Credentials = new NetworkCredential("alexpalacios.sci@outlook.com", "MetallRose2675")
                           };

                mensaje.To.Add(message.Destination); //Cuenta de Correo al que se le quiere enviar el e-mail
                mensaje.From = new MailAddress("alexpalacios.sci@outlook.com", "SkyLab"); //Quien lo envía
                mensaje.Subject = message.Subject; //Sujeto del e-mail
                mensaje.SubjectEncoding = Encoding.UTF8; //Codificación

                mensaje.BodyEncoding = Encoding.UTF8; //Codificación del correo
                mensaje.Priority = MailPriority.Normal;
                mensaje.IsBodyHtml = true;

                var htmlView =
                    AlternateView.CreateAlternateViewFromString(message.Body,
                        Encoding.UTF8,
                        MediaTypeNames.Text.Html);
                
                mensaje.AlternateViews.Add(htmlView);

                try
                {
                    smtp.Send(mensaje);
                    mensaje.Dispose();
                    smtp.Dispose();
                    return Task.FromResult(true);
                }
                catch (SmtpException)
                {
                    return Task.FromResult(false);
                }
            }
            catch (Exception)
            {
                return Task.FromResult(false);
            }
        }

        #endregion
    }

    public class SmsService : IIdentityMessageService
    {
        #region Instance Methods

        public Task SendAsync(IdentityMessage message)
        {
            // Plug in your SMS service here to send a text message.
            return Task.FromResult(0);
        }

        #endregion
    }

    // Configure the application user manager used in this application. UserManager is defined in ASP.NET Identity and is used by the application.
    public class ApplicationUserManager : UserManager<ApplicationUser>
    {
        #region C'tors

        public ApplicationUserManager(IUserStore<ApplicationUser> store)
            : base(store) {}

        #endregion

        #region Class Methods

        public static ApplicationUserManager Create(IdentityFactoryOptions<ApplicationUserManager> options, IOwinContext context)
        {
            var manager = new ApplicationUserManager(new UserStore<ApplicationUser>(context.Get<ApplicationDbContext>()));
            // Configure validation logic for usernames
            manager.UserValidator = new UserValidator<ApplicationUser>(manager)
                                    {
                                        AllowOnlyAlphanumericUserNames = false,
                                        RequireUniqueEmail = true
                                    };

            // Configure validation logic for passwords
            manager.PasswordValidator = new PasswordValidator
                                        {
                                            RequiredLength = 6,
                                            RequireNonLetterOrDigit = true,
                                            RequireDigit = true,
                                            RequireLowercase = true,
                                            RequireUppercase = true
                                        };

            // Configure user lockout defaults
            manager.UserLockoutEnabledByDefault = true;
            manager.DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(5);
            manager.MaxFailedAccessAttemptsBeforeLockout = 5;

            // Register two factor authentication providers. This application uses Phone and Emails as a step of receiving a code for verifying the user
            // You can write your own provider and plug it in here.
            manager.RegisterTwoFactorProvider("Phone Code", new PhoneNumberTokenProvider<ApplicationUser>
                                                            {
                                                                MessageFormat = "Your security code is {0}"
                                                            });
            manager.RegisterTwoFactorProvider("Email Code", new EmailTokenProvider<ApplicationUser>
                                                            {
                                                                Subject = "Security Code",
                                                                BodyFormat = "Your security code is {0}"
                                                            });
            manager.EmailService = new EmailService();
            manager.SmsService = new SmsService();
            var dataProtectionProvider = options.DataProtectionProvider;
            if (dataProtectionProvider != null)
            {
                manager.UserTokenProvider =
                    new DataProtectorTokenProvider<ApplicationUser>(dataProtectionProvider.Create("ASP.NET Identity"));
            }
            return manager;
        }

        #endregion
    }

    // Configure the application sign-in manager which is used in this application.
    public class ApplicationSignInManager : SignInManager<ApplicationUser, string>
    {
        #region C'tors

        public ApplicationSignInManager(ApplicationUserManager userManager, IAuthenticationManager authenticationManager)
            : base(userManager, authenticationManager) {}

        #endregion

        #region Instance Methods

        public override Task<ClaimsIdentity> CreateUserIdentityAsync(ApplicationUser user)
        {
            return user.GenerateUserIdentityAsync((ApplicationUserManager) UserManager);
        }

        #endregion

        #region Class Methods

        public static ApplicationSignInManager Create(IdentityFactoryOptions<ApplicationSignInManager> options, IOwinContext context)
        {
            return new ApplicationSignInManager(context.GetUserManager<ApplicationUserManager>(), context.Authentication);
        }

        #endregion
    }
}
