namespace ConfigurationManagement.SDK
{
    public interface IRedisConnectionService
    {
        string IdentifyTenantCache(string tenantKey);
    }
}
