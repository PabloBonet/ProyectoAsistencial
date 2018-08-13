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
        private String _cuit_cuil;
        private DateTime _fecha_nac;
        private BarrioClass _barrio;
        private List<BeneficioBeneficiarioClass> _beneficios;


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

        /// <summary>
        /// Obtiene y establece el CUIT o CUIL del beneficiario
        /// </summary>
        public String Cuit_Cuil
        {
            get { return _cuit_cuil; }
            set { _cuit_cuil = value; }
        }

        /// <summary>
        /// Obtiene y establece la fecha de nacimiento del beneficiario
        /// </summary>
        public DateTime FechaNac
        {
            get { return _fecha_nac; }
            set { _fecha_nac = value; }
        }
        public BarrioClass Barrio
        {
            get { return _barrio; }
            set { _barrio = value; }
        }

        public List<BeneficioBeneficiarioClass> Beneficios
        {
            get { return _beneficios; }
            set { _beneficios = value; }
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
            _cuit_cuil = "";
            _fecha_nac = new DateTime();
            _barrio = new BarrioClass();
            _beneficios = new List<BeneficioBeneficiarioClass>();

        }

        /// <summary>
        /// Constructor de la clase BeneficiarioClass que crea una instancia de la clase con los valores pasados como parámetros
        /// </summary>
        /// <param name="id_beneficiario">id del beneficiario</param>
        /// <param name="nombre">nombre del beneficiario</param>
        /// <param name="documento">documento del beneficiario</param>
        /// <param name="direccion">dirección del beneficiario</param>
        /// <param name="telefono">teléfono del beneficiario</param>
        public BeneficiarioClass(int id_beneficiario, String nombre, String documento, String direccion, String telefono, BarrioClass barrio, String cuit_cuil, DateTime fechaNac, List<BeneficioBeneficiarioClass> listaBeneficios)
        {
            ctx = new saluddbEntities();
            _id_beneficiario = id_beneficiario;
            _nombre = nombre;
            _documento = documento;
            _direccion = direccion;
            _telefono = telefono;
            _cuit_cuil = cuit_cuil;
            _fecha_nac = fechaNac;
            _barrio = barrio;
            if (listaBeneficios != null)
            {
                _beneficios = listaBeneficios;
            }
            else
            {
                _beneficios = new List<BeneficioBeneficiarioClass>();
            }
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
                    f.cuit_cuil = this._cuit_cuil;
                    f.fecha_nac = this._fecha_nac;
                    f.id_barrio = this._barrio.IdBarrio;

                    ctx.beneficiarios.Add(f);
                    ctx.SaveChanges();
                    _id_beneficiario = f.id_beneficiario;


                    r = true;

                    if(r)
                    {
                            // Cargo los beneficios
                            foreach(BeneficioBeneficiarioClass  ben in _beneficios)
                        {
                            beneficiario_beneficio bb = new beneficiario_beneficio();
                            bb.id_beneficiario = _id_beneficiario;
                            bb.id_beneficio = ben.Id_beneficio;
                            bb.fechadesde = ben.Fecha_asignacion;

                            ctx.beneficiario_beneficio.Add(bb);
                            ctx.SaveChanges();
                        }
                    }
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
                f.cuit_cuil = _cuit_cuil;
                f.fecha_nac = _fecha_nac;
                f.id_barrio = _barrio.IdBarrio;

                    ctx.SaveChanges();
                    r = true;

                if (r)
                {

                    var cur2 = from bb in ctx.beneficiario_beneficio
                               where bb.id_beneficiario == _id_beneficiario
                               select bb;


                    List<beneficiario_beneficio> listaGuardada = new List<beneficiario_beneficio>();
                    List<beneficiario_beneficio> listaAdd = new List<beneficiario_beneficio>();
                    List<beneficiario_beneficio> listaBorrar = new List<beneficiario_beneficio>();
                    foreach (beneficiario_beneficio bb in cur2)
                    {

                        // listaGuardada.Add(BeneficiarioClass.BuscarBeneficiario((bg.id_beneficiario).ToString(), CriterioBusqueda.Busqueda_ID));
                        listaGuardada.Add(bb);
                    }

                    // Si se guardó la descripción guardo los beneficios
                    foreach (BeneficioBeneficiarioClass be in _beneficios)
                    {

                        if (listaGuardada.Exists(x => x.id_beneficio == be.Id_beneficio))
                        {
                            // No hago nada;
                        }
                        else
                        {
                            // Guardo en la lista para agregar
                            // listaAdd.Add(b);
                            beneficiario_beneficio bb = new beneficiario_beneficio();
                            bb.id_beneficio = be.Id_beneficio;
                            bb.id_beneficiario = be.Id_beneficiario;
                            bb.fechadesde = be.Fecha_asignacion;
                            
                            listaAdd.Add(bb);
                            // ctx.beneficiario_grupo.Attach(bg);
                            ctx.beneficiario_beneficio.Add(bb);
                            ctx.SaveChanges();

                            
                        }


                    }


                    foreach (beneficiario_beneficio bb in listaGuardada)
                    {

                        if (_beneficios.Exists(x => x.Id_beneficio == bb.id_beneficio))
                        {
                            // NO hago nada
                        }
                        else
                        {
                            //listaBorrar.Add(b);
                            listaBorrar.Add(bb);
                            ctx.SaveChanges();

                            //ctx.beneficiario_grupo.Remove(bg);

                        }
                    }

                   
                    /*
                     foreach (beneficiario_grupo bg in listaBorrar)
                    {

                        if (eliminarBeneficiarioGrupo(bg.id_beneficiario, bg.id_gupo))
                        {

                        }
                        else
                        {
                            r = false;
                        }


                    }
                    ctx.SaveChanges();
                    */
                }

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
                if(borrarDeGrupos())
                {
                    if(borrarAsignacionBeneficios())
                    {
                        r = true;

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
                    
                }
                else
                {
                    MessageBox.Show("Error borrar el/los grupos al que pertenece el beneficiario");
                    r = false;
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
                        r._fecha_nac = (DateTime)f.fecha_nac;
                        r._cuit_cuil = f.cuit_cuil;
                       r._barrio = BarrioClass.BuscarBarrioPorId((int)f.id_barrio);
                        r._beneficios = BeneficioBeneficiarioClass.ListarBeneficioPorBeneficiario((int)r._id_beneficiario);
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
                        r._fecha_nac = (DateTime)f.fecha_nac;
                        r._cuit_cuil = f.cuit_cuil;
                        r._barrio = BarrioClass.BuscarBarrioPorId((int)f.id_barrio);
                        r._beneficios = BeneficioBeneficiarioClass.ListarBeneficioPorBeneficiario((int)r._id_beneficiario);
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
                        r._fecha_nac = (DateTime)f.fecha_nac;
                        r._cuit_cuil = f.cuit_cuil;
                        r._barrio = BarrioClass.BuscarBarrioPorId((int)f.id_barrio);
                        r._beneficios = BeneficioBeneficiarioClass.ListarBeneficioPorBeneficiario((int)r._id_beneficiario);
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
                x._telefono = f.telefono;
                x._fecha_nac = (DateTime)f.fecha_nac;
                x._cuit_cuil = f.cuit_cuil;
                x._barrio = BarrioClass.BuscarBarrioPorId((int)f.id_barrio);
                x._beneficios = BeneficioBeneficiarioClass.ListarBeneficioPorBeneficiario((int) x._id_beneficiario);
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
                x._fecha_nac = (DateTime)f.fecha_nac;
                x._cuit_cuil = f.cuit_cuil;
                x._barrio = BarrioClass.BuscarBarrioPorId((int)f.id_barrio);
                x._beneficios = BeneficioBeneficiarioClass.ListarBeneficioPorBeneficiario((int) x._id_beneficiario);

                r.Add(x);
            }


            return r;
        }
        /// <summary>
        /// Lista los beneficiarios por criterio
        /// </summary>
        /// <param name="parametro">Parámetro con el que se compara para listar</param>
        /// <param name="criterio">Criterio de búsqueda</param>
        /// <returns>Lista de beneficiarios</returns>
        public static List<BeneficiarioClass> ListarBeneficiarioPorCriterio(string parametro, CriterioBusqueda criterio)
        {
            List<BeneficiarioClass> r = new List<BeneficiarioClass>();
            saluddbEntities mctx = new saluddbEntities();
            BeneficiarioClass x;


            var cur = from b in mctx.beneficiarios
                      select b;

            foreach (var f in cur)
            {
                bool agregar = false;
                switch(criterio)
                {
                    case CriterioBusqueda.Busqueda_Dni:
                        agregar = f.documento.Contains(parametro);
                        break;
                    case CriterioBusqueda.Busqueda_ID:
                        int id = 0;
                        Int32.TryParse(parametro, out id);
                        if (f.id_beneficiario == id)
                        {
                            agregar = true;
                        }
                        else
                        {
                            agregar = false;
                        }
                        
                        break;

                    case CriterioBusqueda.Busqueda_Nombre:
                        agregar = f.nombre.Contains(parametro);
                        break;

                                     
                }

                if (agregar)
                {
                    x = new BeneficiarioClass();

                    x._id_beneficiario = f.id_beneficiario;
                    x._nombre = f.nombre;
                    x._direccion = f.direccion;
                    x._documento = f.documento;
                    x._telefono = f.telefono;
                    x._fecha_nac = (DateTime)f.fecha_nac;
                    x._cuit_cuil = f.cuit_cuil;
                    x._barrio = BarrioClass.BuscarBarrioPorId((int)f.id_barrio);
                    x._beneficios = BeneficioBeneficiarioClass.ListarBeneficioPorBeneficiario((int) x._id_beneficiario);
                    r.Add(x);
                }
                
            }

            return r;
            
        }

        public static List<BeneficiarioClass> ListarBeneficiariosPorGrupo(int id_grupo)
        {
            List<BeneficiarioClass> r = new List<BeneficiarioClass>();
            saluddbEntities mctx = new saluddbEntities();
            BeneficiarioClass x;

            //une las tablas itemEntregas, ordenEntregas y beneficiari mediante un Join para obtener los beneficiarios que adquirieron un cierto articulo
            var cur = from bg in mctx.beneficiario_grupo
                      where bg.id_gupo== id_grupo
                      select bg;


            foreach (var f in cur)
            {

                string id_benef = (f.id_beneficiario).ToString();

                 x = BuscarBeneficiario(id_benef, CriterioBusqueda.Busqueda_ID);
             
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
                x._telefono = f.telefono;
                x._fecha_nac = (DateTime)f.fecha_nac;
                x._cuit_cuil = f.cuit_cuil;
                x._barrio = BarrioClass.BuscarBarrioPorId((int)f.id_barrio);
                x._beneficios = BeneficioBeneficiarioClass.ListarBeneficioPorBeneficiario((int) x._id_beneficiario);
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

        /// <summary>
        /// Borra la relación del beneficiario en los grupos
        /// </summary>
        /// <returns>Return True si se eliminó correctamente</returns>
        private bool borrarDeGrupos()
        {
            bool r = false;

            var cur = from bg in ctx.beneficiario_grupo
                      where bg.id_beneficiario == _id_beneficiario
                      select bg;
            try
            {
                foreach (var bg in cur)
                {
                    ctx.beneficiario_grupo.Remove(bg);
                }
           
                ctx.SaveChanges();
                r = true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error al eliminar la asociación del beneficiario con el grupo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                r = false;
            }
        
         
                         

            return r;
        }


        private bool borrarAsignacionBeneficios()
        {
            bool r = false;

            var cur = from bb in ctx.beneficiario_beneficio
                      where bb.id_beneficiario == _id_beneficiario
                      select bb;
            try
            {
                foreach (var bb in cur)
                {
                    ctx.beneficiario_beneficio.Remove(bb);
                }

                ctx.SaveChanges();
                r = true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error al eliminar la asociación del beneficiario con los beneficios", MessageBoxButtons.OK, MessageBoxIcon.Error);
                r = false;
            }




            return r;
        }
        
        #endregion
    }
}
