using UnityEngine;
using System;


namespace Quests
{
    public class QuestView : MonoBehaviour
    {
        public event Action OnQuestAssignment;
        public event Action OnNPCGoingOff;
        public event Action<bool> OnTriggerChange;
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                OnTriggerChange?.Invoke(true);
                OnQuestAssignment?.Invoke();
            }
        }

        private void OnTriggerExit(Collider other)
        {
            OnTriggerChange?.Invoke(false);
            OnNPCGoingOff?.Invoke();
        }
    }
}
