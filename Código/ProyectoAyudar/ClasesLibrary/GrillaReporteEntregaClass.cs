using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Processar.ProyectoAyudar.ClasesLibrary
{
    public class GrillaReporteEntregaClass
    {
        private long _id_grillaReporte;
        private int _id_articulo;
        private string _cantidad_articulo;
        private string _nombre_articulo;
        private string _descripcion_articulo;
        private string _tipo_articulo;

        private long _id_orden_entrega;
        private string _fechaEntrega_orden_entrega;
        private string _horaEntrega_orden_entrega;
        private string _entregado_por;
        private string _autorizado_por;

        public long Id_grillaReporte
        {
            get { return _id_grillaReporte; }
        }
        public int Id_articulo
        {
            get { return _id_articulo; }
            set { _id_articulo = value; }
        }

        public string Cantidad_articulo
        {
            get { return _cantidad_articulo; }
            set { _cantidad_articulo = value; }
        }

        public string Nombre_articulo
        {
            get { return _nombre_articulo; }
            set { _nombre_articulo = value; }
        }

        public string Descripcion_articulo
        {
            get { return _descripcion_articulo; }
            set { _descripcion_articulo = value; }

        }

        public string Tipo_articulo
        {
            get { return _tipo_articulo; }
            set { _tipo_articulo = value; }
        }

        public long Id_orden_entrega
        {
            get { return _id_orden_entrega; }
            set { _id_orden_entrega = value; }
        }

        public string FechaEntrega_orden_entrega
        {
            get { return _fechaEntrega_orden_entrega; }
            set { _fechaEntrega_orden_entrega = value; }
        }

        public string HoraEntrega_orden_entrega
        {
            get { return _horaEntrega_orden_entrega; }
            set { _horaEntrega_orden_entrega = value; }
        }

        public string Entregado_por
        {
            get { return _entregado_por;}
            set { _entregado_por = value; }
        }

        public string Autorizado_por
        {
            get { return _autorizado_por; }
            set { _autorizado_por = value; }
        }
    }

}
