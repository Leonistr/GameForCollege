using System;
using UnityEngine;


namespace Player
{
    [RequireComponent(typeof(CapsuleCollider))]
    [RequireComponent(typeof(Animator))]
    public class PlayerView : MonoBehaviour
    {
        public event Action<string> OnRoomEnter;
        public event Action OnStepPlay;
        private void OnTriggerStay(Collider other)
        {
            OnRoomEnter?.Invoke(other.name);
        }

        public void StepPlay()
        {
            OnStepPlay?.Invoke();
        }
    }
}
