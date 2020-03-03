using System;
using System.Collections.Generic;
using System.Text;

namespace SecurityModel
{
    /// <summary>
    /// Entidad que representa a la aplicacion
    /// </summary>
    /// 
    [Serializable]
    public class App : EntityClass
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="App"/> class.
        /// </summary>
        public App()
        {
            MessageError = String.Empty;
            TokenSession = String.Empty;
            InvokeAppId = String.Empty;
        }

        /// <summary>
        /// Gets or sets the Modulelication uid.
        /// </summary>
        /// <value>
        /// The Modulelication uid.
        /// </value>
        public String AppId { get; set; }

        /// <summary>
        /// Gets or sets the Modulelication.
        /// </summary>
        /// <value>
        /// The Modulelication.
        /// </value>
        public String AppName { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [allow exp pass].
        /// </summary>
        /// <value>
        ///   <c>true</c> if allow expiration pass; otherwise, <c>false</c>.
        /// </value>
        public Boolean? AllowExpPass { get; set; }

        /// <summary>
        /// Gets or sets the days to exp pass.
        /// </summary>
        /// <value>
        /// The days to expiration pass.
        /// </value>
        public Int32? DaysToExpPass { get; set; }

        /// <summary>
        /// Gets or sets the maximum attepmts to get login.
        /// </summary>
        /// <value>
        /// The maximum attepmts to get login.
        /// </value>
        public Int32? MaxAttemptsToGetLogin { get; set; }

        /// <summary>
        /// Gets or sets the URL reset pass.
        /// </summary>
        /// <value>
        /// The URL reset pass.
        /// </value>
        public String URLResetPass { get; set; }

        /// <summary>
        /// Gets or sets the URL activation user.
        /// </summary>
        /// <value>
        /// The URL activation user.
        /// </value>
        public String URLActivationUser { get; set; }

        /// <summary>
        /// Gets or sets the token life time.
        /// </summary>
        /// <value>
        /// The token life time.
        /// </value>
        public Int32? TokenLifeTime { get; set; }

        /// <summary>
        /// Gets or sets the private key.
        /// </summary>
        /// <value>
        /// The private key.
        /// </value>
        public String PrivateKey { get; set; }
    }
}
