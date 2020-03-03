using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using SecurityModel;

namespace Proxy.Base
{
    public abstract class BaseServices<TChannel> : IDisposable
          where TChannel : IClientChannel
    {
        protected ChannelFactory<TChannel> ChannelFactoryRelay;
        protected BasicHttpBinding binding = null;
        protected string _endpointUrl = string.Empty;
        protected static EventLog eventLog;

        public void SetHTTP(HttpConfigureServices httpConfigureServices)
        {
            this._endpointUrl = httpConfigureServices.endpointUrl;
            this.binding = new BasicHttpBinding();
            setcloseTimeout(httpConfigureServices.closeTimeout);
            setopenTimeout(httpConfigureServices.openTimeout);
            Transfermode(httpConfigureServices);
            setmaxReceivedMessageSize(httpConfigureServices.maxReceivedMessageSize);
            setmaxBufferSize(httpConfigureServices.maxBufferSize);
            var endpoint = new EndpointAddress(_endpointUrl);
            ChannelFactoryRelay = new ChannelFactory<TChannel>(this.binding, endpoint);
            ChannelFactoryRelay.Credentials.UserName.UserName =string.IsNullOrWhiteSpace(httpConfigureServices.userName)?null: httpConfigureServices.userName;
            ChannelFactoryRelay.Credentials.UserName.Password = string.IsNullOrWhiteSpace(httpConfigureServices.password)?null: httpConfigureServices.password;
        }
      
        public void Dispose()
        {
            Dispose(false);
            GC.SuppressFinalize(this);
        }

        public void Transfermode(HttpConfigureServices httpConfigureServices)
        {
            if (httpConfigureServices.maxReceivedMessageSize.HasValue || httpConfigureServices.maxBufferSize.HasValue)
            {
                this.binding.TransferMode = TransferMode.Streamed;
            }
        }
        protected virtual void Dispose(bool prmDisposed)
        {
            try
            {
                if (ChannelFactoryRelay.State == CommunicationState.Faulted)
                {
                    return;
                }
                ChannelFactoryRelay.Close();
                prmDisposed = true;
            }
            finally
            {
                if (!prmDisposed)
                {
                    ChannelFactoryRelay.Abort();
                }
            }
        }
        private void setcloseTimeout(TimeSpan? setcloseTimeout)
        {
            if (setcloseTimeout.HasValue)
            {
                this.binding.CloseTimeout = setcloseTimeout.Value;
            }

        }
        private void setmaxReceivedMessageSize(long? maxReceivedMessageSize)
        {
            if (maxReceivedMessageSize.HasValue)
            {
                this.binding.MaxReceivedMessageSize = maxReceivedMessageSize.Value;
            }

        }
        private void setmaxBufferSize(int? maxBufferSize)
        {
            if (maxBufferSize.HasValue)
            {
                this.binding.MaxBufferSize = maxBufferSize.Value;
            }

        }
        private void setopenTimeout(TimeSpan? openTimeout)
        {
            if (openTimeout.HasValue)
            {
                this.binding.OpenTimeout = openTimeout.Value;
            }

        }
    }
}
