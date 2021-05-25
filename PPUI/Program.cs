using System;
using Serilog;


namespace PPUI
{
    class Program
    {
        public static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .WriteTo.File("log.txt")
            .CreateLogger();
            Intro.GetMenu("HomeScreen").Start();
        }
    }
}