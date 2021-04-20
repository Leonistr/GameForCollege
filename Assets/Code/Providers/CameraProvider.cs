using Interfaces;
using System;


namespace Providers
{
    public class CameraProvider : ICameraProvider, IExecutable
    {
        public event Action OnPlayerTeleport;




        public void Execute(float deltaTime)
        {
            OnPlayerTeleport?.Invoke();
        }
    }
}
