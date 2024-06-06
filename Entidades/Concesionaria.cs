using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Entidades
{
    [XmlInclude(typeof(Auto))]
    [XmlInclude(typeof(Moto))]
    public class Concesionaria
    {
        private int _capacidad;
        private List<Vehiculo> _vehiculos;


        /// <summary>
        /// Constructor privado de la clase Concesionaria.
        /// </summary>
        private Concesionaria()
        {
            _vehiculos = new List<Vehiculo>();
        }

        /// <summary>
        /// Constructor privado de la clase Concesionaria con capacidad específica.
        /// </summary>
        /// <param name="capacidad">La capacidad máxima de la concesionaria.</param>
        private Concesionaria(int capacidad) : this()
        {
            _capacidad = capacidad;
        }

        /// <summary>
        /// Obtiene o modifica la capacidad máxima de la concesionaria.
        /// </summary>
        public int Capacidad
        {
            get { return _capacidad; }
            set { _capacidad = value; }
        }

        /// <summary>
        /// Obtiene o modifica la lista de vehículos en la concesionaria.
        /// </summary>
        public List<Vehiculo> Vehiculos
        {
            get { return _vehiculos; }
            set { _vehiculos = value; }
        }

        /// <summary>
        /// Obtiene el precio de los autos.
        /// </summary>
        public float PrecioDeAutos
        {
            get { return ObtenerPrecio(EVehiculo.Auto); }
        }

        /// <summary>
        /// Obtiene el precio de las motos.
        /// </summary>
        public float PrecioDeMotos
        {
            get { return ObtenerPrecio(EVehiculo.Moto); }
        }

        /// <summary>
        /// Obtiene el precio total, tanto de autos como motos.
        /// </summary>
        public float PrecioTotal
        {
            get { return ObtenerPrecio(EVehiculo.Ambos); }
        }

        /// <summary>
        /// Obtiene el precio total de los vehículos del tipo especificado en la concesionaria.
        /// </summary>
        /// <param name="tipoVehiculo">El tipo de vehículo para el cual se calculará el precio total.</param>
        /// <returns>El precio total de los vehículos del tipo especificado en la concesionaria.</returns>
        private float ObtenerPrecio(EVehiculo tipoVehiculo)
        {
            float precioTotal = 0;

            foreach (var vehiculo in _vehiculos)
            {
                if (tipoVehiculo == EVehiculo.Ambos ||
                   (tipoVehiculo == EVehiculo.Auto && vehiculo is Auto) ||
                   (tipoVehiculo == EVehiculo.Moto && vehiculo is Moto))
                {
                    precioTotal += vehiculo.Precio;
                }
            }

            return precioTotal;
        }

        /// <summary>
        /// Genera una representación de cadena que contiene información detallada sobre la concesionaria y sus vehículos.
        /// </summary>
        /// <param name="concesionaria">La concesionaria de la cual se mostrará la información.</param>
        /// <returns>Una cadena que representa la información detallada de la concesionaria y sus vehículos.</returns>
        public static string Mostrar(Concesionaria concesionaria)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Capacidad: {concesionaria.Capacidad}");
            sb.AppendLine($"Total por Autos: ${concesionaria.PrecioDeAutos}");
            sb.AppendLine($"Total por Motos: ${concesionaria.PrecioDeMotos}");
            sb.AppendLine($"Total: ${concesionaria.PrecioTotal}\n");
            sb.AppendLine("");
            sb.AppendLine("**********************************************");
            sb.AppendLine("             Listado de vehículos             ");
            sb.AppendLine("**********************************************");

            foreach (var vehiculo in concesionaria.Vehiculos)
            {
                sb.AppendLine(vehiculo.ToString());
            }

            return sb.ToString();
        }

        /// <summary>
        /// Convierte un entero en una instancia de Concesionaria, estableciendo la capacidad de la misma.
        /// </summary>
        /// <param name="capacidad">La capacidad máxima de vehículos que puede contener la concesionaria.</param>
        /// <returns>Una instancia de Concesionaria con la capacidad especificada.</returns>
        public static implicit operator Concesionaria(int capacidad)
        {
            return new Concesionaria(capacidad);
        }

        /// <summary>
        /// Comprueba si un vehículo está contenido en la lista de vehículos de una concesionaria.
        /// </summary>
        /// <param name="concesionaria">La concesionaria en la que se buscará el vehículo.</param>
        /// <param name="vehiculo">El vehículo que se buscará en la concesionaria.</param>
        /// <returns>true si el vehículo está contenido en la concesionaria; de lo contrario, false.</returns>
        public static bool operator ==(Concesionaria concesionaria, Vehiculo vehiculo)
        {
            return concesionaria.Vehiculos.Contains(vehiculo);
        }

        /// <summary>
        /// Comprueba si un vehículo no está contenido en la lista de vehículos de una concesionaria.
        /// </summary>
        /// <param name="concesionaria">La concesionaria en la que se buscará el vehículo.</param>
        /// <param name="vehiculo">El vehículo que se buscará en la concesionaria.</param>
        /// <returns>true si el vehículo no está contenido en la concesionaria; de lo contrario, false.</returns>
        public static bool operator !=(Concesionaria concesionaria, Vehiculo vehiculo)
        {
            return !(concesionaria == vehiculo);
        }

        /// <summary>
        /// Agrega un vehículo a la lista de vehículos de una concesionaria si hay espacio disponible y el vehículo no está ya en la concesionaria.
        /// </summary>
        /// <param name="concesionaria">La concesionaria a la que se agregará el vehículo.</param>
        /// <param name="vehiculo">El vehículo que se agregará a la concesionaria.</param>
        /// <returns>La concesionaria con el vehículo agregado si se puede agregar; de lo contrario, la misma concesionaria.</returns>
        public static Concesionaria operator +(Concesionaria concesionaria, Vehiculo vehiculo)
        {
            if (concesionaria.Vehiculos.Count >= concesionaria.Capacidad)
            {
                Console.WriteLine("¡No hay más lugar en la concesionaria!");
            }
            else if (concesionaria == vehiculo)
            {
                Console.WriteLine("¡El vehículo ya está en la concesionaria!");
            }
            else
            {
                concesionaria.Vehiculos.Add(vehiculo);
            }
            return concesionaria;
        }

        /// <summary>
        /// Elimina un vehículo de la lista de vehículos de una concesionaria si el vehículo está presente en ella.
        /// </summary>
        /// <param name="concesionaria">La concesionaria de la que se eliminará el vehículo.</param>
        /// <param name="vehiculo">El vehículo que se eliminará de la concesionaria.</param>
        /// <returns>La concesionaria con el vehículo eliminado si estaba presente; de lo contrario, la misma concesionaria.</returns>
        public static Concesionaria operator -(Concesionaria concesionaria, Vehiculo vehiculo)
        {
            if (concesionaria == vehiculo)
            {
                concesionaria.Vehiculos.Remove(vehiculo);
            }
            else
            {
                Console.WriteLine("¡El vehículo no está en la concesionaria!");
            }
            return concesionaria;
        }

        /// <summary>
        /// Serializa la concesionaria y guarda la información en un archivo XML en la ruta especificada.
        /// </summary>
        /// <param name="path">La ruta donde se guardará el archivo XML.</param>
        public void SerializarConcesionaria(string path)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Concesionaria));

            using (StreamWriter sw = new StreamWriter(path))
            {
                xmlSerializer.Serialize(sw, this);
            }
        }

        /// <summary>
        /// Guarda toda la información de la concesionaria y sus vehículos en un archivo de texto en la ruta especificada.
        /// </summary>
        /// <param name="rutaArchivo">La ruta donde se guardará el archivo de texto.</param>
        public void GuardarConcesionaria(string rutaArchivo)
        {
            if (!File.Exists(rutaArchivo))
            {
                using (FileStream fileStream = File.Create(rutaArchivo))
                {
                    fileStream.Close();
                }
            }

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Concesionaria));

            using (StreamWriter sw = new StreamWriter(rutaArchivo))
            {
                xmlSerializer.Serialize(sw, this);
            }
        }
        /// <summary>
        /// Deserializa la información de una concesionaria y sus vehículos desde un archivo XML en la ruta especificada.
        /// </summary>
        /// <param name="path">La ruta del archivo XML.</param>
        /// <returns>Una instancia de Concesionaria con la información deserializada.</returns>
        /// <exception cref="FileNotFoundException">Se produce si el archivo especificado no existe.</exception>
        public static Concesionaria DeserializarConcesionaria(string path)
        {
            if (!File.Exists(path))
            {
                throw new FileNotFoundException("El archivo no existe.", path);
            }

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Concesionaria));

            using (StreamReader reader = new StreamReader(path))
            {
                return (Concesionaria)xmlSerializer.Deserialize(reader);
            }
        }
    }
}
