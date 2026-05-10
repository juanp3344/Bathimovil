using BibliotecaServicios.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace BibliotecaServicios.Interfaces
{
    public interface ITipos_IntermediaServicios
    {
        List<Tipos_Intermedia> Consultar();
        Tipos_Intermedia Guardar(Tipos_Intermedia entidad);
        Tipos_Intermedia Modificar(Tipos_Intermedia entidad);
        Tipos_Intermedia Eliminar(Tipos_Intermedia entidad);
    }
}
