using Microsoft.EntityFrameworkCore;
using EticaretWebSitesi.Models.Siniflar; // Context burada
using Microsoft.AspNetCore.Authentication.Cookies; // Giriþ-çýkýþ için

var builder = WebApplication.CreateBuilder(args);

// Veritabaný baðlantýsýný ekle
builder.Services.AddDbContext<Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
        sqlOptions => sqlOptions.EnableRetryOnFailure()));

// Giriþ-çýkýþ (Cookie) ayarlarý
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Account/Login";  // Giriþ yapýlmamýþsa yönlendirilecek yer
        options.LogoutPath = "/Account/Logout";
        options.AccessDeniedPath = "/Account/AccessDenied";
        options.ExpireTimeSpan = TimeSpan.FromMinutes(30); // Oturum süresi
    });

// Session
builder.Services.AddSession();

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Middleware ayarlarý
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// ?? Bu ikisi önemli: Kimlik doðrulama ve session
app.UseAuthentication();
app.UseAuthorization();
app.UseSession();

// Varsayýlan rota
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Shop}/{action=MainMenu}/{id?}");

app.Run();
