using Interfaces;
using System;
using UnityEngine;

namespace Providers
{
    public class QuestAndTextProvider : IQuestAndTextProvider, IExecutable
    {
        public event Action<bool> OnGameObjectGet;
        public event Func<bool> OnBooleanValueGet;
        private bool _isInTrigger;

        public QuestAndTextProvider()
        {
            
        }
        
        private void GetGameObject()
        {
            OnGameObjectGet.Invoke(_isInTrigger);
        }

        private void GetBooleanValue()
        {
            _isInTrigger = OnBooleanValueGet.Invoke();
        }

        public void Execute(float deltaTime)
        {
            GetGameObject();
            GetBooleanValue();
        }
    }
}
