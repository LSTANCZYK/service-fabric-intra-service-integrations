using System.ServiceModel;

namespace ConfigurationManagement.SDK
{
    [ServiceContract]
    public interface IDbConnectionService
    {
        [OperationContract]
        string IdentifyTenantDatabase(string tenantKey);
    }
}
