using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Fabricante
    {
        private string _marca;
        private EPais _pais;

        /// <summary>
        /// Constructor vacío de la clase Fabricante.
        /// </summary>
        public Fabricante()
        {
        }

        /// <summary>
        /// Constructor de la clase Fabricante que inicializa la marca y el país.
        /// </summary>
        /// <param name="marca">La marca del fabricante.</param>
        /// <param name="pais">El país del fabricante.</param>
        public Fabricante(string marca, EPais pais)
        {
            _marca = marca;
            _pais = pais;
        }


        /// <summary>
        /// Obtiene o modifica la marca del fabricante.
        /// </summary>
        public string Marca
        {
            get { return _marca; }
            set { _marca = value; }
        }

        /// <summary>
        /// Obtiene o modifica el país del fabricante.
        /// </summary>
        public EPais Pais
        {
            get { return _pais; }
            set { _pais = value; }
        }

        /// <summary>
        /// Compara dos fabricantes para determinar si son iguales.
        /// </summary>
        /// <param name="fabricante1">El primer fabricante a comparar.</param>
        /// <param name="fabricante2">El segundo fabricante a comparar.</param>
        /// <returns>True si los fabricantes son iguales, False en caso contrario.</returns>
        public static bool operator ==(Fabricante fabricante1, Fabricante fabricante2)
        {
            return fabricante1.Marca == fabricante2.Marca && fabricante1.Pais == fabricante2.Pais;
        }

        /// <summary>
        /// Compara dos fabricantes para determinar si son diferentes.
        /// </summary>
        /// <param name="fabricante1">El primer fabricante a comparar.</param>
        /// <param name="fabricante2">El segundo fabricante a comparar.</param>
        /// <returns>True si los fabricantes son diferentes, False en caso contrario.</returns>
        public static bool operator !=(Fabricante fabricante1, Fabricante fabricante2)
        {
            return !(fabricante1 == fabricante2);
        }

        /// <summary>
        /// Devuelve una representación en formato de cadena del objeto Fabricante.
        /// </summary>
        /// <returns>Una cadena que representa al fabricante en formato "Marca, País".</returns>
        public override string ToString()
        {
            return $"{_marca}, {_pais}";
        }
    }
}
