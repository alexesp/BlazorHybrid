using BlazorHybrid.Api.Data;
using BlazorHybrid.Api.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<IPasswordHasher<User>, PasswordHasher<User>>();

builder.Services.AddDbContext<QuizContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    options.UseSqlServer(connectionString);
});



var app = builder.Build();

//using var scope = app.Services.CreateScope();
//var context = scope.ServiceProvider.GetRequiredService<QuizContext>();

//if (context.Database.GetPendingMigrations().Any())
//{
//    await context.Database.MigrateAsync();
//}
//#if DEBUG
//ApplyDbMigrations(app.Services);
//#endif

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();





app.Run();


//static void ApplyDbMigrations(IServiceProvider sp)
//{
//    var scope = sp.CreateScope();
//    var context = scope.ServiceProvider.GetRequiredService<QuizContext>();

//    if (context.Database.GetPendingMigrations().Any())
//    {
//        context.Database.Migrate();
//    }
//}