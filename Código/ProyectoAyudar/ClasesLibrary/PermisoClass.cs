using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Processar.ProyectoAyudar.DatosLibrary;
using System.Windows.Forms;

namespace Processar.ProyectoAyudar.ClasesLibrary
{
    public class PermisoClass
    {

        #region Propiedades
        private saluddbEntities ctx;
        private int _id_permiso;
        private bool _permitido;
        private FuncionClass _funcion;
      


        /// <summary>
        /// Obtiene el Id del permiso
        /// </summary>
        public int Id_permiso
        {
            get { return _id_permiso; }
        }
        /// <summary>
        /// Obtiene y establece si el permiso es permitido o no
        /// </summary>
        public bool Permitido
        {
            get { return _permitido; }
            set { _permitido = value; }
        }


        /// <summary>
        /// Obtiene y establece la función a la cuál hace referencia el permiso
        /// </summary>
        public FuncionClass Funcion
        {
            get { return _funcion; }

            set { _funcion = value; }
        }

 
        #endregion

        #region Constructores

        /// <summary>
        /// Constructor por defecto de la clase permisoClass
        /// crea una instancia vacía de la clase
        /// </summary>
        public PermisoClass()
        {
            ctx = new saluddbEntities();
            _id_permiso = 0;
            _permitido = false;
            _funcion = new FuncionClass();
         
        }

        /// <summary>
        /// Constructor de la clase PermisoClass
        /// Crea una instancia de la clase con los valores pasados como parámetros
        /// </summary>
        /// <param name="id_permiso">Id del permiso</param>
        /// <param name="permitido">Indica si el permiso para utilizar la función  es o no permitido</param>
        /// <param name="funcion">Función relacionada al permiso</param>
        public PermisoClass(int id_permiso, bool permitido, FuncionClass funcion)
        {
            ctx = new saluddbEntities();
            _id_permiso = id_permiso;
            _permitido = permitido;
            _funcion = funcion;
       
        }
        #endregion

        #region Metodos

        /// <summary>
        /// Crea un nuevo permiso en la base de datos
        /// </summary>
        /// <param name="id_usuario">Id del usuario al que se le va a asignar el mermiso</param>
        /// <returns>Retorna True si se modificó correctamente</returns>
        public bool NuevoPermiso(int id_usuario)
        {
            bool r = false;

            permiso f = new permiso();

            
            f.id_funcion = this._funcion.Id_funcion;
            f.permitido = this._permitido;
            f.id_usuario = id_usuario;
            

            try
            {
                ctx.permisoes.Add(f);
                ctx.SaveChanges();
                this._id_permiso = f.id_permiso;
               
                r = true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                r = false;

            }

            return r;
        }


        /// <summary>
        /// Modifica el permiso en la base de datos.
        /// Solo se puede modificar si está permitido o no
        /// </summary>
        /// <returns>Retorna True si se modificó correctamente</returns>
        public bool Modificar()
        {
            bool r = false;
            var cur = from p in ctx.permisoes
                      where p.id_permiso == _id_permiso
                      select p;

            if (cur.Count() > 0)
            {
                var f = cur.First();
                f.permitido = _permitido;
                
                try
                {
                    ctx.SaveChanges();
                    r = true;
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message, "Error al modificar el permiso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    r = false;
                }
            }
            return r;


        }


