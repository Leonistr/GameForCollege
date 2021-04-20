using Interfaces;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


namespace Quests
{
    public class QuestController : IInitializable
    {
        private QuestModel _questModel;
        private QuestView _questView;
        private int _givenObjectID;
        private GameObject _textObject;
        private TextMeshPro _text;
        private IQuestAndTextProvider _questAndTextProvider;
        private bool _isOnTrigger = false;
        public QuestController(QuestModel questModel, QuestView questView, GameObject textObject, IQuestAndTextProvider questAndTextProvider)
        {
            this._questModel = questModel;
            this._questView = questView;
            _textObject = textObject;
            _text = _textObject.GetComponentInChildren<TextMeshPro>();
            _questView.OnQuestAssignment += AssignQuest;
            _questView.OnNPCGoingOff += DeactivateQuestText;
            this._questAndTextProvider = questAndTextProvider;
            _questView.OnTriggerChange += BooleanValueChange;
            _questAndTextProvider.OnBooleanValueGet += GetBool;
        }

        private bool GetBool()
        {
            return _isOnTrigger;
        }


        private void BooleanValueChange(bool arg)
        {
            _isOnTrigger = arg;
        }

        public void AssignQuest()
        {
            if (_questModel.Quest.QuestStatus != QuestStatus.Assigned)
            {
                ChangeStatus(QuestStatus.Assigned);
                _text.text = _questModel.Quest.QuestText[0];
                Debug.Log(_questModel.Quest.QuestStatus);
            }
        }

        public void DeactivateQuestText()
        {
            _textObject.SetActive(false);
        }

        public void CheckQuest()
        {
            if (_givenObjectID == _questModel.Quest.QuestObjectID)
            {
                ChangeStatus(QuestStatus.Done);
            }
            else
            {
                return;
            }
        }

        public void ChangeStatus(QuestStatus questStatus)
        {
            _questModel.Quest.QuestStatus = questStatus;
        }

        public void Initialize()
        {
        }
    }
}
