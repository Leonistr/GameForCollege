using Texts;
using UnityEngine;


namespace WorldData
{
    [CreateAssetMenu(fileName = "Text", menuName = "GameData/Text")]
    public class TextData : ScriptableObject
    {
        public TextInfo TextInfo;
    }
}
