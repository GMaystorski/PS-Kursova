using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLogin
{
    static public class Logger
    {
        private static readonly string fileName = "D:/Downloads/PS-Upr6/PS-Upr6/PS-Project/log.txt";
        private static List<string> currentSessionActivities = new List<string>();
        private static UserLoginContext context = new UserLoginContext();

        public static void LogActivity(string activity)
        {
            string activityLine = DateTime.Now + ";"
                + LoginValidation.Username + ";"
                + LoginValidation.CurrentUserRole + ";"
                + activity;

            currentSessionActivities.Add(activityLine);
            WriteLineToFile(activityLine);
            WriteLogToDatabase(activityLine);
        }

        private static void WriteLineToFile(string line)
        {
            if (File.Exists(fileName))
            { 
                File.AppendAllText(fileName, line + "\n");
            }
        }

        public static void DumpLog()
        {
            foreach (string item in currentSessionActivities)
            {
                Console.WriteLine(item);
            }
        }

        public static string GetCurrentSessionActivities()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var activities in currentSessionActivities)
            {
                sb.Append(activities);
            }
            return sb.ToString();
        }

        public static void WriteLogToDatabase(string logText)
        {
            Logs logEntity = new Logs();
            logEntity.Date = DateTime.Now;
            logEntity.LogMessage = logText;

            context.Logs.Add(logEntity);
            context.SaveChanges();
        }
    }
}
