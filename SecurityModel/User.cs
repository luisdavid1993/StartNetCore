using System;
using System.Collections.Generic;
using System.Text;

namespace SecurityModel
{
    [Serializable]
    public class User : EntityClass
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="User"/> class.
        /// </summary>
        public User()
        {
            LastUpdate = DateTime.Now;
            MessageError = String.Empty;
            TokenSession = String.Empty;
            InvokeAppId = String.Empty;
            Logins = new List<UserAccess>();
        }

        /// <summary>
        /// Gets or sets the user uid.
        /// </summary>
        /// <value>
        /// The user uid.
        /// </value>
        public Int32? UserId { get; set; }

        /// <summary>
        /// Gets or sets the company identifier.
        /// </summary>
        /// <value>
        /// The company identifier.
        /// </value>
        public Int32? CompanyId { get; set; }

        /// <summary>
        /// Gets or sets the tipo identifier.
        /// </summary>
        /// <value>
        /// The tipo identifier.
        /// </value>
        public String TypeId { get; set; }

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public String Id { get; set; }

        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        /// <value>
        /// The first name.
        /// </value>
        public String FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        /// <value>
        /// The last name.
        /// </value>
        public String LastName { get; set; }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>
        /// The email.
        /// </value>
        public String Email { get; set; }

        /// <summary>
        /// Gets or sets my user access.
        /// </summary>
        /// <value>
        /// My user access.
        /// </value>
        public List<UserAccess> Logins { get; set; }

        /// <summary>
        /// Gets or sets the last update.
        /// </summary>
        /// <value>
        /// The last update.
        /// </value>
        public DateTime LastUpdate { get; set; }
    }
}
