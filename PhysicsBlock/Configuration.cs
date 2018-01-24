using System;

static class Configuration
{
    public static TimeSpan DefaultFrameTime
    {
        get { return defaultFrameTime; }
        set { defaultFrameTime = value; }
    }

    private static TimeSpan defaultFrameTime = new TimeSpan();
}