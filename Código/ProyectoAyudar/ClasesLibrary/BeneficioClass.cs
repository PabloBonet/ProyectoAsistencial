using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Processar.ProyectoAyudar.DatosLibrary;
using System.Windows.Forms;

namespace Processar.ProyectoAyudar.ClasesLibrary
{
    public class BeneficioClass
    {

        #region Propiedades
        private saluddbEntities ctx;
        private int _id_beneficio;
        private String _nombre_beneficio;
        private String _descripcion_beneficio;
        

        /// <summary>
        /// Retorna el ID del beneficio
        /// </summary>
        public int Id_beneficio
        {
            get { return _id_beneficio; }
        }

        /// <summary>
        /// Retorna o establece el nombre del del beneficio
        /// </summary>
        public String Nombre_beneficio
        {
            get { return _nombre_beneficio; }
            set { _nombre_beneficio = value; }
        }

        /// <summary>
        /// Retorna o establece la descripción del beneficio
        /// </summary>
        public String Descripcion_beneficio
        {
            get { return _descripcion_beneficio; }
            set { _descripcion_beneficio = value; }
        }

        #endregion

        #region Constructores

        /// <summary>
        /// Constructor por defecto de la clase BeneficioClass
        /// Crea una instancia de la clase, con todas las propiedades en cero o vacias
        /// </summary>
        public BeneficioClass()
        {
            this.ctx = new saluddbEntities();
            this._id_beneficio= 0;
            this._nombre_beneficio= "";
            this._descripcion_beneficio= "";
            
        }

        /// <summary>
        /// Constructor de la clase BeneficioClass
        /// </summary>
        /// <param name="id_beneficio"></param>
        /// <param name="nombre_beneficio"></param>
        /// <param name="descripcion_beneficio"></param>
        public BeneficioClass(int id_beneficio, String nombre_beneficio, String descripcion_beneficio)
        {
            this.ctx = new saluddbEntities();
            this._id_beneficio = id_beneficio;
            this._nombre_beneficio = nombre_beneficio ;
            this._descripcion_beneficio = descripcion_beneficio;
            
        }
        #endregion



