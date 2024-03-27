using UnityEngine;
using UnityEngine.UI;

namespace Global.Components.Localization
{
    [RequireComponent(typeof(Text))]
    public class TextLocalizer : BaseMonoLocalizable
    {
        [SerializeField] private Text text;

        private void OnValidate()
        {
            text = GetComponent<Text>();
        }

        protected override void LanguageChangeAction(string newValue)
        {
            text.text = newValue;
        }
    }
}
