using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileLogger
{
    public class Logger
    {
        private readonly string fileName;
        //const string fileName2 = "stała";
        private static string directory;

        public Logger()
        {
            setDirectory();
        }

        public Logger(string fileName)
        {
            this.fileName = fileName;
            setDirectory();
        }
        public void Log(string text)
        {            
            try
            {
                CreateDirectory();
                File.AppendAllText(Path.Combine(directory, fileName),
                    $"{Environment.NewLine} Data: {DateTime.Now.ToShortDateString()} Informacja: {text}");
            }
            catch (DirectoryNotFoundException dnfe)
            {
                LogError(dnfe.Message);
            }
        }
        public void LogError(string text)
        {
            CreateDirectory();
            File.AppendAllText(Path.Combine(directory, "Error.txt"),
                $"{Environment.NewLine} Data: {DateTime.Now.ToShortDateString()} Informacja: {text}");
        }
        private static void CreateDirectory()
        {
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
        }

        private void setDirectory()
        {
            try
            {
                directory = System.Configuration.ConfigurationManager.AppSettings["dir"];
                //var file = System.Configuration.ConfigurationManager.OpenExeConfiguration("~/FileLogger.dll.config");
                //directory = file.AppSettings["dir"].ToString();
            }
            catch (FileNotFoundException fnfe)
            {

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
