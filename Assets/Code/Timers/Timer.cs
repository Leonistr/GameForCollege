using System.Collections;
using UnityEngine;


namespace Timers
{
    public class Timer
    {
        public Timer()
        {
            Time(5).StartCoroutine(out _);
        }

        IEnumerator Time(float time)
        {
            while (time > 0)
            {
                Debug.LogError(time);
                yield return new WaitForSeconds(1.0f);
                time -= 1;
            }
        }
    }
}
