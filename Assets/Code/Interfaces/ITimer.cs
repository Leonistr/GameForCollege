using System.Collections;
using UnityEngine;


namespace Interfaces
{
    public interface ITimer : IController
    {
        IEnumerator Tick();
    }
}
