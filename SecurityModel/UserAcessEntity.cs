using System;
using System.Collections.Generic;
using System.Text;

namespace SecurityModel
{
    /// <summary>
    /// Entidad que representa al acceso del usuario
    /// </summary>
    /// 
    [Serializable]
    public class UserAccess : EntityClass
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserAccess"/> class.
        /// </summary>
        public UserAccess()
        {
            User = new User();
            ListRoles = new List<Role>();
            LastUpdate = DateTime.Now;
            MessageError = String.Empty;
            TokenSession = String.Empty;
            InvokeAppId = String.Empty;
        }

        /// <summary>
        /// Gets or sets the user access uid.
        /// </summary>
        /// <value>
        /// The user access uid.
        /// </value>
        public Int32? UserAccessId { get; set; }

        /// <summary>
        /// Gets or sets the object user.
        /// </summary>
        /// <value>
        /// The object user.
        /// </value>
        public User User { get; set; }

        /// <summary>
        /// Gets or sets the name of the user.
        /// </summary>
        /// <value>
        /// The name of the user.
        /// </value>
        public String UserName { get; set; }

        /// <summary>
        /// Gets or sets the is verified.
        /// </summary>
        /// <value>
        /// The is verified.
        /// </value>
        public Boolean? IsVerified { get; set; }

        /// <summary>
        /// Gets or sets the is blocked.
        /// </summary>
        /// <value>
        /// The is blocked.
        /// </value>
        public Boolean? IsBlocked { get; set; }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>
        /// The password.
        /// </value>
        public String Pass { get; set; }

        /// <summary>
        /// Gets or sets the attempts to get login wrong.
        /// </summary>
        /// <value>
        /// The attempts to get login wrong.
        /// </value>
        public Int32? AttemptsToGetLoginWrong { get; set; }

        /// <summary>
        /// Gets or sets the expiration date.
        /// </summary>
        /// <value>
        /// The expiration date.
        /// </value>
        public DateTime? ExpirationDate { get; set; }

        /// <summary>
        /// Gets or sets the last update.
        /// </summary>
        /// <value>
        /// The last update.
        /// </value>
        public DateTime LastUpdate { get; set; }

        /** Propiedad de paso **/
        /// <summary>
        /// Gets or sets the lista roles.
        /// </summary>
        /// <value>
        /// The lista roles.
        /// </value>
        public List<Role> ListRoles { get; set; }

        /// <summary>
        /// Gets or sets the role identifier.
        /// </summary>
        /// <value>
        /// The role identifier.
        /// </value>
        public String RoleId { get; set; }
    }
}
