using System.ServiceModel;

namespace ConfigurationManagement.SDK
{
    [ServiceContract]
    public interface IRedisConnectionService
    {
        [OperationContract]
        string IdentifyTenantCache(string tenantKey);
    }
}
