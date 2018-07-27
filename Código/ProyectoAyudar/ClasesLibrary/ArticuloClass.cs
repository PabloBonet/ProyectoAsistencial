using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Processar.ProyectoAyudar.DatosLibrary;
using System.Windows.Forms;


namespace Processar.ProyectoAyudar.ClasesLibrary
{
    public class ArticuloClass
    {

        #region Propiedades
        private saluddbEntities ctx;
        private int _id_articulo;
        private String _nombre_articulo;
        private String _descripcion_articulo;
        private TipoArticuloClass _tipo_articulo;

        /// <summary>
        /// Retorna el ID del articulo
        /// </summary>
        public int Id_articulo
        {
            get { return _id_articulo; }
        }

        /// <summary>
        /// Retorna o establece el nombre del del articulo
        /// </summary>
        public String Nombre_articulo
        {
            get { return _nombre_articulo; }
            set { _nombre_articulo = value; }
        }

        /// <summary>
        /// Retorna o establece la descripción del articulo
        /// </summary>
        public String Descripcion_articulo
        {
            get { return _descripcion_articulo; }
            set { _descripcion_articulo = value; }
        }

        /// <summary>
        /// Retorna o establece el tipo de articulo 
        /// </summary>
        public TipoArticuloClass Tipo_articulo
        {
            get { return _tipo_articulo; }
            set
            {
                _tipo_articulo = value;
            }
        }

        #endregion

        #region Constructores

        /// <summary>
        /// Constructor por defecto de la clase ArticuloClass
        /// Crea una instancia de la clase, con todas las propiedades en cero o vacias
        /// </summary>
        public ArticuloClass()
        {
            this.ctx = new saluddbEntities();
            this._id_articulo = 0;
            this._nombre_articulo = "";
            this._descripcion_articulo = "";
            this._tipo_articulo = new TipoArticuloClass();
        }

