using System;

static class LogManager
{
    #region Constants
    #endregion

    #region Public Static Properties
    public static uint LogLevel
    {
        get { return logLevel; }
        set { logLevel = value; }
    }
    #endregion

    #region Static Variables
    private static uint logLevel = 1;
    #endregion

    #region Public Static Methods
    public static void LogVerbose(string message)
    {
        if (logLevel < 1)
            Log($"VERBOSE: {message}");
    }

    public static void LogInformation(string message)
    {
        if (logLevel < 2)
            Log($"INFO: {message}");
    }

    public static void LogWarning(string message)
    {
        if (logLevel < 3)
            Log($"WARN: {message}");
    }

    public static void LogError(string message)
    {
        if (logLevel < 4)
            Log($"ERROR: {message}");
    }

    public static void LogCritical(string message)
    {
        Log($"CRITICAL: {message}");
    }
    #endregion

    #region Private Static Methods
    private static void Log(string message)
    {
        Console.WriteLine(message);
    }
    #endregion
}