using Microsoft.EntityFrameworkCore;
using PManager.Core.Repositories;
using PManager.Core.Services;
using PManager.Core.UnitOfWorks;
using PManager.Repository;
using PManager.Repository.UnitOfWorks;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



builder.Services.AddScoped<IUnitOfWorks,UnitOfWork>();
builder.Services.AddScoped(typeof(IGenericRepository<>),typeof(IGenericRepository<>));
//builder.Services.AddScoped(typeof(Iservice<>), typeof(Service<>));

builder.Services.AddDbContext<AppDbContext>(x =>
{
    x.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection"), option =>

    {
        //tip g�venli�i i�in dinamik assembly ismi veriyoruz
        option.MigrationsAssembly(Assembly.GetAssembly(typeof(AppContext)).GetName().Name);
    });

});

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
