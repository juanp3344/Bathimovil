using BibliotecaServicios.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace BibliotecaPresentacion.Intefaces
{
    public interface IUbicacionesPresentacion
    {
        List<Ubicaciones> Consultar();
        Ubicaciones Guardar(Ubicaciones entidad);

        Ubicaciones Modificar(Ubicaciones entidad);

        Ubicaciones Eliminar(Ubicaciones entidad);
    }
}