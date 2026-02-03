var builder = WebApplication.CreateBuilder(args);

// 1. Agregar servicios básicos
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

// 2. CONFIGURACIÓN DE CORS: Permite que tu Frontend de Render se conecte
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy => policy.AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod());
});

var app = builder.Build();

// 3. HABILITAR CORS: Debe ir antes de MapControllers
app.UseCors("AllowAll");

// 4. MAPEO DE CONTROLADORES: Debe estar FUERA de cualquier 'if' 
// para que funcione en producción (Render)
app.MapControllers();

// 5. Configuración para desarrollo (Opcional)
if (app.Environment.IsDevelopment())
{
    // Aquí podrías habilitar Swagger si lo necesitas localmente
}

// 6. Endpoint de prueba rápido
app.MapGet("/", () => "API Funcionando correctamente en Render!");

app.Run();