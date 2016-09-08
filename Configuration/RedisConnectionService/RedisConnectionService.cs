using System.Collections.Generic;
using System.Fabric;
using Microsoft.ServiceFabric.Services.Communication.Runtime;
using Microsoft.ServiceFabric.Services.Runtime;
using ConfigurationManagement.SDK;
using Microsoft.ServiceFabric.Services.Communication.Wcf.Runtime;
using Microsoft.ServiceFabric.Services.Communication.Wcf;

namespace RedisConnectionService
{
    /// <summary>
    /// An instance of this class is created for each service instance by the Service Fabric runtime.
    /// </summary>
    internal sealed class RedisConnectionService : StatelessService, IRedisConnectionService
    {
        public RedisConnectionService(StatelessServiceContext context)
            : base(context)
        { }

        public string IdentifyTenantCache(string tenantKey)
        {
            return string.Format("Redis:{0}", tenantKey);
        }

        protected override IEnumerable<ServiceInstanceListener> CreateServiceInstanceListeners()
        {
            return new[] {
                new ServiceInstanceListener( context => CreateTcpListener(this, context), "tcp" ),
            };
        }

        private static ICommunicationListener CreateTcpListener(IRedisConnectionService service, StatelessServiceContext context)
        {
            return new WcfCommunicationListener<IRedisConnectionService>(
                wcfServiceObject: service,
                serviceContext: context,
                endpointResourceName: "RedisConnectionService",
                listenerBinding: WcfUtility.CreateTcpListenerBinding()
            );
        }
    }
}
