using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace WGUD969.Services
{
    public interface ILoggingService
    {
        void LogError(string message);
        Task LogToFileWithTimestamp(string fileName, string username);
    }
    public class LoggingService : ILoggingService
    {
        // For logging run time errors all we really need to see right now is information in the debug
        // output during development of async functions like database operations
        public void LogError(string message)
        {
            Debug.WriteLine(message);
        }

        // Arguably we need a FileService right? :P
        public async Task LogToFileWithTimestamp(string fileName, string message)
        {
            string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string logEntry = $"{timestamp} - {message}";

            using (StreamWriter writer = new StreamWriter($"{fileName}.txt", append: true))
            {
                await writer.WriteLineAsync(logEntry);
            }
        }
    }
}
