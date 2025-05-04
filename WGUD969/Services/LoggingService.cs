using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace WGUD969.Services
{
    public interface ILoggingService
    {
        void LogError(string message);
    }
    public class LoggingService : ILoggingService
    {
        // For logging run time errors all we really need to see right now is information in the debug
        // output during development of async functions like database operations
        public void LogError(string message)
        {
            Debug.WriteLine(message);
        }
    }
}
