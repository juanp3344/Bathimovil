using BibliotecaServicios.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace BibliotecaServicios.Interfaces
{
    public interface IPrestamos_PortatilesServicios
    {
        List<Prestamos_Portatiles> Consultar();
        Prestamos_Portatiles Guardar(Prestamos_Portatiles entidad);
        Prestamos_Portatiles Modificar(Prestamos_Portatiles entidad);
        Prestamos_Portatiles Eliminar(Prestamos_Portatiles entidad);
    }
}
