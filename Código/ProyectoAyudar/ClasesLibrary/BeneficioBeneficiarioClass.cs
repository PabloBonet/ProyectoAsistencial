using Processar.ProyectoAyudar.DatosLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Processar.ProyectoAyudar.ClasesLibrary
{
    public class BeneficioBeneficiarioClass
    {
        #region Propiedades 
        private int _id_beneficio_beneficiario;
        private int _id_beneficio;
        private string _nombre_beneficio;
        private string _descripcion_beneficio;
        private DateTime _fechaAsiganacion;
        private int _id_beneficiario;

        public int Id_beneficio_beneficiario
        {
            get { return _id_beneficio_beneficiario; }
        }

        public int Id_beneficio
        {
            get { return _id_beneficio; }
            set { _id_beneficio = value; }
        }
        public int Id_beneficiario
        {
            get { return _id_beneficiario; }
            set { _id_beneficiario = value; }
        }

        public string Nombre_beneficio
        {
            get { return _nombre_beneficio; }
            set { _nombre_beneficio = value; }
        }


        public string Descripcion_beneficio
        {
            get { return _descripcion_beneficio; }
            set { _descripcion_beneficio = value; }
        }

        public DateTime Fecha_asignacion
        {
            get { return _fechaAsiganacion; }
            set { _fechaAsiganacion = value; }
        }

        public static List<BeneficioBeneficiarioClass> ListarBeneficioPorBeneficiario(int id_beneficiario)
        {
            List<BeneficioBeneficiarioClass> r = new List<BeneficioBeneficiarioClass>();


            saluddbEntities mctx = new saluddbEntities();
            BeneficioBeneficiarioClass x;


            var cur = from bb in mctx.beneficiario_beneficio

                      join b in mctx.beneficios
                      on bb.id_beneficio equals b.id_beneficio

                      where bb.id_beneficiario == id_beneficiario
                      select new
                      {
                          id_beneficio_beneficiario = bb.id_benef_beneficio,
                          id_beneficiario = bb.id_beneficiario,
                          id_beneficio = bb.id_beneficio,
                          fechadesde = bb.fechadesde,
                          nombre_beneficio = b.nombre,
                          descripcion_beneficio = b.descripcion

                      };


            foreach (var f in cur)
            {
                x = new BeneficioBeneficiarioClass();

                x._id_beneficio_beneficiario = f.id_beneficio_beneficiario;
                x.Id_beneficiario = f.id_beneficiario;
                x.Id_beneficio = f.id_beneficio;
                x.Fecha_asignacion = f.fechadesde;
                x.Nombre_beneficio = f.nombre_beneficio;
                x.Descripcion_beneficio = f.descripcion_beneficio;

                r.Add(x);
            }
            return r;
        }


        public static BeneficioBeneficiarioClass BuscarBeneficioBeneficiarioPorID(int id_benef_beneficiario)
        {
            BeneficioBeneficiarioClass r = new BeneficioBeneficiarioClass();
            saluddbEntities mctx = new saluddbEntities();
            BeneficioBeneficiarioClass x;


            var cur = from bb in mctx.beneficiario_beneficio

                      join b in mctx.beneficios
                      on bb.id_beneficio equals b.id_beneficio

                      where bb.id_benef_beneficio == id_benef_beneficiario
                      select new
                      {
                          id_beneficiario = bb.id_beneficiario,
                          id_beneficio = bb.id_beneficio,
                          fechadesde = bb.fechadesde,
                          nombre_beneficio = b.nombre,
                          descripcion_beneficio = b.descripcion

                      };

            if (cur.Count() > 0)
            {
                var f = cur.First();

                r.Id_beneficiario = f.id_beneficiario;
                r.Id_beneficio = f.id_beneficio;
                r.Fecha_asignacion = f.fechadesde;
                r.Nombre_beneficio = f.nombre_beneficio;
                r.Descripcion_beneficio = f.descripcion_beneficio;

            }
           
            return r;
        }
        #endregion
    }
}
