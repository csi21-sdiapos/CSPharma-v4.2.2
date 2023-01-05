using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace CSPharma_v4._1.Areas.Identity.Data;

// Add profile data for application users by adding properties to the UserAuthentication class
public class ApplicationUser : IdentityUser
{
    // los nuevos campos que queramos que tenga el usuario se añadirían aquí

    //public string UsuarioNombre { get; set; }
    //public string UsuarioApellidos { get; set; }
}