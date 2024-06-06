using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Moto : Vehiculo
    {
        private ECilindrada _cilindrada;

        /// <summary>
        /// Constructor vacío de la clase Auto.
        /// </summary>
        public Moto()
        {
        }

        /// <summary>
        /// Constructor de la clase Moto que inicializa una instancia con la marca, país, modelo, precio y cilindrada especificados.
        /// </summary>
        /// <param name="marca">La marca.</param>
        /// <param name="pais">El país.</param>
        /// <param name="modelo">El modelo.</param>
        /// <param name="precio">El precio.</param>
        /// <param name="cilindrada">La cilindrada.</param>
        public Moto(string marca, EPais pais, string modelo, float precio, ECilindrada cilindrada)
            : base(marca, pais, modelo, precio)
        {
            _cilindrada = cilindrada;
        }

        /// <summary>
        /// Propiedad que obtiene o establece la cilindrada de la moto.
        /// </summary>
        public ECilindrada Cilindrada
        {
            get { return _cilindrada; }
            set { _cilindrada = value; }
        }

        /// <summary>
        /// Sobrecarga del operador de igualdad para comparar dos instancias de la clase Moto.
        /// Compara si dos motos son iguales en base a su vehículo base y su cilindrada.
        /// </summary>
        /// <param name="moto1">La primera moto a comparar.</param>
        /// <param name="moto2">La segunda moto a comparar.</param>
        /// <returns>True si las motos son iguales, False en caso contrario.</returns>
        public static bool operator ==(Moto moto1, Moto moto2)
        {
            return (Vehiculo)moto1 == (Vehiculo)moto2 && moto1._cilindrada == moto2._cilindrada;
        }

        /// <summary>
        /// Sobrecarga del operador de desigualdad para comparar dos instancias de la clase Moto.
        /// Compara si dos motos son diferentes en base a su vehículo base o su cilindrada.
        /// </summary>
        /// <param name="moto1">La primera moto a comparar.</param>
        /// <param name="moto2">La segunda moto a comparar.</param>
        /// <returns>True si las motos son diferentes, False en caso contrario.</returns>
        public static bool operator !=(Moto moto1, Moto moto2)
        {
            return !(moto1 == moto2);
        }

        /// <summary>
        /// Conversión implícita a float para obtener el precio de una moto.
        /// </summary>
        /// <param name="moto">La moto de la que se obtendrá el precio.</param>
        /// <returns>El precio de la moto en formato float.</returns>
        public static implicit operator float(Moto moto)
        {
            return moto.Precio;
        }

        /// <summary>
        /// Determina si el objeto actual es igual a otro objeto en función de si son instancias de Moto y tienen las mismas propiedades.
        /// </summary>
        /// <param name="obj">El objeto con el que se comparará.</param>
        /// <returns>True si son iguales, False en caso contrario.</returns>
        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Moto))
                return false;

            Moto other = (Moto)obj;
            return this == other;
        }

        /// <summary>
        /// Devuelve un código hash calculado en base al hash del objeto base y el hash de la cilindrada.
        /// </summary>
        /// <returns>El código hash resultante.</returns>
        public override int GetHashCode()
        {
            return base.GetHashCode() ^ _cilindrada.GetHashCode();
        }

        /// <summary>
        /// Devuelve una cadena que representa la moto, incluyendo su información básica y la cilindrada.
        /// </summary>
        /// <returns>Una cadena que representa la moto.</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine((string)(Vehiculo)this);
            sb.AppendLine($"Cilindrada: {_cilindrada}");

            return sb.ToString();
        }
    }
}
