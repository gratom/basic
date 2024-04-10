using System;
using System.Collections.Generic;
using System.Linq;
using Global.Managers.Localization;
using UnityEngine;

namespace Global.Managers.Datas
{
    [Serializable]
    public class LocalizationDataContainer
    {
        [SerializeField] private List<LanguageContentContainer> languageContainers;

        public LocalizationDataContainer(List<string> languageContents)
        {
            languageContainers = new List<LanguageContentContainer>(languageContents.Count);
            for (int i = 0; i < languageContents.Count; i++)
            {
                languageContainers.Add(new LanguageContentContainer((GT.Language)(i + 1), Normalize(languageContents[i])));
            }
        }

        private string Normalize(string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                value = value.Replace("\"", "");
            }

            return value;
        }

        public string GetTextByLanguage(GT.Language language)
        {
            LanguageContentContainer cont = languageContainers.FirstOrDefault(container => container.Language == language);
            return cont != null ? cont.Text : languageContainers.FirstOrDefault(container => container.Language == GT.Language.English)?.Text;
        }
    }
}
