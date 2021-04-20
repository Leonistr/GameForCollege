using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IQuestProvider
    {
        event Func<int> OnObjectToCompleteID;
        event Func<int> OnRequiredObjectToCompleteID;
        event Action<int, int> OnObjectCompleteCompare;

        void GetQuestCompletion();
    }
}
