using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public TMP_InputField inputField;
    public SceneAsset gameScene;
    
    public void buttonPress(){
        string text = this.inputField.text;

        if(text.Trim() == ""){
            Debug.Log("Inputfield is empty... " + text);
            this.inputField.text = "";
        }else{
            Debug.Log("Loading...");
            Game.playerName = inputField.text;
            SceneManager.LoadScene(gameScene.name, LoadSceneMode.Single);
        }
    }
}
