using Microsoft.Extensions.Configuration;
using SimpleDnDTurnTracker.Data;
using SimpleDnDTurnTracker.Data.Repositories;
using SimpleDnDTurnTracker.Features;
using SimpleDnDTurnTracker.Features.Campaigns;
using SimpleInjector;
using SimpleInjector.Lifestyles;
using System.ComponentModel;
using Microsoft.EntityFrameworkCore;
using SimpleDnDTurnTracker.Util;
using Container = SimpleInjector.Container;

var builder = WebApplication.CreateBuilder(args);

//Injection
var container = new Container();
container.Options.DefaultLifestyle = Lifestyle.Scoped;
container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();
container.Register(typeof(IRequestHandler<,>), typeof(IRequestHandler<,>).Assembly, Lifestyle.Transient);
container.Register(typeof(IRepository<>), typeof(IRepository<>).Assembly, Lifestyle.Transient);

// Add services to the container.
builder.Services.AddDbContext<MainContext>(options => options.UseSqlite("Data Source=Application.db;Cache=Shared").EnableSensitiveDataLogging());
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSimpleInjector(container, options =>
{
    options.AddAspNetCore().AddControllerActivation();
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseInitDatabase();

app.UseHttpsRedirection();
app.UseAuthorization();

app.Services.UseSimpleInjector(container);

app.MapControllers();

app.Run();

