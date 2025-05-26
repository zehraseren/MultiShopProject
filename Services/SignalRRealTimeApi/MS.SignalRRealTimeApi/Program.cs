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
        // Ne yapar?: T�m HTTP metodlar�na izin verir (GET, POST, PUT, DELETE, vb.).
        // Neden kullan�l�r?: API'ye tam eri�im sa�lamak ve k�s�tlama olmadan t�m i�lemlerin yap�labilmesi i�in.
        .AllowAnyHeader()
        // Ne yapar?: Her t�rl� HTTP ba�l���n� kabul eder.
        // Neden kullan�l�r?: Farkl� kaynaklardan gelen �zel ba�l�klar�(Authorization, Content - Type, vb.) kabul edebilmek i�in.
        .SetIsOriginAllowed((host) => true)
        // Ne yapar?: Herhangi bir kaynaktan gelen isteklere izin verir.
        // Neden kullan�l�r?: Uygulaman�n her t�rl� d�� kaynaktan eri�ilebilir olmas�n� sa�lamak i�in.
        .AllowCredentials();
        // Ne yapar?: Kimlik bilgilerini (�erezler, oturum bilgilerinin) i�eren isteklere izin verir.
        // Neden kullan�l�r?: Kimlik do�rulama ve oturum y�netimi i�lemlerinde g�venli veri al��veri�ini sa�lamak i�in.
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
