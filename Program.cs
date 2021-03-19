using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

[assembly: log4net.Config.XmlConfigurator(Watch =true)]
namespace LoggingWithLog4Net
{
    class Program
    {
        static ILog log = LogHelper.GetLogger(); //LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        static void Main(string[] args)
        {
            for (int r = 0; r < 10; r++)
            {
                log.Info("Power is running.. no problem at all!");
                log.Debug("Power is still running.. no problem at all - wifi is running and you can continue your work");
                log.Warn("Power is fluctuating.. be careful at meetings - wifi power backup would be better");
                log.Error("Power is gone.. turn on the generator - wifi would be restarted and network won't be available for the meanwhile");
                try
                {
                    int i = 0;
                    var x = 12 / i;
                }
                catch (DivideByZeroException dEx)
                {
                    log.Fatal("Power is gone and generator is not working either.. no network would be available", dEx);
                }
            }
            Console.ReadLine();
        }
    }

    public class LogHelper
    {
        public static ILog GetLogger([CallerFilePath]string fileName = "")
        {
            return LogManager.GetLogger(fileName);
        }
    }
}
