using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Processar.ProyectoAyudar.DatosLibrary;
using System.Windows.Forms;

namespace Processar.ProyectoAyudar.ClasesLibrary
{
    public class ItemEntregaClass
    {
        #region Propiedades
        private saluddbEntities ctx;
        private long _id_item_entrega;
        private float _cantidad;
        private ArticuloClass _articulo;

        
        /// <summary>
        /// Retorna el Id del item entrega
        /// </summary>
        public long Id_item_entrega
        {
            get {return _id_item_entrega;}
        }

        /// <summary>
        /// Retorna o establece la cantidad de articulos del item entrega
        /// </summary>
        public float Cantidad
        {
            get {return _cantidad;}
            set { _cantidad = value; }
        }

        /// <summary>
        /// Retorna o establece el articulo del item entrega
        /// </summary>
        public ArticuloClass Articulo
        {
            get { return _articulo; }
            set { _articulo = value; }
        }
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor por defecto de la clase ItemEntregaClass
        /// Crea una instancia de la clase, con todas las propiedades en cero o vacias
        /// </summary>
        public ItemEntregaClass()
        {
            ctx = new saluddbEntities();
            _id_item_entrega = 0;
            _cantidad = 0;
            _articulo = new ArticuloClass();
        }

        /// <summary>
        /// Constructor de la clase ItemEntregaClass
        /// </summary>
        /// <param name="id_item_entrega">id del item</param>
        /// <param name="cantidad">cantidad de articulos</param>
        /// <param name="articulo">articulo a colocar en el item de entrega</param>
        public ItemEntregaClass(long id_item_entrega, int cantidad, ArticuloClass articulo)
        {
            ctx = new saluddbEntities();
            _id_item_entrega = id_item_entrega;
            _cantidad = cantidad;
            _articulo = articulo;
        }
        #endregion

        #region Metodos

        
        /// <summary>
        /// Crea un nuevo tipo item en la base de datos
        /// </summary>
        /// <param name="id_orden">id del orden de entrega</param>
        /// <returns>Retorna True si se guardó correctamente</returns>
        public bool NuevoItemEntrega(int id_orden)
        {

            bool r = false;

            itementrega f = new itementrega();

            f.id_articulo = this._articulo.Id_articulo;
            f.cantidad = this._cantidad;
            f.id_orden = id_orden;
            
            try
            {
                ctx.itementregas.Add(f);
                ctx.SaveChanges();
                _id_item_entrega = f.id_item_entrega;

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
        /// Modifica el item entrega en la base de datos
        /// </summary>
        /// <returns>Retorna True si se modificó correctamente</returns>
        public bool ModificarItemEngrega()
        {
            bool r = false;

            var cur = from iE in ctx.itementregas
                      where iE.id_item_entrega == _id_item_entrega
                      select iE;

            var f = cur.First();

            f.cantidad = _cantidad;
            f.id_articulo = _articulo.Id_articulo;
   


            try
            {
                ctx.SaveChanges();
                r = true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error al modificar el item entrega", MessageBoxButtons.OK, MessageBoxIcon.Error);
                r = false;
            }

            return r;
        }


        /// <summary>
        /// Función que determina si se puede borrar o no el itemEntrega
        /// Comprueba que el tipo de articulo no este en una ordenEntrega
        /// </summary>
        /// <returns>Retorna True si el itemEntrega no está asignado a una oredenEntrega</returns>
        private bool Borrar_OK()
        {

            var cur = from iE in ctx.itementregas
                      where iE.id_item_entrega == _id_item_entrega
                      select iE;

            if (cur.Count() == 0)
            {

                return true;
            }
            else
            {
                var f = cur.First();

                var cur2 = from iO in ctx.ordenentregas
                           where iO.id_orden == f.id_orden
                           select iO;

                if (cur2.Count() == 0)
                {

                    return true;
                }
                else
                {
                    return false;
                }
            }

        }

        public bool Eliminar()
        {
            bool r = false;

            if (Borrar_OK())
            {
                var cur = from iE in ctx.itementregas
                          where iE.id_item_entrega == _id_item_entrega
                          select iE;

                if (cur.Count() > 0)
                {
                    var f = cur.First();

                    ctx.itementregas.Remove(f);
                    try
                    {
                        ctx.SaveChanges();
                        r = true;
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message, "Error al eliminar item de entrega", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        r = false;
                    }
                }
            }
            else
            {

                r = false;
                MessageBox.Show("Existen Items de entrega asociados Ordenes de entrega", "Imposible Eliminar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
            return r;
        }

        /// <summary>
        /// Busca un Item entrega según su ID
        /// </summary>
        /// <param name="id_item_entrega">Id del item entrega a buscar</param>
        /// <returns>retorna el objeto ItemEntrega buscado</returns>
        public static ItemEntregaClass BuscarItemEntregaPorId(long id_item_entrega)
        {
            ItemEntregaClass r = new ItemEntregaClass();

            saluddbEntities ctx = new saluddbEntities();

            var cur = from iE in ctx.itementregas
                      where iE.id_item_entrega == id_item_entrega
                      select iE;

            if (cur.Count() > 0)
            {
                var f = cur.First();


                r._id_item_entrega = f.id_item_entrega;
                r._cantidad = (float) f.cantidad;
                r._articulo = ArticuloClass.BuscarArticuloPorId(f.id_articulo);

            }
            else
            {
                r = null;

            }

            return r;
        }


        /// <summary>
        /// Lista todos los Items de entrega registrados en la base de datos
        /// </summary>
        /// <returns>Retorna una lista de objetos de la clase ItemEntregaClass</returns>
        public static List<ItemEntregaClass> ListarItemEntrega()
        {
            List<ItemEntregaClass> r = new List<ItemEntregaClass>();
            saluddbEntities mctx = new saluddbEntities();
            ItemEntregaClass x;

            var cur = from iE in mctx.itementregas
                      
                      select iE;

            foreach (var f in cur)
            {
                x = new ItemEntregaClass();

                x._id_item_entrega = f.id_item_entrega;
                x._cantidad = (float) f.cantidad;
                x._articulo = ArticuloClass.BuscarArticuloPorId(f.id_articulo);
                
                r.Add(x);
            }


            return r;

        }

        /// <summary>
        /// Lista los items de entrega de la orden Id_orden
        /// </summary>
        /// <param name="id_orden">Id de la orden de entrega</param>
        /// <returns>Retorna la lista de Items de entrega</returns>
        public static List<ItemEntregaClass> ListarItemEntregaPorOrden(long id_orden)
        {
            List<ItemEntregaClass> r = new List<ItemEntregaClass>();
            saluddbEntities mctx = new saluddbEntities();
            ItemEntregaClass x;

            var cur = from iE in mctx.itementregas
                      where iE.id_orden == id_orden
                      select iE;

            foreach (var f in cur)
            {
                x = new ItemEntregaClass();

                x._id_item_entrega = f.id_item_entrega;
                x._cantidad = (float)f.cantidad;
                x._articulo = ArticuloClass.BuscarArticuloPorId(f.id_articulo);

                r.Add(x);
            }


            return r;

        }
        #endregion
    }
}