        public bool Eliminar()
        {
            bool r = false;
            var cur = from p in ctx.permisoes
                      where p.id_permiso == _id_permiso
                      select p;

            if (cur.Count() > 0)
            {
                var f = cur.First();
                try
                {
                    ctx.permisoes.Remove(f);
                    ctx.SaveChanges();
                    r = true;
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message, "Error al eliminar el permiso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    r = false;

                }
            }
            return r;
        }
        /// <summary>
        /// Comprueba que el menú este habilitado, si hay algún elemento del menú que tenga permiso, el menú es habilitado
        /// </summary>
        /// <param name="nombreMenu">nombre del menú</param>
        /// <returns>Retorna TRUE si el menu está habilitado, FALSE en otro caso</returns>
        public static bool menuHabilitado(string nombreMenu, int id_usuario)
        {

            bool r = false;
            saluddbEntities mctx = new saluddbEntities();

            var cur = from p in mctx.permisoes
                      join f in mctx.funcions
                      on p.id_funcion equals f.id_funcion
                      where f.nombre_menu == nombreMenu && p.id_usuario == id_usuario
                      select p;


            if(cur.Count() > 0)
            {
                foreach(var f in cur)
                {
                    if((bool)f.permitido)
                    {
                        return true;
                    }
                }
            }
            return r ;
        }

        public static bool TienePermiso(int id_usuario, string nombre_funcion)
        {
            bool r = false;

            saluddbEntities mctx = new saluddbEntities();

            var cur = from p in mctx.permisoes
                      join f in mctx.funcions
                      on p.id_funcion equals f.id_funcion
                      where f.nombre_funcion == nombre_funcion && p.id_usuario == id_usuario
                      select p;


            if (cur.Count() > 0)
            {
                var f = cur.First();

                r = (bool)f.permitido;
            }



            return r;
        }



        /// <summary>
        /// Lista los permisos del usuario Id_usuario
        /// </summary>
        /// <param name="id_usuario">Id del usuario</param>
        /// <returns>Retorna la lista de los permisos para el usuario Id_usuario</returns>
        public static List<PermisoClass> ListarPermisosPorUsuario(int id_usuario)
        {
            List<PermisoClass> r = new List<PermisoClass>();
            saluddbEntities mctx = new saluddbEntities();
            PermisoClass x;

            var cur = from p in mctx.permisoes
                      where p.id_usuario == id_usuario
                      select p;

            foreach (var f in cur)
            {
                x = new PermisoClass();

                x._funcion = FuncionClass.BuscarFuncionPorId((int)f.id_funcion);
                x._id_permiso = f.id_permiso;
                x._permitido = (bool)f.permitido;
                
                r.Add(x);
            }


            return r;
        }

        /// <summary>
        /// Lista permisos por nombre de usuario
        /// </summary>
        /// <param name="nombre_usuario"></param>
        /// <returns>Lista de Permisos</returns>
        public static List<PermisoClass> ListarPermisosPorNombreUsuario(string nombre_usuario)
        {
            List<PermisoClass> r = new List<PermisoClass>();
            saluddbEntities mctx = new saluddbEntities();
            PermisoClass x;

            var cur = from p in mctx.permisoes
                      join u in mctx.usuarios 
                      on p.id_usuario equals u.id_usuario
                      where u.nombre_usuario == nombre_usuario
                      select p;

            foreach (var f in cur)
            {
                x = new PermisoClass();

                x._funcion = FuncionClass.BuscarFuncionPorId((int)f.id_funcion);
                x._id_permiso = f.id_permiso;
                x._permitido = (bool)f.permitido;

                r.Add(x);
            }


            return r;
        }

        /// <summary>
        /// Lista los permisos almacenados en la base de datos
        /// </summary>
        /// <returns>Retorna una lista con todos los permisos</returns>
        public static List<PermisoClass> ListarPermisos()
        {
            List<PermisoClass> r = new List<PermisoClass>();
            saluddbEntities mctx = new saluddbEntities();
            PermisoClass x;

            var cur = from p in mctx.permisoes
                      orderby p.id_permiso
                      select p;

            foreach (var f in cur)
            {
                x = new PermisoClass();

                x._funcion = FuncionClass.BuscarFuncionPorId((int)f.id_funcion);
                x._id_permiso = f.id_permiso;
                x._permitido = (bool)f.permitido;

                r.Add(x);
            }


            return r;
        }

      
        #endregion
    }
}
