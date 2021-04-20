using Quests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Texts;


namespace Interfaces
{
    public interface ITextFactory
    {
        IController Create(IQuestAndTextProvider questAndTextProvider);
        TextView GetTextView();
    }
}
