using System.Diagnostics;

public class SystemHealthChecker
{
    public void CheckSystemHealth()
    {
        var memoryUsage = GetMemoryUsage();
        Console.WriteLine($"Memory Usage: {memoryUsage}%");
    }
    private float GetMemoryUsage()
    {
        var process = Process.GetCurrentProcess();
        return (float)(process.WorkingSet64 / 1024.0 / 1024.0);
    }
}
