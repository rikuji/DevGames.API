using DevGames.API.Mappers;
using DevGames.API.Persistence;
using DevGames.API.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DevGames");

builder.Services
    .AddDbContext<DevGamesContext>(o =>
        o.UseSqlServer(connectionString));

builder.Services.AddScoped<IBoardRepository, BoardRepository>();
builder.Services.AddScoped<IPostRepository, PostRepository>();

builder.Services.AddAutoMapper(typeof(BoardMapper));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
