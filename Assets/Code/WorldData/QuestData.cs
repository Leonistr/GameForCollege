using Quests;
using UnityEngine;


namespace WorldData
{
    [CreateAssetMenu(fileName = "Quest", menuName = "GameData/Quest")]
    public class QuestData : ScriptableObject
    {
        public QuestInfo QuestInfo;
        public GameObject WritingField;
        public GameObject NPCObject;
        public Transform SpawnPosition;
    }
}
