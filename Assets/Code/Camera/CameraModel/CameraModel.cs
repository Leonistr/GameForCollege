using UnityEngine;


namespace CameraSpace
{
    public class CameraModel
    {
        #region Fields

        public CameraStruct CameraStruct;

        #endregion

        #region Constructor

        public CameraModel(CameraStruct cameraStruct)
        {
            CameraStruct = cameraStruct;
        }

        #endregion
    }
}
