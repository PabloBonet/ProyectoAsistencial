using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Processar.ProyectoAyudar.DatosLibrary;
using System.Windows.Forms;

namespace Processar.ProyectoAyudar.ClasesLibrary
{
    public class BeneficiarioClass
    {
        #region Propiedades
        private saluddbEntities ctx;
        private int _id_beneficiario;
        private String _nombre;
        private String _documento;
        private String _direccion;
        private String _telefono;
        private BarrioClass _barrio;


        /// <summary>
        /// Obtiene el id del beneficiario
        /// </summary>
        public int  Id_beneficiario
        {
            get { return _id_beneficiario; }
        }

        /// <summary>
        /// Obtiene y establece el nombre del beneficiario
        /// </summary>

        public String Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }


        /// <summary>
        /// Obtiene y establece el documento del beneficiario
        /// </summary>
        public String Documento
        {
            get { return _documento; }
            set { _documento = value; }
        }


        /// <summary>
        /// Obtiene y establece la dirección del beneficiario
        /// </summary>
        public String Direccion
        {
            get { return _direccion; }
            set { _direccion = value; }
        
        }


        /// <summary>
        /// Obtiene y establece el teléfono del beneficiario
        /// </summary>
        public String Telefono
        {
            get { return _telefono; }
            set { _telefono = value; }
        }

        public BarrioClass Barrio
        {
            get { return _barrio; }
            set { _barrio = value; }
        }
        #endregion


        #region Constructores

        /// <summary>
        /// Constructor por defecto de la clase BeneficiarioClass
        /// Crea una instancia vacia de la clase
        /// </summary>
        public BeneficiarioClass()
        {
            ctx = new saluddbEntities();
            _id_beneficiario = 0;
            _nombre = "";
            _documento = "";
            _direccion = "";
            _telefono = "";
            _barrio = new BarrioClass();

        }

        /// <summary>
        /// Constructor de la clase BeneficiarioClass que crea una instancia de la clase con los valores pasados como parámetros
        /// </summary>
        /// <param name="id_beneficiario">id del beneficiario</param>
        /// <param name="nombre">nombre del beneficiario</param>
        /// <param name="documento">documento del beneficiario</param>
        /// <param name="direccion">dirección del beneficiario</param>
        /// <param name="telefono">teléfono del beneficiario</param>
        public BeneficiarioClass(int id_beneficiario, String nombre, String documento, String direccion, String telefono, BarrioClass barrio)
        {
            ctx = new saluddbEntities();
            _id_beneficiario = id_beneficiario;
            _nombre = nombre;
            _documento = documento;
            _direccion = direccion;
            _telefono = telefono;
            _barrio = barrio;
        }
        #endregion

        #region Metodos

