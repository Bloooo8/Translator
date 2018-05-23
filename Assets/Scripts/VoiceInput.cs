﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VoiceInput : MonoBehaviour {
    Button btn;
    [SerializeField]
    LANG originalLang = LANG.PL;
    string originalLanguage = "pl_PL";
	// Use this for initialization
	void Start () {
        
        btn = GameObject.Find("VoiceInputButton").GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);

    }
	
    void TaskOnClick()
    {   

        AndroidJavaClass pluginClass = new AndroidJavaClass("com.plugin.speech.pluginlibrary.TestPlugin");
        Debug.Log("Call 1 Started");

        // Pass the name of the game object which has the onActivityResult(string recognizedText) attached to it.
        // The speech recognizer intent will return the string result to onActivityResult method of "Main Camera"
        pluginClass.CallStatic("setReturnObject", "Main Camera");
        Debug.Log("Return Object Set");


        // Setting language is optional. If you don't run this line, it will try to figure out language based on device settings
        pluginClass.CallStatic("setLanguage", originalLanguage);
        Debug.Log("Language Set");


        // The following line sets the maximum results you want for recognition
        pluginClass.CallStatic("setMaxResults", 3);
        Debug.Log("Max Results Set");

        // The following line sets the question which appears on intent over the microphone icon
        pluginClass.CallStatic("changeQuestion", "Listening...");
        Debug.Log("Question Set");


        Debug.Log("Call 2 Started");

        // Calls the function from the jar file
        pluginClass.CallStatic("promptSpeechInput");

        Debug.Log("Call End");
    }

    void CheckLanguage()
    {
        switch (originalLang)
        {
            case LANG.EN:
                originalLanguage = "en_US";
                break;

            case LANG.PL:
                originalLanguage = "pl_PL";
                break;

            case LANG.FR:
                originalLanguage = "fr_FR";
                break;

            case LANG.DE:
                originalLanguage = "de_DE";
                break;

            case LANG.ES:
                originalLanguage = "es_ES";
                break;

            default:
                originalLanguage = "pl_PL";
                break;
        }
    }

}


