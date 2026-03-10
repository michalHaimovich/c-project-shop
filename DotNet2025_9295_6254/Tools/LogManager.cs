using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;


namespace Tools
{
    public static class LogManager
    {
        private const string logFolderName = "Log";
        private static DirectoryInfo path = Directory.CreateDirectory(logFolderName);

        public static string TodayPath()
        {
            return DateTime.Now.Day.ToString();
        }

        public static string MonthPath()
        {
            return DateTime.Now.Month.ToString();
        }

        public static void WriteLog(string project, string funcName, string message)
        {
            string monthPath = MonthPath();
            string todayPath = TodayPath();
            string logMessage = $"{DateTime.Now}: [{project}] [{funcName}] - {message}";

            // יצירת תיקיית חודש אם לא קיימת
            string monthDirectoryPath = Path.Combine(path.FullName, monthPath);
            if (!Directory.Exists(monthDirectoryPath))
            {
                Directory.CreateDirectory(monthDirectoryPath);
            }

            // קובץ לוג לפי תאריך
            string logFilePath = Path.Combine(monthDirectoryPath, $"{todayPath}.log");

            // הוספת הודעה לקובץ הלוג
            using (StreamWriter writer = new StreamWriter(logFilePath, true))
            {
                writer.WriteLine(logMessage);
            }
        }

        public static void DeleteOldLogFolders()
        {
            var directories = path.GetDirectories();
            foreach (var directory in directories)
            {
                // Try to parse the directory name as an integer (month number)
                if (int.TryParse(directory.Name, out int monthNumber))
                {
                    // If directory is older than 2 months, delete it
                    if (monthNumber <= DateTime.Now.AddMonths(-2).Date.Month && monthNumber != DateTime.Now.AddMonths(-1).Date.Month && monthNumber != DateTime.Now.Date.Month)
                    {
                        directory.Delete(true);
                    }
                }
            }
        }
    }
}



