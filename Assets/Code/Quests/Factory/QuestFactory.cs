using UnityEngine;
using Interfaces;
using WorldData;
using Extensions;


namespace Quests
{
    public class QuestFactory : IQuestFactory
    {
        private QuestData _questData;
        private GameObject _textField;
        public QuestFactory(QuestData questData, GameObject textField)
        {
            _questData = questData;
            _textField = textField;
        }

        public IController Create(IQuestAndTextProvider questAndTextProvider)
        {
            
            var spawnPosition = GameObject.FindGameObjectWithTag("SpawnNPC");
            var questModel = new QuestModel(_questData.QuestInfo);
            var questObject = Object.Instantiate(_questData.NPCObject, spawnPosition.transform.position, spawnPosition.transform.rotation);
            questObject.isStatic = true;
            var questView = questObject.GetOrAddComponent<QuestView>();
            var questController = new QuestController(questModel, questView, _textField, questAndTextProvider);
            return questController;
        }
    }

}
