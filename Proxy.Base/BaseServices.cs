using System;
using System.Collections.Generic;
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
        protected Binding binding = null;
        protected string _endpointUrl = string.Empty;

        public void SetHTTP(HttpConfigureServices httpConfigureServices)
        {
            this._endpointUrl = httpConfigureServices.endpointUrl;
            this.binding = new BasicHttpBinding();
            setcloseTimeout(httpConfigureServices.closeTimeout);
            setopenTimeout(httpConfigureServices.openTimeout);
            HttpTransportBindingElement httpTransportBindingElement = new HttpTransportBindingElement();
            setmaxReceivedMessageSize(httpConfigureServices.maxReceivedMessageSize,ref httpTransportBindingElement);
            setmaxBufferSize(httpConfigureServices.maxBufferSize, ref httpTransportBindingElement);
            this.binding.CreateBindingElements().Add(httpTransportBindingElement);
            var endpoint = new EndpointAddress(_endpointUrl);
            ChannelFactoryRelay = new ChannelFactory<TChannel>(binding, endpoint);
            ChannelFactoryRelay.Credentials.UserName.UserName = httpConfigureServices.userName;
            ChannelFactoryRelay.Credentials.UserName.Password = httpConfigureServices.password;
        }

        public void Dispose()
        {
            Dispose(false);
            GC.SuppressFinalize(this);
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
        private void setmaxReceivedMessageSize(long? maxReceivedMessageSize,ref HttpTransportBindingElement httpTransportBindingElement)
        {
            if (maxReceivedMessageSize.HasValue)
            {
                httpTransportBindingElement.MaxReceivedMessageSize = maxReceivedMessageSize.Value;
            }

        }
        private void setmaxBufferSize(int? maxBufferSize, ref HttpTransportBindingElement httpTransportBindingElement)
        {
            if (maxBufferSize.HasValue)
            {
                httpTransportBindingElement.MaxBufferSize = maxBufferSize.Value;
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
