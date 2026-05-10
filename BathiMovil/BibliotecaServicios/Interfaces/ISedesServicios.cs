using BibliotecaServicios.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace BibliotecaServicios.Interfaces
{
    public interface ISedesServicios
    {
        List<Sedes> Consultar();
        Sedes Guardar(Sedes entidad);
        Sedes Modificar(Sedes entidad);
        Sedes Eliminar(Sedes entidad);
    }
}
