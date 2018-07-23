using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Processar.ProyectoAyudar.DatosLibrary;
using System.Windows.Forms;


namespace Processar.ProyectoAyudar.ClasesLibrary
{
   public class OrdenEntregaClass
    {

        #region Propiedades

        private saluddbEntities ctx;
        private long _id_orden_entrega;
        private String _descripcion;
        private DateTime _fecha;
        private List<ItemEntregaClass> _items_entrega;
        private BeneficiarioClass _beneficiario;
        private List<OrdenEstadoClass> _estados; //contiene todos los estados por los que paso la orden
        private UsuarioClass _usuario_genero; //Usuario que generó la orden
        private UsuarioClass _usuario_autorizo; //Usuario que autorizó la orden
        private UsuarioClass _usuario_entrego; //Usuario que entregó la orden
        //private UsuarioClass _usuario; //Último usuario que modificó el estado de la orden

       /// <summary>
       /// Obtiene el Id de la orden de entrega
       /// </summary>
       public long Id_orden_entrega
       {
           get { return _id_orden_entrega; }
       }

       /// <summary>
       /// Obtiene y establece la descripción de la orden
       /// </summary>

       public String Descripcion
       {
           get { return _descripcion; }
           set { _descripcion = value; }
       }

       /// <summary>
       /// Obtiene y establece la fecha en la que se emitió la oreden de entrega
       /// </summary>
       public DateTime Fecha
       {
           get { return _fecha; }

           set { _fecha = value; }
       }

        /// <summary>
        /// Obtiene la fecha de creación formateada
        /// </summary>
        public string FechaCreadoFormateada
        {
            get { return _fecha.ToShortDateString(); }
        }

       /// <summary>
       /// Obtiene y establece los items de entrega
       /// </summary>
       public List<ItemEntregaClass> Items_entrega
       {
           get { return _items_entrega; }
           set { _items_entrega = value; }
       }

       /// <summary>
       /// Obtiene y establece el beneficiario de la orden de entrega
       /// </summary>
       public BeneficiarioClass Beneficiario
       {
           get { return _beneficiario; }
           set { _beneficiario = value; }
       }

       /// <summary>
       /// Obtiene y establece los estados de la orden de entrega
       /// </summary>
       public List<OrdenEstadoClass> Estados
       {
           get { return _estados; }
           set { _estados = value; }
       }


       /// <summary>
       /// Retorna el estado actual de la orden.
       /// El estado actual es el último estado de la lista de estados
       /// </summary>
       public OrdenEstadoClass EstadoActual
       {
           get { return _estados.Last(); }
       }

       /// <summary>
       /// Obiene y establece el último usuario que modificó la orden de entrega
       /// </summary>
       public UsuarioClass UltimoUsuario
       {
           get { return ((_estados.Last()).Usuario); }
           
       }

       /// <summary>
       /// Retorna el usuario que creo la orden de entrega
       /// </summary>
       public UsuarioClass UsuarioCreador
       {
           get
           {
               return _usuario_genero;
           }
           set { _usuario_genero = value; }
       }

        /// <summary>
        /// Usuario que autoriza la orden. 
        /// Retorna el usuario que autorizó la orden 
        /// </summary>
        public UsuarioClass UsuarioAutoriza
        {
            get
            {
                return _usuario_autorizo;
            }
            set { _usuario_autorizo = value; }
        }

        /// <summary>
        /// usuario que entrega la orden.
        /// Retorna el usuario que entregó la orden
        /// </summary>
        public UsuarioClass UsuarioEntrega
        {
            get { return _usuario_entrego; }

            set { _usuario_entrego = value; }
        }

       

        #endregion

        #region Constructores
       /// <summary>
       /// Constructor por defecto de la clase OrdenEntregaClass
       /// Crea una instancia vacía de la clase
       /// </summary>
       public OrdenEntregaClass()
       {
           ctx = new saluddbEntities();
           _id_orden_entrega = 0;
           _beneficiario = new BeneficiarioClass();
           _descripcion = "";
           _fecha = new DateTime();
            _fecha = DateTime.Now;
           _items_entrega = new List<ItemEntregaClass>();
           _estados = new List<OrdenEstadoClass>();
           _usuario_genero = new UsuarioClass();
            _usuario_autorizo = new UsuarioClass();
            _usuario_entrego = new UsuarioClass();
       }


       /// <summary>
       /// Constructor por defecto de la clase OrdenEntregaClass
       /// Crea una instancia de la clase OrdenEntegaClass con los valores pasados como parámetros
       /// El estado es por defecto Iniciado
       /// </summary>
       /// <param name="id_orden_entrega">Id de la orden de entrega</param>
       /// <param name="beneficiario">Beneficiario de la orden</param>
       /// <param name="descripcion">Descripción de la orden </param>
       /// <param name="fecha">Fecha de generación de la orden de entega</param>
       /// <param name="items">Lista de items de la orden</param>
       /// <param name="usuario">Usuario que crea la orden de entrega</param>
       public OrdenEntregaClass(long id_orden_entrega, BeneficiarioClass beneficiario, String descripcion, DateTime fecha, List<ItemEntregaClass> items, UsuarioClass usuario)
       {
           ctx = new saluddbEntities();
           _id_orden_entrega = id_orden_entrega;
           _beneficiario = beneficiario;
           _descripcion = descripcion;
           _fecha = fecha;
           _items_entrega = items;
           _estados = new List<OrdenEstadoClass>();

           //Creo un nuevo estado para asignarle a la orden
           //Este estado aùn no tiene su Id por no estar registrado en la base de datos
           OrdenEstadoClass primerEstado = new OrdenEstadoClass();

           primerEstado.IdOrdenEntrega = _id_orden_entrega;
           primerEstado.Estado = EstadoOrden.INICIADO;
           primerEstado.Fecha = DateTime.Now;
           primerEstado.Usuario = _usuario_genero;

           _estados.Add(primerEstado);
           
           _usuario_genero = usuario;

            _usuario_autorizo = null;
            _usuario_entrego = null;
        

          // CargarEstados();
       
       }
        #endregion

