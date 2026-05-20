using BibliotecaServicios.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace BibliotecaServicios.Interfaces
{
    public interface IMantenimientosServicios
    {
        List<Mantenimientos> Consultar();
        Mantenimientos Guardar(Mantenimientos entidad);
        Mantenimientos Modificar(Mantenimientos entidad);
        Mantenimientos Eliminar(Mantenimientos entidad);
    }
}
