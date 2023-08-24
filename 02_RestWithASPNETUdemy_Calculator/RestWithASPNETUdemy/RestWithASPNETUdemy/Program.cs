using Microsoft.Extensions.DependencyInjection;
using RestWithASPNETUdemy.Services;
using RestWithASPNETUdemy.Services.Implementations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.



builder.Services.AddControllers();
//dependecy Ijection
builder.Services.AddScoped<IPersonService, PersonServiceImplementation>();

var app = builder.Build();



//var scope = app.Services.CreateScope<IPersonService,PersonServiceImplementation>();


// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
