using System;
using UnityEngine;


namespace CameraSpace
{
    [Serializable]
    public struct CameraStruct
    {
        #region Fields

        public Vector3 Offset;
        public float LeftMaximum;
        public float RightMaximum;
        public Texture Image;
        #endregion
    }
}
