using UnityEngine;
using Moral;


namespace WorldData
{
    [CreateAssetMenu(fileName = "MoralData", menuName = "GameData/Moral", order = 3)]
    public class MoralData : ScriptableObject
    {
        #region Fields

        public MoralStruct MoralStruct;

        #endregion
    }
}
