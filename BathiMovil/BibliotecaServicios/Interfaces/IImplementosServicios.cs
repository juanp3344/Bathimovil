using BibliotecaServicios.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace BibliotecaServicios.Interfaces
{
    public interface IImplementosServicios
    {
        List<Implementos> Consultar();
        Implementos Guardar(Implementos entidad);
        Implementos Modificar(Implementos entidad);
        Implementos Eliminar(Implementos entidad);
    }
}
