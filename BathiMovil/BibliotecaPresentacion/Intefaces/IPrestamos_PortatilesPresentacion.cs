using BibliotecaServicios.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace BibliotecaPresentacion.Intefaces
{
    public interface IPrestamos_PortatilesPresentacion
    {
        List<Prestamos_Portatiles> Consultar();
        Prestamos_Portatiles Guardar(Prestamos_Portatiles entidad);

        Prestamos_Portatiles Modificar(Prestamos_Portatiles entidad);

        Prestamos_Portatiles Eliminar(Prestamos_Portatiles entidad);
    }
}
