using System;
using System.Collections;
using System.Collections.Generic;
using GoogleSheetsToUnity;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Networking;

[Serializable]
public class Speech
{

    private static string spreadSheet = "1g09BH1PodPGDzc7MtAxKRfNCogc1Bp5FtVf1Ytei9b4";
    private static string workSheet = "Data";

    string speaker;
    string text;
    int phase;
    string timestamp;

    public Speech(string speaker, string text, int phase = -1){
        this.timestamp = DateTime.UtcNow.ToString();
        this.speaker = speaker;
        this.text = text;
        this.phase = phase;

        upload();

    }

    override public string ToString(){
        return speaker + "; "  + text + "; " + timestamp;
    }

    public ValueRange ToValueRange(){
        List<string> returnList = new List<string>
        {
            ConversationSystem.convoSession.ToString(),
            this.speaker,
            this.text,
            this.phase.ToString(),
            this.timestamp
        };
        return new ValueRange(returnList);
    }

    public void upload(){
        GSTU_Search sheet = new GSTU_Search(spreadSheet, workSheet);
        UnityAction callBack = this.Callback;
        SpreadsheetManager.Append(sheet,this.ToValueRange(), callBack);
    }

    public void Callback(){
        Debug.Log("Sent to db: " + this);
    }
}