        /// <summary>
        /// Constructor de la clase ArticuloClass
        /// </summary>
        /// <param name="id_articulo"></param>
        /// <param name="nombre_articulo"></param>
        /// <param name="descripcion_articulo"></param>
        /// <param name="tipo_articulo"></param>
        public ArticuloClass(int id_articulo, String nombre_articulo, String descripcion_articulo, TipoArticuloClass tipo_articulo)
        {
            this.ctx = new saluddbEntities();
            this._id_articulo = id_articulo;
            this._nombre_articulo = nombre_articulo;
            this._descripcion_articulo = descripcion_articulo;
            this._tipo_articulo = tipo_articulo;
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Guarda el Articulo en la base de datos
        /// </summary>
        /// <returns>Retorna True si se guardó correctamente </returns>
        public bool NuevoArticulo()
        {
            bool r = false;

            articulo f = new articulo();

            try
            {
                //busca el articulo para comprobar que no existe uno con el mismo nombre
                var cur = from a in ctx.articuloes
                          where a.nombre == this.Nombre_articulo
                          select a;

                if(cur.Count() == 0)
                {
                    f.id_tipo_articulo = this._tipo_articulo.Id_TipoArticulo;
                    f.nombre = this.Nombre_articulo;
                    f.descripcion = this.Descripcion_articulo;



                    ctx.articuloes.Add(f);
                    ctx.SaveChanges();
                    _id_articulo = f.id_articulo;

                    r = true;
                }
                else
                {
                    MessageBox.Show("Ya existe un artículo con ese nombre!");
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
        /// Modifica el articulo en la base de datos
        /// </summary>
        /// <returns>Retorna True si se modificó correctamente</returns>
        public bool ModificarArticulo()
        {
            bool r = false;
            
            try
            {
               

                
                    var cur = from a in ctx.articuloes
                              where a.id_articulo == _id_articulo
                              select a;


                    var f = cur.First();
                    f.descripcion = _descripcion_articulo;
                    f.nombre = _nombre_articulo;
                    f.id_tipo_articulo = _tipo_articulo.Id_TipoArticulo;



                    ctx.SaveChanges();
                    r = true;
              
                
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error al modificar el artículo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                r = false;
            }

            return r;
        }

        /// <summary>
        /// Función que determina si se puede borrar o no el articulo
        /// Comprueba que el tipo de articulo no este en un itemEntrega a un articulo
        /// </summary>
        /// <returns>Retorna True si el articulo no está asignado a un itemEntrega</returns>
        private bool Borrar_OK()
        {
            
            var cur = from iE in ctx.itementregas
                      where iE.id_articulo == _id_articulo
                      select iE;

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
        /// Elimina el artículo de la base de datos, previamente comprueba que este artículo no este asignado a un itemEntrega
        /// </summary>
        /// <returns>Retorna True si se eliminó correctamente</returns>

        public bool Eliminar()
        {
            bool r = false;

            if (Borrar_OK())
            {
                var cur = from a in ctx.articuloes
                          where a.id_articulo == _id_articulo
                          select a;

                if (cur.Count() > 0)
                {
                    var f = cur.First();

                    ctx.articuloes.Remove(f);
                    try
                    {
                        ctx.SaveChanges();
                        r = true;
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message, "Error al eliminar el artículo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        r = false;
                    }
                }
            }
            else
            {

                r = false;
                MessageBox.Show("Existen Items de entrega asociados a este artículo", "Imposible Eliminar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
            return r;
        }

        /// <summary>
        /// Busca un artículo por Id_articulo
        /// </summary>
        /// <param name="id_articulo">ID del artículo a buscar</param>
        /// <returns>Retorna un objeto ArticuloClass</returns>
        public static ArticuloClass BuscarArticuloPorId(int id_articulo)
        {
            ArticuloClass r = new ArticuloClass();

            saluddbEntities ctx = new saluddbEntities();

            var cur = from a in ctx.articuloes
                      where a.id_articulo == id_articulo
                      select a;

            if (cur.Count() > 0)
            {
                var f = cur.First();

                r._id_articulo = f.id_articulo;
                r._nombre_articulo = f.nombre;
                r._descripcion_articulo = f.descripcion;
                r._tipo_articulo = TipoArticuloClass.BuscarTipoArticuloPorId(f.id_tipo_articulo);    

            }
            else
            {
                r = null;

            }

            return r;

        }

        /// <summary>
        /// Lista todos los artículos registrados en la base de datos
        /// </summary>
        /// <returns>Retorna una lista de objetos de la clase ArticulosClass</returns>
        public static List<ArticuloClass> ListarArticulos()
        {
            List<ArticuloClass> r = new List<ArticuloClass>();
            saluddbEntities mctx = new saluddbEntities();
            ArticuloClass x;

            var cur = from a in mctx.articuloes
                      orderby a.nombre
                      select a;

            foreach (var f in cur)
            {
                x = new ArticuloClass();

                x._id_articulo = f.id_articulo;
                x._nombre_articulo = f.nombre;
                x._descripcion_articulo = f.descripcion;
                x._tipo_articulo = TipoArticuloClass.BuscarTipoArticuloPorId(f.id_tipo_articulo);   

                r.Add(x);
            }


            return r;

        }

        /// <summary>
        /// Lista los articulos por criterio
        /// </summary>
        /// <param name="parametro">Parámetro con el que se compara para listar</param>
        /// <param name="criterio">Criterio de búsqueda</param>
        /// <returns>Lista de Artículos</returns>
        public static List<ArticuloClass> ListarAticulosPorCriterio(string parametro, CriterioBusqueda criterio)
        {
            List<ArticuloClass> r = new List<ArticuloClass>();
            saluddbEntities mctx = new saluddbEntities();
            ArticuloClass x;


            var cur = from b in mctx.articuloes
                      select b;

            foreach (var f in cur)
            {
                bool agregar = false;
                switch (criterio)
                {
                   

                    case CriterioBusqueda.Busqueda_Nombre:
                        agregar = f.nombre.Contains(parametro);
                        break;

                }

                if (agregar)
                {
                    x = new ArticuloClass();

                    x._id_articulo = f.id_articulo;
                    x._nombre_articulo = f.nombre;
                    x._descripcion_articulo = f.descripcion;
                    x._tipo_articulo = TipoArticuloClass.BuscarTipoArticuloPorId(f.id_tipo_articulo);

                    r.Add(x);
                }

            }

            return r;

        }
        ///<summary>
        ///   Lista todos los artículos registrados en la base de datos que fueron entregados al beneficiario (id_beneficiario)
        /// </summary>
        /// <returns>Retorna una lista de objetos de la clase ArticulosClass</returns>
        /// <param name="id_beneficiario">Id del beneficiario al que se le entrego artículos</param>
        /// <returns>Retorna una lista de objetos de la clase ArticulosClass</returns>
        public static List<ArticuloClass> ListarArticulosPorBeneficiario(long id_beneficiario)
        {
          List<ArticuloClass> r = new List<ArticuloClass>();
            saluddbEntities mctx = new saluddbEntities();
            ArticuloClass x;

            //une las tablas articulos, itemEntregas y ordenEntregas mediante un Join para obtener los articulos de un determinado beneficiario
            var cur = from ord in mctx.ordenentregas
                    
                      join item in mctx.itementregas
                      on ord.id_orden equals item.id_orden
                      
                      join art in mctx.articuloes
                       on item.id_articulo equals art.id_articulo

                      where ord.id_beneficiario == id_beneficiario
                      select art;
         

            foreach (var f in cur)
            {
                x = new ArticuloClass();

                x._id_articulo = f.id_articulo;
                x._nombre_articulo = f.nombre;
                x._descripcion_articulo = f.descripcion;
                x._tipo_articulo = TipoArticuloClass.BuscarTipoArticuloPorId(f.id_tipo_articulo);

                r.Add(x);
            }


            return r;

        }

        /// <summary>
        /// Lista los artículos de la base de datos que son del tipo id_tipo
        /// </summary>
        /// <param name="id_tipo"></param>
        /// <returns>Retorna una lista (ordenada por nombre de artículo) con los artículos de ese tipo</returns>
        public static List<ArticuloClass> ListarArticulosPorTipo(int id_tipo)
        {
            List<ArticuloClass> r = new List<ArticuloClass>();
            saluddbEntities mctx = new saluddbEntities();
            ArticuloClass x;

            var cur = from a in mctx.articuloes
                      where a.id_tipo_articulo == id_tipo
                      orderby a.nombre
                      select a;

            foreach (var f in cur)
            {
                x = new ArticuloClass();

                x._id_articulo = f.id_articulo;
                x._nombre_articulo = f.nombre;
                x._descripcion_articulo = f.descripcion;
                x._tipo_articulo = TipoArticuloClass.BuscarTipoArticuloPorId(f.id_tipo_articulo);

                r.Add(x);
            }


            return r;
        }


        /// <summary>
        /// Lista los artículos de la base de datos que contiene el nombre del tipo pasado como parametro
        /// </summary>
        /// <param name="tipo">nombre del tipo de articulo</param>
        /// <returns>Retorna una lista (ordenada por nombre de artículo) con los artículos de ese tipo</returns>
        public static List<ArticuloClass> ListarArticulosPorNombreTipo(string tipo)
        {
            List<ArticuloClass> r = new List<ArticuloClass>();
            saluddbEntities mctx = new saluddbEntities();
            ArticuloClass x;

            
            var cur = from t in mctx.tipoarticuloes
                      join a in mctx.articuloes
                      on t.id_tipo_articulo equals a.id_tipo_articulo
                      where t.nombre_tipo.Contains(tipo)
                      orderby a.nombre
                      select a;


            foreach (var f in cur)
            {
                x = new ArticuloClass();

                x._id_articulo = f.id_articulo;
                x._nombre_articulo = f.nombre;
                x._descripcion_articulo = f.descripcion;
                x._tipo_articulo = TipoArticuloClass.BuscarTipoArticuloPorId(f.id_tipo_articulo);

                r.Add(x);
            }


            return r;
        }

        /// <summary>
        /// Lista los artículos de la base de datos que contiene el nombre pasado como parametro en su nombre
        /// </summary>
        /// <param name="tipo">nombre del tipo de articulo</param>
        /// <returns>Retorna una lista (ordenada por nombre de artículo) con los artículos de ese tipo</returns>
        public static List<ArticuloClass> ListarArticulosPorNombre(string nombre)
        {
            List<ArticuloClass> r = new List<ArticuloClass>();
            saluddbEntities mctx = new saluddbEntities();
            ArticuloClass x;

            var cur = from a in mctx.articuloes
                      where a.nombre.Contains(nombre)
                      orderby a.nombre
                      select a;

            foreach (var f in cur)
            {
                x = new ArticuloClass();

                x._id_articulo = f.id_articulo;
                x._nombre_articulo = f.nombre;
                x._descripcion_articulo = f.descripcion;
                x._tipo_articulo = TipoArticuloClass.BuscarTipoArticuloPorId(f.id_tipo_articulo);

                r.Add(x);
            }


            return r;
        }

        /// <summary>
        /// Lista los artículos por beneficiario en las fechas determinadas. Tenieniendo en cuenta el estado de los articulos
        /// </summary>
        /// <param name="id_beneficiario">Id del beneficiario</param>
        /// <param name="fechaDesde">Fecha desde la cual se seleccionan los artículos</param>
        /// <param name="fechaHasta">Fecha hasta la cual se seleccionan los artículos</param>
        /// <param name="estado">Estado de los articulos relacionados con la orden y el beneficiario</param>
        /// <param name="completo">Lista los artículos completos</param>
        /// <returns></returns>
        public static List<ArticuloClass> ListarArticulosPorBeneficiarioEntreFechas(long id_beneficiario,DateTime fecha_desde,DateTime fecha_hasta, int estado, bool completo = false)
        {

            DateTime fechaDesde = new DateTime(fecha_desde.Year, fecha_desde.Month, fecha_desde.Day, 0, 0, 0);
            DateTime fechaHasta = new DateTime(fecha_hasta.Year, fecha_hasta.Month, fecha_hasta.Day, 23, 59, 59);
            List<ArticuloClass> r = new List<ArticuloClass>();
            saluddbEntities mctx = new saluddbEntities();
            ArticuloClass x;

            //une las tablas articulos, itemEntrega, ordenEntregas y ordenEstado mediante un Join para obtener los articulos de un determinado beneficiario
            var cur = from ord in mctx.ordenentregas

                      join item in mctx.itementregas
                      on ord.id_orden equals item.id_orden

                      join art in mctx.articuloes
                       on item.id_articulo equals art.id_articulo

                       join ordE in mctx.ordenestadoes
                       on ord.id_orden equals ordE.id_orden

                      where ord.id_beneficiario == id_beneficiario && ordE.estado == estado && ordE.fecha >= fechaDesde && ordE.fecha <= fechaHasta
                      select art;


            foreach (var f in cur)
            {
                x = new ArticuloClass();

                x._id_articulo = f.id_articulo;
                x._nombre_articulo = f.nombre;
                x._descripcion_articulo = f.descripcion;
                x._tipo_articulo = TipoArticuloClass.BuscarTipoArticuloPorId(f.id_tipo_articulo);

                r.Add(x);
            }


            return r;

        }


        ///<summary>
        ///Lista los artículos por beneficiario en las fechas determinadas.Tenieniendo en cuenta el estado de los articulos
        /// 
        /// </summary>
        /// <param name="id_beneficiario">Id del beneficiario</param>
        /// <param name="fechaDesde">Fecha desde la cual se seleccionan los artículos</param>
        /// <param name="fechaHasta">Fecha hasta la cual se seleccionan los artículos</param>
        /// <param name="estado">Estado de los articulos relacionados con la orden y el beneficiario</param>
        /// <param name="completo">Lista los artículos completos</param>
        /// 
        /// <returns>Retorna una instancia que se utiliza para mostrar en la grilla </returns>
        public static List<GrillaReporteEntregaClass> ListarArticulosPorBeneficiarioEntreFechasParaGrilla(long id_beneficiario, DateTime fecha_desde, DateTime fecha_hasta, int estado, bool completo = false)
        {

            DateTime fechaDesde = new DateTime(fecha_desde.Year, fecha_desde.Month, fecha_desde.Day, 0, 0, 0);
            DateTime fechaHasta = new DateTime(fecha_hasta.Year, fecha_hasta.Month, fecha_hasta.Day, 23, 59, 59);
            List<GrillaReporteEntregaClass> r = new List<GrillaReporteEntregaClass>();
            saluddbEntities mctx = new saluddbEntities();
            GrillaReporteEntregaClass x;

            //une las tablas articulos, itemEntrega, ordenEntregas y ordenEstado mediante un Join para obtener los articulos de un determinado beneficiario
            var cur = from ord in mctx.ordenentregas

                      join item in mctx.itementregas
                      on ord.id_orden equals item.id_orden


                      join art in mctx.articuloes
                       on item.id_articulo equals art.id_articulo

                      join ordE in mctx.ordenestadoes
                      on ord.id_orden equals ordE.id_orden

                      where ord.id_beneficiario == id_beneficiario && ordE.estado == estado && ordE.fecha >= fechaDesde && ordE.fecha <= fechaHasta
                      select new { id_articulo = art.id_articulo,
                          cantidad_articulo = item.cantidad,
                          nombre_articulo = art.nombre,
                          descripcion_articulo = art.descripcion,
                          id_tipo_articulo = art.id_tipo_articulo,
                           id_orden_entrega = ord.id_orden,
                            fechaEntrega_orden_entrega = ordE.fecha,
                            id_autorizado = ord.id_usu_autoriza,
                            id_entrega = ord.id_usu_entrega};
            
            foreach (var f in cur)
            {
                x = new GrillaReporteEntregaClass();

                x.Id_articulo = f.id_articulo;
                x.Cantidad_articulo = f.cantidad_articulo.ToString();
                x.Nombre_articulo = f.nombre_articulo;
                x.Descripcion_articulo = f.descripcion_articulo;
                x.Tipo_articulo = TipoArticuloClass.BuscarTipoArticuloPorId(f.id_tipo_articulo).Nombre_TipoArticulo;
                x.Id_orden_entrega = f.id_orden_entrega;
                x.FechaEntrega_orden_entrega = ((DateTime)f.fechaEntrega_orden_entrega).Date.ToShortDateString();
                //x.HoraEntrega_orden_entrega = ((DateTime)f.fechaEntrega_orden_entrega).Date.ToShortTimeString();
                x.HoraEntrega_orden_entrega = ((DateTime)f.fechaEntrega_orden_entrega).ToShortTimeString();
                if((int)f.id_autorizado != 0)
                {
                    x.Autorizado_por = UsuarioClass.BuscarUsuarioPorId((int)f.id_autorizado).Nombre_completo.ToString();

                }
                else
                {
                    x.Autorizado_por = "NO AUTORIZADO";
                }

                if ((int)f.id_entrega != 0)
                {
                    x.Entregado_por = UsuarioClass.BuscarUsuarioPorId((int)f.id_entrega).Nombre_completo.ToString();

                }
                else
                {
                    x.Entregado_por = "NO ENTREGADO";
                }

                r.Add(x);
            }


            return r;

        }
        #endregion
    }
}
