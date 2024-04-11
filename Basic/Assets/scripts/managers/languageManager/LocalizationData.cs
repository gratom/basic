using System;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Global.Managers.Datas
{
    using Tools;


    [CreateAssetMenu(fileName = "LocalizationData", menuName = "Scriptables/Localization data", order = 51)]
    public class LocalizationData : ScriptableObject
    {
        private const string DEFAULT_DIRECTORY = "Assets/scriptables/localization/";

        private const string EXTENSION = "csv";
        private const string TITLE = "Select CSV";
        private const string GOOGLE_DOC_ID = "1b0vhTZJDPU3v80Ov6YJTbMxMwxowag6BXdrIFQniS64";

        [SerializeField] private List<ActiveLanguageContainer> allLanguages;
        [SerializeField] private List<LocalizationDataContainer> containers;

        public string GetTextByID(int id)
        {
            return containers[id].GetTextByLanguage(Services.GetManager<DataManager>().DynamicData.Settings.CurrentLanguage);
        }

#if UNITY_EDITOR

        public string GetTextByIDDef(int id)
        {
            return containers[id].GetTextByLanguage(GT.Language.English);
        }

        [MenuItem("Localization/Create main Asset")]
        public static void CreateLocalizationData()
        {
            // Create the directory if it doesn't exist
            if (!Directory.Exists(DEFAULT_DIRECTORY))
            {
                Directory.CreateDirectory(DEFAULT_DIRECTORY);
            }

            // Generate a unique filename
            string fileName = "MainLocalizationData.asset";
            string filePath = AssetDatabase.GenerateUniqueAssetPath(DEFAULT_DIRECTORY + fileName);

            // Create a new instance of the ScriptableObject
            LocalizationData newData = CreateInstance<LocalizationData>();

            // Save the ScriptableObject at the specified path
            AssetDatabase.CreateAsset(newData, filePath);
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
            EditorUtility.FocusProjectWindow();
            Selection.activeObject = newData;
        }

        [ContextMenu("From CSV")]
        private void LoadFromFile()
        {
            SetContainers(CSVParser.GetArrayFromFile(EditorUtility.OpenFilePanel(TITLE, Application.streamingAssetsPath, EXTENSION)));
        }

        [ContextMenu("From GoogleSheet")]
        private void UpdateFromGoogleSheet()
        {
            Action<string> x = str => { SetContainers(CSVParser.ParseArrayFromString(str)); };
            CSVDownloader.Download(GOOGLE_DOC_ID, x);
        }

        public int GetNewValueID()
        {
            //create new value, put it in list
            LocalizationDataContainer dataContainer = new LocalizationDataContainer();

            foreach (ActiveLanguageContainer languageContainer in allLanguages.Where(x => x.IsActive))
            {
                dataContainer.LanguageContainers.Add(new LanguageContentContainer(languageContainer.Language, ""));
            }
            containers.Add(dataContainer);
            return containers.Count - 1;
        }

        public void UpdateValue(int id, string newValue)
        {
            LocalizationDataContainer container = containers[id];
            if (container.LanguageContainers[0].Text != newValue)
            {
                container.LanguageContainers[0].Text = newValue;
                container.TranslateAll();
            }
        }

        public List<string> GetAllValues(int id)
        {
            return containers[id].LanguageContainers.Select(x => x.Text).ToList();
        }

#endif

        private void SetContainers(List<List<string>> unpreparedData)
        {
            if (unpreparedData != null)
            {
                containers = new List<LocalizationDataContainer>(unpreparedData.Count);
                foreach (List<string> languageContents in unpreparedData)
                {
                    //containers.Add(new LocalizationDataContainer(languageContents));
                }
            }
        }
    }
}
