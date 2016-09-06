using System.Web.Http;

namespace CustomerService.Controllers
{
    public class CustomerController : BaseCustomerController
    {
        [HttpGet]
        public IHttpActionResult Query(string tenant, string accountNumber)
        {
            string connectionString = GetTenantDBConnection(tenant);

            return Ok(connectionString);
        }
    }
}
