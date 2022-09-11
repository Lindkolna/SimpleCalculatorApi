using Microsoft.EntityFrameworkCore;
using MinimalApiCalculator;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApiDbContext>(options => options.UseInMemoryDatabase("SimpleCalculatorApi"));

var app = builder.Build();

app.MapGet("/calculator", async (ApiDbContext db) =>
await db.Calculators.ToListAsync());
app.MapPost("/calculator", async (Calculator calculator, ApiDbContext db) =>
{
    db.Calculators.Add(calculator);
    await db.SaveChangesAsync();
    return Results.Created($"/calculator/{calculator.Id}", calculator);
});


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Run();
