using BibliotecaServicios.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace BibliotecaPresentacion.Intefaces
{
    public interface IPagosPresentacion
    {
        List<Pagos> Consultar();
        Pagos Guardar(Pagos entidad);

        Pagos Modificar(Pagos entidad);

        Pagos Eliminar(Pagos entidad);
    }
}
