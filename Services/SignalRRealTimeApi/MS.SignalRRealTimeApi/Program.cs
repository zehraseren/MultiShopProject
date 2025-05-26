using MS.SignalRRealTimeApi.Hubs;
using MS.SignalRRealTimeApi.Services.SignalRCommentServices;
using MS.SignalRRealTimeApi.Services.SignalRMessageServices;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient();

builder.Services.AddCors(opt =>
{
    opt.AddPolicy("CorsPolicy", builder =>
    {
        builder.AllowAnyMethod()
        // Ne yapar?: Tüm HTTP metodlarýna izin verir (GET, POST, PUT, DELETE, vb.).
        // Neden kullanýlýr?: API'ye tam eriþim saðlamak ve kýsýtlama olmadan tüm iþlemlerin yapýlabilmesi için.
        .AllowAnyHeader()
        // Ne yapar?: Her türlü HTTP baþlýðýný kabul eder.
        // Neden kullanýlýr?: Farklý kaynaklardan gelen özel baþlýklarý(Authorization, Content - Type, vb.) kabul edebilmek için.
        .SetIsOriginAllowed((host) => true)
        // Ne yapar?: Herhangi bir kaynaktan gelen isteklere izin verir.
        // Neden kullanýlýr?: Uygulamanýn her türlü dýþ kaynaktan eriþilebilir olmasýný saðlamak için.
        .AllowCredentials();
        // Ne yapar?: Kimlik bilgilerini (çerezler, oturum bilgilerinin) içeren isteklere izin verir.
        // Neden kullanýlýr?: Kimlik doðrulama ve oturum yönetimi iþlemlerinde güvenli veri alýþveriþini saðlamak için.
    });
});

builder.Services.AddSignalR();

builder.Services.AddScoped<ISignalRCommentServices, SignalRCommentServices>();
builder.Services.AddScoped<ISignalRMessageServices, SignalRMessageServices>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("CorsPolicy");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapHub<SignalRHub>("/SignalRHub");

app.Run();
