var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
//productos
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var productos = new List<Productos>();

app.MapGet("/productos", () =>
{
    return productos;
});

app.MapGet("/productos/{id}", (int id) =>
{
    var producto = productos.FirstOrDefault(c => c.Id == id);
});

internal class Productos
{
    public int Id { get; set; }

    public String Nombre { get; set; }

    public int Cantidad { get; set; }
}
