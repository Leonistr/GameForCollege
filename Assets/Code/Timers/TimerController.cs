using System.Collections;


namespace Timers
{
    public class TimerController
    {
        private IEnumerator _routine;

        public CoroutineState CoroutineState;

        public TimerController(IEnumerator routine)
        {
            _routine = routine;
            CoroutineState = CoroutineState.Ready;
        }

        public IEnumerator Start()
        {
            if (CoroutineState != CoroutineState.Ready)
            {
                throw new System.InvalidOperationException($"Unable to start coroutine in state: {CoroutineState}");

            }
            CoroutineState = CoroutineState.Running;
            while (_routine.MoveNext())
            {

                yield return _routine.Current;
                while (CoroutineState == CoroutineState.Paused)
                {
                    yield return null;
                }
                if (CoroutineState == CoroutineState.Finished)
                {
                    yield break;
                }

            }
            CoroutineState = CoroutineState.Finished;
        }

        public void Stop()
        {
            if (CoroutineState != CoroutineState.Running || CoroutineState != CoroutineState.Paused)
            {
                throw new System.InvalidOperationException($"Unable to stop routine in state: {CoroutineState}");
            }
            CoroutineState = CoroutineState.Finished;
        }

        public void Pause()
        {
            if (CoroutineState != CoroutineState.Running)
            {
                throw new System.InvalidOperationException($"Unable to pause routine in state: {CoroutineState}");
            }
            CoroutineState = CoroutineState.Paused;
        }

        public void Resume()
        {
            if (CoroutineState != CoroutineState.Paused)
            {
                throw new System.InvalidOperationException($"Unable to resume routine in state: {CoroutineState}");
            }
        }
    }
}
