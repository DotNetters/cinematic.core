﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Cinematic.Resources {
    using System;
    using System.Reflection;
    
    
    /// <summary>
    ///    A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class Messages {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        internal Messages() {
        }
        
        /// <summary>
        ///    Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Kash.Core.Sandbox.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///    Overrides the current thread's CurrentUICulture property for all
        ///    resource lookups using this strongly typed resource class.
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
        ///    Looks up a localized string similar to El número de la fila es mayor que el máximo permitido.
        /// </summary>
        public static string RowNumberIsAboveMaxAllowed {
            get {
                return ResourceManager.GetString("RowNumberIsAboveMaxAllowed", resourceCulture);
            }
        }
        
        /// <summary>
        ///    Looks up a localized string similar to El número de la fila es menor que el mínimo permitido.
        /// </summary>
        public static string RowNumberIsBelowMinAllowed {
            get {
                return ResourceManager.GetString("RowNumberIsBelowMinAllowed", resourceCulture);
            }
        }
        
        /// <summary>
        ///    Looks up a localized string similar to La butaca no está reservada.
        /// </summary>
        public static string SeatIsNotReserved {
            get {
                return ResourceManager.GetString("SeatIsNotReserved", resourceCulture);
            }
        }
        
        /// <summary>
        ///    Looks up a localized string similar to La butaca ya está reservada. Pruebe con otra butaca.
        /// </summary>
        public static string SeatIsPreviouslyReserved {
            get {
                return ResourceManager.GetString("SeatIsPreviouslyReserved", resourceCulture);
            }
        }
        
        /// <summary>
        ///    Looks up a localized string similar to El número de la butaca es mayor que el máximo permitido.
        /// </summary>
        public static string SeatNumberIsAboveMaxAllowed {
            get {
                return ResourceManager.GetString("SeatNumberIsAboveMaxAllowed", resourceCulture);
            }
        }
        
        /// <summary>
        ///    Looks up a localized string similar to El número de la butaca es menor que el mínimo permitido.
        /// </summary>
        public static string SeatNumberIsBelowMinAllowed {
            get {
                return ResourceManager.GetString("SeatNumberIsBelowMinAllowed", resourceCulture);
            }
        }
        
        /// <summary>
        ///    Looks up a localized string similar to No ha seleccionado ninguna butaca.
        /// </summary>
        public static string SeatsNotFound {
            get {
                return ResourceManager.GetString("SeatsNotFound", resourceCulture);
            }
        }
        
        /// <summary>
        ///    Looks up a localized string similar to Se ha producido un error, y no se ha podido completar la venta. No se ha reservado ninguna entrada..
        /// </summary>
        public static string SellFailed {
            get {
                return ResourceManager.GetString("SellFailed", resourceCulture);
            }
        }
        
        /// <summary>
        ///    Looks up a localized string similar to La sesión ha sido cancelada. No hay entradas a la venta.
        /// </summary>
        public static string SessionIsCancelledNoTicketsAvailable {
            get {
                return ResourceManager.GetString("SessionIsCancelledNoTicketsAvailable", resourceCulture);
            }
        }
        
        /// <summary>
        ///    Looks up a localized string similar to La sesión está cerrada. No se pueden devolver entradas.
        /// </summary>
        public static string SessionIsClosedCannotReturnTickets {
            get {
                return ResourceManager.GetString("SessionIsClosedCannotReturnTickets", resourceCulture);
            }
        }
        
        /// <summary>
        ///    Looks up a localized string similar to La sesión está cerrada. No hay entradas a la venta.
        /// </summary>
        public static string SessionIsClosedNoTicketsAvailable {
            get {
                return ResourceManager.GetString("SessionIsClosedNoTicketsAvailable", resourceCulture);
            }
        }
        
        /// <summary>
        ///    Looks up a localized string similar to No se ha encontrado la sesión especificada, o no está disponible.
        /// </summary>
        public static string SessionNotAvailableOrNotFound {
            get {
                return ResourceManager.GetString("SessionNotAvailableOrNotFound", resourceCulture);
            }
        }
    }
}
