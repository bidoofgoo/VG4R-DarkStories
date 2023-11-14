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

    public static float mainFontSize = 12;
    public static bool mainSizeHasBeenSet = false;

    private TextMeshProUGUI textMeshPro;

    // Start is called before the first frame update
    void Start()
    {
        textMeshPro = GetComponent<TextMeshProUGUI>();
        whatShouldFitHere = textMeshPro.text;
        textMeshPro.enableAutoSizing = false;
    }

    // OnGui is called a few times per frame
    void OnGUI()
    {
        if(isMainFontSize){
            FontSizeOptimizer.mainFontSize = FindBestPointSizeForThisResolution();
            Debug.Log(FontSizeOptimizer.mainFontSize);
        }
        
        if(useMainFontSize){
            textMeshPro.fontSize = FontSizeOptimizer.mainFontSize;
        }else{
            textMeshPro.fontSize = FindBestPointSizeForThisResolution();
        }
    }

    float FindBestPointSizeForThisResolution() {
        textMeshPro.enableAutoSizing = true;
        textMeshPro.text = whatShouldFitHere;
        float fontSize = textMeshPro.fontSize;
        textMeshPro.enableAutoSizing = false;
        return fontSize;
    }
}
