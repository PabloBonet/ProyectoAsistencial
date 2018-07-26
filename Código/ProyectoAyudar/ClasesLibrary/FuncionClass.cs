using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Processar.ProyectoAyudar.DatosLibrary;
using System.Windows.Forms;

namespace Processar.ProyectoAyudar.ClasesLibrary
{
    public class FuncionClass
    {
        #region Propiedades

        private saluddbEntities ctx;
        private int _id_funcion;
        private String _id_menu;
        private String _nombre_funcion;
        private String _nombre_menu;

        /// <summary>
        /// Obtiene el ID de la función
        /// </summary>
        public int Id_funcion
        {
            get { return _id_funcion; }
        
        }

        /// <summary>
        /// Obtiene y establece el id del menú
        /// </summary>
        public String Id_menu
        {
            get { return _id_menu; }
            set { _id_menu = value; }
        }

        /// <summary>
        /// Obtiene y establece el nombre de la función
        /// </summary>
        public String Nombre_funcion
        {
            get { return _nombre_funcion; }
            set { _nombre_funcion = value; }

        }

        /// <summary>
        /// Obtiene y establece el nombre del menú
        /// </summary>
        public String Nombre_menu
        {
            get { return _nombre_menu; }
            set { _nombre_menu = value; }
        }
        #endregion


        #region Constructores

        /// <summary>
        /// Constructor por defecto de la clase FuncionClass
        /// Crea una instancia de la clase con los elementos vacios
        /// </summary>
        public FuncionClass()
        {
            ctx = new saluddbEntities();
            _id_menu = "";
            _id_funcion = 0;
            _nombre_funcion = "";
            _nombre_menu = "";
        }

        /// <summary>
        /// Constructor de la clase FuncionClass
        /// Crea una instancia de la clase con los valores pasados como parámetros
        /// </summary>
        /// <param name="id_funcion">id de la función</param>
        /// <param name="id_menu">id del menú de la función</param>
        /// <param name="nombre_funcion">nombre de la función</param>
        /// <param name="nombre_menu">nombre del menú</param>
        public FuncionClass(int id_funcion, String id_menu, String nombre_funcion, String nombre_menu)
        {
            ctx = new saluddbEntities();
            _id_menu = id_menu;
            _id_funcion = id_funcion;
            _nombre_funcion = nombre_funcion;
            _nombre_menu = nombre_menu;

        }
        #endregion

        #region Metodos

        /// <summary>
        /// Crea la nueva función en la base de datos
        /// </summary>
        /// <returns>Retorna True si se creo correctamente</returns>
        public bool NuevaFuncion()
        {
            bool r = false;

            funcion f = new funcion();
            int idMenu = 0;
            Int32.TryParse( this._id_menu, out idMenu);
            f.id_menu = idMenu;
            f.nombre_funcion = this._nombre_funcion;
            f.nombre_menu = this._nombre_menu;



            try
            {
                ctx.funcions.Add(f);
                ctx.SaveChanges();
                this._id_funcion = f.id_funcion;

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
        /// Modifica la función creada en la base de datos
        /// </summary>
        /// <returns>Retorna True si se modificó correctamente</returns>
        public bool ModificarFuncion()
        {
            bool r = false;

            var cur = from fun in ctx.funcions
                      where fun.id_funcion == _id_funcion
                      select fun;

            var f = cur.First();

            int idMenu = 0;
            Int32.TryParse(this._id_menu, out idMenu);
            f.id_menu = idMenu;
          
            f.nombre_funcion = _nombre_funcion;
            f.nombre_menu = _nombre_menu;


            try
            {
                ctx.SaveChanges();
                r = true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error al modificar la función", MessageBoxButtons.OK, MessageBoxIcon.Error);
                r = false;
            }

            return r;
        }


        /// <summary>
        /// Comprueba si se puede eliminar la función. La función se va a poder eliminar si ésta no pertenece a un permiso
        /// </summary>
        /// <returns>Retorna True si se puede eliminar</returns>
        private bool Borrar_OK()
        {

            var cur = from p in ctx.permisoes
                      where p.id_funcion == _id_funcion
                      select p;

            if (cur.Count() == 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        /// <summary>
        /// Elimina la Función de la base de datos, previamente comprueba que la función no pertenezca a un permiso
        /// </summary>
        /// <returns>Retorna True si la función se eliminó correctamente</returns>
        public bool EliminarFuncion()
        {
            bool r = false;

            if (Borrar_OK())
            {
                var cur = from fun in ctx.funcions
                          where fun.id_funcion == _id_funcion
                          select fun;

                if (cur.Count() > 0)
                {
                    var f = cur.First();

                    ctx.funcions.Remove(f);
                    try
                    {
                        ctx.SaveChanges();
                        r = true;
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message, "Error al eliminar la función", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        r = false;
                    }
                }
            }
            else
            {

                r = false;
                MessageBox.Show("No se puede eliminar, existen permisos asociados a esta función", "Imposible Eliminar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
            return r;
        }
        /// <summary>
        /// Busca en la base de datos la función correspondiente al id pasado como parámetro
        /// </summary>
        /// <param name="id_funcion">Id de la función</param>
        /// <returns>Retorna la Función buscada</returns>
        public static FuncionClass BuscarFuncionPorId(int id_funcion)
        {
            FuncionClass r = new FuncionClass();

            saluddbEntities ctx = new saluddbEntities();

            var cur = from fun in ctx.funcions
                      where fun.id_funcion == id_funcion
                      select fun;

            if (cur.Count() > 0)
            {
                var f = cur.First();

                r._id_funcion = f.id_funcion;
                r._id_menu = (f.id_menu).ToString();
                r._nombre_funcion = f.nombre_funcion;
                r._nombre_menu = f.nombre_menu;


            }
            else
            {
                r = null;

            }

            return r;
        }

        /// <summary>
        /// Lista las funciones almacenadas en la base de datos
        /// </summary>
        /// <returns>Retorna la lista de funciones</returns>
        public static List<FuncionClass> ListarFunciones()
        {
            List<FuncionClass> r = new List<FuncionClass>();
            saluddbEntities mctx = new saluddbEntities();
             FuncionClass x;

            var cur = from fun in mctx.funcions
                      orderby fun.nombre_funcion
                      select fun;

            foreach (var f in cur)
            {
                x = new FuncionClass();

                x._nombre_menu = f.nombre_menu;
                x._nombre_funcion = f.nombre_funcion;
                x._id_menu =(f.id_menu).ToString();
                x._id_funcion = f.id_funcion;

                r.Add(x);
            }


            return r;
        }

        #endregion
    }
}
