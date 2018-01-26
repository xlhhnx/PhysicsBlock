using System.Collections.Generic;

interface Command
{
    void Initialize(Dictionary<string,int> parameters);
    void Execute();
}