using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Processar.ProyectoAyudar.DatosLibrary;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace Processar.ProyectoAyudar.ClasesLibrary
{
    public class UsuarioClass
    {
        #region Propiedades
        private saluddbEntities ctx;
        private int _id_usuario;
        private String _nombre_usuario;
        private String _constrasenia;
        private String _nombre_completo;
        private List<PermisoClass> _permisos;
       
        /// <summary>
        /// Obtiene el id de usuario
        /// </summary>
        public int Id_usuario
        {
            get { return _id_usuario; }
        }

        /// <summary>
        /// Obtiene y establece el nombre de usuario
        /// </summary>
        public String Nombre_usuario
        {
            get { return _nombre_usuario; }
            set { _nombre_usuario = value; }
        }

        /// <summary>
        /// Obtiene y establece la contraseña
        /// </summary>
        public String Contrasenia
        {
            set
            {
                _constrasenia = CodificarPassword(value);
            }

            get
            {
                return _constrasenia;
            }
        }

        /// <summary>
        /// Obtiene y establece el nombre completo del usuario
        /// </summary>
        public String Nombre_completo
        {
            get { return _nombre_completo; }
            set { _nombre_completo = value; }
        }

        public List<PermisoClass> Permisos
        {
            get { return _permisos; }
            set { _permisos = value; }
        }
        #endregion

        #region Constructores

        /// <summary>
        /// Constructor por defecto de la clase UsuarioClass
        /// Crea un objeto Usuario pero con las propiedades vacias
        /// </summary>
        public UsuarioClass()
        {
            ctx = new saluddbEntities();
            _nombre_completo = "";
            _nombre_usuario = "";
            _constrasenia = "";
            _id_usuario = 0;
            _permisos = new List<PermisoClass>();
        }

        /// <summary>
        /// Constructor de la clase UsuarioClass
        /// Crea una instancia de la clase UsuarioClass con los parámetros pasados 
        /// </summary>
        /// <param name="id_usuario">Id del usuario</param>
        /// <param name="nombre_usuario">Nombre de usuario</param>
        /// <param name="contrasenia">Contraseña del usuario</param>
        /// <param name="nombre_completo">Nombre completo del usuario</param>
        public UsuarioClass(int id_usuario, String nombre_usuario, String contrasenia, String nombre_completo, List<PermisoClass> permisos)
        {
            ctx = new saluddbEntities();
            _id_usuario = id_usuario;
            _nombre_usuario = nombre_usuario;
            _nombre_completo = nombre_completo;
            _constrasenia = contrasenia;
            _permisos = permisos;

        }
        #endregion

        #region Metodos


        public bool NuevoUsuario()
        {
            bool r = false;

            using (System.Transactions.TransactionScope tr = new System.Transactions.TransactionScope())
            {
                try
                {

                if(!existeUsuario(this.Nombre_usuario))
                {
                        usuario f = new usuario();


                        f.contrasenia = this._constrasenia;
                        f.nombre_completo = this._nombre_completo;
                        f.nombre_usuario = this._nombre_usuario;



                        ctx.usuarios.Add(f);
                        ctx.SaveChanges();
                        _id_usuario = f.id_usuario;

                        r = true;
                }
                else
                    {
                        MessageBox.Show("Ya existe ese nombre de usuario!");
                        r = false;
                    }


                
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message, "Error de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    r = false;

                }

                if(r)
                {
                    /*Crea los permisos en la base de datos*/

                    permiso p = new permiso();

                    foreach(PermisoClass permiso in _permisos)
                    {
                        if(!permiso.NuevoPermiso(_id_usuario))
                        {
                            r = false;
                        }
                        
                        
                    }

                }

                if(r)
                {
                    tr.Complete();
                }
            }




             

            return r;
        }

        public bool ModificarUsuario()
        {
            bool r = true;

            using (System.Transactions.TransactionScope tr = new System.Transactions.TransactionScope())
            {

                foreach(PermisoClass p in _permisos)
                {
                    if(!p.Modificar())
                    {
                        r = false;
                        break;
                    }
                }

                if(r)
                {
                    //Modifico el usuario
                    var cur = from u in ctx.usuarios
                              where u.id_usuario == _id_usuario
                              select u;

                    var f = cur.First();
                    f.contrasenia = this._constrasenia;
                    f.nombre_completo = this._nombre_completo;

                    //f.nombre_usuario = this._nombre_usuario;

                    try
                    {
                        ctx.SaveChanges();
                        r = true;
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message, "Error al modificar el usuario", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        r = false;
                    }
                }
                

                if (r)
                {
                    tr.Complete();
                }
            }

                

            return r;
        }

        /// <summary>
        /// Comprueba si se puede borrar el usuario
        /// </summary>
        /// <returns>Retorna True se si puede borrar; False en otro caso</returns>
        private bool Borrar_OK()
        {
            
            //Busca en la base de datos si hay ordenes entregas para este usuario
            var cur = from oE in ctx.ordenentregas
                      where oE.id_usuario == _id_usuario
                      select oE;

            if (cur.Count() == 0)
            {
                //Busca en la base de datos si hay permisos relacionados con el usuario
               /* var cur2 = from p in ctx.permisoes
                           where p.id_usuario == _id_usuario
                           select p;
                if (cur2.Count() == 0)
                {
                    //Busca en la base de datos si hay ordenes relacionadas con el usuario
                    var cur3 = from o in ctx.ordenestadoes
                               where o.id_usuario == _id_usuario
                               select o;
                    if (cur3.Count() == 0)
                    {
                        return true; //Se puede borrar si no hay permisos, ordenes de Entrega ni ordenes de estado relacionadas con el usuario.
                    }
                    else
                    {
                        return false;
                    }
                }*/
                if(cur.Count() == 0)
                {
                    //Busca en la base de datos si hay ordenes relacionadas con el usuario
                    var cur3 = from o in ctx.ordenestadoes
                               where o.id_usuario == _id_usuario
                               select o;
                    if (cur3.Count() == 0)
                    {
                        return true; //Se puede borrar si no ordenes de Entrega ni ordenes de estado relacionadas con el usuario.
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                   
                    return false;
                }
            }
            else
            {

                    return false;
                
            }
         
        }


        public bool Eliminar()
        {
            bool r = true;

            if (Borrar_OK())
            {
                using (System.Transactions.TransactionScope tr = new System.Transactions.TransactionScope())
                {
                    //Elimino los permisos

                    foreach(PermisoClass p in _permisos)
                    {

                        if(!p.Eliminar())
                        {
                            r = false;
                            break;
                        }
                        

                    }


                    if(r)
                    {
                        //Elimino el usuario
                        var cur = from u in ctx.usuarios
                                  where u.id_usuario == _id_usuario
                                  select u;

                        if (cur.Count() > 0)
                        {
                            var f = cur.First();

                            ctx.usuarios.Remove(f);
                            try
                            {
                                ctx.SaveChanges();
                                r = true;
                            }
                            catch (Exception e)
                            {
                                MessageBox.Show(e.Message, "Error al eliminar el usuario", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                r = false;
                            }
                        }
                    }
                    

                    if (r)
                    {
                        tr.Complete();
                    }
                }
                 
            }
            else
            {

                r = false;
                MessageBox.Show("No se puede eliminar. Existen ordenes de entregas asociadas a este usuario!", "Imposible Eliminar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
            return r;
        }

        /// <summary>
        /// Busca un usuario en la base de datos por su Id
        /// </summary>
        /// <param name="id_usuario">Id del usuario a buscar</param>
        /// <param name="completo">Indica si se quiere obtener el usuario completo, con la lista de permisos o no</param>
        /// <returns>Retorna el usuario buscado o Null si no lo encuentra</returns>
        public static UsuarioClass BuscarUsuarioPorId(int id_usuario, bool completo = false)
        {
            UsuarioClass r = new UsuarioClass();

            saluddbEntities ctx = new saluddbEntities();

            var cur = from u in ctx.usuarios
                      where u.id_usuario == id_usuario
                      select u;

            if (cur.Count() > 0)
            {
                var f = cur.First();

                r._id_usuario = f.id_usuario;
                r._constrasenia = f.contrasenia;
                r._nombre_completo = f.nombre_completo;
                r._nombre_usuario = f.nombre_usuario;
                
                
                if(completo)
                {
                    r._permisos = PermisoClass.ListarPermisosPorUsuario(id_usuario);
                }
            }
            else
            {
                r = null;

            }

            return r;

        }

        /// <summary>
        /// Busca un usuario por permiso
        /// </summary>
        /// <param name="id_permiso">Id del permiso</param>
        /// <param name="completo">Parametro que indica si se va a obtener el usuario en forma completa, cargando sus permisos o no</param>
        /// <returns>Retorna el usuario</returns>
        public static UsuarioClass BuscarUsuarioPorPermiso(int id_permiso, bool completo = false)
        {
            UsuarioClass r = new UsuarioClass();

            saluddbEntities ctx = new saluddbEntities();

            var cur = from u in ctx.usuarios
                      join p in ctx.permisoes
                      on u.id_usuario equals p.id_usuario
                      where p.id_permiso == id_permiso
                      select u;

            if (cur.Count() > 0)
            {
                var f = cur.First();

                r._id_usuario = f.id_usuario;
                r._constrasenia = f.contrasenia;
                r._nombre_completo = f.nombre_completo;
                r._nombre_usuario = f.nombre_usuario;


                if (completo)
                {
                    r._permisos = PermisoClass.ListarPermisosPorUsuario(r.Id_usuario);
                }
            }
            else
            {
                r = null;

            }

            return r;

        }

        /// <summary>
        /// Busca un usuario por nombre de usuario
        /// </summary>
        /// <param name="nombre_usuario">Nombre de usuario del usuario buscado</param>
        /// <param name="completo">Carga el usuario completo</param>
        /// <returns></returns>
        public static UsuarioClass BuscarUsuarioPorNombre(string nombre_usuario, bool completo = false)
        {
            UsuarioClass r = new UsuarioClass();

            saluddbEntities ctx = new saluddbEntities();

            var cur = from u in ctx.usuarios
                      where u.nombre_usuario == nombre_usuario
                      select u;

            if (cur.Count() > 0)
            {
                var f = cur.First();

                r._id_usuario = f.id_usuario;
                r._constrasenia = f.contrasenia;
                r._nombre_completo = f.nombre_completo;
                r._nombre_usuario = f.nombre_usuario;


                if (completo)
                {
                    r._permisos = PermisoClass.ListarPermisosPorNombreUsuario(nombre_usuario);
                }
            }
            else
            {
                r = null;

            }

            return r;

        }

        /// <summary>
        /// Lista todos los usuarios de la base de datos
        /// </summary>
        /// <param name="completo">Indica si se va a cargar el usuario completo, implica cargar todos los permisos</param>
        /// <returns>Retorna una lista de usuarios</returns>
        public static List<UsuarioClass> ListarUsuarios(bool completo = false)
        {
            List<UsuarioClass> r = new List<UsuarioClass>();
            saluddbEntities mctx = new saluddbEntities();
            UsuarioClass x;


            var cur = from usu in mctx.usuarios
                      orderby usu.nombre_usuario
                      select usu;
            
            foreach (var f in cur)
            {
                x = new UsuarioClass();

                x._id_usuario = f.id_usuario;
                x._nombre_completo = f.nombre_completo;
                x._nombre_usuario = f.nombre_usuario;
                x._constrasenia = f.contrasenia;

                if(completo)
                {
                    x._permisos = PermisoClass.ListarPermisosPorUsuario(f.id_usuario);
                }

                r.Add(x);
            }

            
            return r;
        }

        /// <summary>
        /// Lista los usuarios por nombre de usuario
        /// </summary>
        /// <param name="nombre">nombre de usuario</param>
        /// <param name="completo">indica si se va a cargar el usuario completo, implica cargar los permisos</param>
        /// <returns>Retorna una lista de usuarios</returns>
        public static List<UsuarioClass> ListarUsuariosPorNombre(string nombre, bool completo = false)
        {
            List<UsuarioClass> r = new List<UsuarioClass>();
            saluddbEntities mctx = new saluddbEntities();
            UsuarioClass x;


            var cur = from usu in mctx.usuarios
                      where usu.nombre_usuario.Contains(nombre)
                      select usu;


            foreach (var f in cur)
            {
                x = new UsuarioClass();

                x._id_usuario = f.id_usuario;
                x._nombre_completo = f.nombre_completo;
                x._nombre_usuario = f.nombre_usuario;
                x._constrasenia = f.contrasenia;

                if (completo)
                {
                    x._permisos = PermisoClass.ListarPermisosPorUsuario(f.id_usuario);
                }

                r.Add(x);
            }
            return r;
        }


        /// <summary>
        ///Codifica el password ingresado
        /// </summary>
        /// <param name="clave">Clave Password.</param>
        /// <returns></returns>
        private string CodificarPassword(string clave)
        {
            string r = "";
            // Create a new instance of the MD5 object.


            MD5 md5Hasher = MD5.Create();

            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(clave));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            int i = 0;
            for (i = 0; i <= data.Length - 1; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.

            r = sBuilder.ToString();

            //if (sBuilder.ToString == _password)
            //{
            //    return true;
            //}
            //else
            //{
            //    return false;
            //}





            return r;
        }

        public bool ValidarPassword(string passwd)
        {
            MD5 md5Hasher = MD5.Create();

            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(passwd));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            int i = 0;
            for (i = 0; i <= data.Length - 1; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.

            string contra = sBuilder.ToString();

            if (sBuilder.ToString() == _constrasenia)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        /// <summary>
        /// Comprueba que el usuario no exista en la base de datos, la comprobacion la hace por el nombre de usuario
        /// </summary>
        /// <param name="nombre">Nombre de usuario a comprobar existencia</param>
        /// <returns></returns>
        public static bool existeUsuario(string nombre)
        {
            bool existe = false;

            saluddbEntities ctx = new saluddbEntities();


            var cur = from b in ctx.usuarios
                      where b.nombre_usuario == nombre
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
