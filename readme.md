# CSPharma-v4.2.2

## Introducción

En esta continuación de la v4.2.1 vamos a implementar el login con Google.

## Documentación y guías a seguir

- [Configuración de inicio de sesión externo de Google en ASP.NET Core](https://learn.microsoft.com/es-es/aspnet/core/security/authentication/social/google-logins?view=aspnetcore-7.0)

- [Google Authentication with .NET 6 Identity, a Web API & Blazor WebAssembly](https://www.youtube.com/watch?v=r3tytnzCuNw&ab_channel=PatrickGod)

# 1. Google Cloud Platform

El primer paso será ir a nuestra consola de Google Cloud, y creamos un nuevo proyecto.

Le ponemos un *nombre de proyecto* pero sin ninguna *organización*.

Ahora vamos al apartado de *Credenciales*, para configurar rápidamente la *pantalla de consentimiento*... 

- *UserType*: External
- *Información de la aplicación*: Nombre, Email de asistencia, Email del desarrollador
- *Permisos*: los tres primeros básicos de google
- *Usuarios de prueba*: añadir los emails que podrán hacer este login luego

El siguiente paso será crear una nueva credencial del tipo *ID de cliente de OAuth*...

- *Tipo de aplicación*: Aplicación Web
- *Nombre*: nombre de tu aplicación
- *URI de redireccionamiento autorizados*: https://localhost:{PORT}/signin-google

**(Copia el ClientId y el ClientSecret en tu portapapeles o pégalo en unas notas o algo)**

# 2. Instalar el paquete NuGet

- Microsoft.AspNetCore.Authentication.Google

# 3. *appsettings.json*

```json
"Authentication": {
    "Google": {
      "ClientId": "PegaAquíTuClientId",
      "ClientSecret": "PegaAquíTuClientSecret"
    }
  }
```

**Nota**: de forma alternativa y aportando aún más seguridad al ClientId y al ClientSecret, en vez de poner éstos en el *appsettings.json*, podríamos guardarlos en el "secret storage" de .NET a través de ejecutar un par de comandos de *dotnet*:

- `dotnet user-secrets init`
- `dotnet user-secrets set "Authentication:Google:ClientId" "PegaAquíTuClientId"`
- `dotnet user-secrets set "Authentication:Google:ClientSecret" "PegaAquíTuClientSecret"`

# 4. *Program.cs*

```csharp
// añadimos el servicio del login externo con Google
builder.Services.AddAuthentication()
    .AddGoogle(googleOptions =>
    {
        googleOptions.ClientId = builder.Configuration["Authentication:Google:ClientId"];
        googleOptions.ClientSecret = builder.Configuration["Authentication:Google:ClientSecret"];
    });
```

# 5. *Login.cshtml*

Para el paso final, si partíesemos desde cero, tendríamos que crear la entidad y tabla de Usuarios, y hacer una nueva página de razor (vista y controlador) para implementar este nuevo login...

Pero la realidad es que nosotros ya partimos de que en la v4.2.0 ya implementamos el login y register, además de todas las demás funcionalidades que Scaffold-Identity generaron automáticamente.

Es decir, nosotros en su día, ya hicimos una migración con las tablas de Scaffold-Identity entre las cuales vimos el uso de AspNetUsers, AspNetRoles, AspNetUserRoles... entre las demás tablas que se generaron.

¿Te acuerdas de cuando se autogeneró el Login.cshtml, que por defecto venía con un bloque de código, que mostraba a la derecha del login los demás proveedores externos (que no había ninguno en su momento) para hacer login externamente con Google por ejemplo? Pues ahora tenemos que recuperar ese bloque de código para volverlo a poner en nuestro login, ya que ese bloque de código conectaba a su vez, con los métodos de Scaffold para hacer login con proveedores externos... y sin nosotros saberlo, ya nos venía hecho todo!.

```html
@page
@model LoginModel

@{
    ViewData["Title"] = "Log in";
}

<link rel="stylesheet" href="~/css/Login.css" asp-append-version="true" />

@*<h1>@ViewData["Title"]</h1>*@

<div class="body">
    <div class="box">
        <form id="account" method="post" class="form">
            <h2>Sign In</h2>

            <div asp-validation-summary="ModelOnly" class="text-danger"></div>

            <div class="inputBox">
                <input asp-for="Input.Email" autocomplete="username" aria-required="true" />
                <span asp-for="Input.Email" class="span">Email</span>
                <span asp-validation-for="Input.Email" class="text-danger"></span>
                <i></i>
            </div>

            <div class="inputBox">
                <input asp-for="Input.Password" autocomplete="current-password" aria-required="true" />
                <span asp-for="Input.Password" class="span">Password</span>
                <span asp-validation-for="Input.Email" class="text-danger"></span>
                <i></i>
            </div>

            <!--
            <div>
                <div class="checkbox">
                    <label asp-for="Input.RememberMe" class="form-label">
                    <input class="form-check-input" asp-for="Input.RememberMe" />
                    @Html.DisplayNameFor(m => m.Input.RememberMe)
                    </label>
                </div>
            </div>
            -->

            <div class="links">
                <a id="forgot-password" asp-page="./ForgotPassword">Forgot Password</a>
                <a asp-page="./Register" asp-route-returnUrl="@Model.ReturnUrl">SignUp</a>
                <!--
                <a id="resend-confirmation" asp-page="./ResendEmailConfirmation">Resend email confirmation</a>
                -->
            </div>

            <input id="login-submit" type="submit" value="Login">
        </form>
<!-- comienzo del bloque de código rescatado -->
        <form id="external-account" asp-page="./ExternalLogin" asp-route-returnUrl="@Model.ReturnUrl" method="post" class="form2">
            <div>
                <p>
                    @foreach (var provider in Model.ExternalLogins)
                    {
                        <button type="submit" name="provider" value="@provider.Name" title="Log in using your @provider.DisplayName account">@provider.DisplayName</button>
                    }
                </p>
            </div>
        </form>
<!-- fin del bloque de código rescatado -->
    </div>
</div>

@section Scripts {
    <partial name="_ValidationScriptsPartial" />
}
```

**Nota**: [Puedes consultar mi css aquí](./CSPharma-v4.1/wwwroot/css/Login.css)

**Nota**: Para esta nueva versión, con el fin de evitar errores de null/undefined o para evitar trastocar más las vistas y controladores, decidí eliminar los campos de *UsuarioNombre* y *UsuarioApellidos* que en su día añadí a la entidad del IdentityUser (AspNetUsers). 

A fin de cuentas, ya aprendimos tanto a añadir nuevos campos, como a eliminar algunos otros, y hasta modificar sus nombres.

# Resultado final

[Prueba de ejecución - Login con Google](https://github.com/csi21-sdiapos/CSPharma-v4.2.2/issues/1)