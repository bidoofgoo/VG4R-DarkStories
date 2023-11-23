using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Inworld;
using Inworld.Util;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ConversationSystem : MonoBehaviour
{

    public static ConversationSystem cs;

    public static Speech[] fullConvo = {};

    public TextMeshProUGUI nameField;
    public TextMeshProUGUI textField;

    public TMP_InputField inputField;

    public string currentSpeaker = "";
    public string currentText = "";

    // Start is called before the first frame update
    void Start()
    {
        cs = this;
        //setConversation("???", "...");
    }

    void emptyInputField(){
        this.inputField.text = null;
    }

    void emptyTextField(){
        this.textField.text = null;
        currentText = "";
    }

    public static void setConversation(string speaker = null, string text = null){
        if(text != null)
            cs.setText(text);
        if(speaker != null)
            cs.setSpeaker(speaker);
    }

    public void receiveResponse(string speaker, string text){
        cs.setSpeaker(speaker);
        currentText += text + "\n";
        setText(currentText);
    }

    public void finishTalking(){

        fullConvo.Append(new Speech(currentSpeaker, currentText));
    }

    private void setText(string text){
        cs.textField.text = text;
    }

    private void setSpeaker(string speaker){
        cs.nameField.text = speaker;
        currentSpeaker = speaker;
    }

    public void sendText(){
        if (string.IsNullOrEmpty(inputField.text))
            return;
        if (!InworldController.Instance.CurrentCharacter)
        {
            InworldAI.LogError("No Character is interacting.");
            return;
        }
        fullConvo.Append(new Speech("player", inputField.text));
        emptyTextField();
        InworldController.Instance.CurrentCharacter.SendText(inputField.text);
        emptyInputField();
    }

}