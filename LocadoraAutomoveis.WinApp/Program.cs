using FluentValidation;
using Serilog;
using System.Globalization;

namespace LocadoraAutomoveis.WinApp
{
     internal static class Program
     {
          /// <summary>
          ///  The main entry point for the application.
          /// </summary>
          [STAThread]
          static void Main()
          {
               // To customize application configuration such as set high DPI settings or default font,
               // see https://aka.ms/applicationconfiguration.
               ValidatorOptions.Global.LanguageManager.Culture = new CultureInfo("pt-BR");

               Log.Logger = new LoggerConfiguration().MinimumLevel
                    .Debug()
                    .WriteTo
                    .File(@"C:\temp\logs\locadora-automoveis.txt",
                    outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message}{NewLine}{Exception}",
                    rollingInterval: RollingInterval.Day, retainedFileCountLimit: 5).CreateLogger();

               Application.SetHighDpiMode(HighDpiMode.SystemAware);
               Application.EnableVisualStyles();
               Application.SetCompatibleTextRenderingDefault(false);
               Application.Run(new TelaPrincipalForm());
          }
     }
}