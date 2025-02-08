using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Data.Common;

namespace InterceptorsEFCore.Interceptors
{
    public class RetryInterceptor : DbCommandInterceptor
    {
        public override async ValueTask<InterceptionResult<DbDataReader>> ReaderExecutingAsync(
            DbCommand command,
            CommandEventData eventData,
            InterceptionResult<DbDataReader> result,
            CancellationToken cancellationToken = default)
        {
            int retryCount = 3;
            while (retryCount > 0)
            {
                try
                {
                    return await base.ReaderExecutingAsync(command, eventData, result, cancellationToken);
                }
                catch (Exception ex)
                {
                    retryCount--;
                    if (retryCount == 0) throw;
                    Console.WriteLine($"Retrying due to error: {ex.Message}");
                }
            }
            return result;
        }
    }
}
