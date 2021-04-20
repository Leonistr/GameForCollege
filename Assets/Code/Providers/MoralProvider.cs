using Interfaces;
using System;


namespace Providers
{
    public class MoralProvider : IMoralProvider, IExecutable
    {
        #region Fields

        private float _damageToDeal;

        #endregion

        #region Events

        public event Action<float> onPlayerHPChange;
        public event Func<float> GetDamage;

        #endregion

        #region Constructor

        public MoralProvider()
        {
        }

        #endregion

        #region Methods

        private void SetDamage()
        {
            _damageToDeal = GetDamage.Invoke();
        }

        public void GetPlayerHPChange()
        {
            SetDamage();
            onPlayerHPChange.Invoke(_damageToDeal);
        }

        public void Execute(float deltaTime)
        {
            GetPlayerHPChange();
        }

        #endregion
    }
}
