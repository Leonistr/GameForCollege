using Interfaces;


namespace Quests
{
    public class QuestInitializer : IInitializable
    {
        private IQuestFactory _questFactory;
        private IController _questController;

        public QuestInitializer(IQuestFactory questFactory, IQuestAndTextProvider questAndTextProvider)
        {
            _questFactory = questFactory;
            _questController = _questFactory.Create(questAndTextProvider);
        }

        public IController GetController()
        {
            return _questController;
        }

        public void Initialize()
        {

        }
    }
}
