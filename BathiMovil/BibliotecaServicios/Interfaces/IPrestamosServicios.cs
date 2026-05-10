using BibliotecaServicios.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace BibliotecaServicios.Interfaces
{
    public interface IPrestamosServicios
    {
        List<Prestamos> Consultar();
        Prestamos Guardar(Prestamos entidad);
        Prestamos Modificar(Prestamos entidad);
        Prestamos Eliminar(Prestamos entidad);
    }
}
