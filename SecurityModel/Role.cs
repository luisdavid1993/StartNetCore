using System;
using System.Collections.Generic;
using System.Text;

namespace SecurityModel
{
    /// <summary>
    /// Entidad que representa al Rol
    /// </summary>
    /// 
    [Serializable]
    public class Role : EntityClass
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Role"/> class.
        /// </summary>
        public Role()
        {
            App = new App();
            ListModules = new List<Module>();
            ListAppModules = new List<Module>();
            MessageError = String.Empty;
            TokenSession = String.Empty;
            InvokeAppId = String.Empty;
        }

        /// <summary>
        /// Gets or sets the rol uid.
        /// </summary>
        /// <value>
        /// The rol uid.
        /// </value>
        public String RoleId { get; set; }

        /// <summary>
        /// Gets or sets the Modulelication uid.
        /// </summary>
        /// <value>
        /// The App uid.
        /// </value>
        public App App { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public String RoleName { get; set; }

        /// <summary>
        /// Gets or sets the list modules.
        /// </summary>
        /// <value>
        /// The list modules.
        /// </value>
        public List<Module> ListModules { get; set; }

        /// <summary>
        /// Gets or sets the list app modules.
        /// </summary>
        /// <value>
        /// The list app modules.
        /// </value>
        public List<Module> ListAppModules { get; set; }
    }
}
