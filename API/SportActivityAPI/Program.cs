using SportActivityAPI;
using SportActivityAPI.Repository.Extension;
using SportActivityAPI.Service.Implementations;
using SportActivityAPI.Service.Interfaces;

var builder = WebApplication.CreateBuilder(args);

IConfiguration configuration = new ConfigurationBuilder()
                            .AddJsonFile("appsettings.json")
                            .Build();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Database connection
builder.Services.ConfigureMySqlContext(configuration);
builder.Services.ConfigureRepositoryDependencies();

// Configure automapper.
builder.Services.AddAutoMapper(typeof(MappingProfile));

//Configure services
//builder.Services.ConfigureServices();
builder.Services.AddScoped<IUserService, UserService>();

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
