using Interfaces;
using System;
using UnityEngine;


namespace Texts
{
    [Serializable]
    public struct TextInfo : IText
    {
        public GameObject TextObject;

        public GameObject Text { get => TextObject; set => TextObject = value; }
    }
}
