using BibliotecaServicios.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace BibliotecaServicios.Interfaces
{
    public interface IMantenimientoServicios
    {
        List<Mantenimiento> Consultar();
        Mantenimiento Guardar(Mantenimiento entidad);
        Mantenimiento Modificar(Mantenimiento entidad);
        Mantenimiento Eliminar(Mantenimiento entidad);
    }
}
