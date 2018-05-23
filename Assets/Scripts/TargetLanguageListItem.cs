using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetLanguageListItem : MonoBehaviour {

    LanguageChoose language;
    Toggle toggle;
    LANG currentLanguage;
    string label;
    Dictionary<LANG, string> langNames = new Dictionary<LANG, string>();

	void Start () {
        language = LanguageChoose.Instance;
        toggle = GetComponent<Toggle>();
       
        label = gameObject.name.Substring(8);

        FillDictionary();

        currentLanguage = language.OriginalLanguage;
        if (label == langNames[currentLanguage])
            toggle.interactable = false;

    }



    void FillDictionary()
    {
        langNames.Add(LANG.PL, "Polish");
        langNames.Add(LANG.EN, "English");
        langNames.Add(LANG.FR, "French");
        langNames.Add(LANG.DE, "German");
        langNames.Add(LANG.ES, "Spanish");
    }
}
