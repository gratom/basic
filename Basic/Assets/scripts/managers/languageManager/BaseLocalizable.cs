using System;
using UnityEngine;

namespace Global.Components.Localization
{
    using Managers.Localization;
    using Managers.Datas;

    [Serializable]
    public abstract class BaseLocalizable
    {
        [SerializeField] protected int id = -1;

        public void Init()
        {
            Services.GetManager<DataManager>().DynamicData.Settings.OnLanguageChange += OnLanguageChange;
            LanguageChangeAction(Services.GetManager<LanguageManager>().GetTextByID(id));
        }

        public void UnInit()
        {
            Services.GetManager<DataManager>().DynamicData.Settings.OnLanguageChange -= OnLanguageChange;
        }

        private void OnLanguageChange(Language language)
        {
            LanguageChangeAction(Services.GetManager<LanguageManager>().GetTextByID(id));
        }

        protected abstract void LanguageChangeAction(string newValue);
    }
}
