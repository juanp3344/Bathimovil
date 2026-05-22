
using BibliotecaServicios.Entidades;
using BibliotecaServicios.Interfaces;
using BibliotecaServicios.Nucleo;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaServicios.Implementaciones
{
    public class EmpleadosServicios: IEmpleadosServicios
    {
        private IConexion? iConexion;

        public List<Empleados> Consultar()
        {
            iConexion = new Conexion();
            iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            var lista = iConexion.Empleados!.ToList();
            return lista;
        }

        public Empleados Guardar(Empleados entidad)
        {
            if (entidad.Id_Persona != 0)
                throw new Exception("Ya se guardo");

            iConexion = new Conexion();
            iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            

            iConexion.Empleados!.Add(entidad!);
            var lista = iConexion.Empleados!.ToList();


            iConexion.SaveChanges();
            return entidad;
        }

        public Empleados Modificar(Empleados entidad)
        {
            if (entidad.Id_Persona == 0)
                throw new Exception("No se ha guardado");

            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            var entry = this.iConexion!.Entry<Empleados>(entidad!);
            entry.State = EntityState.Modified;
            var lista = iConexion.Empleados!.ToList();
            iConexion.SaveChanges();
            return entidad;
        }
        public Empleados Eliminar(Empleados entidad)
        {
            if (entidad.Id_Persona == 0)
                throw new Exception("No se ha guardado");

            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            this.iConexion.Empleados!.Remove(entidad!);
            iConexion.SaveChanges();
            return entidad;
        }

        public Empleados AñadirSalario(Empleados entidad)
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            IRolesServicios? IRolesServicios;

            IRolesServicios = new RolesServicios();

            // DEFINIR SALARIO PARA CADA EMPLEADO SEGUN SU ROL
            var usuario = iConexion.Usuarios!.FirstOrDefault(x => x.Persona == entidad.Id_Persona); //encontramos al usuario de la persona, en este caso el empleado

            var rol = iConexion.Roles!.FirstOrDefault(x => x.Id_Rol == usuario!.Rol);

            entidad.Salario_Base = rol!.Salario_Empleado;
            iConexion.SaveChanges();
            return entidad;
        }
    }
}
