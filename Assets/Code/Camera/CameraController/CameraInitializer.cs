using Interfaces;


namespace CameraSpace
{
    class CameraInitializer
    {
        #region Fields

        private ICameraFactory _cameraFactory;
        private IController _controller;
        private CameraView _cameraView;

        #endregion

        #region Constructor

        public CameraInitializer(ICameraFactory cameraFactory, ICameraProvider cameraProvider)
        {
            _cameraFactory = cameraFactory;
            _controller = _cameraFactory.CreateCamera(cameraProvider);
            _cameraView = _cameraFactory.GetCameraView();
        }

        #endregion

        #region Methods

        public IController GetController()
        {
            return _controller;
        }

        public CameraView GetCameraView()
        {
            return _cameraView;
        }

        #endregion
    }
}
