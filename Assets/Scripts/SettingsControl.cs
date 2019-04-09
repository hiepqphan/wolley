using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Toggle>().onValueChanged.AddListener(delegate
        {
            ToggleValueChangedHandler();
        });

        int diffNum;
        switch (tag)
        {
            case "easy":
                diffNum = 0;
                break;
            case "medium":
                diffNum = 1;
                break;
            default:
                diffNum = 2;
                break;
        }

        if (GetComponent<Toggle>().isOn)
            PlayerPrefs.SetInt("Difficulty", diffNum);
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    void ToggleValueChangedHandler()
    {
        int diffNum;
        switch (tag)
        {
            case "easy":
                diffNum = 0;
                break;
            case "medium":
                diffNum = 1;
                break;
            default:
                diffNum = 2;
                break;
        }

        if (GetComponent<Toggle>().isOn)
            PlayerPrefs.SetInt("Difficulty", diffNum);
    }
    
}
