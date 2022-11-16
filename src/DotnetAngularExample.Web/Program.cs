using DotnetAngularExample.Core.Domain.Entities;
using DotnetAngularExample.Core.Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSqlServer<MyAppDbContext>(builder.Configuration.GetConnectionString("Default"));

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.MapFallbackToFile("index.html");

SeedDemoData();

app.Run();


void SeedDemoData()
{
    using var scope = app.Services.CreateScope();
    var context = scope.ServiceProvider.GetRequiredService<MyAppDbContext>();

    if (!context.Customers.Any())
    {
        for (int i = 0; i < 100; i++)
        {
            context.Customers.Add(new Customer
            {
                Name = $"Customer No. {i}",
                Email = $"Email No. {i}"
            });
        }

        context.SaveChanges();
    }
}