using System;
using System.IO;

public static class Logger
{
    private static readonly string rutaLog = "log.txt";

    public static event Action<string> OnLogAdded;

    public static void Log(string mensaje)
    {
        string logEntry = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - {mensaje}";
        try
        {
            File.AppendAllText(rutaLog, logEntry + Environment.NewLine);
            OnLogAdded?.Invoke(logEntry);
        }
        catch (Exception ex)
        {
            // Manejo de error si quieres
        }
    }
}
