using Interfaces;
using System;
using Managers;
using UnityEngine;


namespace InputControllers
{
    public class HorizontalInputController : IInputProvider
    {
        #region Events

        public event Action<float> OnAxisChange;

        #endregion

        #region Methods

        public void GetAxis()
        {
            OnAxisChange.Invoke(Input.GetAxis(AxisManager.HORIZONTAL));
        }

        #endregion
    }
}
