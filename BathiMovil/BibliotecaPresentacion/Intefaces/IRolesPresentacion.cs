using BibliotecaServicios.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace BibliotecaPresentacion.Intefaces
{
    public interface IRolesPresentacion
    {
        List<Roles> Consultar();
        Roles Guardar(Roles entidad);

        Roles Modificar(Roles entidad);

        Roles Eliminar(Roles entidad);
    }
}
