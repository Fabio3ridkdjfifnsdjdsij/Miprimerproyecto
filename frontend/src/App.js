import { BrowserRouter, Routes, Route } from "react-router-dom";
import Inicio from "./paginas/Inicio";
import ServicioDetalle from "./componentes/ServicioDetalle";

function App() {
  return (
    <BrowserRouter>
      <Routes>
        <Route path="/" element={<Inicio />} />
        <Route path="/servicios/:id" element={<ServicioDetalle />} />
      </Routes>
    </BrowserRouter>
  );
}

export default App;