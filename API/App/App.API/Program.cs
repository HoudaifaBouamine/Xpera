using App.API.AuthenticationService;
using App.API.Data;
using App.API.Extentions;
using App.API.Extentions.DtosExtentions;
using App.API.Repositories.Implimentations;
using App.API.Repositories.Interfaces;
using App.API.Servises.Implimentations;
using App.API.Servises.Interfaces;
using AutoMapper;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAuthentication(Auth.Scheme.UserCookie)
    .AddCookie(Auth.Scheme.UserCookie);
builder.Services.AddAuthorization(conf =>
{
    conf.AddPolicy(Auth.Policy.RequireUser, p =>
    {
        p.RequireAuthenticatedUser();
    });
});
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddDbContext<AppDbContext>();
builder.Services.AddScoped<IUserRepository,UserRepositoryEF>();
builder.Services.AddScoped<IPostRepository,PostRepositoryEF>();
builder.Services.AddScoped<ICommandService,CommandService>();
builder.Services.AddScoped<IQueryService,QueryService>();
builder.Services.AddScoped<IAuthService, AuthService>();

var app = builder.Build();

app.UseConfigration();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
