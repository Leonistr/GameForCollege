using Interfaces;
using UnityEngine;
using Extensions;
using Player;
using WorldData;


namespace CameraSpace
{
    public class CameraFactory : ICameraFactory
    {
        #region Fields

        private CameraData _cameraData;
        private PlayerView _playerView;
        private CameraView _cameraView;

        #endregion

        #region Constructor

        public CameraFactory(CameraData cameraData, PlayerView playerView)
        {
            _cameraData = cameraData;
            _playerView = playerView;
        }

        #endregion

        #region Methods

        public CameraController CreateCamera(ICameraProvider cameraProvider)
        {
            var cameraModel = new CameraModel(_cameraData.CameraStruct);
            _cameraView = Object.Instantiate(_cameraData.Camera, Vector3.zero, Quaternion.identity).GetOrAddComponent<CameraView>();
            
            var controller = new CameraController(cameraModel, _cameraView, _playerView, cameraProvider);
            return controller;
        }

        public CameraView GetCameraView()
        {
            return _cameraView;
        }

        #endregion
    }
}
