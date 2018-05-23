using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class LanguageChoose  {

    private static LanguageChoose instance;

    private LanguageChoose(){}
    string sourceLanguageText, targetLanguageText;
   
    LANG originalLanguage=LANG.PL, targetLanguage=LANG.EN;
    Dropdown originalLangDropdown,targetLangDropdown;
    List<Toggle> languagesList = new List<Toggle>();


    public static LanguageChoose Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new LanguageChoose();
            }
            return instance;
        }
    }
    // Use this for initialization
    public void Start () {
        sourceLanguageText=GameObject.Find("LabelSrc").GetComponent<Text>().text;
        targetLanguageText = GameObject.Find("LabelTrg").GetComponent<Text>().text;

        targetLangDropdown = GameObject.Find("DestLang").GetComponent<Dropdown>();
        originalLangDropdown = GameObject.Find("SrcLang").GetComponent<Dropdown>();
        
    }
	

    public void SetOriginalLanguage()
    {
        originalLanguage = (LANG)originalLangDropdown.value;
        Debug.Log("set original language");
    }
    public void SetTargetLanguage()
    {
        targetLanguage = (LANG)targetLangDropdown.value;
        Debug.Log("set target language");

    }
    public LANG OriginalLanguage
    {
        get
        {
            return originalLanguage;
        }
    }
    public LANG TargetLanguage
    {
        get
        {
            return targetLanguage;
        }
    }

    public string GetOriginalLanguage()
    {
        switch (originalLanguage)
        {
            case LANG.EN:
                return "en";
              

            case LANG.PL:
                return "pl";
                

            case LANG.FR:
                return "fr";
               

            case LANG.DE:
                return "de";
               

            case LANG.ES:
                return "es";
               

            default:
                return "pl";
               
        }

    }

    public string GetTargetLanguage()
    {
        switch (targetLanguage)
        {
            case LANG.EN:
                return "en";


            case LANG.PL:
                return "pl";


            case LANG.FR:
                return "fr";


            case LANG.DE:
                return "de";


            case LANG.ES:
                return "es";


            default:
                return "pl";

        }
    }

}

public enum LANG { PL, EN, FR, DE, ES }
