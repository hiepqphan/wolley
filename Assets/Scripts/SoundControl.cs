using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundControl : MonoBehaviour
{
    [SerializeField] Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Toggle>().onValueChanged.AddListener(delegate
        {
            ToggleValueChangedHandler();
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ToggleValueChangedHandler()
    {
        if (GetComponent<Toggle>().isOn)
        {
            PlayerPrefs.SetInt("Sound", 1);
            cam.GetComponent<AudioSource>().UnPause();
        }
        else
        {
            PlayerPrefs.SetInt("Sound", 0);
            cam.GetComponent<AudioSource>().Pause();
        }
    }
}
