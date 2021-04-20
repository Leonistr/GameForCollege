using Interfaces;


namespace Texts
{
    public class TextModel
    {
        public IText Text;
        public TextModel(IText text)
        {
            Text = text;
        }
    }
}
