using BibliotecaServicios.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace BibliotecaServicios.Interfaces
{
    public interface IPagosServicios
    {
        List<Pagos> Consultar();
        Pagos Guardar(Pagos entidad);
        Pagos Modificar(Pagos entidad);
        Pagos Eliminar(Pagos entidad);
    }
}
