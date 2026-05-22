using BibliotecaServicios.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace BibliotecaPresentacion.Intefaces
{
    public interface IPrestamosPresentacion
    {
        List<Prestamos> Consultar();
        Prestamos Guardar(Prestamos entidad);

        Prestamos Modificar(Prestamos entidad);

        Prestamos Eliminar(Prestamos entidad);
    }
}
