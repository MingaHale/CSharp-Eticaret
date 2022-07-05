using Bussiness.Extensions;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews().AddFluentValidation();

//Bussines i�erisindeki dependency injection ile �retilen yap�y� buraya �ekiyoruz.
builder.Services.MyService();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(x =>
{
    x.AccessDeniedPath = "/admin/AccessDenied";
    x.LoginPath = "/Admin/Login";
    x.LogoutPath = "/admin/Logout";
});

var app = builder.Build();

//Developer hesab�nda ise hatalar g�z�ks�n, Canl�daysa g�z�kmesin
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseStatusCodePagesWithReExecute("/ExceptionError");
}

app.UseRouting();
app.UseStaticFiles();//Resimleri aktif ediyoruz
app.UseAuthentication();//Kullan�c� giri� kontrol� yapan middleware'i aktif ediyoruz
app.UseAuthorization();//Kullan�c� yetki kontrol� yapan Middleware'i aktif ediyoruz
app.UseEndpoints(x => 
{ 
    x.MapDefaultControllerRoute(); 
});

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
});


app.Run();
