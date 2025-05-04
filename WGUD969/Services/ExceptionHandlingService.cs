using System;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using WGUD969.Services;

namespace WGUD969.Services
{
    public interface IExceptionHandlingService
    {
        // You must implement a function for async functions with and without return types
        Task<T> ExecuteAsync<T>(Func<Task<T>> operation, string operationDescription);
        Task ExecuteAsync(Func<Task> operation, string operationDescription);
    }

    // The biggest motivation behind this service is to catch run time exception stack traces that wouldn't otherwise bubble up
    // For example, MySqlExceptions will log a single debug line that it was thrown with no other context and is does not stop run time
    // This allows us to catch exceptions like MySqlExceptions during run time and pinpoint where the error happend to log it. 
    // Any ILoggingService could be utilized, currently it's just using Debug.WriteLine()

    public class ExceptionHandlingService : IExceptionHandlingService
    {
        private readonly ILoggingService _LoggingService;

        public ExceptionHandlingService(ILoggingService loggingService)
        {
            _LoggingService = loggingService;
        }

        public async Task<T> ExecuteAsync<T>(Func<Task<T>> operation, string operationDescription)
        {
            try
            {
                return await operation();
            }
            catch (MySqlException e)
            {
                LogMySqlException(e, operationDescription);
                throw;
            }
            catch (InvalidOperationException e)
            {
                LogException(e, operationDescription, "Invalid Operation");
                throw;
            }
            catch (Exception e)
            {
                LogException(e, operationDescription, "General");
                throw;
            }
        }

        public async Task ExecuteAsync(Func<Task> operation, string operationDescription)
        {
            try
            {
                await operation();
            }
            catch (MySqlException e)
            {
                LogMySqlException(e, operationDescription);
                throw;
            }
            catch (InvalidOperationException e)
            {
                LogException(e, operationDescription, "Invalid Operation");
                throw;
            }
            catch (Exception e)
            {
                LogException(e, operationDescription, "General");
                throw;
            }
        }

        private void LogMySqlException(MySqlException e, string operationDescription)
        {
            _LoggingService.LogError($"MySQL Exception during {operationDescription}");
            _LoggingService.LogError($"Error Number: {e.Number}");
            _LoggingService.LogError($"Message: {e.Message}");
            _LoggingService.LogError($"Stack trace: {e.StackTrace}");
        }

        private void LogException(Exception e, string operationDescription, string exceptionType)
        {
            _LoggingService.LogError($"{exceptionType} Exception during {operationDescription}");
            _LoggingService.LogError($"Type: {e.GetType().Name}");
            _LoggingService.LogError($"Message: {e.Message}");
            _LoggingService.LogError($"Stack trace: {e.StackTrace}");
        }
    }
}