using App.API.Data;
using App.API.Repositories.Implimentations;
using App.API.Repositories.Interfaces;
using App.API.Servises.Implimentations;
using App.API.Servises.Interfaces;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>();
builder.Services.AddScoped<IUserRepository,UserRepositoryEF>();
builder.Services.AddScoped<IPostRepository,PostRepositoryEF>();
builder.Services.AddScoped<ICommandService,CommandService>();
builder.Services.AddScoped<IQueryService,QueryService>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
