using Bussiness.Extensions;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews().AddFluentValidation();

//Bussines içerisindeki dependency injection ile üretilen yapýyý buraya çekiyoruz.
builder.Services.MyService();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(x =>
{
    x.AccessDeniedPath = "/admin/AccessDenied";
    x.LoginPath = "/Admin/Login";
    x.LogoutPath = "/admin/Logout";
});

var app = builder.Build();

//Developer hesabýnda ise hatalar gözüksün, Canlýdaysa gözükmesin
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
app.UseAuthentication();//Kullanýcý giriþ kontrolü yapan middleware'i aktif ediyoruz
app.UseAuthorization();//Kullanýcý yetki kontrolü yapan Middleware'i aktif ediyoruz
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
