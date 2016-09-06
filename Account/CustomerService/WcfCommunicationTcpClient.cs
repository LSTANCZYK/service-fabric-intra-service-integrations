using ConfigurationManagement.SDK;
using Microsoft.ServiceFabric.Services.Client;
using Microsoft.ServiceFabric.Services.Communication.Client;
using Microsoft.ServiceFabric.Services.Communication.Wcf.Client;
using System;

namespace CustomerService
{
    internal class WcfCommunicationTcpClient : ServicePartitionClient<WcfCommunicationClient<IDbConnectionService>>

    {
        public WcfCommunicationTcpClient(ICommunicationClientFactory<WcfCommunicationClient<IDbConnectionService>> communicationClientFactory, Uri serviceUri, ServicePartitionKey partitionKey = null, TargetReplicaSelector targetReplicaSelector = TargetReplicaSelector.Default, string listenerName = null, OperationRetrySettings retrySettings = null)
            : base(communicationClientFactory, serviceUri, partitionKey, targetReplicaSelector, listenerName, retrySettings)
        {
        }
    }
}
