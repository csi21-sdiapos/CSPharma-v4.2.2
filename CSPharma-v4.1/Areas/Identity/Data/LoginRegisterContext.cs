using CSPharma_v4._1.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Emit;

namespace CSPharma_v4._1.Areas.Identity.Data;

public class LoginRegisterContext : IdentityDbContext<ApplicationUser>
{
    public LoginRegisterContext(DbContextOptions<LoginRegisterContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfiguration(new UserEntityConfiguration());
        builder.HasDefaultSchema("dlk_torrecontrol");

        /*************************** to change the table names ***************************/
        // builder.Entity<IdentityUser>().ToTable("Dlk_cat_acc_empleados"); // esto da error luego
        // https://stackoverflow.com/questions/19460386/how-can-i-change-the-table-names-when-using-asp-net-identity
        builder.Entity<ApplicationUser>().ToTable("Dlk_cat_acc_empleados");
        builder.Entity<IdentityRole>().ToTable("Dlk_cat_acc_roles");

        // Error: Using the generic type 'IdentityUserRole<TKey>' requires 1 type arguments
        // https://stackoverflow.com/questions/54283342/using-the-generic-type-identityuserroletkey-requires-1-type-arguments
        builder.Entity<IdentityUserRole<string>>().ToTable("Dlk_cat_acc_empleados_roles");
        builder.Entity<IdentityRoleClaim<string>>().ToTable("Dlk_cat_acc_claim_roles");
        builder.Entity<IdentityUserClaim<string>>().ToTable("Dlk_cat_acc_claim_empleados");
        builder.Entity<IdentityUserLogin<string>>().ToTable("Dlk_cat_acc_login_empleados");
        builder.Entity<IdentityUserToken<string>>().ToTable("Dlk_cat_acc_token_empleados");
    }
}

// para añadir efectivamente los nuevos campos que hemos definido en el ApplicationUser
public class UserEntityConfiguration : IEntityTypeConfiguration<ApplicationUser>
{
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
        //builder.Property(usuario => usuario.UsuarioNombre).HasMaxLength(255);
        //builder.Property(usuario => usuario.UsuarioApellidos).HasMaxLength(255);
    }
}