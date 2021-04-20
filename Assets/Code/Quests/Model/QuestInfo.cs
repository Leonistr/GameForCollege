using System;
using Interfaces;



namespace Quests
{
    [Serializable]
    public struct QuestInfo : IQuest
    {
        public int QuestID;
        public int QuestObjectID;
        public string[] QuestText;
        public QuestStatus QuestStatus;
        
        int IQuest.QuestID => throw new NotImplementedException();

        int IQuest.QuestObjectID => throw new NotImplementedException();

        string[] IQuest.QuestText => QuestText;

        QuestStatus IQuest.QuestStatus { get => QuestStatus; set => QuestStatus = value; }
    }
}