        #region Metodos

       /// <summary>
       /// Guarda en la base de datos una nueva orden de entrega
       /// </summary>
       /// <param name="id_beneficiario">Id del beneficiario de la orden de entrega</param>
       
       /// <returns>Retorna True si la orden se registró correctamente</returns>
       public bool NuevaOrdenEntrega(int id_beneficiario)
       {
           bool r = false;

           ordenentrega f = new ordenentrega();

           using ( System.Transactions.TransactionScope tr = new System.Transactions.TransactionScope())
           {

               f.descripcion = this._descripcion;
               f.fecha = this._fecha;
               f.id_beneficiario = id_beneficiario;
               f.id_usuario = _usuario_genero.Id_usuario;
                f.id_usu_autoriza = 0;
                f.id_usu_entrega = 0;
               // f.estado = (int)EstadoOrden.Iniciado;



               try
               {
                   ctx.ordenentregas.Add(f);
                   ctx.SaveChanges();
                   _id_orden_entrega = f.id_orden;

                   r = true;
               }
               catch (Exception e)
               {
                   MessageBox.Show(e.Message, "Error de datos: no se pudo crear la Orden de entrega", MessageBoxButtons.OK, MessageBoxIcon.Error);
                   r = false;

               }

                //Si se creo correctamente la orden de entrega, creo los items
                if (r)
                {
                    itementrega item = new itementrega();
                    foreach (ItemEntregaClass i in _items_entrega)
                    {

                        if(!i.NuevoItemEntrega(_id_orden_entrega))
                        {
                            r = false;
                            break;
                        }
                        /*
                        item.id_orden = _id_orden_entrega;
                        item.id_articulo = i.Articulo.Id_articulo;
                        item.cantidad = i.Cantidad;


                        try
                        {
                            ctx.itementregas.Add(item);
                            ctx.SaveChanges();
                            = item.id_item_entrega;
                        }
                        catch (Exception e)
                        {
                            MessageBox.Show(e.Message, "Error de datos: No se pudo crear el Item de Entrega", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            r = false;
                            break;
                        }*/
                    }
                    

                    
                }

                if (r) // Si se creo correctamente la orden de Entrega. Guardo el estado en la tabla OrdenEstado
               {

                    OrdenEstadoClass primerEstado = new OrdenEstadoClass();

                    primerEstado.IdOrdenEntrega = _id_orden_entrega;
                    primerEstado.Estado = EstadoOrden.INICIADO;
                    primerEstado.Fecha = _fecha;
                    primerEstado.Usuario = _usuario_genero;

                    

                    

                   //Crea una nueva ordenEstado con el estado en Iniciado
                   ordenestado oe = new ordenestado();

                   oe.id_orden = primerEstado.IdOrdenEntrega;
                   oe.estado = (int)primerEstado.Estado;
                   oe.id_usuario = primerEstado.Usuario.Id_usuario;
                   oe.fecha = primerEstado.Fecha;


                    

                    try
                   {
                       ctx.ordenestadoes.Add(oe);
                       ctx.SaveChanges();

                        primerEstado.IdOrdenEstado = oe.id_ordenEstado;

                        _estados.Add(primerEstado);
                        r = true;
                   }
                   catch (Exception e)
                   {
                       MessageBox.Show(e.Message, "Error de datos: No se pudo crear la Orden Estado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                       r = false;

                   }

               }

               
               if (r)
               {
                   tr.Complete();
               }

           } //Fin transacción
           return r;
       }

       /// <summary>
       /// Modifica una orden de entega creada en la base de datos 
       /// Solo puede modificar la descripción y si el estado es Iniciado si la orden está autorizada es imposible modificar su id, su usuario y el beneficiario.
       /// </summary>
       /// <returns>Retorna true si la orden ha sido modificada correctamente</returns>
       public bool ModificarOrdenEntrega()
       {
           bool r = true;

           if(this.EstadoActual.Estado == EstadoOrden.INICIADO)
           {
                List<ItemEntregaClass> itemsAnteriores = ItemEntregaClass.ListarItemEntregaPorOrden(_id_orden_entrega);

                using (System.Transactions.TransactionScope tr = new System.Transactions.TransactionScope())
                {
                    

                    //Crea nuevos items si se agregaron a la lista.
                    foreach(ItemEntregaClass item in _items_entrega)
                    {
                        if(!contieneItem(item, itemsAnteriores))
                        {
                            if(!item.NuevoItemEntrega(_id_orden_entrega))
                            {
                                r = false;
                                break;
                            }
                        }

                    }

                    if(r)
                    {
                        //Elimina los items sacados de la lista
                        foreach (ItemEntregaClass item in itemsAnteriores)
                        {
                            if (!contieneItem(item, _items_entrega))
                            {
                                if (!item.Eliminar())
                                {
                                    r = false;
                                    break;
                                }
                            }
                        }
                    }
                    


                    if(r)
                    {
                        var cur = from o in ctx.ordenentregas
                                  where o.id_orden == _id_orden_entrega
                                  select o;

                        var f = cur.First();

                        f.descripcion = this._descripcion;
                        //f.fecha = this._fecha;


                        //f.estado = (int)this._estado;



                        try
                        {
                            ctx.SaveChanges();
                            r = true;
                        }
                        catch (Exception e)
                        {
                            MessageBox.Show(e.Message, "Error al modificar la orden de entrega", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            r = false;
                        }


                    }



                    if (r)
                    {
                        tr.Complete();
                    }
                }

                 

           }
           
           return r;
       }

        /// <summary>
        /// Comprueba si el item pasado como parametro se encuentra en la lista,
        /// la comparación la hace por id
        /// </summary>
        /// <param name="item">item a comparar en la lista</param>
        /// <param name="items">lista de items entrega</param>
        /// <returns></returns>
        private bool contieneItem(ItemEntregaClass item, List<ItemEntregaClass> items)
        {
            bool r = false;

            foreach(ItemEntregaClass i in items)
            {
                if(i.Id_item_entrega == item.Id_item_entrega)
                {
                    r = true;
                    break;
                }
            }


            return r;
        }

       /// <summary>
       /// Comprueba el estado de la orden. Si el estado de la orden es Iniciado, se podrá borrar, en otro caso no se puede
       /// </summary>
       /// <returns>Retorna True si se puede eliminar la orden de entrega</returns>
       private bool Borrar_OK()
       {

           
               if(this.EstadoActual.Estado == EstadoOrden.INICIADO)
                { 
                   return true;
               }
           
           return false;

       }


       /// <summary>
       /// Eliminar la orden de entrega
       /// Esta acción cambia el estado de la orden a Eliminado, sin borrarla fisicamente. 
       /// </summary>
       /// <returns>Retorna True si se a borrado correctamente</returns>
       public bool Eliminar(UsuarioClass usuario)
       {
           bool r = false;

           if (Borrar_OK())
           {
                   //Crea una nueva orenEstado con el estado en Eliminado

               OrdenEstadoClass estado = new OrdenEstadoClass();

               estado.IdOrdenEntrega = _id_orden_entrega;
               estado.Estado = EstadoOrden.ELIMINADO;
               estado.Usuario = usuario;
               estado.Fecha = DateTime.Now;

               
                   ordenestado oe = new ordenestado();

                   oe.id_orden = _id_orden_entrega;
                   oe.estado = (int)EstadoOrden.ELIMINADO;
                   oe.id_usuario = usuario.Id_usuario;
                   oe.fecha = DateTime.Now;

                   try
                   {
                       ctx.ordenestadoes.Add(oe);
                       ctx.SaveChanges();

                       estado.IdOrdenEstado = oe.id_ordenEstado;
                       _estados.Add(estado);
                       r = true;
                   }
                   catch (Exception e)
                   {
                       MessageBox.Show(e.Message, "Error al Eliminar la orden: No se pudo crear el estado Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                       r = false;

                   }
               
           }
           else
           {

               r = false;
               MessageBox.Show("El estado de la Orden de entrega ya no es Iniciado", "Imposible Eliminar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

           }
           return r;
       }

        /// <summary>
        /// Función que realiza el cambio de estado de la orden a Cancelado
        /// </summary>
        /// <param name="usuario">Usuario que cancela la orden</param>
        /// <returns>retorna True si la orden se canceló correctamente, False en otro caso</returns>
        public bool Cancelar(UsuarioClass usuario)
        {
            bool r = false;


            if (Cancelar_Ok())
            {
                OrdenEstadoClass nuevoEstado = new OrdenEstadoClass();
                nuevoEstado.IdOrdenEntrega = _id_orden_entrega;
                nuevoEstado.Usuario = usuario;
                nuevoEstado.Estado = EstadoOrden.CANCELADO;
                nuevoEstado.Fecha = DateTime.Now;

                if (nuevoEstado.NuevaOrdenEstado())
                {
                    _estados.Add(nuevoEstado);
                    r = true;
                }
                else
                {
                    MessageBox.Show("Ocurrió un error al crear el estado para esta orden!", "Entregar orden");
                    r = false;
                }
            }
        
                
            return r;

        }

        /// <summary>
        /// La orden se va a poder cancelar, solo si el estado actual es autorizado
        /// </summary>
        /// <returns>Retorna True si la orden se puede cancelar</returns>
        private bool Cancelar_Ok()
        {
            bool r = false;

            if(EstadoActual.Estado == EstadoOrden.AUTORIZADO)
            {
                r = true;
            }

            return r;
        }


        /// <summary>
        /// Función que realiza el cambio de estado de la orden a Entregado
        /// </summary>
        /// <param name="usuario">Usuario que entrega la orden</param>
        /// <returns>retorna True si la orden se entregó correctamente, False en otro caso</returns>
        public bool Entregar(UsuarioClass usuario, DateTime fecha)
        {
            bool r = false;


            if (Entregar_Ok())
            {
                OrdenEstadoClass nuevoEstado = new OrdenEstadoClass();
                nuevoEstado.IdOrdenEntrega = _id_orden_entrega;
                nuevoEstado.Usuario = usuario;
                nuevoEstado.Estado = EstadoOrden.ENTREGADO;
                nuevoEstado.Fecha = fecha;
                this._usuario_entrego = usuario;


                if (nuevoEstado.NuevaOrdenEstado())
                {
                    _estados.Add(nuevoEstado);

                    //Guarda en la base de datos el usuario que Entregó la orden
                    saluddbEntities ctx = new saluddbEntities();

                    var cur = from o in ctx.ordenentregas
                              where o.id_orden == this.Id_orden_entrega
                              select o;

                    if (cur.Count() > 0)
                    {
                        var f = cur.First();

                        f.id_usu_entrega = usuario.Id_usuario;

                        try
                        {
                            ctx.SaveChanges();
                            r = true;
                        }
                        catch (Exception e)
                        {
                            MessageBox.Show(e.Message, "Error al Autorizar la orden de entrega. Error al modificar la orden de entrega", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            r = false;
                        }


                    }

                    r = true;
                }
                else
                {
                    MessageBox.Show("Ocurrió un error al crear el estado para esta orden!", "Entregar orden");
                    r = false;
                }
            }


            return r;

        }

        /// <summary>
        /// La orden se va a poder entregar, solo si el estado actual es autorizado
        /// </summary>
        /// <returns>Retorna True si la orden se puede entregar, False en otro caso</returns>
        private bool Entregar_Ok()
        {
            bool r = false;

            if (EstadoActual.Estado == EstadoOrden.AUTORIZADO)
            {
                r = true;
            }

            return r;
        }

        /// <summary>
        /// Función que realiza el cambio de estado de la orden a Autorizado
        /// </summary>
        /// <param name="usuario">Usuario que autoriza la orden</param>
        /// <returns>retorna True si la orden se autorizó correctamente, False en otro caso</returns>
        public bool Autorizar(UsuarioClass usuario, DateTime fecha)
        {
            bool r = false;


            if (Autorizar_Ok())
            {
                OrdenEstadoClass nuevoEstado = new OrdenEstadoClass();
                nuevoEstado.IdOrdenEntrega = _id_orden_entrega;
                nuevoEstado.Usuario = usuario;
                nuevoEstado.Estado = EstadoOrden.AUTORIZADO;
                nuevoEstado.Fecha = fecha;
                this._usuario_autorizo = usuario;

                if (nuevoEstado.NuevaOrdenEstado())
                {
                    _estados.Add(nuevoEstado);


                    //Guarda en la base de datos el usuario que Autorizó la orden
                    saluddbEntities ctx = new saluddbEntities();

                    var cur = from o in ctx.ordenentregas
                              where o.id_orden == this.Id_orden_entrega
                              select o;

                    if (cur.Count() > 0)
                    {
                        var f = cur.First();

                        f.id_usu_autoriza = usuario.Id_usuario;

                        try
                        {
                            ctx.SaveChanges();
                            r = true;
                        }
                        catch (Exception e)
                        {
                            MessageBox.Show(e.Message, "Error al Autorizar la orden de entrega. Error al modificar la orden de entrega", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            r = false;
                        }


                    }

                    
                }
                else
                {
                    MessageBox.Show("Ocurrió un error al crear el estado para esta orden!", "Entregar orden");
                    r = false;
                }
            }


            return r;

        }

        /// <summary>
        /// La orden se va a poder autorizar, solo si el estado actual es iniciado
        /// </summary>
        /// <returns>Retorna True si la orden se puede cancelar</returns>
        private bool Autorizar_Ok()
        {
            bool r = false;

            if (EstadoActual.Estado == EstadoOrden.INICIADO)
            {
                r = true;
            }

            return r;
        }

        /// <summary>
        /// Busca una orden de entrega por su ID en la base de datos
        /// </summary>
        /// <param name="id_orden">Id de la orden a buscar</param>
        /// <param name="completo">Indica si se quiere obtener la orden completa, esto es con la lista de items o no</param>
        /// <returns>Retorna la Orden de entrega buscada. Null si no existe oi está eliminada</returns>
        public static OrdenEntregaClass BuscarOrdenEntregaPorId(long id_orden, bool completo = false)
       {
           OrdenEntregaClass r = new OrdenEntregaClass();

           saluddbEntities ctx = new saluddbEntities();

           
           if(ordenEliminada(id_orden)) //Si la orden esta eliminada retorna null
           {
               return null;
           }

           var cur = from o in ctx.ordenentregas
                     where o.id_orden == id_orden
                     select o;

           if (cur.Count() > 0)
           {
               var f = cur.First();


               r._id_orden_entrega = f.id_orden;
              // r._usuario = UsuarioClass.BuscarUsuarioPorId(f.id_usuario);
               r._usuario_genero = UsuarioClass.BuscarUsuarioPorId(f.id_usuario);
               String criterio = f.id_beneficiario.ToString();
               r.Beneficiario = BeneficiarioClass.BuscarBeneficiario(criterio, CriterioBusqueda.Busqueda_ID);
               r.Descripcion = f.descripcion;
              
               r.Fecha = (DateTime)f.fecha;

               r._estados = OrdenEstadoClass.ListarPorOrden(id_orden);
  
               r._usuario_autorizo = UsuarioClass.BuscarUsuarioPorId((int)f.id_usu_autoriza);
                r._usuario_entrego = UsuarioClass.BuscarUsuarioPorId((int)f.id_usu_entrega);

                if (completo)
               {
                   r.Items_entrega = ItemEntregaClass.ListarItemEntregaPorOrden(f.id_orden);

          
               }

           }
           else
           {
               r = null;

           }

           return r;

       }

       /// <summary>
       /// Lista las ordenes de entrega guardadas en la base de datos.
       /// </summary>
       /// <param name="completo">Indica si las ordenes de entrega van a ser completas o no, se refiere a que si van a tener la lista de Items</param>
       /// <returns>Retorna la lista de Ordenes de Entrega</returns>
       public static List<OrdenEntregaClass> ListarOrdenesEntrega(bool completo = false)
       {
           List<OrdenEntregaClass> r = new List<OrdenEntregaClass>();
           saluddbEntities mctx = new saluddbEntities();
           OrdenEntregaClass x;


           var cur = from o in mctx.ordenentregas

                     select o;

          
           foreach(var f in cur)
           {
            /*   x = new OrdenEntregaClass();
               var cur2 = from oe in mctx.ordenestadoes
                          where oe.id_orden == f.id_orden
                          select oe;

               */
               if(!ordenEliminada(f.id_orden))
               {
                   x = new OrdenEntregaClass();
                   
                       x._estados = OrdenEstadoClass.ListarPorOrden(f.id_orden);

                       x._id_orden_entrega = f.id_orden;
                     //  x._usuario = UsuarioClass.BuscarUsuarioPorId(f.id_usuario);
                       x._usuario_genero = UsuarioClass.BuscarUsuarioPorId(f.id_usuario);
                           String criterio = f.id_beneficiario.ToString();
                       x.Beneficiario = BeneficiarioClass.BuscarBeneficiario(criterio, CriterioBusqueda.Busqueda_ID);
                       x.Descripcion = f.descripcion;
                       
                       x.Fecha = (DateTime)f.fecha;
                        x._usuario_autorizo = UsuarioClass.BuscarUsuarioPorId((int)f.id_usu_autoriza);
                        x._usuario_entrego = UsuarioClass.BuscarUsuarioPorId((int)f.id_usu_entrega);

                    if (completo)
                       {
                           x.Items_entrega = ItemEntregaClass.ListarItemEntregaPorOrden(f.id_orden);
                       }

                       r.Add(x);
                   
                  
               }
               

           }

           return r;

       }
        /// <summary>
        /// Muestra las últimas n ordenes de entrega ( n = cantidad)
        /// </summary>
        /// <param name="cantidad">Cantidad de ordenes a listar</param>
        /// <param name="completo">Carga las ordenes completas</param>
        /// <returns>Retorna una lista de ordenes</returns>
        public static List<OrdenEntregaClass> ListarUltimasOrdenesEntrega(int cantidad, bool completo = false)
        {
            List<OrdenEntregaClass> r = new List<OrdenEntregaClass>();
            saluddbEntities mctx = new saluddbEntities();
            OrdenEntregaClass x;


            var cur = from o in mctx.ordenentregas
                      orderby o.fecha descending
                      select o;

            int contador = cantidad;

            foreach (var f in cur)
            {

                if(contador > 0)
                {
                    if (!ordenEliminada(f.id_orden))
                    {
                        x = new OrdenEntregaClass();

                        x._estados = OrdenEstadoClass.ListarPorOrden(f.id_orden);

                        x._id_orden_entrega = f.id_orden;
                        //  x._usuario = UsuarioClass.BuscarUsuarioPorId(f.id_usuario);
                        x._usuario_genero = UsuarioClass.BuscarUsuarioPorId(f.id_usuario);
                        String criterio = f.id_beneficiario.ToString();
                        x.Beneficiario = BeneficiarioClass.BuscarBeneficiario(criterio, CriterioBusqueda.Busqueda_ID);
                        x.Descripcion = f.descripcion;

                        x.Fecha = (DateTime)f.fecha;
                        x._usuario_autorizo = UsuarioClass.BuscarUsuarioPorId((int)f.id_usu_autoriza);
                        x._usuario_entrego = UsuarioClass.BuscarUsuarioPorId((int)f.id_usu_entrega);

                        if (completo)
                        {
                            x.Items_entrega = ItemEntregaClass.ListarItemEntregaPorOrden(f.id_orden);
                        }

                        r.Add(x);


                    }

                    contador--;
                }
                else
                {
                    break;
                }
                


            }
            // r.OrderBy(a => a.Id_orden_entrega);

            r.Reverse();
            return r;

        }


        /// <summary>
        /// Lista las ordenes de Entrega generadas en el periodo Desde - Hasta
        /// </summary>
        /// <param name="desde"></param>
        /// <param name="hasta"></param>
        /// <param name="completo">Indica si las ordenes de entrega van a ser completas o no, se refiere a que si van a tener la lista de Items</param>
        /// <returns>Retorna la lista con las ordenes de entrega del periodo</returns>
        public static List<OrdenEntregaClass> ListarOrdenesEntregaDesdeHasta(DateTime desde, DateTime hasta, bool completo = false)
       {
           List<OrdenEntregaClass> r = new List<OrdenEntregaClass>();
           saluddbEntities mctx = new saluddbEntities();
           OrdenEntregaClass x;

           var cur = from o in mctx.ordenentregas
                     where o.fecha >= desde && o.fecha <= hasta
                     select o;

           foreach (var f in cur)
           {
              


               if (!ordenEliminada(f.id_orden))
               {


                   x = new OrdenEntregaClass();

                   x._estados = OrdenEstadoClass.ListarPorOrden(f.id_orden);


                       x._id_orden_entrega = f.id_orden;
                   //    x._usuario = UsuarioClass.BuscarUsuarioPorId(f.id_usuario);
                       x._usuario_genero = UsuarioClass.BuscarUsuarioPorId(f.id_usuario);
                       String criterio = f.id_beneficiario.ToString();
                       x.Beneficiario = BeneficiarioClass.BuscarBeneficiario(criterio, CriterioBusqueda.Busqueda_ID);
                       x.Descripcion = f.descripcion;
                    
                       x.Fecha = (DateTime)f.fecha;
                 
                       

                    x._usuario_autorizo = UsuarioClass.BuscarUsuarioPorId((int)f.id_usu_autoriza);
                    x._usuario_entrego = UsuarioClass.BuscarUsuarioPorId((int)f.id_usu_entrega);
                    if (completo)
                       {
                           x.Items_entrega = ItemEntregaClass.ListarItemEntregaPorOrden(f.id_orden);
                       }

                       r.Add(x);
                   

               }

           }

           return r;

       }

       /// <summary>
       /// Lista las ordenes de entrega No eliminadas que contienen el articulo Id_articulo
       /// </summary>
       /// <param name="id_articulo">Id del articulo</param>
       /// <param name="completo">Indica si las ordenes de entrega van a ser completas o no, se refiere a que si van a tener la lista de Items</param>
       /// <returns></returns>
       public static List<OrdenEntregaClass> ListarOrdenesPorArticulo(int id_articulo, bool completo = false)
       {
           List<OrdenEntregaClass> r = new List<OrdenEntregaClass>();
           saluddbEntities mctx = new saluddbEntities();
           OrdenEntregaClass x;

           var cur = from o in mctx.ordenentregas

                     join ie in mctx.itementregas
                     on o.id_orden equals ie.id_orden
                     where ie.id_articulo == id_articulo
                     select o;

           foreach (var f in cur)
           {
            

               if (!ordenEliminada(f.id_orden))
               {

                   x = new OrdenEntregaClass();

                   x._estados = OrdenEstadoClass.ListarPorOrden(f.id_orden);
                       x._id_orden_entrega = f.id_orden;
                   //    x._usuario = UsuarioClass.BuscarUsuarioPorId(f.id_usuario);
                       x._usuario_genero = UsuarioClass.BuscarUsuarioPorId(f.id_usuario);
                       String criterio = f.id_beneficiario.ToString();
                       x.Beneficiario = BeneficiarioClass.BuscarBeneficiario(criterio, CriterioBusqueda.Busqueda_ID);
                       x.Descripcion = f.descripcion;

                       x.Fecha = (DateTime)f.fecha;

                    x._usuario_autorizo = UsuarioClass.BuscarUsuarioPorId((int)f.id_usu_autoriza);
                    x._usuario_entrego = UsuarioClass.BuscarUsuarioPorId((int)f.id_usu_entrega);

                    if (completo)
                       {
                           x.Items_entrega = ItemEntregaClass.ListarItemEntregaPorOrden(f.id_orden);
                       }

                       r.Add(x);
                   

               }


           }

           return r;


       }

       /// <summary>
       /// Lista las ordenes de entrega que fueron realizadas al beneficiario Id_beneficiario
       /// </summary>
       /// <param name="id_beneficiario">Id del beneficiario de la ordenes</param>
       /// <param name="completo">Indica si las ordenes de entrega van a ser completas o no, se refiere a que si van a tener la lista de Items</param>
       /// <returns>Lista de ordenes que fueron entregadas al beneficiario Id_beneficiario</returns>
       public static List<OrdenEntregaClass> ListarOrdenesPorBeneficiario(int id_beneficiario, bool completo = false)
       {
           List<OrdenEntregaClass> r = new List<OrdenEntregaClass>();
           saluddbEntities mctx = new saluddbEntities();
           OrdenEntregaClass x;

           var cur = from o in mctx.ordenentregas

                     where o.id_beneficiario == id_beneficiario
                     select o;

           foreach (var f in cur)
           {

               if (!ordenEliminada(f.id_orden))
               {
                        x = new OrdenEntregaClass();

                       x._estados = OrdenEstadoClass.ListarPorOrden(f.id_orden);
                       x._id_orden_entrega = f.id_orden;
                       //x._usuario = UsuarioClass.BuscarUsuarioPorId(f.id_usuario);
                       x._usuario_genero = UsuarioClass.BuscarUsuarioPorId(f.id_usuario);
                       String criterio = f.id_beneficiario.ToString();
                       x.Beneficiario = BeneficiarioClass.BuscarBeneficiario(criterio, CriterioBusqueda.Busqueda_ID);
                       x.Descripcion = f.descripcion;

                       x.Fecha = (DateTime)f.fecha;

                    x._usuario_autorizo = UsuarioClass.BuscarUsuarioPorId((int)f.id_usu_autoriza);
                    x._usuario_entrego = UsuarioClass.BuscarUsuarioPorId((int)f.id_usu_entrega);

                    if (completo)
                       {
                           x.Items_entrega = ItemEntregaClass.ListarItemEntregaPorOrden(f.id_orden);
                       }

                       r.Add(x);
                  

               }


           }

           return r;
       }

        public static List<OrdenEntregaClass> ListarOrdenesPorNombreBeneficiario(string nombreBen, bool completo = false)
        {
            List<OrdenEntregaClass> r = new List<OrdenEntregaClass>();
            saluddbEntities mctx = new saluddbEntities();
            OrdenEntregaClass x;

            var cur = from o in mctx.ordenentregas
                      join b in mctx.beneficiarios
                      on o.id_beneficiario equals b.id_beneficiario
                      where b.nombre.Contains(nombreBen)
                      select o;

            foreach (var f in cur)
            {

                if (!ordenEliminada(f.id_orden))
                {
                    x = new OrdenEntregaClass();

                    x._estados = OrdenEstadoClass.ListarPorOrden(f.id_orden);
                    x._id_orden_entrega = f.id_orden;
                    //x._usuario = UsuarioClass.BuscarUsuarioPorId(f.id_usuario);
                    x._usuario_genero = UsuarioClass.BuscarUsuarioPorId(f.id_usuario);
                    String criterio = f.id_beneficiario.ToString();
                    x.Beneficiario = BeneficiarioClass.BuscarBeneficiario(criterio, CriterioBusqueda.Busqueda_ID);
                    x.Descripcion = f.descripcion;

                    x.Fecha = (DateTime)f.fecha;

                    x._usuario_autorizo = UsuarioClass.BuscarUsuarioPorId((int)f.id_usu_autoriza);
                    x._usuario_entrego = UsuarioClass.BuscarUsuarioPorId((int)f.id_usu_entrega);

                    if (completo)
                    {
                        x.Items_entrega = ItemEntregaClass.ListarItemEntregaPorOrden(f.id_orden);
                    }

                    r.Add(x);


                }


            }

            return r;
        }


       /// <summary>
       /// Carga los estados de la base de datos pertenecientes a la orden de entrega
       /// </summary>
      /* private void CargarEstados()
       {
          
           var cur = from oe in ctx.ordenestadoes
                     where oe.id_orden == _id_orden_entrega
                     select oe;

           foreach (var f in cur)
           {

               _estados.Add((EstadoOrden)f.estado); //Agrega los estados a la lista de estados

           }
       }*/

       private static bool ordenEliminada(long id_orden)
       {
           saluddbEntities ctx = new saluddbEntities();

                var cur2 = from oe in ctx.ordenestadoes
                     where oe.id_orden == id_orden && oe.estado == (int)EstadoOrden.ELIMINADO
                     select oe;

           if(cur2.Count() > 0)
           {
               return true;
           }

           return false;
       }


       /// <summary>
       /// Retorna la lista de ordenes no eliminadas en las que el usuario realizó algún cambio de estado
       /// </summary>
       /// <param name="id_usuario">Id del usuario</param>
       /// <param name="completo">Indica si las ordenes de entrega van a ser completas o no, se refiere a que si van a tener la lista de Items</param>
       /// <returns>Retorna la lista de ordenes de entrega</returns>
       public static List<OrdenEntregaClass> ListarOrdenesPorUsuario(int id_usuario, bool completo = false)
       {

           List<OrdenEntregaClass> r = new List<OrdenEntregaClass>();
           saluddbEntities mctx = new saluddbEntities();
           OrdenEntregaClass x;

           var cur = (from oEst in mctx.ordenestadoes

                     join oEnt in mctx.ordenentregas
                     on oEst.id_orden equals oEnt.id_orden

                     where oEst.id_usuario == id_usuario
                     select oEnt).Distinct();

           foreach (var f in cur)
           {

               if (!ordenEliminada(f.id_orden))
               {
                        x = new OrdenEntregaClass();

                       x._estados = OrdenEstadoClass.ListarPorOrden(f.id_orden);
                       x._id_orden_entrega = f.id_orden;
                       //x._usuario = UsuarioClass.BuscarUsuarioPorId(f.id_usuario);
                       x._usuario_genero = UsuarioClass.BuscarUsuarioPorId(f.id_usuario);
                       String criterio = f.id_beneficiario.ToString();
                       x.Beneficiario = BeneficiarioClass.BuscarBeneficiario(criterio, CriterioBusqueda.Busqueda_ID);
                       x.Descripcion = f.descripcion;

                       x.Fecha = (DateTime)f.fecha;

                    x._usuario_autorizo = UsuarioClass.BuscarUsuarioPorId((int)f.id_usu_autoriza);
                    x._usuario_entrego = UsuarioClass.BuscarUsuarioPorId((int)f.id_usu_entrega);

                    if (completo)
                       {
                           x.Items_entrega = ItemEntregaClass.ListarItemEntregaPorOrden(f.id_orden);
                       }

                       r.Add(x);
                  

               }


           }

           return r;
       }


       /// <summary>
       /// Lista las ordenes creadas por el usuario  Id_usuario
       /// </summary>
       /// <param name="id_usuario">Id del usuario que creo las ordenes a listar</param>
       /// <param name="completo">Indica si las ordenes de entrega van a ser completas o no, se refiere a que si van a tener la lista de Items</param>
       /// <returns>Retorna una lista de ordenes creadas por el usaurio Id_usaurio</returns>
       public static List<OrdenEntregaClass> ListarOrdenesCreadasPorUsuario(int id_usuario, bool completo = false)
       {
           List<OrdenEntregaClass> r = new List<OrdenEntregaClass>();
           saluddbEntities mctx = new saluddbEntities();
           OrdenEntregaClass x;

           var cur = (from oEst in mctx.ordenestadoes

                      join oEnt in mctx.ordenentregas
                      on oEst.id_orden equals oEnt.id_orden

                      where oEst.id_usuario == id_usuario && oEst.estado == (int)EstadoOrden.INICIADO// selecciona solo los estados iniciados para conocer los creadores de la orden
                      select oEnt).Distinct();

           foreach (var f in cur)
           {

               if (!ordenEliminada(f.id_orden))
               {
                   x = new OrdenEntregaClass();

                   x._estados = OrdenEstadoClass.ListarPorOrden(f.id_orden);
                   x._id_orden_entrega = f.id_orden;
                   //x._usuario = UsuarioClass.BuscarUsuarioPorId(f.id_usuario);
                   x._usuario_genero = UsuarioClass.BuscarUsuarioPorId(f.id_usuario);
                   String criterio = f.id_beneficiario.ToString();
                   x.Beneficiario = BeneficiarioClass.BuscarBeneficiario(criterio, CriterioBusqueda.Busqueda_ID);
                   x.Descripcion = f.descripcion;

                   x.Fecha = (DateTime)f.fecha;
                    x._usuario_autorizo = UsuarioClass.BuscarUsuarioPorId((int)f.id_usu_autoriza);
                    x._usuario_entrego = UsuarioClass.BuscarUsuarioPorId((int)f.id_usu_entrega);

                    if (completo)
                   {
                       x.Items_entrega = ItemEntregaClass.ListarItemEntregaPorOrden(f.id_orden);
                   }

                   r.Add(x);


               }


           }

           return r;

       }

        public static List<OrdenEntregaClass> ListarOrdenesPorEstado(EstadoOrden est, bool completo = false)
        {
            List<OrdenEntregaClass> r = new List<OrdenEntregaClass>();
            saluddbEntities mctx = new saluddbEntities();
            OrdenEntregaClass x;
            int estado = (int)est;

            var cur = from o in mctx.ordenentregas
                      join oe in mctx.ordenestadoes
                      on o.id_orden equals oe.id_orden
                      where oe.estado == estado
                      select o;

            foreach (var f in cur)
            {

                if (!ordenEliminada(f.id_orden))
                {
                    x = new OrdenEntregaClass();

                    x._estados = OrdenEstadoClass.ListarPorOrden(f.id_orden);
                    x._id_orden_entrega = f.id_orden;

                    //x._usuario = UsuarioClass.BuscarUsuarioPorId(f.id_usuario);
                    x._usuario_genero = UsuarioClass.BuscarUsuarioPorId(f.id_usuario);
                    String criterio = f.id_beneficiario.ToString();
                    x.Beneficiario = BeneficiarioClass.BuscarBeneficiario(criterio, CriterioBusqueda.Busqueda_ID);
                    x.Descripcion = f.descripcion;

                    x.Fecha = (DateTime)f.fecha;
                    x._usuario_autorizo = UsuarioClass.BuscarUsuarioPorId((int)f.id_usu_autoriza);
                    x._usuario_entrego = UsuarioClass.BuscarUsuarioPorId((int)f.id_usu_entrega);
                    if (completo)
                    {
                        x.Items_entrega = ItemEntregaClass.ListarItemEntregaPorOrden(f.id_orden);
                    }

                    r.Add(x);


                }


            }

            return r;
        }

        /// <summary>
        /// Lista las ordenes cuyo ultimo estado (estado actual) sea el pasado como parámetro
        /// </summary>
        /// <param name="est">ultimo estado </param>
        /// <param name="completo">indica si se cargan las ordenes completas</param>
        /// <returns>Retorna una lista de ordenes que tienen como ultimo estado el pasado como parámetro</returns>
        public static List<OrdenEntregaClass> ListarOrdenesPorUltimoEstado(EstadoOrden est, bool completo = false)
        {
            List<OrdenEntregaClass> r = new List<OrdenEntregaClass>();
            saluddbEntities mctx = new saluddbEntities();
            OrdenEntregaClass x;
            int estado = (int)est;

            var cur = from o in mctx.ordenentregas
                      join oe in mctx.ordenestadoes
                      on o.id_orden equals oe.id_orden
                      where oe.estado == estado
                      select o;

            foreach (var f in cur)
            {

                if (!ordenEliminada(f.id_orden))
                {
                    OrdenEstadoClass ordenEstado = OrdenEstadoClass.UltimoEstado(f.id_orden);
                    if(ordenEstado != null)
                    {
                        if(ordenEstado.Estado == est)
                        {
                            x = new OrdenEntregaClass();

                            x._estados = OrdenEstadoClass.ListarPorOrden(f.id_orden);
                            x._id_orden_entrega = f.id_orden;

                            //x._usuario = UsuarioClass.BuscarUsuarioPorId(f.id_usuario);
                            x._usuario_genero = UsuarioClass.BuscarUsuarioPorId(f.id_usuario);
                            String criterio = f.id_beneficiario.ToString();
                            x.Beneficiario = BeneficiarioClass.BuscarBeneficiario(criterio, CriterioBusqueda.Busqueda_ID);
                            x.Descripcion = f.descripcion;

                            x.Fecha = (DateTime)f.fecha;

                            x._usuario_autorizo = UsuarioClass.BuscarUsuarioPorId((int)f.id_usu_autoriza);
                            x._usuario_entrego = UsuarioClass.BuscarUsuarioPorId((int)f.id_usu_entrega);
                            if (completo)
                            {
                                x.Items_entrega = ItemEntregaClass.ListarItemEntregaPorOrden(f.id_orden);
                            }

                            r.Add(x);

                        }
                    }

                    

                }


            }

            return r;
        }




        /// <summary>
        /// Retorna una lista de ordenes de entrega por fecha.
        /// 
        /// </summary>
        /// <param name="fecha_desde">fecha de inicio</param>
        /// <param name="fecha_hasta">fecha de fin</param>
        /// <param name="completo">Indica si se carga la orden completa</param>
        /// <returns></returns>
        public static List<OrdenEntregaClass>  ListarOrdenesPorFecha(DateTime fecha_desde,DateTime fecha_hasta, bool completo = false)
        {
            List<OrdenEntregaClass> r = new List<OrdenEntregaClass>();
            saluddbEntities mctx = new saluddbEntities();
            OrdenEntregaClass x;



            var cur = from o in mctx.ordenentregas
                      where fecha_desde <= o.fecha && fecha_hasta >= o.fecha  
                      select o;

            foreach (var f in cur)
            {

                if (!ordenEliminada(f.id_orden))
                {
                    x = new OrdenEntregaClass();

                    x._estados = OrdenEstadoClass.ListarPorOrden(f.id_orden);
                    x._id_orden_entrega = f.id_orden;

                    //x._usuario = UsuarioClass.BuscarUsuarioPorId(f.id_usuario);
                    x._usuario_genero = UsuarioClass.BuscarUsuarioPorId(f.id_usuario);
                    String criterio = f.id_beneficiario.ToString();
                    x.Beneficiario = BeneficiarioClass.BuscarBeneficiario(criterio, CriterioBusqueda.Busqueda_ID);
                    x.Descripcion = f.descripcion;

                    x.Fecha = (DateTime)f.fecha;
                    x._usuario_autorizo = UsuarioClass.BuscarUsuarioPorId((int)f.id_usu_autoriza);
                    x._usuario_entrego = UsuarioClass.BuscarUsuarioPorId((int)f.id_usu_entrega);
                    if (completo)
                    {
                        x.Items_entrega = ItemEntregaClass.ListarItemEntregaPorOrden(f.id_orden);
                    }

                    r.Add(x);


                }


            }


            return r;
        }
        #endregion
    }
}
