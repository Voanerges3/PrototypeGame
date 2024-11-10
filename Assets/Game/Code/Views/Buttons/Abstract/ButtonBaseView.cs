using Assets.Game.Code.Enums.Buttons;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Assets.Game.Code.Abstracts.Buttons.Abstract
{
    internal class ButtonBaseView<T> : MonoBehaviour where T : Enum
    {
        [SerializeField] private Button button;
        [SerializeField] private Image image;
        [SerializeField] private TextMeshProUGUI text;

        public T Type { get; private set; }

        private bool isLocked;

        public void Init(T type, bool isLocked, UnityAction action)
        {
            this.button.onClick.AddListener(action);
            this.Type = type;
            this.isLocked = isLocked;
        }
        public void SetSprite(Sprite sprite) => this.image.sprite = sprite;
        public void SetText(string text) => this.text.text = text;
    }
}
