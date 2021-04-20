using System;
using Managers;
using Interfaces;
using UnityEngine;


namespace InputControllers
{
    class VerticalInputController : IInputProvider
    {
        #region Events

        public event Action<float> OnAxisChange;

        #endregion

        #region Methods

        public void GetAxis()
        {
            OnAxisChange.Invoke(Input.GetAxis(AxisManager.VERTICAL));
        }

        #endregion
    }
}
