﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Cinematic.Resources {
    using System;
    using System.Reflection;
    
    
    /// <summary>
    ///    Clase de recurso fuertemente tipada para buscar cadenas localizadas, etc.
    /// </summary>
    // StronglyTypedResourceBuilder generó automáticamente esta clase
    // a través de una herramienta como ResGen o Visual Studio.
    // Para agregar o quitar un miembro, edite el archivo .ResX y, a continuación, vuelva a ejecutar ResGen
    // con la opción /str o recompile su proyecto de VS.
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class Messages {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        internal Messages() {
        }
        
        /// <summary>
        ///    Devuelve la instancia de ResourceManager en caché que usa la clase.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Cinematic.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///    Reemplaza la propiedad CurrentUICulture del subproceso actual para todas
        ///    las búsquedas de recursos que usan esta clase de recursos fuertemente tipada.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///    Busca una cadena localizada similar a No se puede cancelar la sesión, porque su estado actual es CERRADA o CANCELADA.
        /// </summary>
        public static string CannotCancelSessionBecauseIsClosedOrCancelled {
            get {
                return ResourceManager.GetString("CannotCancelSessionBecauseIsClosedOrCancelled", resourceCulture);
            }
        }
        
        /// <summary>
        ///    Busca una cadena localizada similar a No se puede cerrar la sesión, porque su estado actual es CANCELADA o CERRADA.
        /// </summary>
        public static string CannotCloseSessionBecauseIsCancelledOrClosed {
            get {
                return ResourceManager.GetString("CannotCloseSessionBecauseIsCancelledOrClosed", resourceCulture);
            }
        }
        
        /// <summary>
        ///    Busca una cadena localizada similar a No se puede reabrir la sesión, porque ya está ABIERTA.
        /// </summary>
        public static string CannotReopenSessionBecauseIsOpen {
            get {
                return ResourceManager.GetString("CannotReopenSessionBecauseIsOpen", resourceCulture);
            }
        }
        
        /// <summary>
        ///    Busca una cadena localizada similar a El número de la fila es mayor que el máximo permitido.
        /// </summary>
        public static string RowNumberIsAboveMaxAllowed {
            get {
                return ResourceManager.GetString("RowNumberIsAboveMaxAllowed", resourceCulture);
            }
        }
        
        /// <summary>
        ///    Busca una cadena localizada similar a El número de la fila es menor que el mínimo permitido.
        /// </summary>
        public static string RowNumberIsBelowMinAllowed {
            get {
                return ResourceManager.GetString("RowNumberIsBelowMinAllowed", resourceCulture);
            }
        }
        
        /// <summary>
        ///    Busca una cadena localizada similar a La butaca no está reservada.
        /// </summary>
        public static string SeatIsNotReserved {
            get {
                return ResourceManager.GetString("SeatIsNotReserved", resourceCulture);
            }
        }
        
        /// <summary>
        ///    Busca una cadena localizada similar a La butaca ya está reservada. Pruebe con otra butaca.
        /// </summary>
        public static string SeatIsPreviouslyReserved {
            get {
                return ResourceManager.GetString("SeatIsPreviouslyReserved", resourceCulture);
            }
        }
        
        /// <summary>
        ///    Busca una cadena localizada similar a El número de la butaca es mayor que el máximo permitido.
        /// </summary>
        public static string SeatNumberIsAboveMaxAllowed {
            get {
                return ResourceManager.GetString("SeatNumberIsAboveMaxAllowed", resourceCulture);
            }
        }
        
        /// <summary>
        ///    Busca una cadena localizada similar a El número de la butaca es menor que el mínimo permitido.
        /// </summary>
        public static string SeatNumberIsBelowMinAllowed {
            get {
                return ResourceManager.GetString("SeatNumberIsBelowMinAllowed", resourceCulture);
            }
        }
        
        /// <summary>
        ///    Busca una cadena localizada similar a No ha seleccionado ninguna butaca.
        /// </summary>
        public static string SeatsNotFound {
            get {
                return ResourceManager.GetString("SeatsNotFound", resourceCulture);
            }
        }
        
        /// <summary>
        ///    Busca una cadena localizada similar a Se ha producido un error, y no se ha podido completar la venta. No se ha reservado ninguna entrada..
        /// </summary>
        public static string SellFailed {
            get {
                return ResourceManager.GetString("SellFailed", resourceCulture);
            }
        }
        
        /// <summary>
        ///    Busca una cadena localizada similar a Ya existe una sesión a la misma fecha y hora.
        /// </summary>
        public static string SessionCannotBeCreatedBecauseIsDupe {
            get {
                return ResourceManager.GetString("SessionCannotBeCreatedBecauseIsDupe", resourceCulture);
            }
        }
        
        /// <summary>
        ///    Busca una cadena localizada similar a La sesión {0} no se puede eliminar por que ya se han vendido entradas.
        /// </summary>
        public static string SessionCannotBeRemovedBecauseItHasSoldTickets {
            get {
                return ResourceManager.GetString("SessionCannotBeRemovedBecauseItHasSoldTickets", resourceCulture);
            }
        }
        
        /// <summary>
        ///    Busca una cadena localizada similar a No se puede actualizar la fecha de la sesión porque ya existe otra sesión con la misma fecha.
        /// </summary>
        public static string SessionCannotBeUpdatedBecauseDateIsDupe {
            get {
                return ResourceManager.GetString("SessionCannotBeUpdatedBecauseDateIsDupe", resourceCulture);
            }
        }
        
        /// <summary>
        ///    Busca una cadena localizada similar a La sesión ha sido cancelada. No hay entradas a la venta.
        /// </summary>
        public static string SessionIsCancelledNoTicketsAvailable {
            get {
                return ResourceManager.GetString("SessionIsCancelledNoTicketsAvailable", resourceCulture);
            }
        }
        
        /// <summary>
        ///    Busca una cadena localizada similar a La sesión está cerrada. No se pueden devolver entradas.
        /// </summary>
        public static string SessionIsClosedCannotReturnTickets {
            get {
                return ResourceManager.GetString("SessionIsClosedCannotReturnTickets", resourceCulture);
            }
        }
        
        /// <summary>
        ///    Busca una cadena localizada similar a La sesión está cerrada. No hay entradas a la venta.
        /// </summary>
        public static string SessionIsClosedNoTicketsAvailable {
            get {
                return ResourceManager.GetString("SessionIsClosedNoTicketsAvailable", resourceCulture);
            }
        }
        
        /// <summary>
        ///    Busca una cadena localizada similar a No se ha encontrado la sesión especificada, o no está disponible.
        /// </summary>
        public static string SessionNotAvailableOrNotFound {
            get {
                return ResourceManager.GetString("SessionNotAvailableOrNotFound", resourceCulture);
            }
        }
    }
}
