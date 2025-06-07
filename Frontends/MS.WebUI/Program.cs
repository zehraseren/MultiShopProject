using System.Reflection;
using MS.WebUI.Container;
using System.Globalization;
using MS.WebUI.Resources;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddCookie(JwtBearerDefaults.AuthenticationScheme, opt =>
{
    opt.LoginPath = "/Login/Index/";
    opt.LogoutPath = "/Login/LogOut/";
    opt.AccessDeniedPath = "/Pages/AccessDenied/";
    opt.Cookie.HttpOnly = true;
    opt.Cookie.SameSite = SameSiteMode.Strict;
    opt.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
    opt.Cookie.Name = "MultiShopJwt";
});

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, opt =>
{
    opt.LoginPath = "/Login/Index/";
    opt.ExpireTimeSpan = TimeSpan.FromDays(5);
    opt.Cookie.Name = "MultiShopCookie";
    opt.SlidingExpiration = true;
});

builder.Services.AddMemoryCache();
builder.Services.AddHttpContextAccessor();
builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient();
builder.Services.ContainerDependencies(builder.Configuration);

#region Language Localization

// Localization servisleri projeye eklenir
// Resources klas�r�n� kaynak (resx) dosyalar�n�n yeri olarak belirtilir
builder.Services.AddLocalization(opt => { opt.ResourcesPath = "Resources"; });

// MVC yap�land�rmas�:
// ViewLocalization ile Razor View'lar i�in �eviri deste�i eklenir
// DataAnnotationsLocalization ile model do�rulama mesajlar� �evirilebilir hale getirilir
builder.Services.AddControllersWithViews()
    .AddViewLocalization() // _ViewImports.cshtml �zerinden kullan�lacak @Localizer eri�imi buradan sa�lan�r
    .AddDataAnnotationsLocalization(opt =>
    {
        // Bu delegate, hangi s�n�f�n hangi resource dosyas�na ba�lanaca��n� tan�mlar
        // AppResource, ortak do�rulama metinleri i�in kullan�lan s�n�f
        opt.DataAnnotationLocalizerProvider = (type, factory) =>
        {
            var assembly = new AssemblyName(typeof(SharedResources).GetTypeInfo().Assembly.FullName);
            return factory.Create(nameof(SharedResources), assembly.Name);
        };
    });


// Request bazl� localization ayarlar� yap�land�r�l�r
// Burada desteklenen k�lt�rler (culture ve uiCulture) tan�mlan�r
builder.Services.Configure<RequestLocalizationOptions>(opt =>
{
    var cultures = new List<CultureInfo>
    {
        new CultureInfo("tr-TR"),
        new CultureInfo("en-US"),
        new CultureInfo("de-DE"),
        new CultureInfo("fr-FR"),
        new CultureInfo("it-IT")
    };

    // Uygulaman�n varsay�lan dili tr-TR olarak ayarlan�r
    opt.DefaultRequestCulture = new RequestCulture(culture: "tr-TR", uiCulture: "tr-TR");
    // K�lt�rel bi�imlendirme (tarih, say� vs.) i�in desteklenen k�lt�rler
    opt.SupportedCultures = cultures;
    // UI �eviri deste�i i�in desteklenen diller (resx dosyalar�na kar��l�k gelir)
    opt.SupportedUICultures = cultures;
    // Kullan�c�n�n tercih etti�i k�lt�r (dil) belirlenirken farkl� kaynaklar kontrol edilir
    // Bu liste, k�lt�r�n hangi �ncelik s�ras�na g�re belirlenece�ini tan�mlar:
    opt.RequestCultureProviders = new List<IRequestCultureProvider>
    {
        // 1. �ncelik: Daha �nce se�ilmi� ve taray�c�ya g�nderilen �erezde dil bilgisi kontrol edilir
        new CookieRequestCultureProvider(),
        // 2. �ncelik: URL'de query string �zerinden dil bilgisi aran�r (?culture=en-US gibi)
        new QueryStringRequestCultureProvider()
    };
});

#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

// Yukar�da tan�mlanan RequestLocalizationOptions'� uygulamaya entegre edilir
var localizationOptions = app.Services.GetRequiredService<IOptions<RequestLocalizationOptions>>().Value;
// Middleware olarak UseRequestLocalization �a�r�larak t�m request'ler i�in ge�erli hale gelir
app.UseRequestLocalization(localizationOptions);

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.Run();
