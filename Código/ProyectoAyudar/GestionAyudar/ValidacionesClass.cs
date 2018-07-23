using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Processar.ProyectoAyudar.DatosLibrary;

namespace Processar.ProyectoAyudar.GestionAyudar
{
    class ValidacionesClass
    {
        public static bool ValidarApellidoNombreTextBox(System.Windows.Controls.TextBox mitextbox)
        {
            String texto = mitextbox.Text.ToString();
            bool valido = false;



            foreach (char c in texto)
            {

                if ((c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z') || c == '\'' || (c >= 'á' && c <= 'Ñ') || c == 'ü' || c == 'Ü' || c == ' ' || c == 'é' || c == 'Á' || c == 'É' || c == 'Í' || c == 'Ó' || c == 'Ú' || c == 'ç' || c == 'Ç')
                {
                    valido = true;
                }
                else
                {
                    valido = false;
                }

                if (!valido)
                    return false;
            }

            return valido;


        }

        public static bool ValidarNumericoTextBox(System.Windows.Controls.TextBox mitextbox)
        {
            double numero;
            return double.TryParse(mitextbox.Text, out numero);

        }

        
    }
}
