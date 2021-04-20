using UnityEngine;


namespace WorldData
{
    [CreateAssetMenu(fileName = "WorldData", menuName = "GameData/WorldData", order = 0)]
    public class Data : ScriptableObject
    {
        #region Fields

        public MoralData MoralData;
        public CameraData CameraData;
        public PlayerData PlayerData;
        public QuestData[] QuestDatas;
        public TextData TextData;
        #endregion
    }
}
