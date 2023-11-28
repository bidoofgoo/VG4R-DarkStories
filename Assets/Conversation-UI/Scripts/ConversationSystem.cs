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

    public static int convoSession;

    public static ConversationSystem cs;

    public static Speech[] fullConvo = {};

    public TextMeshProUGUI nameField;
    public TextMeshProUGUI textField;

    public TMP_InputField inputField;

    public string currentSpeaker = "";

    private int speakerTimer = 0;
    public string currentText = "";

    private bool hasStarted = false;

    // Start is called before the first frame update
    void Start()
    {
        cs = this;
        ConversationSystem.convoSession = UnityEngine.Random.Range(0, 100000000);
        InworldController.Instance.Init();
        // setConversation("???", "...");

    }

    void FixedUpdate(){
        if(speakerTimer > 0){
            if(speakerTimer == 1){
                this.FinishTalking();
            }
            speakerTimer--;
        }
        if(InworldController.State == ControllerStates.Connected && !hasStarted){
            InworldController.Instance.CurrentCharacter.SendText("Hello. I am " + Game.playerName + ". Please introduce yourself and give me an explaination of what's going on.");
            hasStarted = true;
        }
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
            cs.SetText(text);
        if(speaker != null)
            cs.SetSpeaker(speaker);
    }

    public void ReceiveResponse(string speaker, string text){
        cs.SetSpeaker(speaker);
        currentText += text + "";
        SetText(currentText);
        speakerTimer = 100;
    }

    public void FinishTalking(){
        Speech aiSpeech = new Speech(currentSpeaker, currentText, Game.conversationState);
        // Debug.Log(aiSpeech);
        fullConvo.Append(aiSpeech);
    }

    private void SetText(string text){
        cs.textField.text = text;
    }

    private void SetSpeaker(string speaker){
        cs.nameField.text = speaker;
        currentSpeaker = speaker;
    }

    public void SendText(){
        if (string.IsNullOrEmpty(inputField.text))
            return;
        if (!InworldController.Instance.CurrentCharacter)
        {
            InworldAI.LogError("No Character is interacting.");
            return;
        }
        fullConvo.Append(new Speech("Player", inputField.text, Game.conversationState));
        emptyTextField();
        InworldController.Instance.CurrentCharacter.SendText(inputField.text);
        emptyInputField();
    }
}