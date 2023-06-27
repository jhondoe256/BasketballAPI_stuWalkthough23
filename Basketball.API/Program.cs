
using Basketball.Data.Context;
using Basketball.Models.MappingConfigurations;
using Basketball.Services.PlayerServices;
using Basketball.Services.PositionServices;
using Basketball.Services.TeamServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<BasketBallDbContext>(options => options
                            .UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddScoped<ITeamService, TeamService>();
builder.Services.AddScoped<IPositionService, PositionService>();
builder.Services.AddScoped<IPlayerServiceNameTeam, PlayerService>();


builder.Services.AddAutoMapper(typeof(Mapper));
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
