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
// Resources klasörünü kaynak (resx) dosyalarýnýn yeri olarak belirtilir
builder.Services.AddLocalization(opt => { opt.ResourcesPath = "Resources"; });

// MVC yapýlandýrmasý:
// ViewLocalization ile Razor View'lar için çeviri desteði eklenir
// DataAnnotationsLocalization ile model doðrulama mesajlarý çevirilebilir hale getirilir
builder.Services.AddControllersWithViews()
    .AddViewLocalization() // _ViewImports.cshtml üzerinden kullanýlacak @Localizer eriþimi buradan saðlanýr
    .AddDataAnnotationsLocalization(opt =>
    {
        // Bu delegate, hangi sýnýfýn hangi resource dosyasýna baðlanacaðýný tanýmlar
        // AppResource, ortak doðrulama metinleri için kullanýlan sýnýf
        opt.DataAnnotationLocalizerProvider = (type, factory) =>
        {
            var assembly = new AssemblyName(typeof(SharedResources).GetTypeInfo().Assembly.FullName);
            return factory.Create(nameof(SharedResources), assembly.Name);
        };
    });


// Request bazlý localization ayarlarý yapýlandýrýlýr
// Burada desteklenen kültürler (culture ve uiCulture) tanýmlanýr
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

    // Uygulamanýn varsayýlan dili tr-TR olarak ayarlanýr
    opt.DefaultRequestCulture = new RequestCulture(culture: "tr-TR", uiCulture: "tr-TR");
    // Kültürel biçimlendirme (tarih, sayý vs.) için desteklenen kültürler
    opt.SupportedCultures = cultures;
    // UI çeviri desteði için desteklenen diller (resx dosyalarýna karþýlýk gelir)
    opt.SupportedUICultures = cultures;
    // Kullanýcýnýn tercih ettiði kültür (dil) belirlenirken farklý kaynaklar kontrol edilir
    // Bu liste, kültürün hangi öncelik sýrasýna göre belirleneceðini tanýmlar:
    opt.RequestCultureProviders = new List<IRequestCultureProvider>
    {
        // 1. Öncelik: Daha önce seçilmiþ ve tarayýcýya gönderilen çerezde dil bilgisi kontrol edilir
        new CookieRequestCultureProvider(),
        // 2. Öncelik: URL'de query string üzerinden dil bilgisi aranýr (?culture=en-US gibi)
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

// Yukarýda tanýmlanan RequestLocalizationOptions'ý uygulamaya entegre edilir
var localizationOptions = app.Services.GetRequiredService<IOptions<RequestLocalizationOptions>>().Value;
// Middleware olarak UseRequestLocalization çaðrýlarak tüm request'ler için geçerli hale gelir
app.UseRequestLocalization(localizationOptions);

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.Run();
