using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReceiveResult : MonoBehaviour {

    //private Translator translator;
    private Text originalText, translatedText;
    Translator translator;
    LanguageChoose language;
    [SerializeField]
    LANG org, tar;

    private void Start()
    {
        originalText = GameObject.Find("Original Text").GetComponent<Text>();
        translatedText = GameObject.Find("Translated Text").GetComponent<Text>();
        translator = GameObject.Find("SpeechRecognition").GetComponent<Translator>();
        language = LanguageChoose.Instance;
        language.Start();

    }

    private void Update()
    {
        org = language.OriginalLanguage;
        tar = language.TargetLanguage;
    }

    void onActivityResult(string recognizedText){
        char[] delimiterChars = {'~'};
        string[] result = recognizedText.Split(delimiterChars);

        //You can get the number of results with result.Length
        //And access a particular result with result[i] where i is an int
        //I have just assigned the best result to UI text
        originalText.text = result[0];
        StartCoroutine(translator.Process(language.GetOriginalLanguage(),
           language.GetTargetLanguage(),
           originalText.text));

    }
    public void SetOriginalLanguage()
    {
        Debug.Log("set original language");
        language.SetOriginalLanguage();
    }
    public void SetTargetLanguage()
    {
        Debug.Log("set target language");
        language.SetTargetLanguage();
    }

    public void SetTranslatedText(string text)
    {
        translatedText.text = text;
    }

}
