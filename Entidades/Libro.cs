using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Entidades.Documento;

namespace Entidades
{        
    /// <summary>
    /// Clase que representa un libro, derivada de Documento.
    /// </summary>
    public class Libro : Documento
    {
        #region Atributos
        private int numPaginas;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor de la clase Libro.
        /// </summary>
        /// <param name="titulo">Título del libro.</param>
        /// <param name="autor">Autor del libro.</param>
        /// <param name="anio">Año de publicación del libro.</param>
        /// <param name="numNormalizado">Número normalizado del libro (ISBN).</param>
        /// <param name="codebar">Código de barras del libro.</param>
        /// <param name="numPaginas">Número de páginas del libro.</param>
        public Libro(string titulo, string autor, int anio, string numNormalizado,
        string codebar, int numPaginas) :
        base(titulo, autor, anio, numNormalizado, codebar)
        {
            this.numPaginas = numPaginas;
        }
        #endregion

        #region Propiedades
        public string ISBN { get => this.NumNormalizado; }
        public int NumPaginas { get => this.numPaginas; }
        #endregion

        #region Metodos
        public static bool operator !=(Libro l1, Libro l2)
        {
            return !(l1 == l2);
        }
        public static bool operator ==(Libro l1, Libro l2)
        {
            return l1.Barcode == l2.Barcode || l1.ISBN == l2.ISBN 
            || (l1.Titulo == l2.Titulo && l1.Autor == l2.Autor);
        }

        public  override string ToString()
        {
            StringBuilder datos = new StringBuilder(base.ToString());
            int index = datos.ToString().IndexOf($" Cód. de barras: {Barcode}");
            datos.Insert(index, $" ISBN: {ISBN}\n"); // Agregar un espacio antes de "ISBN"
            datos.AppendLine($" Número de páginas: {NumPaginas}.");
            return datos.ToString();
        }
        #endregion
    }
}
