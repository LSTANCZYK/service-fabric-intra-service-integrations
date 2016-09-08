using System.ServiceModel;

namespace ConfigurationManagement.SDK
{
    [SerivceContract]
    public interface IRedisConnectionService
    {
        [OperationContract]
        string IdentifyTenantCache(string tenantKey);
    }
}
