using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Processar.ProyectoAyudar.DatosLibrary;
using System.Windows.Forms;

namespace Processar.ProyectoAyudar.ClasesLibrary
{
    public class GrupoBeneficiarioClass
    {



        #region Propiedades
        private saluddbEntities ctx;
        private int _id_grupo;
        private String _nombre;
        private String _descripcion;
        private List<BeneficiarioClass> _beneficiarios;
      


        /// <summary>
        /// Obtiene el id del grupo 
        /// </summary>
        public int Id_grupo
        {
            get { return _id_grupo; }
        }

        /// <summary>
        /// Obtiene y establece el nombre del grupo
        /// </summary>

        public String Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }


        /// <summary>
        /// Obtiene y establece la descripción del grupo
        /// </summary>
        public String Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }

        /// <summary>
        /// Obtiene y retorna los beneficiarios del grupo
        /// </summary>
        public List<BeneficiarioClass> Beneficiarios
        {
            get { return _beneficiarios; }
            set { _beneficiarios = value; }
        }

     
        #endregion


        #region Constructores

        /// <summary>
        /// Constructor por defecto de la clase BeneficiarioClass
        /// Crea una instancia vacia de la clase
        /// </summary>
        public GrupoBeneficiarioClass()
        {
            ctx = new saluddbEntities();
            _id_grupo = 0;
            _nombre = "";
            _descripcion = "";
            _beneficiarios = new List<ClasesLibrary.BeneficiarioClass>();
           
        }

        /// <summary>
        /// Constructor de la clase GrupoBeneficiarioClass que crea una instancia de la clase con los valores pasados como parámetros
        /// </summary>
        /// <param name="id_grupo">id del Grupo</param>
        /// <param name="nombre">nombre del Grupo</param>
        /// <param name="descripcion">descripción del grupo</param>
        /// <param name="beneficiarios">Lista de beneficiarios del grupo</param>
        /// <param name="telefono">teléfono del beneficiario</param>
        public GrupoBeneficiarioClass(int id_grupo, String nombre, String descripcion, List<BeneficiarioClass> listBeneficiarios)
        {
            ctx = new saluddbEntities();
            _id_grupo= id_grupo;
            _nombre = nombre;
            _descripcion= descripcion;
            if (listBeneficiarios == null)
            {
                _beneficiarios = new List<BeneficiarioClass>();
            }
            else
            {
                _beneficiarios = listBeneficiarios;
            }
           
            
        }
        #endregion

        #region Metodos

        /// <summary>
        /// Guarda el Grupo en la base de datos
        /// </summary>
        /// <returns>Retorna True si se guardó correctamente </returns>
        public bool NuevoGrupoBeneficiario()
        {
            bool r = false;
            try
            {

                if (!existeGrupoBeneficiario(this._nombre))
                {
                    grupo f = new grupo();

                    
                    f.nombre = this._nombre;
                    f.descripcion = this._descripcion;

                    ctx.grupoes.Add(f);
                    ctx.SaveChanges();
                    _id_grupo = f.id_grupo;


                    r = true;


                    if(r == true && _id_grupo > 0)
                    {
                        // Si se guardó correctamente el grupo, guardo los beneficiarios asociados

                        foreach(BeneficiarioClass b in _beneficiarios)
                        {
                            beneficiario_grupo bg = new beneficiario_grupo();

                            bg.id_beneficiario = b.Id_beneficiario;
                            bg.id_gupo = this._id_grupo;

                            ctx.beneficiario_grupo.Add(bg);
                            ctx.SaveChanges();
                            r = true;
                      
                        }
                    }
                    
                }
                else
                {
                    MessageBox.Show("Ya existe un Grupo con ese Nombre!");
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


                var cur = from g in ctx.grupoes
                          where g.id_grupo == _id_grupo
                          select g;


                var f = cur.First();
                f.descripcion = _descripcion;
                
                ctx.SaveChanges();
                r = true;

                if(r)
                {

                    var cur2 = from bg in ctx.beneficiario_grupo
                              where bg.id_gupo == _id_grupo
                              select bg;


                    List<BeneficiarioClass> listaGuardada = new List<BeneficiarioClass>();
                    List<BeneficiarioClass> listaAdd = new List<BeneficiarioClass>();
                    List<BeneficiarioClass> listaBorrar = new List<BeneficiarioClass>();
                    foreach (beneficiario_grupo bg in cur2)
                    {
                        listaGuardada.Add(BeneficiarioClass.BuscarBeneficiario((bg.id_beneficiario).ToString(), CriterioBusqueda.Busqueda_ID));
                    }

                    // Si se guardó la descripción guardo los beneficiarios
                    foreach (BeneficiarioClass b in _beneficiarios)
                    {
                        if(listaGuardada.Contains(b))
                        {
                            // No hago nada;
                        }
                        else
                        {
                            // Guardo en la lista para agregar
                            // listaAdd.Add(b);
                            beneficiario_grupo bg = new beneficiario_grupo();
                            bg.id_gupo = this.Id_grupo;
                            bg.id_beneficiario = b.Id_beneficiario;
                            ctx.beneficiario_grupo.Add(bg);
                            ctx.SaveChanges();
                        }

                        
                    }


                    foreach(BeneficiarioClass b in listaGuardada)
                    {
                        if(_beneficiarios.Contains(b))
                        {
                            // NO hago nada
                        }
                        else
                        {
                            //listaBorrar.Add(b);
                            beneficiario_grupo bg = new beneficiario_grupo();
                            bg.id_gupo = this.Id_grupo;
                            bg.id_beneficiario = b.Id_beneficiario;
                            ctx.beneficiario_grupo.Remove(bg);
                            ctx.SaveChanges();
                        }
                    }


                   
                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error al modificar el grupo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                r = false;
            }



            return r;
        }

        /// <summary>
        /// Función que retorna si se puede borrar o no el grupo
        /// Se va a borrar sin restricciones, solo que existe en la BD
        /// </summary>
        /// <returns>Retorna True si se puede borrar </returns>
        private bool Borrar_OK()
        {

            var cur = from g in ctx.grupoes
                      where g.id_grupo == _id_grupo
                      select g;

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
        /// Elimina el grupo de la base de datos, No tiene restricción para borrar el grupo, se eliminaran las relaciones con los beneficiarios
        /// </summary>
        /// <returns>Retorna True si se eliminó correctamente</returns>

        public bool Eliminar()
        {
            bool r = false;

            if (Borrar_OK())
            {


                // BORRO PRIMERO LAS RELACIONES


                var cur2 = from bg in ctx.beneficiario_grupo
                           where bg.id_gupo == _id_grupo
                           select bg;

                if (cur2.Count() > 0)
                {
                    foreach (beneficiario_grupo bg in cur2)
                    {
                        ctx.beneficiario_grupo.Remove(bg);
                        
                    }

                    try
                    {
                        ctx.SaveChanges();
                        r = true;
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message, "Error al eliminar la asociación de grupos con beneficiarios", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        r = false;
                    }
                    r = true;
                }
                else
                {
                    r = false;
                }

                if (r)
                {
                    var cur = from g in ctx.grupoes
                              where g.id_grupo == _id_grupo
                              select g;

                    if (cur.Count() > 0)
                    {
                        var f = cur.First();

                        ctx.grupoes.Remove(f);
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

                r = false;
                MessageBox.Show("No se puede eliminar el grupo", "Imposible Eliminar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
            return r;
        }

        /// <summary>
        /// Busca el grupo según el criterio de busqueda y el  parametro
        /// </summary>
        /// <param name="criterio"></param>
        /// <returns>Retorna el Beneficiario. Null en otro  caso</returns>
        public static GrupoBeneficiarioClass BuscarGrupo(String parametro, CriterioBusqueda criterio)
        {
            GrupoBeneficiarioClass r = new GrupoBeneficiarioClass();

            saluddbEntities ctx = new saluddbEntities();

            switch (criterio)
            {

                case CriterioBusqueda.Busqueda_ID:
                    int id = 0;
                    Int32.TryParse(parametro, out id);

                    var cur = from g in ctx.grupoes
                              where g.id_grupo == id
                              select g;

                    if (cur.Count() > 0)
                    {
                        var f = cur.First();

                        r._id_grupo = f.id_grupo;
                        r._descripcion = f.descripcion;
                        r._nombre = f.nombre;

                        r._beneficiarios= BeneficiarioClass.ListarBeneficiariosPorGrupo(f.id_grupo);
                        return r;
                    }

                    break;


               

                case CriterioBusqueda.Busqueda_Nombre:
                    var cur3 = from g in ctx.grupoes
                               where g.nombre == parametro
                               select g;
                    if (cur3.Count() > 0)
                    {
                        var f = cur3.First();

                      
                        r._id_grupo = f.id_grupo;
                        r._descripcion = f.descripcion;
                        r._nombre = f.nombre;

                        r._beneficiarios = BeneficiarioClass.ListarBeneficiariosPorGrupo(f.id_grupo);
                        return r;
                    }
                    break;
            }



            return null;
        }

        public static List<GrupoBeneficiarioClass> ListarGrupoBeneficiariosPorNombre(string nombre)
        {
            List<GrupoBeneficiarioClass> r = new List<GrupoBeneficiarioClass>();
            saluddbEntities mctx = new saluddbEntities();
            GrupoBeneficiarioClass x;


            var cur = from ben in mctx.grupoes
                      where ben.nombre.Contains(nombre)
                      select ben;


            foreach (var f in cur)
            {
                x = new GrupoBeneficiarioClass();

                x._id_grupo = f.id_grupo;
                x._descripcion = f.descripcion;
                x._nombre = f.nombre;

                x._beneficiarios = BeneficiarioClass.ListarBeneficiariosPorGrupo(f.id_grupo);

                r.Add(x);
            }
            return r;

        }

        

        /// <summary>
        /// Lista todos los grupos que se encuentran en la base de datos
        /// </summary>
        /// <returns>Lista de grupos</returns>
        public static List<GrupoBeneficiarioClass> ListarGrupos()
        {
            List<GrupoBeneficiarioClass> r = new List<GrupoBeneficiarioClass>();
            saluddbEntities mctx = new saluddbEntities();
            GrupoBeneficiarioClass x;

            var cur = from g in mctx.grupoes
                      orderby g.nombre
                      select g;

            foreach (var f in cur)
            {
                x = new GrupoBeneficiarioClass();

                x._id_grupo = f.id_grupo;
                x._descripcion = f.descripcion;
                x._nombre = f.nombre;

                x._beneficiarios = BeneficiarioClass.ListarBeneficiariosPorGrupo(f.id_grupo);

                r.Add(x);
            }


            return r;
        }
        /// <summary>
        /// Lista los grupos por criterio
        /// </summary>
        /// <param name="parametro">Parámetro con el que se compara para listar</param>
        /// <param name="criterio">Criterio de búsqueda</param>
        /// <returns>Lista de grupos</returns>
        public static List<GrupoBeneficiarioClass> ListarGruposPorCriterio(string parametro, CriterioBusqueda criterio)
        {
            List<GrupoBeneficiarioClass> r = new List<GrupoBeneficiarioClass>();
            saluddbEntities mctx = new saluddbEntities();
            GrupoBeneficiarioClass x;


            var cur = from g in mctx.grupoes
                      select g;

            foreach (var f in cur)
            {
                bool agregar = false;
                switch (criterio)
                {
                    
                    case CriterioBusqueda.Busqueda_ID:
                        int id = 0;
                        Int32.TryParse(parametro, out id);
                        if (f.id_grupo == id)
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
                    x = new GrupoBeneficiarioClass();

                    x._id_grupo = f.id_grupo;
                    x._descripcion = f.descripcion;
                    x._nombre = f.nombre;

                    x._beneficiarios = BeneficiarioClass.ListarBeneficiariosPorGrupo(f.id_grupo);

                    r.Add(x);
                }

            }

            return r;

        }
     

        /// <summary>
        /// Comprueba que el grupo exista en la base de datos, la comprobacion la hace por el NOMBRE
        /// </summary>
        /// <param name="dni">DNI del beneficiario a comprobar existencia</param>
        /// <returns></returns>
        public static bool existeGrupoBeneficiario(string nombre)
        {
            bool existe = false;

            saluddbEntities ctx = new saluddbEntities();


            var cur = from g in ctx.grupoes
                      where g.nombre == nombre
                      select g;

            if (cur.Count() > 0) //existe
            {

                existe = true;
            }
            return existe;
        }

        #endregion
    }
}
