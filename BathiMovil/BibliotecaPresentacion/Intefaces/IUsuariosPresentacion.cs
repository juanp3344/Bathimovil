using BibliotecaServicios.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace BibliotecaPresentacion.Intefaces
{
    public interface IUsuariosPresentacion
    {
        List<Usuarios> Consultar();
        Usuarios Guardar(Usuarios entidad);

        Usuarios Modificar(Usuarios entidad);

        Usuarios Eliminar(Usuarios entidad);
    }
}
