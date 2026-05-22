using BibliotecaServicios.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace BibliotecaPresentacion.Intefaces
{
    public interface IRolesPresentacion
    {
        List<Roles_Empleados> Consultar();
        Roles_Empleados Guardar(Roles_Empleados entidad);

        Roles_Empleados Modificar(Roles_Empleados entidad);

        Roles_Empleados Eliminar(Roles_Empleados entidad);
    }
}
