using UnityEngine;
using CameraSpace;


namespace WorldData
{
    [CreateAssetMenu(fileName = "Camera", menuName = "GameData/Camera", order = 2)]
    public class CameraData : ScriptableObject
    {
        #region Fields

        public CameraStruct CameraStruct;
        public GameObject Camera;

        #endregion
    }
}
