function ServiceCard({ servicio, onEdit }) { // <--- Agregamos onEdit aquí
  return (
    <div className="service-item"> {/* Nota: En React usa className en vez de class */}
      <h3>{servicio.nombre}</h3>
      <p>{servicio.descripcion}</p>

      {/* Ahora usamos la función que viene por props */}
      <button onClick={() => onEdit(servicio)}>Editar</button>
    </div>
  );
}
export default ServiceCard;