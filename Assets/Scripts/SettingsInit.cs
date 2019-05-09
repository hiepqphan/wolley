using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsInit : MonoBehaviour
{
    [SerializeField] Toggle soundToggle;
    [SerializeField] Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        int sound = PlayerPrefs.GetInt("Sound");
        if (sound == 1)
            soundToggle.isOn = true;
        else
            soundToggle.isOn = false;

        if (PlayerPrefs.GetInt("Sound") == 0)
            cam.GetComponent<AudioSource>().Pause();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
