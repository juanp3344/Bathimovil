using BibliotecaServicios.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace BibliotecaServicios.Interfaces
{
    public interface ITipos_PortatilesServicios
    {
        List<Tipos_Portatiles> Consultar();
        Tipos_Portatiles Guardar(Tipos_Portatiles entidad);
        Tipos_Portatiles Modificar(Tipos_Portatiles entidad);
        Tipos_Portatiles Eliminar(Tipos_Portatiles entidad);
    }
}
