using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace leaveQuote
{
    public class cls_Logger
    {
        private IConfiguration configuration;

        public cls_Logger(IConfiguration iConfig)
        {
            configuration = iConfig;
        }

        public void LogError(string sMsg)
        {
            try
            {
                string FilePath = configuration.GetValue<string>("AppSettings:ErrorLog");
                FileInfo flInfo = new FileInfo(FilePath);
                lock (flInfo)
                {
                    string message = string.Format("Time:{0}", DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt"));
                    message += Environment.NewLine;
                    message += string.Format("Message: {0}", sMsg);
                    message += Environment.NewLine;
                    message += "-------------------------------------------------------------------";

                    using (StreamWriter writer = new StreamWriter(FilePath, true))
                    {
                        writer.WriteLine(message);
                        writer.Close();
                    }
                }
            }
            catch (Exception)
            {

            }
        }
    }
}
