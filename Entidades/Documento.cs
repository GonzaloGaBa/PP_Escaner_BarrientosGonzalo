using System.Drawing;
using System.Text;

namespace Entidades
{
    public abstract class Documento
    {
        #region Atributos 
        private int anio;
        private string autor;
        private string barcode;
        private Paso estado;
        private string numNormalizado;
        private string titulo;
        #endregion

        #region Enumerados
        /// <summary>
        /// Enumerado que define los posibles estados de un documento.
        /// </summary>
        public enum Paso { Inicio, Distribuido, EnEscaner, EnRevision, Terminado }
        #endregion

        #region Constructor
        public Documento(string titulo, string autor, int anio, string numNormalizado,
        string barcode)
        {
            this.titulo = titulo;
            this.autor = autor;
            this.anio = anio;
            this.numNormalizado = numNormalizado;
            this.barcode = barcode;
            this.estado = Paso.Inicio; // Inicialización del estado como "Inicio".
        }
        #endregion

        #region Propiedades
        public int Anio { get => this.anio; }
        public string Autor { get => this.autor; }
        public string Barcode { get => this.barcode; }
        public Paso Estado { get => this.estado; }
        /// <summary>
        /// Obtiene el número normalizado del documento. Visible solo desde clases derivadas.
        /// </summary>
        protected string NumNormalizado { get => this.numNormalizado; }
        public string Titulo { get => this.titulo; }
        #endregion

        #region Métodos
        /// <summary>
        /// Avanza el estado del documento al siguiente paso.
        /// </summary>
        /// <returns>True si el estado avanzó, False si ya está en el estado "Terminado".</returns>
        public bool AvanzarEstado()

        {
            if (this.estado == Paso.Terminado)
            {
                return false;
            }
            this.estado++;
            return true;    
        }


        public override string ToString()
        {
            
            StringBuilder datos = new StringBuilder();
            
            datos.AppendLine($" Titulo: {titulo}");
            datos.AppendLine($" Autor: {autor}");
            datos.AppendLine($" Año: {anio}");
            datos.AppendLine($" Cód. de barras: {barcode}");
            return datos.ToString();
        }
        #endregion
    }
}
