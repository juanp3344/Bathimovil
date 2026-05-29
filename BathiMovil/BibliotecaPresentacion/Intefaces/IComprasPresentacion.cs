using BibliotecaServicios.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace BibliotecaPresentacion.Intefaces
{
    public interface IComprasPresentacion
    {
        List<Compras> Consultar();
        Compras Guardar(Compras entidad);

        Compras Modificar(Compras entidad);

        Compras Eliminar(Compras entidad);
        Task<byte[]> ExportarPdf();
    }
}
