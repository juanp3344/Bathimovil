using BibliotecaServicios.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace BibliotecaServicios.Interfaces
{
    public interface IPortatilesServicios
    {
        List<Portatiles> Consultar();
        Portatiles Guardar(Portatiles entidad);
        Portatiles Modificar(Portatiles entidad);
        Portatiles Eliminar(Portatiles entidad);
        List<Portatiles> ComprobarCantidad(Tipos_Portatiles entidad);
    }
}
