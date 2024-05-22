using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Entidades.Documento;

namespace Entidades
{
    public static class Informes
    {
        #region Metodos

        public static void MostrarDistribuidos(Escaner e, out int extension, out int cantidad, out string resumen)
        {
            MostrarDocumentosPorEstado(e, Documento.Paso.Distribuido, out extension, out cantidad, out resumen);
        }

        public static void MostrarEnEscaner(Escaner e, out int extension, out int cantidad, out string resumen)
        {
            MostrarDocumentosPorEstado(e, Documento.Paso.EnEscaner, out extension, out cantidad, out resumen);
        }

        public static void MostrarEnRevision(Escaner e, out int extension, out int cantidad, out string resumen)
        {
            MostrarDocumentosPorEstado(e, Documento.Paso.EnRevision, out extension, out cantidad, out resumen);
        }

        public static void MostrarTerminados(Escaner e, out int extension, out int cantidad, out string resumen)
        {
            MostrarDocumentosPorEstado(e, Documento.Paso.Terminado, out extension, out cantidad, out resumen);
        }

        /// <summary>
        /// Muestra un informe de los documentos en un estado específico.
        /// </summary>
        /// <param name="e">Escáner a analizar.</param>
        /// <param name="estado">Estado de los documentos a listar.</param>
        /// <param name="extension">Extensión total de los documentos en el estado especificado.</param>
        /// <param name="cantidad">Cantidad de documentos en el estado especificado.</param>
        /// <param name="resumen">Resumen de los documentos en el estado especificado.</param>
        private static void MostrarDocumentosPorEstado(Escaner e, Documento.Paso estado, out int extension, out int cantidad, out string resumen)
        {
            extension = 0;
            cantidad = 0;
            StringBuilder sbResumen = new StringBuilder();

            // Recorre la lista de documentos del escáner
            foreach (var doc in e.ListaDocumentos)
            {
                // Verifica si el documento está en el estado especificado
                if (doc.Estado == estado)
                {
                    cantidad++;
                    // Acumula la extensión total según el tipo de documento
                    if (doc is Libro libro)
                    {
                        extension += libro.NumPaginas;
                    }
                    else if (doc is Mapa mapa)
                    {
                        extension += mapa.Superficie;
                    }

                    sbResumen.AppendLine(doc.ToString());
                }
            }
            resumen = sbResumen.ToString();
        }

        #endregion
    }
}
