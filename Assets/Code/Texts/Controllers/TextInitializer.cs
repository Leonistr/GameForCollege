using Interfaces;
using Quests;


namespace Texts
{
    public class TextInitializer : IInitializable
    {
        private TextView _textView;
        private IController _textController;
        private ITextFactory _textFactory;

        public TextInitializer(ITextFactory textFactory, IQuestAndTextProvider questAndTextProvider)
        {
            _textFactory = textFactory;
            _textController = _textFactory.Create(questAndTextProvider);
            _textView = _textFactory.GetTextView();
        }

        public IController GetController()
        {
            return _textController;
        }

        public TextView GetTextView()
        {
            return _textView;
        }

        public void Initialize()
        {

        }
    }
}
