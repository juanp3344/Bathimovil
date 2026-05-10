using BibliotecaServicios.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace BibliotecaServicios.Interfaces
{
    public interface ITipo_Aseo_ElementosServicios
    {
        List<Tipo_Aseo_Elementos> Consultar();
        Tipo_Aseo_Elementos Guardar(Tipo_Aseo_Elementos entidad);
        Tipo_Aseo_Elementos Modificar(Tipo_Aseo_Elementos entidad);
        Tipo_Aseo_Elementos Eliminar(Tipo_Aseo_Elementos entidad);
    }
}
