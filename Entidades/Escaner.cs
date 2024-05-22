using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Entidades
{
    /// <summary>
    /// Clase que representa un escáner de documentos.
    /// </summary>
    public class Escaner
    {       
        #region Atributos
        private List<Documento> listaDocumentos;
        private Departamento locacion;
        private string marca;
        private TipoDoc tipo;
        #endregion

        #region Enumerados
        /// <summary>
        /// Enumerado que define los posibles tipos de documentos.
        /// </summary>
        public enum Departamento { nulo, mapoteca, procesosTecnicos }
        /// <summary>
        /// Enumerado que define las posibles locaciones del escáner.
        /// </summary>
        public enum TipoDoc { libro, mapa }
        #endregion

        #region Constructor  
        public Escaner(string marca, TipoDoc tipo)
        {
            this.marca = marca;
            this.tipo = tipo;
            this.listaDocumentos = new List<Documento>(); //Inicialización de la lista de documentos.

            // Inicialización de la locación según el tipo de documento
            switch (tipo)
            {
                case TipoDoc.mapa:
                    this.locacion = Departamento.mapoteca;
                    break;

                case TipoDoc.libro:
                    this.locacion = Departamento.procesosTecnicos;
                    break;

                default:
                    this.locacion = Departamento.nulo;
                    break;
            }

        }
        #endregion

        #region Propiedades     
        public List<Documento> ListaDocumentos { get => listaDocumentos; }
        public Departamento Locacion { get => locacion; }
        public string Marca { get => marca; }
        public TipoDoc Tipo { get => tipo; }
        #endregion

        #region Metodos
        /// <summary>
        /// Cambia el estado de un documento en la lista del escáner.
        /// </summary>
        /// <param name="d">Documento cuyo estado se va a cambiar.</param>
        /// <returns>True si el estado cambió, False si el documento no está en la lista.</returns>
        public bool CambiarEstadoDocumento(Documento d)
        {

            // Iterar sobre la lista de documentos del escáner
            foreach (Documento item in listaDocumentos)
            {
                // Verifica si el documento actual es igual al documento proporcionado
                if (item == d)
                {
                    // Avanza al siguiente estado del documento
                    item.AvanzarEstado();
                    return true; // Retorna true indicando que se cambió el estado del documento
                }
            }

            return false; // Retorna false si el documento no se encuentra en dicha lista
        }

        public static bool operator !=(Escaner e, Documento d)
        {
            return !(e == d);
        }

        /// <summary>
        /// Sobrecarga del operador + para agregar un documento a la lista del escáner.
        /// </summary>
        public static bool operator +(Escaner e, Documento d)
        {

            // Verificar si el documento NO está en la lista y si el documento está en estado "Inicio"
            if (!e.listaDocumentos.Contains(d) && d.Estado == Documento.Paso.Inicio)
            {
                d.AvanzarEstado(); // Cambiar el estado a "Distribuido" antes de añadirlo a la lista
                e.listaDocumentos.Add(d); // Agregar el documento a la lista
                return true; // Retornar true indicando que se añadió el documento
            }

            // Si el estado no es "Inicio" y si esta en la lista, no se añade y se retorna false
            return false;


        }

        public static bool operator ==(Escaner e, Documento d)
        {
            // Iterar sobre la lista de documentos del escáner
            foreach (Documento item in e.listaDocumentos)
            {
                // Si el documento actual es un Libro y el documento a comparar también es un Libro
                if (item is Libro libroItem && d is Libro libro)
                {
                    // Comparar los libros utilizando la sobrecarga del operador ==
                    if (libroItem == libro)
                    {
                        return true; // Retorna true si los libros son iguales
                    }
                }
                // Si el documento actual es un Mapa y el documento a comparar también es un Mapa
                else if (item is Mapa mapaItem && d is Mapa mapa)
                {
                    // Comparar los mapas utilizando la sobrecarga del operador ==
                    if (mapaItem == mapa)
                    {
                        return true; // Retorna true si los mapas son iguales
                    }
                }
            }

            // Si el documento no se encuentra en la lista, retornar false
            return false;
        }
        #endregion
    }
}
