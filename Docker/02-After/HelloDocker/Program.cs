using HelloDocker.Services;

var builder = WebApplication.CreateBuilder(args);

// Adiciona suporte a controllers
builder.Services.AddControllers();

// Registra o servi�o concreto
builder.Services.AddScoped<InstanceInformationService>();

// Configura a porta programaticamente (CORRETO no .NET 10)
builder.WebHost.UseUrls("http://*:5000");
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseRouting();
app.UseAuthorization();
app.MapControllers();

app.Run();