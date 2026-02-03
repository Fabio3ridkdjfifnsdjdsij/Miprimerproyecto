using Microsoft.AspNetCore.Mvc;

namespace backend_api.Controllers;

[ApiController]
[Route("api/servicios")]
public class ServiciosController : ControllerBase
{
    private static readonly List<ServicioDto> _servicios = new()
    {
        new ServicioDto { Id = 1, Nombre = "Soporte TI", Descripcion = "Soporte técnico empresarial" },
        new ServicioDto { Id = 2, Nombre = "Desarrollo Web", Descripcion = "Aplicaciones web modernas" },
        new ServicioDto { Id = 3, Nombre = "Consultoría", Descripcion = "Asesoría tecnológica" }
    };

//marca un método en el backend, para:
    //traer datos
    //consultar informacion
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_servicios);
    }

    public class CrearServicioRequest
    {
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
    }

//marca un método en el backend, para:
    //enviar datos al servidor
    //enviar datos al servidor
    //guardar un registro
    [HttpPost]
    public IActionResult Post([FromBody] CrearServicioRequest req)
    {
        if (req == null || string.IsNullOrWhiteSpace(req.Nombre) || string.IsNullOrWhiteSpace(req.Descripcion))
            return BadRequest("Nombre y descripción son obligatorios.");

        var nuevoId = _servicios.Count == 0 ? 1 : _servicios.Max(s => s.Id) + 1;

        var nuevo = new ServicioDto
        {
            Id = nuevoId,
            Nombre = req.Nombre.Trim(),
            Descripcion = req.Descripcion.Trim()
        };

        _servicios.Add(nuevo);

        return Ok(nuevo);
    }

    //lo nuevo

    public class ActualizarServicioRequest
    {
        public string? Nombre {get; set;}

        public string? Descripcion {get; set;}  
    }

    [HttpPut("{id:int}")]

    public IActionResult Put(int id, [FromBody] ActualizarServicioRequest req)
    {
        // 1. Buscamos el servicio en la lista estática
        var existente = _servicios.FirstOrDefault(s => s.Id == id);
        
        // 2. Si no existe, devolvemos 404
        if (existente == null) return NotFound("Servicio no encontrado.");

        // 3. Validamos que los datos no vengan vacíos
        if (req == null || string.IsNullOrWhiteSpace(req.Nombre) || string.IsNullOrWhiteSpace(req.Descripcion))
            return BadRequest("Nombre y descripción son obligatorios.");

        // 4. Actualizamos los valores del objeto existente
        existente.Nombre = req.Nombre.Trim();
        existente.Descripcion = req.Descripcion.Trim();

        // 5. Devolvemos el objeto actualizado
        return Ok(existente);
    }


    public class ServicioDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = "";
        public string Descripcion { get; set; } = "";
    }
}