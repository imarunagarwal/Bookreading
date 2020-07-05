using Nagarro.Training.MVC.DAL.Interceptor;
using System.Data.Entity;
using System.Data.Entity.Infrastructure.Interception;
using System.Data.Entity.SqlServer;

namespace Nagarro.Training.MVC.DAL
{
    public class BookReadingConfiguration : DbConfiguration
    {
        public BookReadingConfiguration()
        {
            SetExecutionStrategy("System.Data.SqlClient", () => new SqlAzureExecutionStrategy());
            DbInterception.Add(new BookReadingInterceptorTransientErrors());
            DbInterception.Add(new BookReadingInterceptorLogging());
        }
    }
}
