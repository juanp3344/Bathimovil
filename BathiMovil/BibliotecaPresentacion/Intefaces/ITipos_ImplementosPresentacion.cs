using BibliotecaServicios.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace BibliotecaPresentacion.Intefaces
{
    public interface ITipos_ImplementosPresentacion
    {
        List<Tipos_Implementos> Consultar();
        Tipos_Implementos Guardar(Tipos_Implementos entidad);

        Tipos_Implementos Modificar(Tipos_Implementos entidad);

        Tipos_Implementos Eliminar(Tipos_Implementos entidad);
    }
}
