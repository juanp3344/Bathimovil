using BibliotecaServicios.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace BibliotecaPresentacion.Intefaces
{
    public interface IPortatilesPresentacion
    {
        List<Portatiles> Consultar();
        Portatiles Guardar(Portatiles entidad);

        Portatiles Modificar(Portatiles entidad);

        Portatiles Eliminar(Portatiles entidad);
    }
}
