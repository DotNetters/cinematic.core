using System;

namespace Cinematic
{
    /// <summary>
    /// Excepción general de la capa de dominio / aplicación
    /// </summary>
    public class CinematicException : Exception
    {
        /// <inheritdoc />
        public CinematicException() { }
        /// <inheritdoc />
        public CinematicException(string message) : base(message) { }
        /// <inheritdoc />
        public CinematicException(string message, Exception inner) : base(message, inner) { }
    }
}
