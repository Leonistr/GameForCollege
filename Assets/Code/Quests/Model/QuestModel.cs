using Interfaces;


namespace Quests
{
    public class QuestModel
    {
        public IQuest Quest;

        public QuestModel(IQuest quest)
        {
            Quest = quest;
        }
    }
}
