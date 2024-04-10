using Microsoft.AspNetCore.Authentication.Cookies;
/*
 * https://metanit.com/sharp/aspnet5/15.1.php
 * https://metanit.com/sharp/aspnet6/13.1.php
 */
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMvc();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).
    AddCookie(option =>
    {
        option.LoginPath = new PathString("/Autorization/Login");
        option.LogoutPath = new PathString("/Home/Homepage");
    });

builder.Services.AddAuthorization();

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();

app.UseStaticFiles();

app.MapControllerRoute(
    name:"default",
    pattern:"{Controller=Home}/{Action=HomePage}"
    );
//app.MapGet("/", () => "Hello World!");

app.Run();
