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

        private readonly string fileError = "Error.txt"; //tu domyslnie ustawiam Error.txt

        private static string directory; //dladczego static?



        public Logger()  //konstruktor wywoluje metode stDirectory
        {
            this.fileName = "aaa.txt";
            SetDirectory();
        }

        public Logger(string fileName, string fileError)  //2 konstruktor, tu w nawiasie to jest parametr, konstruktor przypisuje wartosc fileName          
        {
            this.fileName = fileName;
            this.fileError = fileError;
            SetDirectory();
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
            catch (Exception)
            {
                LogError("Coś się zepsuło");
            }
        }

        public void LogError(string text)
        {
            CreateDirectory();
            File.AppendAllText(Path.Combine(directory, fileError),
                $"{Environment.NewLine} Błąd {DateTime.Now.ToShortDateString()} | Error: {text}");
        }

        private static void CreateDirectory()
        {
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
        }

        private void SetDirectory()
        {
            try
            {
                directory = System.Configuration.ConfigurationManager.AppSettings["dir"];
                //var file = System.Configuration.ConfigurationManager.OpenExeConfiguration("~/FileLogger.dll.config");
                //directory = file.AppSettings["dir"].ToString();
            }
            catch (FileNotFoundException fnfe)
            {
                LogError(fnfe.Message);
            }
            catch (Exception)
            {
                LogError("Coś się zepsuło");
            }
        }
    }
}
