using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Data.Common;

namespace InterceptorsEFCore.Interceptors
{
    public class SoftDeleteInterceptor : DbCommandInterceptor
    {
        public override InterceptionResult<DbDataReader> ReaderExecuting(
            DbCommand command,
            CommandEventData eventData,
            InterceptionResult<DbDataReader> result)
        {
            if (command.CommandText.StartsWith("SELECT", StringComparison.OrdinalIgnoreCase))
            {
                command.CommandText += " WHERE IsDeleted = 0";
            }
            return base.ReaderExecuting(command, eventData, result);
        }
    }
}
