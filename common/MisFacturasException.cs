using System;
using System.Runtime.Serialization;

namespace common
{
  public  class MisFacturasException : Exception
    {
        public string UserMessage { get; set; }
        public MisFacturasException()
        {
            UserMessage = "";
        }

        public MisFacturasException(string message) : base(message)
        {
            UserMessage = "";
        }

        public MisFacturasException(string message, Exception innerException) : base(message, innerException)
        {
            UserMessage = "";
        }

        protected MisFacturasException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
        public MisFacturasException AddUserMessage(string _UserMessage)
        {
            UserMessage = _UserMessage;
            return this;
        }
    }
}
