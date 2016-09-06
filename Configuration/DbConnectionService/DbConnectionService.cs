using System;
using System.Collections.Generic;
using System.Fabric;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.ServiceFabric.Services.Communication.Runtime;
using Microsoft.ServiceFabric.Services.Runtime;
using ConfigurationManagement.SDK;
using Microsoft.ServiceFabric.Services.Communication.Wcf.Runtime;
using Microsoft.ServiceFabric.Services.Communication.Wcf;

namespace DbConnectionService
{
    /// <summary>
    /// An instance of this class is created for each service instance by the Service Fabric runtime.
    /// </summary>
    internal sealed class DbConnectionService : StatelessService, IDbConnectionService
    {
        public DbConnectionService(StatelessServiceContext context)
            : base(context)
        { }

        public string IdentifyTenantDatabase(string tenantKey)
        {
            return string.Format("Connection:{0}", tenantKey);
        }

        protected override IEnumerable<ServiceInstanceListener> CreateServiceInstanceListeners()
        {
            return new[] {
                new ServiceInstanceListener( context => CreateTcpListener(this, context), "tcp" ),
            };
        }

        private static ICommunicationListener CreateTcpListener(IDbConnectionService service, StatelessServiceContext context)
        {
            return new WcfCommunicationListener<IDbConnectionService>(
                wcfServiceObject: service,
                serviceContext: context,
                endpointResourceName: "DatabaseConnectionService",
                listenerBinding: WcfUtility.CreateTcpListenerBinding()
            );
        }
    }
}
