using ConfigurationManagement.SDK;
using Microsoft.ServiceFabric.Services.Client;
using Microsoft.ServiceFabric.Services.Communication.Client;
using Microsoft.ServiceFabric.Services.Communication.Wcf;
using Microsoft.ServiceFabric.Services.Communication.Wcf.Client;
using System;
using System.ServiceModel.Channels;
using System.Web.Http;

namespace CustomerService.Controllers
{
    public abstract class BaseCustomerController : ApiController
    {
        private static readonly string SF_CONFIG_DBCONNECTION_SERVICE = "fabric:/ConfigurationManagement-1.0.0/DbConnectionService";

        protected string GetTenantDBConnection(string tenant)
        {
            Binding binding = WcfUtility.CreateTcpClientBinding();
            IServicePartitionResolver partitionResolver = ServicePartitionResolver.GetDefault();

            var wcfClientFactory = new WcfCommunicationClientFactory<IDbConnectionService>(clientBinding: binding, servicePartitionResolver: partitionResolver);

            var client = new ServicePartitionClient<WcfCommunicationClient<IDbConnectionService>>(wcfClientFactory, new Uri(SF_CONFIG_DBCONNECTION_SERVICE));

            var results = client.InvokeWithRetry(
                    c => c.Channel.IdentifyTenantDatabase(tenant)
                );

            return results;
        }
    }
}