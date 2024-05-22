using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Entidades
{
    /// <summary>
    /// Clase que representa un mapa, derivada de Documento.
    /// </summary>
    public class Mapa : Documento
    {   
        #region Atributos
        private int alto;
        private int ancho;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor de la clase Mapa.
        /// </summary>
        /// <param name="titulo">Título del mapa.</param>
        /// <param name="autor">Autor del mapa.</param>
        /// <param name="anio">Año de publicación del mapa.</param>
        /// <param name="numNormalizado">Número normalizado del mapa (no aplicable, se pasa una cadena vacía o un valor por defecto).</param>
        /// <param name="codebar">Código de barras del mapa.</param>
        /// <param name="ancho">Ancho del mapa en cm.</param>
        /// <param name="alto">Alto del mapa en cm.</param>
        public Mapa(string titulo, string autor, int anio, string numNormalizado,
        string codebar,int ancho,int alto) : base(titulo, autor, anio, numNormalizado, codebar)
        { 
            this.alto = alto;
            this.ancho = ancho;
        }
        #endregion

        #region Propiedades
        public int Ancho { get => this.ancho; }

        public int Alto { get => this.alto; }
        /// <summary>
        /// Obtiene la superficie del mapa (alto * ancho).
        /// </summary>
        public int Superficie { get => Alto * Ancho;}
        #endregion

        #region Metodos
        public static bool operator !=(Mapa m1, Mapa m2)
        {
            return !(m1 == m2);
        }
        public static bool operator ==(Mapa m1, Mapa m2)
        {
            return m1.Barcode == m2.Barcode || 
                  (m1.Titulo == m2.Titulo && m1.Autor == m2.Autor && 
                   m1.Anio == m2.Anio && m1.Superficie == m2.Superficie);
        }

        public override string ToString()
        {
            StringBuilder datos = new StringBuilder(base.ToString());
            datos.AppendLine($" Superficie: {Ancho} * {Alto} = {Superficie} cm2.");
            return datos.ToString();
        }
        #endregion
    }
}
