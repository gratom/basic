using System;
using Global.Managers.Localization;
using UnityEngine;

namespace Global.Managers.Datas
{
    [Serializable]
    public class SettingsData
    {
        [SerializeField] private Language currentLanguage = Language.EN;

        public Language CurrentLanguage
        {
            get => currentLanguage;
            set
            {
                if (currentLanguage != value && value != Language.NULL)
                {
                    currentLanguage = value;
                    OnLanguageChange?.Invoke(currentLanguage);
                }
            }
        }

        public event Action<Language> OnLanguageChange;
    }
}