        #region Metodos
        /// <summary>
        /// Guarda el Beneficio en la base de datos
        /// </summary>
        /// <returns>Retorna True si se guardó correctamente </returns>
        public bool NuevoBeneficio()
        {
            bool r = false;

            beneficio f = new beneficio();

            try
            {
                //busca el beneficio para comprobar que no existe uno con el mismo nombre
                var cur = from b in ctx.beneficios
                          where b.nombre == this.Nombre_beneficio
                          select b;

                if (cur.Count() == 0)
                {

                    f.nombre = this.Nombre_beneficio;
                    f.descripcion = this.Descripcion_beneficio;
                   



                    ctx.beneficios.Add(f);
                    ctx.SaveChanges();
                    _id_beneficio = f.id_beneficio;

                    r = true;
                }
                else
                {
                    MessageBox.Show("Ya existe un Beneficio con ese nombre!");
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
        /// Modifica el beneficio en la base de datos
        /// </summary>
        /// <returns>Retorna True si se modificó correctamente</returns>
        public bool ModificarBeneficio()
        {
            bool r = false;

            try
            {

                
                var cur = from b in ctx.beneficios
                          where b.id_beneficio == _id_beneficio
                          select b;


                var f = cur.First();
                f.descripcion = _descripcion_beneficio;
                
            
                ctx.SaveChanges();
                r = true;


            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error al modificar el Beneficio", MessageBoxButtons.OK, MessageBoxIcon.Error);
                r = false;
            }

            return r;
        }

        /// <summary>
        /// Función que determina si se puede borrar o no el beneficio
        /// Comprueba que el beneficio no esté asignado a algún beneficiario
        /// </summary>
        /// <returns>Retorna True si el articulo no está asignado a un itemEntrega</returns>
        private bool Borrar_OK()
        {

            var cur = from bb in ctx.beneficiario_beneficio
                      where bb.id_beneficio == _id_beneficio
                      select bb;

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
        /// Elimina el Beneficio de la base de datos, previamente comprueba que este beneficio no este asignado a un beneficiario
        /// </summary>
        /// <returns>Retorna True si se eliminó correctamente</returns>

        public bool Eliminar()
        {
            bool r = false;

            if (Borrar_OK())
            {
                var cur = from b in ctx.beneficios
                          where b.id_beneficio == _id_beneficio
                          select b;

                if (cur.Count() > 0)
                {
                    var f = cur.First();

                    ctx.beneficios.Remove(f);
                    try
                    {
                        ctx.SaveChanges();
                        r = true;
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message, "Error al eliminar el Beneficio", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        r = false;
                    }
                }
            }
            else
            {

                r = false;
                MessageBox.Show("Existen Beneficiarios con este Beneficio", "Imposible Eliminar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
            return r;
        }

        /// <summary>
        /// Busca un Beneficio por Id_beneficio
        /// </summary>
        /// <param name="id_beneficio">ID del beneficio a buscar</param>
        /// <returns>Retorna un objeto BeneficioClass</returns>
        public static BeneficioClass BuscarBeneficioPorId(int id_beneficio)
        {
            BeneficioClass r = new BeneficioClass();

            saluddbEntities mctx = new saluddbEntities();

            var cur = from b in mctx.beneficios
                      where b.id_beneficio == id_beneficio
                      select b;

            if (cur.Count() > 0)
            {
                var f = cur.First();

                r._id_beneficio = f.id_beneficio;
                r._nombre_beneficio = f.nombre;
                r._descripcion_beneficio = f.descripcion;

              
            }
            else
            {
                r = null;

            }

            return r;

        }

        /// <summary>
        /// Lista todos los beneficios registrados en la base de datos
        /// </summary>
        /// <returns>Retorna una lista de objetos de la clase BeneficioClass</returns>
        public static List<BeneficioClass> ListarBeneficios()
        {
            List<BeneficioClass> r = new List<BeneficioClass>();
            saluddbEntities mctx = new saluddbEntities();
            BeneficioClass x;

            var cur = from b in mctx.beneficios
                      orderby b.nombre
                      select b;

            foreach (var f in cur)
            {
                x = new BeneficioClass();

                x._id_beneficio = f.id_beneficio;
                x._nombre_beneficio = f.nombre;
                x._descripcion_beneficio = f.descripcion;
                

                r.Add(x);
            }


            return r;

        }

        /// <summary>
        /// Lista los Beneficios por criterio
        /// </summary>
        /// <param name="parametro">Parámetro con el que se compara para listar</param>
        /// <param name="criterio">Criterio de búsqueda</param>
        /// <returns>Lista de Beneficios</returns>
        public static List<BeneficioClass> ListarBeneficioPorCriterio(string parametro, CriterioBusqueda criterio)
        {
            List<BeneficioClass> r = new List<BeneficioClass>();
            saluddbEntities mctx = new saluddbEntities();
            BeneficioClass x;



            var cur = from b in mctx.beneficios
                      select b;

            foreach (var f in cur)
            {
                bool agregar = false;
                switch (criterio)
                {

                    case CriterioBusqueda.Busqueda_ID:
                        int id = 0;
                        Int32.TryParse(parametro, out id);
                        if (f.id_beneficio == id)
                        {
                            agregar = true;
                        }
                        else
                        {
                            agregar = false;
                        }

                        break;

                    case CriterioBusqueda.Busqueda_Nombre_Beneficio:
                        agregar = f.nombre.Contains(parametro);
                        break;

                    case CriterioBusqueda.Busqueda_Dni:
                        List<BeneficiarioClass> listaBenef = BeneficiarioClass.ListarBeneficiarioPorCriterio(parametro, CriterioBusqueda.Busqueda_Dni);
                        List<BeneficioClass> listaBeneficio = new List<BeneficioClass>();
                        foreach (BeneficiarioClass b in listaBenef)
                        {


                            List<BeneficioClass> listaGrupoBenf = BeneficioClass.ListarBeneficiosPorBeneficiario(b.Id_beneficiario);

                            foreach (BeneficioClass g in listaGrupoBenf)
                            {
                                if (listaBeneficio.Contains(g))
                                {

                                }
                                else
                                {
                                    listaBeneficio.Add(g);
                                }
                            }


                        }


                        BeneficioClass  benef = listaBeneficio.Find(b => b.Id_beneficio == f.id_beneficio);

                        if (benef != null)
                        {
                            agregar = true;
                        }

                        break;

                    case CriterioBusqueda.Busqueda_Nombre:
                        List<BeneficiarioClass> listaBen = BeneficiarioClass.ListarBeneficiarioPorCriterio(parametro, CriterioBusqueda.Busqueda_Nombre);
                        List<BeneficioClass> listaB = new List<BeneficioClass>();
                        foreach (BeneficiarioClass b in listaBen)
                        {


                            List<BeneficioClass> listaBeneficiario = BeneficioClass.ListarBeneficiosPorBeneficiario(b.Id_beneficiario);

                            foreach (BeneficioClass g in listaBeneficiario)
                            {
                                if (listaB.Contains(g))
                                {

                                }
                                else
                                {
                                    listaB.Add(g);
                                }
                            }


                        }


                        BeneficioClass ben = listaB.Find(b => b.Id_beneficio == f.id_beneficio);

                        if (ben != null)
                        {
                            agregar = true;
                        }

                        break;



                }

                if (agregar)
                {
                    x = new BeneficioClass();

                    x._id_beneficio = f.id_beneficio;
                    x._descripcion_beneficio = f.descripcion;
                    x._nombre_beneficio = f.nombre;

                    r.Add(x);
                }

            }

            return r;
        }
        ///<summary>
        ///   Lista todos los beneficios registrados en la base de datos que están asociados al beneficiario (id_beneficiario)
        /// </summary>
        /// <returns>Retorna una lista de objetos de la clase BeneficioClass</returns>
        /// <param name="id_beneficiario">Id del beneficiario</param>
        /// <returns>Retorna una lista de objetos de la clase ArticulosClass</returns>
        public static List<BeneficioClass> ListarBeneficiosPorBeneficiario(long id_beneficiario)
        {
            List<BeneficioClass> r = new List<BeneficioClass>();
            saluddbEntities mctx = new saluddbEntities();
            BeneficioClass x;

            //une las tablas articulos, itemEntregas y ordenEntregas mediante un Join para obtener los articulos de un determinado beneficiario
            var cur = from bb in mctx.beneficiario_beneficio

                      join b in mctx.beneficios
                      on bb.id_beneficio equals b.id_beneficio
                      
                      where bb.id_beneficiario == id_beneficiario
                      select b;


            foreach (var f in cur)
            {
                x = new BeneficioClass();

                x._id_beneficio = f.id_beneficio;
                x._nombre_beneficio = f.nombre;
                x._descripcion_beneficio = f.descripcion;
               

                r.Add(x);
            }


            return r;

        }

       

        /// <summary>
        /// Lista los beneficio de la base de datos que contiene el nombre pasado como parametro en su nombre
        /// </summary>
        /// <param name="nombre">nombre del Beneficio</param>
        /// <returns>Retorna una lista (ordenada por nombre de artículo) con los beneficios</returns>
        public static List<BeneficioClass> ListarBeneficiosPorNombre(string nombre)
        {
            List<BeneficioClass> r = new List<BeneficioClass>();
            saluddbEntities mctx = new saluddbEntities();
            BeneficioClass x;

            var cur = from b in mctx.beneficios
                      where b.nombre.Contains(nombre)
                      orderby b.nombre
                      select b;

            foreach (var f in cur)
            {
                x = new BeneficioClass();

                x._id_beneficio = f.id_beneficio;
                x._nombre_beneficio = f.nombre;
                x._descripcion_beneficio = f.descripcion;
              
                r.Add(x);
            }


            return r;
        }

      
        
        
        #endregion
    }
}
