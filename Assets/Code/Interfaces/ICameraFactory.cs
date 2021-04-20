using CameraSpace;
using UnityEngine;


namespace Interfaces
{
    public interface ICameraFactory : IController
    {
        CameraController CreateCamera(ICameraProvider cameraProvider);
        CameraView GetCameraView();
    }
}
