using Interfaces;
using UnityEngine;
using WorldData;
using Extensions;
using CameraSpace;
using Quests;


namespace Texts
{
    public class TextFactory : ITextFactory
    {
        private TextData _textData;
        private TextView _textView;
        private CameraView _cameraView;
        

        public TextFactory(TextData textData, CameraView cameraView)
        {
            _textData = textData;
            _cameraView = cameraView;
        }
        public IController Create(IQuestAndTextProvider questAndTextProvider)
        {
            var textModel = new TextModel(_textData.TextInfo);
            var textObject = Object.Instantiate(_textData.TextInfo.TextObject);
            _textView = textObject.GetOrAddComponent<TextView>();
            var canvas = textObject.GetComponent<Canvas>();
            canvas.worldCamera = _cameraView.GetComponent<Camera>();
            canvas.planeDistance = 1;
            var controller = new TextController(textModel, _textView, questAndTextProvider);
            return controller;
        }

        public TextView GetTextView()
        {
            return _textView;
        }

    }
}
