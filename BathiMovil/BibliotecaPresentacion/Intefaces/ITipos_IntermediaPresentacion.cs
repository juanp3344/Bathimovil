using BibliotecaServicios.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace BibliotecaPresentacion.Intefaces
{
    public interface ITipos_IntermediaPresentacion
    {
        List<Tipos_Intermedia> Consultar();
        Tipos_Intermedia Guardar(Tipos_Intermedia entidad);

        Tipos_Intermedia Modificar(Tipos_Intermedia entidad);

        Tipos_Intermedia Eliminar(Tipos_Intermedia entidad);
    }
}
