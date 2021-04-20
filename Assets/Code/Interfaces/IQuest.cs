using Quests;
using UnityEngine;


namespace Interfaces
{
    public interface IQuest
    {
        int QuestID { get; }
        int QuestObjectID { get; }
        string[] QuestText { get; }
        QuestStatus QuestStatus { get; set; }
    }
}