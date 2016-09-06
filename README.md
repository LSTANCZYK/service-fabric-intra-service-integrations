# demo-service-fabric-intra-service-integrations

To run this example:

1.  Deploy application type:  ConfigurationManagement
2.  Deploy application type:  AccountManagement
3.  Access the application:  http://localhost:8281/api/customer/{tenant}/query?accountNumber=123 (replace tenant with any arbitary string).

When you access the REST endpoint, it will in turn make a WCF (over TCP) call to Configuration Manager to access the database connection information.  For illustrative purposes, the endpoint returns only the value that's returned from the Configuration Manager.
