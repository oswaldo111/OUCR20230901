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
    return producto;
});

app.MapPost("/productos", (Productos Producto) =>
{
    productos.Add(Producto);
    return Results.Ok();
});

app.MapPut("/productos/{id}", (int id, Productos producto) =>
{
    var existingProducs = productos.FirstOrDefault(c => c.Id == id);

    if (existingProducs != null)
    {
        existingProducs.Nombre = producto.Nombre;
        existingProducs.Cantidad = producto.Cantidad;
        return Results.Ok();
    }
    else return Results.NotFound();
});

app.MapDelete("/productos/{id}", (int id) =>
{
    var existingProduc = productos.FirstOrDefault(c => c.Id == id);
    if (existingProduc != null) {
        productos.Remove(existingProduc);
        return Results.Ok();
    }
    else return Results.NotFound();
});

app.Run();

internal class Productos
{
    public int Id { get; set; }

    public String Nombre { get; set; }

    public int Cantidad { get; set; }
}
