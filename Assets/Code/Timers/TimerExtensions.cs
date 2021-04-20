using System;
using System.Collections;
using UnityEngine;
using Object = UnityEngine.Object;


namespace Timers
{
    public static class TimerExtensions
    {
        private static AsyncOperationBehaviour _asyncOperationBehaviour = null;

        public static Coroutine StartCoroutine(this IEnumerator task, out TimerController controller)
        {
            Initialize();
            if (task == null)
            {
                throw new System.ArgumentNullException(nameof(task));
            }
            controller = new TimerController(task);
            return _asyncOperationBehaviour.StartCoroutine(controller.Start());
        }

        private static void Initialize()
        {
            if (_asyncOperationBehaviour != null)
            {
                return;
            }
            GameObject gameObject = new GameObject();
            Object.DontDestroyOnLoad(gameObject);
            gameObject.name = "AsyncOperationTimer";
            gameObject.hideFlags = HideFlags.HideAndDontSave;
            _asyncOperationBehaviour = gameObject.AddComponent<AsyncOperationBehaviour>();

        }
    }
}
