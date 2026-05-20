using BibliotecaServicios.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace BibliotecaPresentacion.Intefaces
{
    public interface IPersonasPresentacion
    {
        List<Personas> Consultar();
        Personas Guardar(Personas entidad);

        Personas Modificar(Personas entidad);

        Personas Eliminar(Personas entidad);
    }
}
