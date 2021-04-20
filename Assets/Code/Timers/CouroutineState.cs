using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public enum CoroutineState
{
    None = 0,
    Ready = 1,
    Running = 2,
    Paused = 3,
    Finished = 4
}
