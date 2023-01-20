using KartuliEnaApi.Models;
using KartuliEnaApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<WordDatabaseSettings>(builder.Configuration.GetSection("WordDatabase"));
builder.Services.Configure<TagDatabaseSettings>(builder.Configuration.GetSection("TagDatabase"));
builder.Services.AddSingleton<WordServices>();
builder.Services.AddSingleton<TagServices>();
builder.Services.AddControllers()
    .AddJsonOptions(
        options => options.JsonSerializerOptions.PropertyNamingPolicy = null);
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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
