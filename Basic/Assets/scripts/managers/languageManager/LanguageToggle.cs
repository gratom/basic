using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Global.Components.Localization
{
    using Tools;
    using Global.Managers.Localization;

    [Assert]
    [RequireComponent(typeof(Toggle))]
    public class LanguageToggle : MonoBehaviour
    {
#pragma warning disable
        [SerializeField] private Language language = Language.NULL;
        [SerializeField] private Toggle toggle;
#pragma warning restore

        public bool IsOn
        {
            get => toggle.isOn;
            set => toggle.isOn = value;
        }

        public Language Language => language;

        public event Action<Language> OnChoose;

        private void OnValidate()
        {
            toggle = GetComponent<Toggle>();
        }

        private void Start()
        {
            toggle.onValueChanged.AddListener(x =>
            {
                if (x)
                {
                    OnChoose?.Invoke(language);
                }
            });
        }
    }
}
