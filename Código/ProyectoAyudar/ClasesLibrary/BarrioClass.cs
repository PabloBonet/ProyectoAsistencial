using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Processar.ProyectoAyudar.DatosLibrary;
using System.Windows.Forms;

namespace Processar.ProyectoAyudar.ClasesLibrary
{
    public class BarrioClass
    {
        #region Propiedades
        private saluddbEntities ctx;
        private int _id_barrio;
        private String _nombre_barrio;
        private String _ciudad;

        /// <summary>
        /// Retorna el Id del barrio
        /// </summary>
        public int IdBarrio
        {
            
            get { return _id_barrio; }
        }

        /// <summary>
        /// Retorna o establece el nombre del barrio
        /// </summary>
        public String Nombre
        {
            set { _nombre_barrio = value; }
            get { return _nombre_barrio; }
        }

        /// <summary>
        /// retorna o establece la ciudad a la que pertenece el barrio
        /// </summary>
        public String Ciudad
        {
            set { _ciudad = value; }
            get { return _ciudad; }
        }
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor por defecto de la clase BarrioClass
        /// Crea una instancia vacia de Barrio
        /// </summary>
        public BarrioClass()
        {
            ctx = new saluddbEntities();
            _id_barrio = 0;
            _nombre_barrio = "";
            _ciudad = "";
        }

        /// <summary>
        /// Constructor de la clase BarrioClass
        /// Crea una instancia de la clase Barrio con los valores pasados como parámetros
        /// </summary>
        /// <param name="id_barrio">Id del barrio</param>
        /// <param name="nombre">Nombre del barrio</param>
        /// <param name="ciudad">Ciudad a la que pertenece el barrio</param>
        public BarrioClass(int id_barrio, string nombre, string ciudad)
        {
            ctx = new saluddbEntities();
            _id_barrio = id_barrio;
            _nombre_barrio = nombre;
            _ciudad = ciudad;
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Guarda en la base de datos el nuevo barrio
        /// </summary>
        /// <returns>Retorna True si el barrio se guardó correctamente</returns>
        public bool NuevoBarrio()
        {
            bool r = false;

            try
            {

                if(!existeBarrio(this.Nombre))
                {
                    barrio f = new barrio();

                    f.ciudad = this._ciudad;
                    f.nombre_barrio = this._nombre_barrio;


                    ctx.barrios.Add(f);
                    ctx.SaveChanges();
                    _id_barrio = f.id_barrio;

                    r = true;
                }
                else
                {
                    MessageBox.Show("Ya existe un barrio con ese nombre!");
                    r = false;
                }
                
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                r = false;

            }

            return r;
        }

        /// <summary>
        /// Modifica el barrio de la base de datos
        /// Modifica los campos Nombre y Ciudad
        /// </summary>
        /// <returns>Retorna True si se modificó correctamente</returns>
        public bool ModificarBarrio()
        {
            bool r = false;

            try
            {
               
                    var cur = from b in ctx.barrios
                              where b.id_barrio == _id_barrio
                              select b;

                    var f = cur.First();
                    f.nombre_barrio = _nombre_barrio;
                    f.ciudad = _ciudad;




                    ctx.SaveChanges();
                    r = true;
                
                
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error al modificar el barrio", MessageBoxButtons.OK, MessageBoxIcon.Error);
                r = false;
            }

            return r;
        }


        /// <summary>
        /// Comprueba si se puede borrar el barrio
        /// Si un beneficiario tiene asignado ese barrio no se puede borrar
        /// </summary>
        /// <returns>Retorna True si se puede borrar</returns>
        private bool Borrar_OK()
        {

            var cur = from b in ctx.beneficiarios
                      where b.id_barrio == _id_barrio
                      select b;

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
        /// Elimina el barrio de la base de datos
        /// Previamente comprueba que el barrio no este asignado a un beneficiario
        /// </summary>
        /// <returns>Retorna True si se borró correctamente</returns>
        public bool Eliminar()
        {
            bool r = false;

            if (Borrar_OK())
            {
                var cur = from b in ctx.barrios
                          where b.id_barrio == _id_barrio
                          select b;

                if (cur.Count() > 0)
                {
                    var f = cur.First();

                    ctx.barrios.Remove(f);
                    try
                    {
                        ctx.SaveChanges();
                        r = true;
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message, "Error al eliminar el barrio", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        r = false;
                    }
                }
            }
            else
            {

                r = false;
                MessageBox.Show("Existen beneficiarios asociados a este barrio", "Imposible Eliminar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
            return r;
        }


        /// <summary>
        /// Busca el barrio en la base de datos por su ID
        /// 
        /// </summary>
        /// <param name="id_barrio">ID del barrio a buscar</param>
        /// <returns>Retorna el barrio buscado. Null en otro caso</returns>
        public static BarrioClass BuscarBarrioPorId(int id_barrio)
        {
            BarrioClass r = new BarrioClass();

            saluddbEntities ctx = new saluddbEntities();

            var cur = from b in ctx.barrios
                      where b.id_barrio == id_barrio
                      select b;

            if (cur.Count() > 0)
            {
                var f = cur.First();

                r._id_barrio = f.id_barrio;
                r._ciudad = f.ciudad;
                r._nombre_barrio = f.nombre_barrio;

            }
            else
            {
                r = null;

            }

            return r;

        }

        /// <summary>
        /// Busca barrios por su nombre.
        /// Hace una busqueda de contenido
        /// </summary>
        /// <param name="nombre">Nombre del barrio buscado</param>
        /// <returns>Retorna una lista con los barrios que tienen incluido en su nombre, el parametro pasado</returns>
        public static List<BarrioClass> BuscarBarrioPorNombre(string nombre)
        {
            List<BarrioClass> lista = new List<BarrioClass>();
            
            

            saluddbEntities ctx = new saluddbEntities();

            var cur = from b in ctx.barrios
                      where b.nombre_barrio.Contains(nombre)
                      select b;

            if (cur.Count() > 0)
            {
                BarrioClass r = new BarrioClass();
                var f = cur.First();

                r._id_barrio = f.id_barrio;
                r._ciudad = f.ciudad;
                r._nombre_barrio = f.nombre_barrio;

                lista.Add(r);
            }
            

            return lista;

        }

        /// <summary>
        /// Lista los barrios de la base de datos
        /// </summary>
        /// <returns>Retorna la lista de barrios</returns>
        public static List<BarrioClass> ListarBarrios()
        {
            List<BarrioClass> r = new List<BarrioClass>();
            saluddbEntities mctx = new saluddbEntities();
            BarrioClass x;

            var cur = from b in mctx.barrios
                      orderby b.nombre_barrio
                      select b;

            foreach (var f in cur)
            {
                x = new BarrioClass();

                x._id_barrio = f.id_barrio;
                x._nombre_barrio = f.nombre_barrio;
                x._ciudad = f.ciudad;

                r.Add(x);
            }


            return r;

        }

        /// <summary>
        /// Comprueba que el barrio no exista en la base de datos, la comprobacion la hace por el Nombre
        /// </summary>
        /// <param name="nombre">Nombre del barrio a comprobar existencia</param>
        /// <returns></returns>
        public static bool existeBarrio(string nombre)
        {
            bool existe = false;

            saluddbEntities ctx = new saluddbEntities();


            var cur = from b in ctx.barrios
                      where b.nombre_barrio == nombre
                      select b;

            if (cur.Count() > 0) //existe
            {

                existe = true;
            }
            return existe;
        }
        #endregion
    }
}
