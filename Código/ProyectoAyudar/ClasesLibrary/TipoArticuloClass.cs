using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Processar.ProyectoAyudar.DatosLibrary;
using System.Windows.Forms;


namespace Processar.ProyectoAyudar.ClasesLibrary
{
    public class TipoArticuloClass
    {
        #region Propiedades
        private saluddbEntities ctx;
        private int _id_tipo_articulo;
        private String _nombre_tipo_articulo;
        private bool _es_dinero;

        /// <summary>
        /// Retorna el id del TipoArticulo
        /// </summary>
        public  int Id_TipoArticulo
        {
            get { return _id_tipo_articulo; }
        }

        /// <summary>
        /// Retorna o establece el nombre del tipo de articulo
        /// </summary>
        public String Nombre_TipoArticulo
        {
            get { return _nombre_tipo_articulo; }
            set { _nombre_tipo_articulo = value; }
        }

        /// <summary>
        /// Retorna o establece si es dinero 
        /// </summary>
        public bool EsDinero
        {
            get { return _es_dinero; }
            set { _es_dinero = value; }
        }
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor por defecto de la clase TipoArticuloClass
        /// Crea una instancia de la clase, con todas las propiedades en cero o vacias
        /// </summary>
        public TipoArticuloClass()
        {
            this.ctx = new saluddbEntities();
            _id_tipo_articulo = 0;
            _nombre_tipo_articulo = "";
            _es_dinero = false;
        }

        /// <summary>
        /// Constructor de la clase TipoArticuloClass
        /// </summary>
        /// <param name="id_tipoArticulo"> Id del tipo de articulo</param>
        /// <param name="nombre_tipoArticulo">Nombre del tipo de articulo</param>
        /// <param name="es_dinero">Indica si el tipo de articulo es dinero o no</param>
        public TipoArticuloClass(int id_tipoArticulo, String nombre_tipoArticulo, bool es_dinero)
        {
            this.ctx = new saluddbEntities();
            this._id_tipo_articulo = id_tipoArticulo;
            this._nombre_tipo_articulo = nombre_tipoArticulo;
            this._es_dinero = es_dinero;
        }
        #endregion


        #region Metodos

