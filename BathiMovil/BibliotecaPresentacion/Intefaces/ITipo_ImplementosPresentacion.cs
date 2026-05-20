using BibliotecaServicios.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace BibliotecaPresentacion.Intefaces
{
    public interface ITipo_ImplementosPresentacion
    {
        List<Tipo_Implementos> Consultar();
        Tipo_Implementos Guardar(Tipo_Implementos entidad);

        Tipo_Implementos Modificar(Tipo_Implementos entidad);

        Tipo_Implementos Eliminar(Tipo_Implementos entidad);
    }
}
