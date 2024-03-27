using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace Global.Managers.Localization
{
    using Datas;

    public enum Language
    {
        NULL = 0,
        EN = 1,
        RU = 2,
        FR = 3,
        PT = 4,
        DE = 5
    }

    public class LanguageManager : BaseManager
    {
        public override Type ManagerType => typeof(LanguageManager);

        private static Dictionary<SystemLanguage, Action> languageAutosetActionsDictionary = new Dictionary<SystemLanguage, Action>()
        {
            { SystemLanguage.Russian, () => Services.GetManager<DataManager>().DynamicData.Settings.CurrentLanguage = Language.RU },
            { SystemLanguage.French, () => Services.GetManager<DataManager>().DynamicData.Settings.CurrentLanguage = Language.FR },
            { SystemLanguage.Portuguese, () => Services.GetManager<DataManager>().DynamicData.Settings.CurrentLanguage = Language.PT },
            { SystemLanguage.German, () => Services.GetManager<DataManager>().DynamicData.Settings.CurrentLanguage = Language.DE }
        };

#pragma warning disable

        protected override async Task<bool> OnInit()
        {
            return true;
        }

#pragma warning restore

        public void RefreshLanguages()
        {
            if (Services.GetManager<DataManager>().DynamicData.Settings.CurrentLanguage == Language.NULL)
            {
                if (languageAutosetActionsDictionary.ContainsKey(Application.systemLanguage))
                {
                    languageAutosetActionsDictionary[Application.systemLanguage]();
                    return;
                }

                Services.GetManager<DataManager>().DynamicData.Settings.CurrentLanguage = Language.EN;
            }
        }

        public string GetTextByID(int id)
        {
            return Services.GetManager<DataManager>().StaticData.LocalizationData.GetTextByID(id);
        }
    }
}