        /// <summary>
        /// Guarda el TipoArticulo en la base de datos
        /// </summary>
        /// <returns>Retorna True si se guardó correctamente </returns>
        public bool NuevoTipoArticulo()
        {
            bool r = false;
            try
            {
                if(!existeTipoArticulo(this.Nombre_TipoArticulo))
                {
                    tipoarticulo f = new tipoarticulo();

                    f.nombre_tipo = this._nombre_tipo_articulo;
                    f.es_dinero = this._es_dinero;


                    ctx.tipoarticuloes.Add(f);
                    ctx.SaveChanges();
                    _id_tipo_articulo = f.id_tipo_articulo;

                    r = true;
                }
                else
                {
                    MessageBox.Show("Ya existe un tipo de artículo con ese nombre!");
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
        /// Modifica el tipo de articulo en la base de datos
        /// </summary>
        /// <returns>Retorna True si se modificó correctamente</returns>
        public bool ModificarTipoArticulo()
        {
            bool r = false;

            try
            {
                
                    var cur = from t in ctx.tipoarticuloes
                              where t.id_tipo_articulo == _id_tipo_articulo
                              select t;

                    var f = cur.First();

                    f.es_dinero = _es_dinero;
                    f.nombre_tipo = _nombre_tipo_articulo;

                    ctx.SaveChanges();
                    r = true;
                
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error al modificar el tipo de artículo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                r = false;
            }


            return r;
        }

        /// <summary>
        /// Función que determina si se puede borrar o no el tipo de articulo
        /// Comprueba que el tipo de articulo no este asignado a un articulo
        /// </summary>
        /// <returns>Retorna True si el tipo de articulo no está asignado a un Articulo</returns>
        private bool Borrar_OK()
        {
            var cur = from a in ctx.articuloes
                      where a.id_tipo_articulo == _id_tipo_articulo
                      select a;

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
        /// Elimina el tipo de artículo de la base de datos, previamente comprueba que este tipo de artículo no este asignado a un artículo
        /// </summary>
        /// <returns>Retorna True si se eliminó correctamente</returns>

        public bool Eliminar()
        {
            bool r = false;

            if (Borrar_OK())
            {
                var cur = from t in ctx.tipoarticuloes
                          where t.id_tipo_articulo == _id_tipo_articulo
                          select t;

                if (cur.Count() > 0)
                {
                    var f = cur.First();

                    ctx.tipoarticuloes.Remove(f);
                    try
                    {
                        ctx.SaveChanges();
                        r = true;
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message, "Error al eliminar el tipo de artículo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        r = false;
                    }
                }
            }
            else
            {

                r = false;
                MessageBox.Show("Existen Artículos que son de éste tipo", "Imposible Eliminar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
            return r;
        }

        /// <summary>
        /// Busca un tipo artículo por Id_tipo_articulo
        /// </summary>
        /// <param name="id_tipo_articulo">ID del tipo de artículo a buscar</param>
        /// <returns>Retorna un objeto TipoArticuloClass</returns>
        public static TipoArticuloClass BuscarTipoArticuloPorId(int id_tipo_articulo)
        {
            TipoArticuloClass r = new TipoArticuloClass();
            
            saluddbEntities ctx = new saluddbEntities();

            var cur = from t in ctx.tipoarticuloes
                      where t.id_tipo_articulo == id_tipo_articulo
                      select t;

            if (cur.Count() > 0)
            {
                var f = cur.First();

                r._id_tipo_articulo = f.id_tipo_articulo;
                r._nombre_tipo_articulo = f.nombre_tipo;
                r._es_dinero = (bool) f.es_dinero;

                
            }
            else
            {
                r = null;

            }

            return r;

        }

        /// <summary>
        /// Lista todos los tipos de artículos registrados en la base de datos
        /// </summary>
        /// <returns>Retorna una lista de objetos de la clase TipoArticulosClass</returns>
        public static List<TipoArticuloClass> ListarTipoArticulos()
        {
            List<TipoArticuloClass> r = new List<TipoArticuloClass>();
            saluddbEntities mctx = new saluddbEntities();
            TipoArticuloClass x;

            var cur = from t in mctx.tipoarticuloes
                      orderby t.nombre_tipo
                      select t;

            foreach (var f in cur)
            {
                x = new TipoArticuloClass();
                x._nombre_tipo_articulo = f.nombre_tipo;
                x._id_tipo_articulo = f.id_tipo_articulo;
                x._es_dinero = (bool) f.es_dinero;
            
                r.Add(x);
            }


            return  r;

        }

        /// <summary>
        ///Busca todos los tipos de artículos registrados en la base de datos que contengan como nombre, el nombre pasado como parametro
        /// </summary>
        /// <returns>Retorna una lista de objetos de la clase TipoArticulosClass</returns>
        public static List<TipoArticuloClass> BuscarTipoArticuloPorNombre(string nombre)
        {
            List<TipoArticuloClass> r = new List<TipoArticuloClass>();
            saluddbEntities mctx = new saluddbEntities();
            TipoArticuloClass x;

            var cur = from t in mctx.tipoarticuloes
                      where t.nombre_tipo.Contains(nombre)
                      select t;

            foreach (var f in cur)
            {
                x = new TipoArticuloClass();
                x._nombre_tipo_articulo = f.nombre_tipo;
                x._id_tipo_articulo = f.id_tipo_articulo;
                x._es_dinero = (bool)f.es_dinero;

                r.Add(x);
            }


            return r;

        }

        /// <summary>
        /// Comprueba que el tipo de articulo no exista en la base de datos, la comprobacion la hace por el Nombre
        /// </summary>
        /// <param name="nombre">Nombre del tipo de artículo a comprobar existencia</param>
        /// <returns></returns>
        public static bool existeTipoArticulo(string nombre)
        {
            bool existe = false;

            saluddbEntities ctx = new saluddbEntities();


            var cur = from b in ctx.tipoarticuloes
                      where b.nombre_tipo == nombre
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
