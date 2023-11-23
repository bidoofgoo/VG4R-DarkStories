using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class FontSizeOptimizer : MonoBehaviour
{

    public bool isMainFontSize = false;

    public bool useMainFontSize = false;

    private string whatShouldFitHere = "Lorem Ipsum";

    public static float mainFontSize;

    public float toSetTo;
    public static bool mainSizeHasBeenSet = false;
    public bool sizeHasBeenSet = false;

    private string whatWasHere;

    private TextMeshProUGUI gui;

    // Start is called before the first frame update
    void Start()
    {
        gui = GetComponent<TextMeshProUGUI>();
        whatShouldFitHere = gui.text;

        
        PrepareFindBestPointSizeForThisResolution();

        
    }

    // OnGui is called a few times per frame
    void Update()
    {
        if(!sizeHasBeenSet){
            setSizes();
            sizeHasBeenSet = true;
        }
        
        if(useMainFontSize && mainSizeHasBeenSet){
            gui.fontSize = mainFontSize;
        }else{
            gui.fontSize = toSetTo;
        }
    }

    void PrepareFindBestPointSizeForThisResolution() {

        whatWasHere = gui.text;
        Debug.Log(whatWasHere);
        gui.enableAutoSizing = true;
        gui.text = whatShouldFitHere;

    }
    void setSizes(){
        Debug.Log("setting sizes");
        //gui.enableAutoSizing = true;

        if(isMainFontSize && !mainSizeHasBeenSet){
            mainFontSize = gui.fontSize;
            //Debug.Log(FontSizeOptimizer.mainFontSize);
            mainSizeHasBeenSet = true;
        }

        toSetTo = gui.fontSize;

    	Debug.Log(whatWasHere);
        gui.text = whatWasHere;
        gui.enableAutoSizing = false;
    }

}
