using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public abstract class Vehiculo
    {
        protected Fabricante _fabricante;
        protected string _modelo;
        protected float _precio;
        protected static Random _generadorDeVelocidades = new Random();
        protected int _velocidadMaxima;

        /// <summary>
        /// Constructor vacío de la clase Vehiculo.
        /// </summary>
        protected Vehiculo()
        {
        }

        /// <summary>
        /// Constructor estático de la clase Vehiculo.
        /// Inicializa el generador de velocidades aleatorias.
        /// </summary>
        static Vehiculo()
        {
            _generadorDeVelocidades = new Random();
        }

        /// <summary>
        /// Constructor de la clase Vehiculo que inicializa los atributos básicos del vehículo.
        /// </summary>
        /// <param name="marca">La marca.</param>
        /// <param name="pais">El país del fabricante.</param>
        /// <param name="modelo">El modelo.</param>
        /// <param name="precio">El precio.</param>
        protected Vehiculo(string marca, EPais pais, string modelo, float precio)
        {
            _fabricante = new Fabricante(marca, pais);
            _modelo = modelo;
            _precio = precio;
        }

        /// <summary>
        /// Constructor de la clase Vehiculo que inicializa los atributos básicos del vehículo.
        /// </summary>
        /// <param name="modelo">El modelo.</param>
        /// <param name="precio">El precio.</param>
        /// <param name="fabricante">El fabricante.</param>
        protected Vehiculo(string modelo, float precio, Fabricante fabricante)
        {
            _fabricante = fabricante;
            _modelo = modelo;
            _precio = precio;
        }

        /// <summary>
        /// Obtiene o modifica el fabricante del vehículo.
        /// </summary>
        public Fabricante Fabricante
        {
            get { return _fabricante; }
            set { _fabricante = value; }
        }

        /// <summary>
        /// Obtiene o modifica el modelo del vehículo.
        /// </summary>
        public string Modelo
        {
            get { return _modelo; }
            set { _modelo = value; }
        }

        /// <summary>
        /// Obtiene o modifica el precio del vehículo.
        /// </summary>
        public float Precio
        {
            get { return _precio; }
            set { _precio = value; }
        }

        /// <summary>
        /// Obtiene o establece la velocidad máxima del vehículo.
        /// </summary>
        public int VelocidadMaxima
        {
            get
            {
                if (_velocidadMaxima == 0)
                {
                    _velocidadMaxima = _generadorDeVelocidades.Next(100, 281);
                }
                return _velocidadMaxima;
            }
            set { _velocidadMaxima = value; }
        }

        /// <summary>
        /// Devuelve una cadena que representa la información del vehículo, incluyendo su fabricante, modelo, velocidad máxima y precio.
        /// </summary>
        /// <returns>Una cadena que representa la información del vehículo.</returns>
        private string Mostrar()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine($"Fabricante: {_fabricante}");
            stringBuilder.AppendLine($"Modelo: {_modelo}");
            stringBuilder.AppendLine($"Velocidad Máxima: {VelocidadMaxima}");
            stringBuilder.Append($"Precio: ${_precio}");

            return stringBuilder.ToString();
        }

        /// <summary>
        /// Compara dos vehículos para determinar si son iguales. Dos vehículos son iguales si tienen el mismo modelo y el mismo fabricante.
        /// </summary>
        /// <param name="vehiculo1">Primer vehículo a comparar.</param>
        /// <param name="vehiculo2">Segundo vehículo a comparar.</param>
        /// <returns>True si los vehículos son iguales, False en caso contrario.</returns>
        public static bool operator ==(Vehiculo vehiculo1, Vehiculo vehiculo2)
        {
            return vehiculo1._modelo == vehiculo2._modelo && vehiculo1._fabricante == vehiculo2._fabricante;
        }

        /// <summary>
        /// Compara dos vehículos para determinar si son diferentes. Dos vehículos son diferentes si no tienen el mismo modelo o no tienen el mismo fabricante.
        /// </summary>
        /// <param name="vehiculo1">Primer vehículo a comparar.</param>
        /// <param name="vehiculo2">Segundo vehículo a comparar.</param>
        /// <returns>True si los vehículos son diferentes, False en caso contrario.</returns>
        public static bool operator !=(Vehiculo vehiculo1, Vehiculo vehiculo2)
        {
            return !(vehiculo1 == vehiculo2);
        }

        /// <summary>
        /// Convierte un objeto de tipo Vehiculo en una representación de cadena de caracteres, mostrando información detallada sobre el vehículo.
        /// </summary>
        /// <param name="vehiculo">Vehículo a convertir en cadena de caracteres.</param>
        /// <returns>Una cadena que representa la información detallada del vehículo.</returns>
        public static explicit operator string(Vehiculo vehiculo)
        {
            return vehiculo.Mostrar();
        }
    }
}
