var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/loterry/numbers", () =>
{
    var numbers = new List<int>();
    var random = new Random();
    for (int i = 0; i < 6; i++)
    {
        numbers.Add(random.Next(1, 61));
    }
    return numbers;
}).WithName("get-lottery_numbers")
.WithOpenApi();

app.Run();

