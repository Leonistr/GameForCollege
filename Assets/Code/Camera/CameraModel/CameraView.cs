using System;
using UnityEngine;


namespace CameraSpace
{
    public class CameraView : MonoBehaviour
    {
        public event Action OnCameraChange;
        private void OnGUI()
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                OnCameraChange.Invoke();
            }
        }
    }
}
