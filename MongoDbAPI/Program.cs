using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

var connectionString = "mongodb+srv://Kendall2300:Chocolate@nutritecp2.0mapdar.mongodb.net/?retryWrites=true&w=majority";
var settings = MongoClientSettings.FromConnectionString(connectionString);
settings.ServerSelectionTimeout = TimeSpan.FromSeconds(60); // Aumenta el tiempo de espera a 60 segundos
var client = new MongoClient(settings);

// Add services to the container.

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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
