using System;
using System.Collections.Generic;
using System.Text;

namespace SecurityModel
{
    /// <summary>
    /// Entidad que representa al modulo
    /// </summary>
    /// 
    [Serializable]
    public class Module : EntityClass
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Module"/> class.
        /// </summary>
        public Module()
        {
            App = new App();
            LastUpdate = DateTime.Now;
            MessageError = String.Empty;
            TokenSession = String.Empty;
            InvokeAppId = String.Empty;
        }

        /// <summary>
        /// Gets or sets the module uid.
        /// </summary>
        /// <value>
        /// The module uid.
        /// </value>
        public String ModuleId { get; set; }

        /// <summary>
        /// Gets or sets the application.
        /// </summary>
        /// <value>
        /// The application.
        /// </value>
        public App App { get; set; }

        /// <summary>
        /// Gets or sets the module.
        /// </summary>
        /// <value>
        /// The module.
        /// </value>
        public String ModuleName { get; set; }

        /// <summary>
        /// Gets or sets the URL.
        /// </summary>
        /// <value>
        /// The URL.
        /// </value>
        public String URL { get; set; }

        /// <summary>
        /// Gets or sets the icon.
        /// </summary>
        /// <value>
        /// The icon o image if it has.
        /// </value>
        public String Icon { get; set; }

        /// <summary>
        /// Gets or sets the style.
        /// </summary>
        /// <value>
        /// The style css if it has.
        /// </value>
        public String Style { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is view.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is view; otherwise, <c>false</c>.
        /// </value>
        public Boolean? IsView { get; set; }

        /// <summary>
        /// Gets or sets the last update.
        /// </summary>
        /// <value>
        /// The last update.
        /// </value>
        public DateTime LastUpdate { get; set; }

        #region "Propiedades de Paso"
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Module"/> is reading.
        /// </summary>
        /// <value>
        ///   <c>true</c> if allows reading; otherwise, <c>false</c>.
        /// </value>
        public Boolean? Reading { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Module"/> is writing.
        /// </summary>
        /// <value>
        ///   <c>true</c> if allows writing; otherwise, <c>false</c>.
        /// </value>
        public Boolean? Writing { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Module"/> is modifing.
        /// </summary>
        /// <value>
        ///   <c>true</c> if allows modifying; otherwise, <c>false</c>.
        /// </value>
        public Boolean? Modifying { get; set; }

        /// <summary>
        /// Gets or sets the role identifier.
        /// </summary>
        /// <value>
        /// The role identifier.
        /// </value>
        public String RoleId { get; set; }
        #endregion
    }
}
