using System.Collections.Generic;

static class CommandManager
{
    private static Queue<Command> commandQueue = new Queue<Command>();

    public static void EnqueueCommand(Command cmd)
    {
        commandQueue.Enqueue(cmd);
    }

    public static void ExecuteAll()
    {
        while (commandQueue.Count > 0)
        {
            Command cmd = commandQueue.Dequeue();
            cmd.Execute();
        }
    }
}