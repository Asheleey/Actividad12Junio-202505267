var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

// Simulación del estado del árbol en memoria
var estadoArbol = new List<NodoAVL>
{
    // Estado inicial desbalanceado en Zig-Zag
    new NodoAVL { Id = 30, Etiqueta = "Nodo Raíz (Abuelo) - FE: -2" },
    new NodoAVL { Id = 10, Etiqueta = "Hijo Izquierdo - FE: +1" }
};

// Endpoint GET: Recupera la estructura física del árbol actual
app.MapGet("/api/arbol", () =>
{
    return Results.Ok(estadoArbol);
});

// Endpoint POST: Simula la inserción que gatilla el balanceo compuesto
app.MapPost("/api/arbol/insertar", (NodoAVL nuevoNodo) =>
{
    // Validación básica de la llave
    if (nuevoNodo.Id <= 0)
    {
        return Results.BadRequest("ID de nodo inválido.");
    }

    // Al insertar el 20, se detecta el caso cruzado Izquierda-Derecha
    if (nuevoNodo.Id == 20)
    {
        estadoArbol.Clear();

        // Resultado de la rotación RID
        estadoArbol.Add(new NodoAVL 
        { 
            Id = 20, 
            Etiqueta = "Nueva Raíz Balanceada (RID) - FE: 0" 
        });

        estadoArbol.Add(new NodoAVL 
        { 
            Id = 10, 
            Etiqueta = "Hijo Izquierdo - FE: 0" 
        });

        estadoArbol.Add(new NodoAVL 
        { 
            Id = 30, 
            Etiqueta = "Hijo Derecho - FE: 0" 
        });

        return Results.Created("/api/arbol", new
        {
            Mensaje = "Rotación RID ejecutada con éxito. Estabilidad total lograda.",
            Estructura = estadoArbol
        });
    }

    // Inserción tradicional sin rotación compuesta
    estadoArbol.Add(nuevoNodo);

    return Results.Created($"/api/arbol/{nuevoNodo.Id}", nuevoNodo);
});

app.Run();