using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace SecurityModel
{
    [Serializable]
    public abstract class EntityClass
    {
        /// <summary>
        /// Gets or sets the token session.
        /// </summary>
        /// <value>
        /// The token session.
        /// </value>
        [JsonIgnoreAttribute]
        public String TokenSession { get; set; }

        /// <summary>
        /// Gets or sets the invoke application identifier.
        /// </summary>
        /// <value>
        /// The invoke application identifier.
        /// </value>
        [JsonIgnoreAttribute]
        public String InvokeAppId { get; set; }

        /// <summary>
        /// Gets or sets the name of the user.
        /// </summary>
        /// <value>
        /// The name of the user.
        /// </value>
        public String UserNameByRequest { get; set; }

        /// <summary>
        /// Gets or sets the message error.
        /// </summary>
        /// <value>
        /// The message error.
        /// </value>
        [JsonIgnoreAttribute]
        public String MessageError { get; set; }
    }
}
