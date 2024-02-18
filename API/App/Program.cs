using App.API.AuthenticationService;
using App.API.Data;
using App.API.Extentions;
using App.API.Repositories.Comment;
using App.API.Repositories.PostRepository;
using App.API.Repositories.UserRepository;
using App.API.Services.Interfaces;
using App.API.Servises.Implimentations;
using Microsoft.AspNetCore.Http.HttpResults;

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
builder.Services.AddScoped<IUserRepository, UserRepositoryEF>();
builder.Services.AddScoped<IPostRepository, PostRepositoryEF>();
builder.Services.AddScoped<ICommentRepository,CommentRepository >();
builder.Services.AddScoped<ICommandService,CommandService>();
builder.Services.AddScoped<IQueryService, QueryServiceEF>();
builder.Services.AddScoped<IAuthService, AuthService>();

var app = builder.Build();

app.UseConfigration();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapGet("/", () =>
{
    return Results.Redirect( "/swagger/index.html" );
});

app.Run();