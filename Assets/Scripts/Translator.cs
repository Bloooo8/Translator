using SimpleJSON;
using UnityEngine;
using System.Collections;

public class Translator : MonoBehaviour
{

    private string yandexKey= "trnsl.1.1.20180514T164218Z.2aa64f016e323450.d32da3d60520e515ff486d5efa8e34f20568e0ce";
    // Should we debug?
    public bool isDebug = false;
    ReceiveResult result;



    // This is only called when the scene loads.
    void Start()
    {
        result = GameObject.Find("Main Camera").GetComponent<ReceiveResult>();
        // Strictly for debugging to test a few words!
        if (isDebug)
            StartCoroutine(Process("fr","en", "Bonsoir"));
    }

    // We have use googles own api built into google Translator.
    public IEnumerator Process(string sourceLang, string targetLang, string sourceText)
    {
 
         
        // Construct the url using our variables and yandex api.
        string url = "https://translate.yandex.net/api/v1.5/tr.json/translate?"+"key="+yandexKey
            +"&text="+ WWW.EscapeURL(sourceText)
            + "&lang="+ sourceLang+"-"+targetLang ;

        // Put together our unity bits for the web call.
        WWW www = new WWW(url);
        // Now we actually make the call and wait for it to finish.
        yield return www;

        // Check to see if it's done.
        if (www.isDone)
        {
            // Check to see if we don't have any errors.
            if (string.IsNullOrEmpty(www.error))
            {
                // Parse the response using JSON.
                var N = JSONNode.Parse(www.text);
                // Dig through and take apart the text to get to the good stuff.
                //translatedText = N["text"];
                result.SetTranslatedText(N["text"][0]);
                // This is purely for debugging in the Editor to see if it's the word you wanted.
                //Debug.Log(N["text"].ToString());

            }
            else { Debug.Log("wrong url"); Debug.Log(www.error); }
        }
    }

   
}