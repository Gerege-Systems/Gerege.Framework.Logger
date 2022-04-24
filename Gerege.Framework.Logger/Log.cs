using System;

namespace Gerege.Framework.Logger
{
    /// <author>
    /// codesaur - 2021.12.03
    /// </author>
    /// <package>
    /// Gerege Application Development Framework V5
    /// </package>

    /// <summary>
    /// Лог мэдээлэл.
    /// </summary>
    public struct Log
    {
        /// <summary>Лог дугаар.</summary>
        public string Id;

        /// <summary>Лог түвшин.</summary>
        public string Level;

        /// <summary>Лог тайлбар мессеж.</summary>
        public string Message;

        /// <summary>Лог өгөгдөл/утгууд.</summary>
        public dynamic Context;

        /// <summary>Лог үүссэн огноо.</summary>
        public DateTime CreatedAt;
    }
}
