using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Speech
{

    string speaker;
    string text;
    string metadata;
    string timestamp;

    public Speech(string speaker, string text, string metadata = ""){
        this.timestamp = DateTime.UtcNow.ToString();
        this.speaker = speaker;
        this.text = text;
        this.metadata = metadata;

        Debug.Log(this);

    }

    override public string ToString(){
        return speaker + "; "  + text + "; " + timestamp;
    }
}
