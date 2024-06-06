using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Auto : Vehiculo
    {
        private ETipo _tipo;

        /// <summary>
        /// Constructor vacío de la clase Auto.
        /// </summary>
        public Auto() : base()
        {
        }

        /// <summary>
        /// Constructor de la clase Auto que inicializa el modelo, precio, fabricante y tipo.
        /// </summary>
        /// <param name="modelo">El modelo.</param>
        /// <param name="precio">El precio.</param>
        /// <param name="fabricante">El fabricante.</param>
        /// <param name="tipo">El tipo.</param>
        public Auto(string modelo, float precio, Fabricante fabricante, ETipo tipo)
            : base(modelo, precio, fabricante)
        {
            _tipo = tipo;
        }

        /// <summary>
        /// Propiedad para acceder y modificar el tipo de auto.
        /// </summary>
        public ETipo Tipo
        {
            get { return _tipo; }
            set { _tipo = value; }
        }

        /// <summary>
        /// Comprueba si dos objetos de tipo Auto son iguales. Dos autos son iguales si tienen el mismo modelo, fabricante y tipo.
        /// </summary>
        /// <param name="auto1">Primer auto a comparar.</param>
        /// <param name="auto2">Segundo auto a comparar.</param>
        /// <returns>True si los autos son iguales, False en caso contrario.</returns>
        public static bool operator ==(Auto auto1, Auto auto2)
        {
            return (Vehiculo)auto1 == (Vehiculo)auto2 && auto1._tipo == auto2._tipo;
        }

        /// <summary>
        /// Comprueba si dos objetos de tipo Auto son diferentes. Dos autos son diferentes si tienen distintos modelos, fabricantes o tipos.
        /// </summary>
        /// <param name="auto1">Primer auto a comparar.</param>
        /// <param name="auto2">Segundo auto a comparar.</param>
        /// <returns>True si los autos son diferentes, False en caso contrario.</returns>
        public static bool operator !=(Auto auto1, Auto auto2)
        {
            return !(auto1 == auto2);
        }

        /// <summary>
        /// Realiza una conversión explícita de un objeto de tipo Auto a un valor de tipo float, devolviendo el precio del auto.
        /// </summary>
        /// <param name="auto">El objeto Auto a convertir.</param>
        /// <returns>El precio del auto en formato float.</returns>
        public static explicit operator float(Auto auto)
        {
            return auto.Precio;
        }

        /// <summary>
        /// Determina si el objeto actual es igual a otro objeto, comparando si son del mismo tipo y tienen los mismos atributos.
        /// </summary>
        /// <param name="obj">El objeto a comparar con el objeto actual.</param>
        /// <returns>True si los objetos son iguales, False en caso contrario.</returns>
        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Auto))
                return false;

            Auto auto2 = (Auto)obj;
            return this == auto2;
        }

        /// <summary>
        /// Devuelve una representación de cadena que describe el objeto actual, incluyendo el modelo, fabricante, precio y tipo del auto.
        /// </summary>
        /// <returns>Una cadena que representa el objeto actual.</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine((string)(Vehiculo)this);
            sb.AppendLine($"Tipo: {_tipo}");

            return sb.ToString();
        }
    }
}
