using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Processar.ProyectoAyudar.DatosLibrary;
using System.Windows.Forms;

namespace Processar.ProyectoAyudar.ClasesLibrary
{
    public class OrdenEstadoClass
    {
        #region Propiedades
        private saluddbEntities ctx;
        private int _id_orden_estado;
        private int _id_orden_entrega;
        private UsuarioClass _usuario;
        private EstadoOrden _estado;
        private DateTime _fecha;


        /// <summary>
        /// Retorna o establece el Id de la ordenEstado
        /// </summary>
        public int IdOrdenEstado
        {
            get { return _id_orden_estado; }

            set { _id_orden_estado = value; }
        }

        /// <summary>
        /// Retorna o establece el id del orden de entrega
        /// </summary>
        public int IdOrdenEntrega
        {
            get { return _id_orden_entrega; }
            set { _id_orden_entrega = value; }
        }

        /// <summary>
        /// Retorna o establece el usuario que realizo el cambio de estado
        /// </summary>
        public UsuarioClass Usuario
        {
            get { return _usuario; }

            set { _usuario = value; }
        }

        public EstadoOrden Estado
        {
            get { return _estado; }

            set { _estado = value; }
        
        }

        public DateTime Fecha
        {
            get { return _fecha; }
            set { _fecha = value; }

        }

        /// <summary>
        /// Obtiene la fecha formateada
        /// </summary>
        public string FechaFormateada
        {
            get { return _fecha.ToShortDateString(); }
        }
        #endregion



        #region Constructores

        /// <summary>
        /// Constructor por defecto, crea una instancia de OrdenEstado vacía
        /// </summary>
        public OrdenEstadoClass()
        {
            ctx = new saluddbEntities();
        _id_orden_estado = 0;
        _id_orden_entrega = 0;
        _usuario = new UsuarioClass();
        _estado = EstadoOrden.INICIADO;
        _fecha = new DateTime();
        }


        /// <summary>
        /// Constructor de la clase, Crea una instacia de la clase OrdenEstado con los valor proporcionados
        /// </summary>
        /// <param name="id_ordenEstado">Id de la orden de estado</param>
        /// <param name="id_ordenEntrega">Id de la Orden de Entrega </param>
        /// <param name="usuario">Usuario que realizo el cambio de estado</param>
        /// <param name="estado">Estado de la orden</param>
        /// <param name="fecha">Fecha de modificación del estado</param>
        public OrdenEstadoClass(int id_ordenEstado, int id_ordenEntrega, UsuarioClass usuario, EstadoOrden estado, DateTime fecha)
        {
            ctx = new saluddbEntities();
            _id_orden_entrega = id_ordenEstado;
            _id_orden_entrega = id_ordenEntrega;
            _usuario = usuario;
            _estado = estado;
            _fecha = fecha;
        }
        #endregion

        #region Metodos


        /// <summary>
        /// Guarda en la base de datos la nueva orden estado.
        /// </summary>
        /// <returns>Retorna True si la nueva orden se guardo correctamente</returns>
        public bool NuevaOrdenEstado()
        {
            bool r = false;

            ordenestado f = new ordenestado();

            f.id_orden = this._id_orden_entrega;
            f.id_usuario = this._usuario.Id_usuario;
            f.estado = (int) this._estado;
            f.fecha = this._fecha;


            try
            {
                ctx.ordenestadoes.Add(f);
                ctx.SaveChanges();
                _id_orden_estado = f.id_ordenestado;

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
        /// Busca una ordenEstado en la base de datos por su Id
        /// </summary>
        /// <param name="id_ordenEstado">Id orden estado</param>
        /// <returns>Retorna la orden de estado buscada</returns>
        public static OrdenEstadoClass BuscarOrdenEstadoPorId(long id_ordenEstado)
        {
            OrdenEstadoClass r = new OrdenEstadoClass();

            saluddbEntities ctx = new saluddbEntities();

            var cur = from o in ctx.ordenestadoes
                      where o.id_ordenestado == id_ordenEstado
                      select o;

            if (cur.Count() > 0)
            {
                var f = cur.First();


                r._id_orden_estado = f.id_ordenestado;
                r._estado = (EstadoOrden)f.estado;
                r._fecha = (DateTime) f.fecha;
                r._id_orden_entrega = f.id_orden;
                r._usuario = UsuarioClass.BuscarUsuarioPorId(f.id_usuario);

            }
            else
            {
                r = null;

            }

            return r;

        }


        /// <summary>
        /// Función que obtiene el ultimo estado para la orden pasada como parámetro
        /// </summary>
        /// <param name="id_ordenEntrega">Id de la orden de entrega a buscar el estado</param>
        /// <returns>Retorna una instancia de OrdenEstadoClass o null en otro caso</returns>
        public static OrdenEstadoClass UltimoEstado(long id_ordenEntrega)
        {
            OrdenEstadoClass r = new OrdenEstadoClass();

            saluddbEntities ctx = new saluddbEntities();

            var cur = from o in ctx.ordenestadoes
                      where o.id_orden == id_ordenEntrega
                      orderby o.id_ordenestado descending
                      select o;

            if (cur.Count() > 0)
            {



                var f = cur.First();


                r._id_orden_estado = f.id_ordenestado;
                r._estado = (EstadoOrden)f.estado;
                r._fecha = (DateTime)f.fecha;
                r._id_orden_entrega = f.id_orden;
                r._usuario = UsuarioClass.BuscarUsuarioPorId(f.id_usuario);

            }
            else
            {
                r = null;

            }

            return r;

        }

        /// <summary>
        /// Lista todas las ordenesEstado ubicadas en la base de datos
        /// </summary>
        /// <returns>Retorna una lista de OrdenesEstados</returns>
        public static List<OrdenEstadoClass> Listar()
        {
            List<OrdenEstadoClass> r = new List<OrdenEstadoClass>();
            saluddbEntities mctx = new saluddbEntities();
            OrdenEstadoClass x;


            var cur = from o in mctx.ordenestadoes
                      
                      select o;


            foreach (var f in cur)
            {
                x = new OrdenEstadoClass();

                x._id_orden_entrega = f.id_orden;
                x._id_orden_estado = f.id_ordenestado;
                x._estado = (EstadoOrden)f.estado;
                x._fecha = (DateTime)f.fecha;
                x._usuario = UsuarioClass.BuscarUsuarioPorId((int)f.id_usuario);

                r.Add(x);
            }


            return r;
        }
        
        /// <summary>
        /// Lista los estados por los que paso la Orden de entrega.
        /// </summary>
        /// <param name="id_orden">Id de la orden de entrega</param>
        /// <returns>Retorna la lista de estados para la orden de entrega</returns>
        public static List<OrdenEstadoClass> ListarPorOrden(long id_orden)
        {
            List<OrdenEstadoClass> r = new List<OrdenEstadoClass>();
            saluddbEntities mctx = new saluddbEntities();
            OrdenEstadoClass x;

            
            var cur = from o in mctx.ordenestadoes
                      where o.id_orden == id_orden
                      select o;


            foreach (var f in cur)
            {
                x = new OrdenEstadoClass();

                x._id_orden_entrega = f.id_orden;
                x._id_orden_estado = f.id_ordenestado;
                x._estado = (EstadoOrden)f.estado;
                x._fecha = (DateTime) f.fecha;
                x._usuario = UsuarioClass.BuscarUsuarioPorId((int)f.id_usuario);

                r.Add(x);
            }


            return r;
        }
        #endregion
    }
}
