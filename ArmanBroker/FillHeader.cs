using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;

namespace ArmanBroker
{
    public class FillHeader :  IClientMessageInspector, IEndpointBehavior
    {
        public object BeforeSendRequest(ref Message request, IClientChannel channel)
        {
            var client = new ServiceReference2.TBSDefaultExternalServiceClient(ServiceReference2.TBSDefaultExternalServiceClient.EndpointConfiguration.BasicHttpBinding_ITBSDefaultExternalService1);
            client.Endpoint.Binding =new BasicHttpsBinding();
            var d = client.GetEmptyHeaderAsync().GetAwaiter().GetResult();
            d.UserName = "CustomerClub";
            d.Password = "123456cC";

            const string headerName = "CustomHeaderMessage";
            const string headerNamespace = "TadbirPardaz.TBS/PrincipalHeader";
            var header = d;
            var customHeader = MessageHeader.CreateHeader(headerName,
                                                          headerNamespace, header);
            request.Headers.Add(customHeader);
            return request;
        }

        public void AfterReceiveReply(ref Message reply, object correlationState)
        {
        }

       
        public void Validate(ServiceEndpoint endpoint)
        {
        }

        public void AddBindingParameters(ServiceEndpoint endpoint, BindingParameterCollection bindingParameters)
        {
        }

        public void ApplyDispatchBehavior(ServiceEndpoint endpoint, EndpointDispatcher endpointDispatcher)
        {
        }

        public void ApplyClientBehavior(ServiceEndpoint endpoint, ClientRuntime clientRuntime)
        {
            clientRuntime.ClientMessageInspectors.Add(this);
        }
    }
}
