using Interfaces;
using Quests;
using UnityEngine;


namespace Texts
{
    public class TextController : IInitializable, IExecutable
    {
        private TextModel _textModel;
        private TextView _textView;
        private IQuestAndTextProvider _questAndTextProvider;
        private bool _isActive;
        public TextController(TextModel textModel, TextView textView, IQuestAndTextProvider questAndTextProvider)
        {
            this._textModel = textModel;
            this._textView = textView;
            _textView.gameObject.SetActive(false);
            this._questAndTextProvider = questAndTextProvider;
            _questAndTextProvider.OnGameObjectGet += ChangeActive;
        }

        private void ChangeActive(bool obj)
        {
            _isActive = obj;
        }

        private GameObject GetGameObject()
        {
            return _textView.gameObject;
        }

        private void DeactivateText()
        {
            _textView.gameObject.SetActive(_isActive);
        }

        private void ActivateText()
        {
            _textView.gameObject.SetActive(_isActive);
        }

        public void Initialize()
        {

        }

        public void Execute(float deltaTime)
        {
            if (_isActive)
            {
                ActivateText();
            }
            else
            {
                DeactivateText();
            }
        }
    }
}
