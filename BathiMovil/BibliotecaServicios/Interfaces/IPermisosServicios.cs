using BibliotecaServicios.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace BibliotecaServicios.Interfaces
{
    public interface IPermisosServicios
    {
        List<Permisos> Consultar();
        Permisos Guardar(Permisos entidad);
        Permisos Modificar(Permisos entidad);
        Permisos Eliminar(Permisos entidad);
    }
}