        /// <summary>
        /// Guarda el Beneficiario en la base de datos
        /// </summary>
        /// <returns>Retorna True si se guardó correctamente </returns>
        public bool NuevoBeneficiario()
        {
            bool r = false;
            try
            {

                if (!existeBeneficiario(this.Documento))
                {
                    beneficiario f = new beneficiario();

                    f.direccion = this._direccion;
                    f.documento = this._documento;
                    f.nombre = this._nombre;
                    f.telefono = this._telefono;
                    f.id_barrio = this._barrio.IdBarrio;

                    ctx.beneficiarios.Add(f);
                    ctx.SaveChanges();
                    _id_beneficiario = f.id_beneficiario;


                    r = true;
                }
                else
                {
                    MessageBox.Show("Ya existe un beneficiario con ese Documento!");
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

        public bool Modificar()
        {

            bool r = false;
            try
            {

               
                var cur = from b in ctx.beneficiarios
                          where b.id_beneficiario == _id_beneficiario
                          select b;


                var f = cur.First();
                f.direccion = _direccion;
                f.documento = _documento;
                f.nombre = _nombre;
                f.telefono = _telefono;
                f.id_barrio = _barrio.IdBarrio;

                    ctx.SaveChanges();
                    r = true;
                
            
                    
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message, "Error al modificar el beneficiario", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    r = false;
                }
            
            

            return r;
        }

        /// <summary>
        /// Función que retorna si se puede borrar o no el beneficiario
        /// Se va a poder borrar si no está incluido en alguna orden de entrega
        /// </summary>
        /// <returns>Retorna True si se puede borrar </returns>
        private bool Borrar_OK()
        {

            var cur = from oE in ctx.ordenentregas
                      where oE.id_beneficiario == _id_beneficiario
                      select oE;

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
        /// Elimina el beneficiario de la base de datos, previamente comprueba que el beneficiario no se encuentre asignado a alguna orden de entrega
        /// </summary>
        /// <returns>Retorna True si se eliminó correctamente</returns>

        public bool Eliminar()
        {
            bool r = false;

            if (Borrar_OK())
            {
                var cur = from b in ctx.beneficiarios
                          where b.id_beneficiario == _id_beneficiario
                          select b;

                if (cur.Count() > 0)
                {
                    var f = cur.First();

                    ctx.beneficiarios.Remove(f);
                    try
                    {
                        ctx.SaveChanges();
                        r = true;
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message, "Error al eliminar el beneficiario", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        r = false;
                    }
                }
            }
            else
            {

                r = false;
                MessageBox.Show("Existen beneficiarios asociados a ordenes", "Imposible Eliminar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
            return r;
        }

        /// <summary>
        /// Busca el beneficiario según el criterio de busqueda y el  parametro
        /// </summary>
        /// <param name="criterio"></param>
        /// <returns>Retorna el Beneficiario. Null en otro  caso</returns>
        public static BeneficiarioClass BuscarBeneficiario(String parametro, CriterioBusqueda criterio)
        {
            BeneficiarioClass r = new BeneficiarioClass();

            saluddbEntities ctx = new saluddbEntities();

            switch (criterio)
            {
                    
                case CriterioBusqueda.Busqueda_ID:
                    int id = 0;
                    Int32.TryParse(parametro, out id);

                   var cur = from b in ctx.beneficiarios
                          where b.id_beneficiario == id
                          select b;

                   if (cur.Count() > 0)
                   {
                       var f = cur.First();

                       r._id_beneficiario = f.id_beneficiario;
                       r._documento = f.documento;
                       r._direccion = f.direccion;
                       r._telefono = f.telefono;
                       r._nombre = f.nombre;
                       r._barrio = BarrioClass.BuscarBarrioPorId((int)f.id_barrio);
                       return r;
                   }

                    break;


                case CriterioBusqueda.Busqueda_Dni:
                   var cur2 = from b in ctx.beneficiarios
                          where b.documento == parametro
                          select b;
                   if (cur2.Count() > 0)
                   {
                       var f = cur2.First();

                       r._id_beneficiario = f.id_beneficiario;
                       r._documento = f.documento;
                       r._direccion = f.direccion;
                       r._telefono = f.telefono;
                       r._nombre = f.nombre;
                       r._barrio = BarrioClass.BuscarBarrioPorId((int)f.id_barrio);
                       return r;
                   }
                    break;

                case CriterioBusqueda.Busqueda_Nombre:
                   var cur3 = from b in ctx.beneficiarios
                          where b.nombre == parametro
                          select b;
                    if (cur3.Count() > 0)
                    {
                        var f = cur3.First();

                        r._id_beneficiario = f.id_beneficiario;
                        r._documento = f.documento;
                        r._direccion = f.direccion;
                        r._telefono = f.telefono;
                        r._nombre = f.nombre;
                        r._barrio = BarrioClass.BuscarBarrioPorId((int)f.id_barrio);
                        return r;
                    }
                    break;
            }



            return null;
        }

        public static List<BeneficiarioClass> ListarBeneficiariosPorNombre(string nombre)
        {
            List<BeneficiarioClass> r = new List<BeneficiarioClass>();
            saluddbEntities mctx = new saluddbEntities();
            BeneficiarioClass x;

            
            var cur = from ben in mctx.beneficiarios
                      where ben.nombre.Contains(nombre)
                      select ben;


            foreach (var f in cur)
            {
                x = new BeneficiarioClass();

                x._id_beneficiario = f.id_beneficiario;
                x._nombre = f.nombre;
                x._direccion = f.direccion;
                x._documento = f.documento;
                x._telefono = f.documento;
                x._barrio = BarrioClass.BuscarBarrioPorId((int)f.id_barrio);

                r.Add(x);
            }
            return r;

        }

        public static BeneficiarioClass BuscarBeneficiariosPorOrden(long id_orden)
        {
            BeneficiarioClass r = new BeneficiarioClass();

            saluddbEntities ctx = new saluddbEntities();

            var cur = from o in ctx.ordenentregas
                       where o.id_orden == id_orden
                       select o;

            if(cur.Count() > 0)
            {
                var f = cur.First();

                r = BeneficiarioClass.BuscarBeneficiario(f.id_beneficiario.ToString(), CriterioBusqueda.Busqueda_ID);


                return r;
            }

            return r;
        }

        /// <summary>
        /// Lista todos los beneficiarios que se encuentran en la base de datos
        /// </summary>
        /// <returns>Lista de beneficiarios</returns>
        public static List<BeneficiarioClass> ListarBeneficiarios()
        {
            List<BeneficiarioClass> r = new List<BeneficiarioClass>();
            saluddbEntities mctx = new saluddbEntities();
            BeneficiarioClass x;

            var cur = from b in mctx.beneficiarios
                      orderby b.nombre
                      select b;

            foreach (var f in cur)
            {
                x = new BeneficiarioClass();

                x._id_beneficiario = f.id_beneficiario;
                x._nombre = f.nombre;
                x._direccion = f.direccion;
                x._documento = f.documento;
                x._telefono = f.telefono;
                x._barrio = BarrioClass.BuscarBarrioPorId((int)f.id_barrio);
                               
                r.Add(x);
            }


            return r;
        }

        /// <summary>
        /// Lista los beneficiarios que adquirieron el articulo pasado como parametro.
        /// </summary>
        /// <param name="id_articulo">id del articulo al que se va a buscar el beneficiario</param>
        /// <returns>Lista de beneficiarios</returns>
        public static List<BeneficiarioClass> ListarBeneficiarioPorArticulo(int id_articulo)
        {

            List<BeneficiarioClass> r = new List<BeneficiarioClass>();
            saluddbEntities mctx = new saluddbEntities();
            BeneficiarioClass x;

            //une las tablas itemEntregas, ordenEntregas y beneficiari mediante un Join para obtener los beneficiarios que adquirieron un cierto articulo
            var cur = from ben in mctx.beneficiarios

                      join ord in mctx.ordenentregas
                      on ben.id_beneficiario equals ord.id_beneficiario

                      join item in mctx.itementregas
                       on ord.id_orden equals item.id_orden

                      where item.id_articulo == id_articulo
                      select ben;


            foreach (var f in cur)
            {
                x = new BeneficiarioClass();

                x._id_beneficiario = f.id_beneficiario;
                x._nombre = f.nombre;
                x._direccion = f.direccion;
                x._documento = f.documento;
                x._telefono = f.documento;
                x._barrio = BarrioClass.BuscarBarrioPorId((int)f.id_barrio);

                r.Add(x);
            }


            return r;
        }

        /// <summary>
        /// Comprueba que el beneficiario no exista en la base de datos, la comprobacion la hace por el DNI
        /// </summary>
        /// <param name="dni">DNI del beneficiario a comprobar existencia</param>
        /// <returns></returns>
        public static bool existeBeneficiario(string dni)
        {
            bool existe = false;

            saluddbEntities ctx = new saluddbEntities();
            

            var cur = from b in ctx.beneficiarios
                      where b.documento == dni
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
