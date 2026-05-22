using BibliotecaServicios.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace BibliotecaPresentacion.Intefaces
{
    public interface IBodegasPresentacion
    {
        List<Bodegas> Consultar();
        Bodegas Guardar(Bodegas entidad);

        Bodegas Modificar(Bodegas entidad);

        Bodegas Eliminar(Bodegas entidad);
    }
}
