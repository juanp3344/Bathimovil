using BibliotecaServicios.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace BibliotecaPresentacion.Intefaces
{
    public interface IDetalle_FacturasPresentacion
    {
        List<Detalle_Facturas> Consultar();
        Detalle_Facturas Guardar(Detalle_Facturas entidad);

        Detalle_Facturas Modificar(Detalle_Facturas entidad);

        Detalle_Facturas Eliminar(Detalle_Facturas entidad);
    }
}
