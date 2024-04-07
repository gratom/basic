using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

#if UNITY_EDITOR
using Global.Components.Localization;
using UnityEditor;
#endif

namespace Global.Managers.Datas
{
    using Tools;
    using Localization;

    [CreateAssetMenu(fileName = "LocalizationData", menuName = "Scriptables/Localization data", order = 51)]
    public class LocalizationData : ScriptableObject
    {
        private const string Extension = "csv";
        private const string Title = "Select CSV";
        private const string googleDocID = "1b0vhTZJDPU3v80Ov6YJTbMxMwxowag6BXdrIFQniS64";

        [SerializeField] private List<LocalizationDataContainer> containers;

        public string GetTextByID(int id)
        {
            return containers[id].GetTextByLanguage(Services.GetManager<DataManager>().DynamicData.Settings.CurrentLanguage);
        }

#if UNITY_EDITOR

        public string GetTextByIDDef(int id)
        {
            return containers[id].GetTextByLanguage(Language.EN);
        }

        [ContextMenu("From CSV")]
        private void LoadFromFile()
        {
            SetContainers(CSVParser.GetArrayFromFile(EditorUtility.OpenFilePanel(Title, Application.streamingAssetsPath, Extension)));
        }

        [ContextMenu("From GoogleSheet")]
        private void UpdateFromGoogleSheet()
        {
            Action<string> x = str => { SetContainers(CSVParser.ParseArrayFromString(str)); };
            CSVDownloader.Download(googleDocID, x);
        }

#endif

        private void SetContainers(List<List<string>> unpreparedData)
        {
            if (unpreparedData != null)
            {
                containers = new List<LocalizationDataContainer>(unpreparedData.Count);
                foreach (List<string> languageContents in unpreparedData)
                {
                    containers.Add(new LocalizationDataContainer(languageContents));
                }
            }
        }

        public int GetNewValueID()
        {
            //create new value, put it in list
            //connect to google sheets
            //update data
            //put new value in sheet
            //update data
            //return new value
            return 0;
        }

        public void UpdateValue(int id, string newValue)
        {

        }

    }

    [Serializable]
    public class LocalizationDataContainer
    {
        [SerializeField] private List<LanguageContentContainer> languageContainers;

        public LocalizationDataContainer(List<string> languageContents)
        {
            languageContainers = new List<LanguageContentContainer>(languageContents.Count);
            for (int i = 0; i < languageContents.Count; i++)
            {
                languageContainers.Add(new LanguageContentContainer((Language)(i + 1), Normalize(languageContents[i])));
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

        public string GetTextByLanguage(Language language)
        {
            LanguageContentContainer cont = languageContainers.FirstOrDefault(container => container.Language == language);
            return cont != null ? cont.Text : languageContainers.FirstOrDefault(container => container.Language == Language.EN)?.Text;
        }
    }

    [Serializable]
    public class LanguageContentContainer
    {
        [SerializeField] private Language language;
        [SerializeField] private string text;

        public Language Language => language;
        public string Text => text;

        public LanguageContentContainer(Language language, string text)
        {
            this.language = language;
            this.text = text;
        }
    }
}
