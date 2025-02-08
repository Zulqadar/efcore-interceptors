using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Data.Common;

namespace InterceptorsEFCore.Interceptors
{
    public class LoggingInterceptor : DbCommandInterceptor
    {
        public override InterceptionResult<DbDataReader> ReaderExecuting(
            DbCommand command,
            CommandEventData eventData,
            InterceptionResult<DbDataReader> result)
        {
            Console.WriteLine($"Executing SQL Command: {command.CommandText}");
            return base.ReaderExecuting(command, eventData, result);
        }
    }
}
