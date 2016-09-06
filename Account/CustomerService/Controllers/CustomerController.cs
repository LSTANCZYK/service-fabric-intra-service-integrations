using ConfigurationManagement.SDK;
using Microsoft.ServiceFabric.Services.Client;
using Microsoft.ServiceFabric.Services.Communication.Wcf;
using Microsoft.ServiceFabric.Services.Communication.Wcf.Client;
using System;
using System.ServiceModel.Channels;
using System.Web.Http;

namespace CustomerService.Controllers
{
    public class CustomerController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Query(string accountNumber)
        {
            Binding binding = WcfUtility.CreateTcpClientBinding();
            IServicePartitionResolver partitionResolver = ServicePartitionResolver.GetDefault();

            var wcfClientFactory = new WcfCommunicationClientFactory<IDbConnectionService>
                (clientBinding: binding, servicePartitionResolver: partitionResolver);

            var client = new WcfCommunicationTcpClient(
                            wcfClientFactory,
                            new Uri("fabric:/ConfigurationManagement/DbConnectionService"),
                            ServicePartitionKey.Singleton,
                            listenerName: "tcp");
            
            var results = client.InvokeWithRetry(
                    c => c.Channel.IdentifyTenantDatabase("BankOfSenthuran")
                );

            return Ok(results);
        }
    }
}
