using BibliotecaServicios.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace BibliotecaPresentacion.Intefaces
{
    public interface IRoles_PermisosPresentacion
    {
        List<Roles_Permisos> Consultar();
        Roles_Permisos Guardar(Roles_Permisos entidad);

        Roles_Permisos Modificar(Roles_Permisos entidad);

        Roles_Permisos Eliminar(Roles_Permisos entidad);
    }
}
