using System.Collections;
using System.Collections.Generic;
using Global.Components.Localization;
using UnityEngine;

public class test1 : MonoBehaviour
{
    [SerializeField] private string textToTranslate = "Hello, how are you?";
    [SerializeField] private GT.Language inputLanguage;
    [SerializeField] private GT.Language outputLanguage;

    [ContextMenu("Test")]
    private void Test()
    {
        // Example usage of the GT.Translate function

        // Translate the text
        string translatedText = GT.Translate(textToTranslate, inputLanguage, outputLanguage);

        // Print the translated text to the console
        Debug.Log("Translated text: " + translatedText);
    }


    // Update is called once per frame
    private void Update()
    {

    }
}
