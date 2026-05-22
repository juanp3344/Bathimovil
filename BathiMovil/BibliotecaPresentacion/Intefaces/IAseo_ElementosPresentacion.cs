using BibliotecaServicios.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace BibliotecaPresentacion.Intefaces
{
    public interface IAseo_ElementosPresentacion
    {
        List<Aseo_Elementos> Consultar();
        Aseo_Elementos Guardar(Aseo_Elementos entidad);

        Aseo_Elementos Modificar(Aseo_Elementos entidad);

        Aseo_Elementos Eliminar(Aseo_Elementos entidad);
    }
}
