

using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Assets.Game.Code.ScriptableObjects.Abstract
{
    internal abstract class ButtonsDataBaseSO<T> : ScriptableObject where T : Enum
    {
        public List<ElementData<T>> ElementConfigs = new List<ElementData<T>>();
    }

    [Serializable]
    internal class ElementData<T>
    {
        public T Type;
        public VisualData VisualData;
    }

    [Serializable]
    internal class VisualData
    {
        public Sprite Sprite;
        public string Text;
    }
}
